using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Localization;
using MacroTools.Setup;
using MacroTools.Utils;
using WarcraftLegacies.Source.Factions.TaurenTribes;
using WarcraftLegacies.Source.Shared;
using WCSharp.Events;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.OrcishHorde;

/// <summary>Turns the Orcish Horde into the Chaos Orcs after they drink the blood of Mannoroth, and back again.</summary>
public sealed class ChaosOrcs
{
  private static readonly Dictionary<int, int> ChaosEquivalents = new()
  {
    { UNIT_OPEO_PEON_ORCISH_HORDE_WORKER, UNIT_O00E_CHAOS_PEON_WARSONG_BLOODPACT },
    { UNIT_OGRU_GRUNT_ORCISH_HORDE, UNIT_O00P_CHAOS_WARSONG_GRUNT_WARSONG },
    { UNIT_ORAI_RAIDER_ORCISH_HORDE, UNIT_O00S_CHAOS_RAIDER_WARSONG },
    { UNIT_OSHM_SHAMAN_ORCISH_HORDE, UNIT_NCHW_FEL_WARLOCK_FEL }
  };

  private static readonly Dictionary<int, int> OrcEquivalents = new()
  {
    { UNIT_O00E_CHAOS_PEON_WARSONG_BLOODPACT, UNIT_OPEO_PEON_ORCISH_HORDE_WORKER },
    { UNIT_O00P_CHAOS_WARSONG_GRUNT_WARSONG, UNIT_OGRU_GRUNT_ORCISH_HORDE },
    { UNIT_O00S_CHAOS_RAIDER_WARSONG, UNIT_ORAI_RAIDER_ORCISH_HORDE },
    { UNIT_NCHW_FEL_WARLOCK_FEL, UNIT_OSHM_SHAMAN_ORCISH_HORDE }
  };

  private readonly Faction _orcs;
  private readonly string _orcName;
  private player? _orcPlayer;
  private bool _corrupted;

  public ChaosOrcs(Faction orcs)
  {
    _orcs = orcs;
    _orcName = orcs.Name;
  }

  /// <summary>Whether the orcs are currently the Chaos Orcs.</summary>
  public bool IsCorrupted => _corrupted;

  /// <summary>Fired when Mannoroth dies for good while the orcs are corrupted.</summary>
  public event System.Action? MannorothSlain;

  /// <summary>The orcs drink the blood: their warriors turn to chaos, Thrall leaves for the Tauren, Vol'jin departs, and Mannoroth arrives.</summary>
  public void Corrupt()
  {
    var orcPlayer = _orcs.Player;
    if (_corrupted || orcPlayer == null)
    {
      return;
    }

    _corrupted = true;
    _orcPlayer = orcPlayer;
    _orcs.Name = Loc.Get("Chaos Orcs");
    ReplaceUnits(orcPlayer, ChaosEquivalents);
    PlayerUnitEvents.Register(CustomPlayerUnitEvents.PlayerFinishesTraining, OnUnitTrained, orcPlayer.Id);

    SendThrallAndVoljinAway();
    CorruptGrom();

    var fountain = AllLegends.Neutral.FountainOfBlood.Unit;
    var fountainPosition = new Point(fountain.X, fountain.Y - 300);
    _orcs.ModObjectLimit(UNIT_VSWS_HIGH_OVERLORD_OF_THE_KOR_KRON_WARSONG, 1);
    _orcs.ModObjectLimit(UNIT_NMAN_MANNOROTH_THE_DESTROYER_WARSONG_BLOODPACT, 1);
    PathBase.SummonLegend(AllLegends.Warsong.Mannoroth, orcPlayer, fountainPosition);
    AllLegends.Warsong.Mannoroth.Died += OnMannorothDied;
  }

  /// <summary>The blood's hold breaks and the Chaos Orcs become the Orcish Horde again.</summary>
  public void Redeem()
  {
    var orcPlayer = _orcPlayer;
    if (!_corrupted || orcPlayer == null)
    {
      return;
    }

    _corrupted = false;
    _orcs.Name = _orcName;
    PlayerUnitEvents.Unregister(CustomPlayerUnitEvents.PlayerFinishesTraining, OnUnitTrained, orcPlayer.Id);
    ReplaceUnits(orcPlayer, OrcEquivalents);

    LoseGrom();
    BringThrallHome(orcPlayer);
  }

