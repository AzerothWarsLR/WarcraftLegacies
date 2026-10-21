using System.Diagnostics.CodeAnalysis;
using MacroTools.ControlPoints;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Localization;
using MacroTools.Quests;
using MacroTools.Utils;
using WarcraftLegacies.Source.Factions.OrcishHorde.Quests;
using WarcraftLegacies.Source.Factions.TaurenTribes;
using WarcraftLegacies.Source.Shared;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.OrcishHorde;

/// <summary>
/// Turns the Orcish Horde's player into the <see cref="ChaosOrcsFaction"/> after they drink the blood of Mannoroth,
/// and back again. Live units change through Chaos abilities in the object data, switched on by the blood pact
/// researches. The Orcish Horde's quests and powers wait until the orcs return.
/// </summary>
public sealed class ChaosOrcs
{
  private const float LumberCampX = -10432;
  private const float LumberCampY = 1920;

  private static readonly int[] _chaosAbilities =
  {
    ABILITY_A204_CHAOS_CHAOS_ORCS_GRUNT, ABILITY_A205_CHAOS_CHAOS_ORCS_PEON, ABILITY_A206_CHAOS_CHAOS_ORCS_SHAMAN,
    ABILITY_A209_CHAOS_CHAOS_ORCS_GROM, ABILITY_A20A_CHAOS_CHAOS_ORCS_RAIDER
  };

  private readonly Faction _orcs;
  private ChaosOrcsFaction? _chaosFaction;
  private player? _orcPlayer;
  private player? _orgrimmarHolder;
  private bool _corrupted;

  public ChaosOrcs(Faction orcs)
  {
    _orcs = orcs;
  }

  /// <summary>Whether the orcs are currently the Chaos Orcs.</summary>
  public bool IsCorrupted => _corrupted;

  /// <summary>The faction the orcs become while corrupted, once they have drunk.</summary>
  public ChaosOrcsFaction? ChaosFaction => _chaosFaction;

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
    var chaosFaction = new ChaosOrcsFaction(_orcs);
    _chaosFaction = chaosFaction;
    FactionTransition.AssignNewFaction(_orcs, chaosFaction);
    chaosFaction.SetObjectLevel(UPGRADE_R09O_DRINK_THE_BLOOD_OF_MANNOROTH, 1);
    TeamHandicaps.Refresh();
    SendThrallAndVoljinAway();
    GiveUpOrgrimmar(orcPlayer);
    BuildLumberCamp(orcPlayer);

