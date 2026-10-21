using System;
using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Localization;
using MacroTools.Quests;
using MacroTools.Sounds;
using MacroTools.Utils;
using MacroTools.WorldEvents;
using WarcraftLegacies.Source.Factions.Kultiras.Paths;
using WarcraftLegacies.Source.Factions.Theramore;
using WarcraftLegacies.Source.Factions.Theramore.Paths;
using WarcraftLegacies.Source.Objectives.MetaBased;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Shared;
using WarcraftLegacies.Source.Shared.Powers;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Kultiras.Events;

/// <summary>Theramore has sided with the Horde, so Daelin Proudmoore sails to Kalimdor to destroy them.</summary>
public sealed class DaelinsVengeanceEvent : WorldEvent
{
  private const float WarBonus = 0.15f;
  private const int WarIncome = 75;
  private const float DefianceBonus = 0.05f;
  private const string BattleshipModel = @"doodads\northrend\water\battleship\battleship.mdl";
  private const string RowboatModel = @"doodads\northrend\water\rowboat\rowboat.mdl";
  private const float WaterSurfaceZ = 38;

  private static readonly Rectangle _outpostArea = new(-10000, -12100, -8200, -10650);

  private readonly KultirasFaction _kultiras;
  private readonly ObjectiveTriggered _theramoreJoinedHorde;
  private readonly PathDaelinsVengeance _path;
  private readonly List<KeyValuePair<Faction, Power>> _warPowers = new();
  private bool _daelinFallen;
  private bool _warOver;

  public DaelinsVengeanceEvent(KultirasFaction kultiras)
  {
    _kultiras = kultiras;
    Name = "Daelin's Vengeance";
    IconName = "Proudmoore";
    Description = "The Kul Tiran fleet makes landfall at the Shimmering Flats, with Lord Admiral Daelin Proudmoore at its head. He has come to finish the orcs once and for all, and Jaina must choose between her father and her new allies.";

    _theramoreJoinedHorde = new ObjectiveTriggered("Theramore has joined the Horde");
    AddRequirement(_theramoreJoinedHorde);
    AddRequirement(new ObjectiveTriggered("Kul Tiras gives the order to sail"));
    _path = new PathDaelinsVengeance(this);
    kultiras.AddPath(_path);
    TeamChanges.OnAnyTeamChanged(CheckTheramoreJoinedHorde);
    AllLegends.Kultiras.LegendAdmiral.Died += OnDaelinDied;

    var deathTrigger = trigger.Create();
    deathTrigger.RegisterUnitEvent(AllLegends.Kultiras.LegendBoralus.Unit, unitevent.Death);
    deathTrigger.AddAction(EndWar);
  }

  /// <summary>Theramore, if it has been founded.</summary>
  private static TheramoreFaction? GetTheramore() =>
    FactionManager.TryGetFactionByType<TheramoreFaction>(out var theramore) ? theramore : null;

  private static bool IsOnHorde(Faction? faction) =>
    faction?.Player != null && faction.ScoreStatus != ScoreStatus.Defeated &&
    faction.Player.GetPlayerData().Team == TeamSetup.Horde;

  private bool KultirasCanSail() =>
    _kultiras.Player != null && _kultiras.ScoreStatus != ScoreStatus.Defeated && !IsOnHorde(_kultiras) &&
    AllLegends.Kultiras.LegendBoralus.Unit.Alive;

  /// <summary>Puts Theramore on the Horde if it isn't already, which offers Kul Tiras the path. Meant for testing.</summary>
  public void ForceOffer()
  {
    var theramorePlayer = GetTheramore()?.Player;
    if (theramorePlayer != null && theramorePlayer.GetPlayerData().Team != TeamSetup.Horde)
    {
      TeamChanges.Move(theramorePlayer, TeamSetup.Horde);
    }

    _path.ForceAvailable();
  }

  /// <summary>Lands the fleet straight away, as if Kul Tiras had taken the path. Meant for testing.</summary>
  public void ForceHappen()
  {
    ForceOffer();
    _path.Close();
    HappenNow(_kultiras.ColoredName);
  }

  private void CheckTheramoreJoinedHorde()
  {
    if (_theramoreJoinedHorde.Progress == QuestProgress.Complete)
    {
      return;
    }

    var theramore = GetTheramore();
    if (!IsOnHorde(theramore) || !KultirasCanSail())
    {
      return;
    }

    _theramoreJoinedHorde.Trigger();
    _path.Offer();
  }

  /// <inheritdoc />
  protected override void OnHappened()
  {
    var kultirasPlayer = _kultiras.Player;
    if (kultirasPlayer == null || !KultirasCanSail())
    {
      Outcome = Loc.Get("The fleet never left Boralus.");
      return;
    }

    LandFleet(kultirasPlayer);
    AddWarPower(_kultiras, new EmpoweredAgainst(x => x.GetPlayerData().Team == TeamSetup.Horde, WarBonus)
    {
      Name = "Daelin's Vengeance",
      IconName = "Proudmoore",
      Income = WarIncome,
      DescriptionTemplate = "Daelin's hatred of the orcs drives his sailors on. While Boralus stands, your forces deal {bonus}% more damage to the Horde, and you gain {income} extra income."
    });

    Outcome = Loc.Format("{kultiras}'s fleet made landfall at the Shimmering Flats.", ("{kultiras}", _kultiras.ColoredName));
    var theramore = GetTheramore();
    if (theramore != null && IsOnHorde(theramore))
    {
      theramore.AddPath(new PathSideWithYourFather(_kultiras, SideWithFather, StandWithThrall));
    }
  }