  private void LoseGrom()
  {
    _orcs.ModObjectLimit(UNIT_OPGH_CORRUPTOR_OF_THE_WARSONG_CLAN_WARSONG_BLOODPACT, -1);
    var grom = AllLegends.Orc.GromHellscream;
    if (grom.Unit != null)
    {
      grom.PermanentlyKill();
    }

    var message = Loc.Get("Grom Hellscream breaks the blood curse at the cost of his life. He dies free, and his people are free with him.");
    foreach (var whichPlayer in WCSharp.Shared.Util.EnumeratePlayers())
    {
      whichPlayer.DisplayTextTo($"\n|cffffcc00{Loc.Get("HERO SLAIN")}|r\n{message}");
    }
  }

  private void BringThrallHome(player orcPlayer)
  {
    var thrall = AllLegends.Orc.Thrall;
    if (FactionManager.TryGetFactionByType<TaurenTribesFaction>(out var tauren) && thrall.Unit != null &&
        thrall.Unit.Owner == tauren.Player)
    {
      tauren.ModObjectLimit(thrall.UnitType, -1);
    }

    _orcs.ModObjectLimit(thrall.UnitType, 1);
    var orgrimmar = AllLegends.Orc.Orgrimmar.Unit;
    PathBase.SummonLegend(thrall, orcPlayer, new Point(orgrimmar.X, orgrimmar.Y - 400));
  }

  private void OnMannorothDied(LegendDiedEventArgs args)
  {
    if (args.Permanent && _corrupted)
    {
      MannorothSlain?.Invoke();
    }
  }

  private void OnUnitTrained()
  {
    var trained = @event.TrainedUnit;
    if (_corrupted && ChaosEquivalents.ContainsKey(trained.UnitType))
    {
      Replace(trained, ChaosEquivalents[trained.UnitType]);
    }
  }

  private static void ReplaceUnits(player whichPlayer, Dictionary<int, int> equivalents)
  {
    foreach (var whichUnit in GlobalGroup.EnumUnitsOfPlayer(whichPlayer))
    {
      if (whichUnit.Alive && equivalents.ContainsKey(whichUnit.UnitType))
      {
        Replace(whichUnit, equivalents[whichUnit.UnitType]);
      }
    }
  }

  private static void Replace(unit whichUnit, int newType)
  {
    var owner = whichUnit.Owner;
    var x = whichUnit.X;
    var y = whichUnit.Y;
    var facing = whichUnit.Facing;
    var lifePercent = whichUnit.Life / whichUnit.MaxLife;
    whichUnit.Dispose();
    var replacement = unit.Create(owner, newType, x, y, facing);
    if (replacement == null)
    {
      return;
    }

    replacement.Life = replacement.MaxLife * lifePercent;
  }

  private void SendThrallAndVoljinAway()
  {
    var thrall = AllLegends.Orc.Thrall;
    var voljin = AllLegends.Orc.Voljin;
    _orcs.ModObjectLimit(thrall.UnitType, -1);
    _orcs.ModObjectLimit(voljin.UnitType, -1);

    RemoveHero(voljin);

    if (!FactionManager.TryGetFactionByType<TaurenTribesFaction>(out var tauren))
    {
      RemoveHero(thrall);
      return;
    }

    var taurenPlayer = tauren.Player;
    if (taurenPlayer == null || tauren.ScoreStatus == ScoreStatus.Defeated)
    {
      RemoveHero(thrall);
      return;
    }

    var thunderBluff = AllLegends.Tauren.ThunderBluff.Unit;
    tauren.ModObjectLimit(thrall.UnitType, 1);
    PathBase.SummonLegend(thrall, taurenPlayer, new Point(thunderBluff.X, thunderBluff.Y - 400));
  }

  private static void RemoveHero(LegendaryHero hero)
  {
    var heroUnit = hero.Unit;
    if (heroUnit == null)
    {
      return;
    }

    heroUnit.DropAllItems();
    hero.Unit = null;
    heroUnit.Dispose();
  }

  private void CorruptGrom()
  {
    var grom = AllLegends.Orc.GromHellscream;
    _orcs.ModObjectLimit(UNIT_OGRH_CHIEFTAIN_OF_THE_WARSONG_CLAN_ORCISH_HORDE, -1);
    _orcs.ModObjectLimit(UNIT_OPGH_CORRUPTOR_OF_THE_WARSONG_CLAN_WARSONG_BLOODPACT, 1);
    if (grom.Unit == null || grom.Unit.Alive)
    {
      grom.UnitType = UNIT_OPGH_CORRUPTOR_OF_THE_WARSONG_CLAN_WARSONG_BLOODPACT;
    }
  }
}