    var fountain = AllLegends.Neutral.FountainOfBlood.Unit;
    PathBase.SummonLegend(AllLegends.Warsong.Mannoroth, orcPlayer, new Point(fountain.X, fountain.Y - 300));
    AllLegends.Warsong.Mannoroth.Died += OnMannorothDied;
    orcPlayer.PlayMusicThematic("Doom");
  }

  /// <summary>The blood's hold breaks: Grom dies breaking the curse, Thrall and Vol'jin return, and the orcs are themselves again.</summary>
  public void Redeem()
  {
    var orcPlayer = _orcPlayer;
    var chaosFaction = _chaosFaction;
    if (!_corrupted || orcPlayer == null || chaosFaction == null)
    {
      return;
    }

    _corrupted = false;
    chaosFaction.HandBackUnlocks(_orcs);
    _orcs.CopyObjectLevelsFrom(chaosFaction);
    foreach (var chaosAbility in _chaosAbilities)
    {
      _orcs.ModAbilityAvailability(chaosAbility, -1);
    }

    _orcs.ModObjectLimit(UPGRADE_R09P_REVERT_BLOODPACT, 1);
    _orcs.SetObjectLevel(UPGRADE_R09P_REVERT_BLOODPACT, 1);
    orcPlayer.GetPlayerData().Faction = _orcs;
    ControlPointDefenderManager.RefreshDefenders(orcPlayer);
    TeamHandicaps.Refresh();
    RemoveHero(AllLegends.Warsong.Saurfang);
    LoseGrom();
    ReclaimOrgrimmar(orcPlayer);
    BringHeroesHome(orcPlayer);
  }

  private void OnMannorothDied(LegendDiedEventArgs args)
  {
    if (args.Permanent && _corrupted)
    {
      MannorothSlain?.Invoke();
    }
  }

  private static bool TryGetTaurenPlayer([NotNullWhen(true)] out player? taurenPlayer)
  {
    taurenPlayer = null;
    if (!FactionManager.TryGetFactionByType<TaurenTribesFaction>(out var tauren) || tauren.ScoreStatus == ScoreStatus.Defeated)
    {
      return false;
    }

    taurenPlayer = tauren.Player;
    return taurenPlayer != null;
  }

  private void GiveUpOrgrimmar(player orcPlayer)
  {
    var holder = TryGetTaurenPlayer(out var taurenPlayer) ? taurenPlayer : player.NeutralPassive;
    _orgrimmarHolder = holder;
    var questOrgrimmar = _orcs.GetQuestByType<QuestOrgrimmar>();
    if (questOrgrimmar.Progress != QuestProgress.Complete && questOrgrimmar.Progress != QuestProgress.Failed)
    {
      questOrgrimmar.HandOver(holder);
    }

    TransferOrgrimmar(orcPlayer, holder);
  }

  private void ReclaimOrgrimmar(player orcPlayer)
  {
    if (_orgrimmarHolder != null)
    {
      TransferOrgrimmar(_orgrimmarHolder, orcPlayer);
      _orgrimmarHolder = null;
    }
  }

  private static void TransferOrgrimmar(player from, player to)
  {
    foreach (var whichUnit in GlobalGroup.EnumUnitsInRect(Regions.Orgrimmar))
    {
      if (whichUnit.Owner == from && whichUnit.IsUnitType(unittype.Structure))
      {
        whichUnit.SetOwner(to);
      }
    }
  }

  private static void BuildLumberCamp(player orcPlayer)
  {
    const float x = LumberCampX;
    const float y = LumberCampY;
    PathBase.ClaimArea(new Rectangle(x - 1100, y - 1100, x + 1100, y + 1100), orcPlayer);
    var lumberCamp = PathBase.CreateStructure(orcPlayer, UNIT_OFRT_FORTRESS_ORCISH_HORDE_T3, x + 384, y + 384);
    if (lumberCamp != null)
    {
      lumberCamp.Name = Loc.Get("Warsong Lumber Camp");
    }

    PathBase.CreateStructure(orcPlayer, UNIT_OBAR_WAR_CAMP_ORCISH_HORDE_BARRACKS, x + 256, y - 384);
    PathBase.CreateStructure(orcPlayer, UNIT_OALT_ALTAR_OF_STORMS_ORCISH_HORDE_ALTAR, x - 256, y - 576);
    PathBase.CreateStructure(orcPlayer, UNIT_OSLD_SPIRIT_LODGE_ORCISH_HORDE_MAGIC, x - 704, y - 576);
    PathBase.CreateStructure(orcPlayer, UNIT_OFOR_WAR_MILL_ORCISH_HORDE_RESEARCH, x + 256, y + 960);
    PathBase.CreateStructure(orcPlayer, UNIT_OBEA_BEASTIARY_ORCISH_HORDE_SPECIALIST, x + 640, y + 64);
    PathBase.CreateStructure(orcPlayer, UNIT_OTRB_BURROW_ORCISH_HORDE_FARM, x + 576, y + 896);
    PathBase.CreateStructure(orcPlayer, UNIT_OTRB_BURROW_ORCISH_HORDE_FARM, x + 128, y - 768);
    PathBase.CreateStructure(orcPlayer, UNIT_OTRB_BURROW_ORCISH_HORDE_FARM, x - 1024, y - 384);
    PathBase.CreateStructure(orcPlayer, UNIT_OWTW_WATCH_TOWER_ORCISH_HORDE_TOWER, x - 128, y + 384);
    PathBase.CreateStructure(orcPlayer, UNIT_OWTW_WATCH_TOWER_ORCISH_HORDE_TOWER, x + 640, y - 320);
    PathBase.CreateUnits(orcPlayer, UNIT_O00E_CHAOS_PEON_WARSONG_BLOODPACT, 5, x + 256, y);
  }

  private void SendThrallAndVoljinAway()
  {
    var thrall = AllLegends.Orc.Thrall;
    RemoveHero(AllLegends.Orc.Voljin);

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

  private void LoseGrom()
  {
    _orcs.ModObjectLimit(UNIT_OGRH_CHIEFTAIN_OF_THE_WARSONG_CLAN_ORCISH_HORDE, -1);
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

  private void BringHeroesHome(player orcPlayer)
  {
    var thrall = AllLegends.Orc.Thrall;
    if (FactionManager.TryGetFactionByType<TaurenTribesFaction>(out var tauren) && thrall.Unit != null &&
        thrall.Unit.Owner == tauren.Player)
    {
      tauren.ModObjectLimit(thrall.UnitType, -1);
    }

    var orgrimmar = AllLegends.Orc.Orgrimmar.Unit;
    var home = orgrimmar.Owner == orcPlayer ? new Point(orgrimmar.X, orgrimmar.Y - 400) : new Point(LumberCampX + 256, LumberCampY);
    PathBase.SummonLegend(thrall, orcPlayer, home);
    PathBase.SummonLegend(AllLegends.Orc.Voljin, orcPlayer, home);
  }
}