  private void LandFleet(player kultirasPlayer)
  {
    ClearOldStructures(kultirasPlayer);
    PathBase.CreateStructure(kultirasPlayer, UNIT_H062_TOWN_HALL_KULTIRAS_T1, -8768, -11392);
    PathBase.CreateStructure(kultirasPlayer, UNIT_H06R_GARRISON_KULTIRAS_BARRACKS, -8768, -10880);
    PathBase.CreateStructure(kultirasPlayer, UNIT_H07Q_SCHOOL_OF_THE_TIDES_KULTIRAS_MAGIC, -9280, -10880);
    PathBase.CreateStructure(kultirasPlayer, UNIT_H07S_GUARD_TOWER_KULTIRAS_TOWER, -8384, -11008);
    PathBase.CreateStructure(kultirasPlayer, UNIT_H07S_GUARD_TOWER_KULTIRAS_TOWER, -8384, -11776);
    PathBase.CreateStructure(kultirasPlayer, UNIT_H07N_HOMESTEAD_KULTIRAS_FARM, -8960, -11904);
    PathBase.CreateStructure(kultirasPlayer, UNIT_H07N_HOMESTEAD_KULTIRAS_FARM, -8640, -11904);

    if (!_daelinFallen)
    {
      PathBase.SummonLegend(AllLegends.Kultiras.LegendAdmiral, kultirasPlayer, new Point(-9152, -11392));
    }

    PathBase.CreateUnits(kultirasPlayer, UNIT_H041_MARINE_KULTIRAS, 4, -9152, -11200);
    PathBase.CreateUnits(kultirasPlayer, UNIT_N07G_MUSKETEER_KULTIRAS, 3, -9280, -11600);
    PathBase.CreateUnits(kultirasPlayer, UNIT_H05K_TIDESAGE_KULTIRAS, 2, -9088, -11600);

    CreateShip(BattleshipModel, -7552, -11600, 200);
    CreateShip(BattleshipModel, -7744, -12000, 160);
    CreateShip(RowboatModel, -7936, -11264, 180);
    CreateShip(RowboatModel, -7936, -11520, 210);
  }

  private static void ClearOldStructures(player kultirasPlayer)
  {
    foreach (var structure in GlobalGroup.EnumUnitsInRect(_outpostArea))
    {
      if (structure.Owner != kultirasPlayer && structure.IsUnitType(unittype.Structure) && structure.IsRemovable())
      {
        structure.SafelyRemove();
      }
    }
  }

  private static void CreateShip(string model, float x, float y, float facing)
  {
    var ship = effect.Create(model, x, y);
    ship.SetPosition(x, y, WaterSurfaceZ);
    ship.SetYaw(facing * MathF.PI / 180);
  }

  private void SideWithFather(Faction theramore) =>
    Outcome += " " + Loc.Format("Jaina returned to her father's side, and {theramore} rejoined the Alliance.",
      ("{theramore}", theramore.ColoredName));

  private void StandWithThrall(Faction theramore)
  {
    var message = Loc.Format("{theramore} stands with Thrall. Jaina will face her father's fleet rather than betray her new allies.",
      ("{theramore}", theramore.ColoredName));
    foreach (var whichPlayer in WCSharp.Shared.Util.EnumeratePlayers())
    {
      whichPlayer.DisplayTextTo($"\n|cffffcc00{Loc.Get("EVENT")}|r - {Loc.Get(Name)}\n{message}");
    }

    Outcome += " " + message;
    if (_warOver)
    {
      return;
    }

    AddWarPower(theramore, new EmpoweredAgainst(x => x == _kultiras.Player, DefianceBonus)
    {
      Name = "Jaina's Defiance",
      IconName = "Jaina",
      DescriptionTemplate = "Jaina will not let her father's hatred destroy her new home. While Boralus stands, your forces deal {bonus}% more damage to Kul Tiras."
    });
  }

  private void AddWarPower(Faction faction, Power power)
  {
    faction.AddPower(power);
    _warPowers.Add(new KeyValuePair<Faction, Power>(faction, power));
  }

  private void EndWar()
  {
    if (_warOver)
    {
      return;
    }

    _warOver = true;
    _path.Close();
    Cancel();
    if (_warPowers.Count == 0)
    {
      return;
    }

    foreach (var warPower in _warPowers)
    {
      warPower.Key.RemovePower(warPower.Value);
    }

    _warPowers.Clear();
    foreach (var whichPlayer in WCSharp.Shared.Util.EnumeratePlayers())
    {
      whichPlayer.DisplayTextTo($"\n|cffffcc00{Loc.Get("EVENT")}|r - {Loc.Get(Name)}\n{Loc.Get("Boralus has fallen. With their home in ruins, the Kul Tirans' crusade against the Horde collapses.")}");
    }

    SoundLibrary.Warning.Start();
  }

  private void OnDaelinDied(LegendDiedEventArgs args)
  {
    if (!args.Permanent)
    {
      return;
    }

    _daelinFallen = true;
    if (State != WorldEventState.Happened || !IsOnHorde(GetTheramore()))
    {
      return;
    }

    foreach (var whichPlayer in WCSharp.Shared.Util.EnumeratePlayers())
    {
      whichPlayer.DisplayTextTo($"\n|cffffcc00{Loc.Get("EVENT")}|r - {Loc.Get(Name)}\n{Loc.Get("Lord Admiral Daelin Proudmoore has fallen. Jaina mourns the father she could not reach.")}");
    }
  }
}
