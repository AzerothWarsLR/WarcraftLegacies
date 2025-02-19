﻿using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.Libraries;
using MacroTools.ObjectiveSystem.Objectives.MetaBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using MacroTools.Utils;
using WarcraftLegacies.Source.FactionMechanics.Scourge;
using WarcraftLegacies.Source.Rocks;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Scourge
{
  /// <summary>
  /// When completed, the plague begins, granting either the Forsaken or the quest holder several Plague Cauldrons that periodically spawn undead units.
  /// </summary>
  public sealed class QuestPlague : QuestData
  {
    private readonly Faction _plagueVictim;
   
    private readonly Faction _secondaryPlagueFaction;
    private readonly PlagueParameters _plagueParameters;

    private readonly List<unit> _deathknellUnits;
    private readonly List<unit> _coastUnits;
    private readonly List<unit> _scholomanceUnits;

    /// <summary>
    /// When completed, the quest holder initiates the Plague.
    /// </summary>
    /// <param name="plagueParameters">Provides information about how the Plague should work.</param>
    /// <param name="plagueVictim">The faction that the plague will primarily affect.</param>
    /// <param name="secondaryPlagueFaction">The faction that will gain some of the fringe benefits of the plague.</param>
    /// /// <param name="coast">The base near Stratholme coast.</param>
    /// /// <param name="deathknell">The base near Capital Palace.</param>
    /// /// <param name="scholomance">The base at Caer Darrow.</param>
    public QuestPlague(PlagueParameters plagueParameters, Faction plagueVictim,
      Faction secondaryPlagueFaction, Rectangle deathknell, Rectangle coast, Rectangle scholomance) : base(
      "Plague of Undeath",
      "The Cult of the Damned is prepared to unleash a devastating zombifying plague across the lands of Lordaeron.",
      @"ReplaceableTextures\CommandButtons\BTNPlagueBarrel.blp")
    {
      _plagueVictim = plagueVictim;
      _plagueParameters = plagueParameters;
      _secondaryPlagueFaction = secondaryPlagueFaction;
      AddObjective(new ObjectiveEitherOf(
        new ObjectiveResearch(UPGRADE_R06I_PLAGUE_OF_UNDEATH_SCOURGE, FourCC("u000")),
        new ObjectiveTime(660)));
      AddObjective(new ObjectiveTime(540));
      _deathknellUnits = deathknell.PrepareUnitsForRescue(RescuePreparationMode.HideAll);
      _scholomanceUnits = scholomance.PrepareUnitsForRescue(RescuePreparationMode.HideAll);
      _coastUnits = coast.PrepareUnitsForRescue(RescuePreparationMode.HideAll);
      Global = true;
      ResearchId = UPGRADE_R009_QUEST_COMPLETED_PLAGUE_OF_UNDEATH;
    }

    /// <inheritdoc />
    public override string RewardFlavour =>
      "The plague has been unleashed! The citizens of Lordaeron are quickly transforming into mindless zombies";

    /// <inheritdoc />
    protected override string RewardDescription =>
      "Several small armies under your control spawn throughout Lordaeron, you gain control of three bases around Lordaeron, Lordaeron's Control Points reset to level 0, and you will be given a choice to instantly move your military units from Northrend to one of three locations in Lordaeron";

    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction)
    {
      completingFaction.ModObjectLimit(UPGRADE_R06I_PLAGUE_OF_UNDEATH_SCOURGE, -Faction.UNLIMITED);
      if (completingFaction.Player != null)
        SpawnArmies(completingFaction);

      ResetVictimControlPointLevel();
      KillVillagers();
      PresentInvasionDialogs();
      RescueBases(completingFaction);
      RegisterRocks();

      if (completingFaction.TryGetPowerByName("Cult Spies", out var spiesPower))
        completingFaction.RemovePower(spiesPower);
      else
        Logger.LogWarning($"Expected {completingFaction.Name} to have the Cult Spies Power.");
    }

    private static void RegisterRocks()
    {
      RockSystem.Register(new RockGroup(Regions.Northrend_Blocker_1, FourCC("B013"), 120));
      RockSystem.Register(new RockGroup(Regions.Northrend_Blocker_2, FourCC("B013"), 120));
    }

    private void RescueBases(Faction completingFaction)
    {
      completingFaction.Player.RescueGroup(_deathknellUnits);
      completingFaction.Player.RescueGroup(_coastUnits);
      completingFaction.Player.RescueGroup(_scholomanceUnits);
    }

    private static void PresentInvasionDialogs()
    {
      new ScourgeInvasionDialogPresenter(
          new ScourgeInvasionChoice(null, "No invasion"),
          new ScourgeInvasionChoice(Regions.CaerDarrow, "Scholomance"),
          new ScourgeInvasionChoice(Regions.StratholmeScourgeBase, "Stratholme"),
          new ScourgeInvasionChoice(Regions.DeathknellUnlock, "Deathknell"))
        .Run(Player(3));
    }

    /// <inheritdoc />
    protected override void OnAdd(Faction whichFaction) =>
      whichFaction.ModObjectLimit(UPGRADE_R06I_PLAGUE_OF_UNDEATH_SCOURGE, Faction.UNLIMITED);

    private static void KillVillagers()
    {
      var villagerUnitTypeIds = new List<int>
      {
        FourCC("nvlw"),
        FourCC("nvl2"),
        FourCC("nvil"),
        FourCC("nvlk"),
        FourCC("nvk2")
      };

      var villagers = GlobalGroup
        .EnumUnitsOfPlayer(Player(PLAYER_NEUTRAL_PASSIVE))
        .Where(x => villagerUnitTypeIds.Contains(x.GetTypeId()));
      
      foreach (var villager in villagers) 
        villager.Kill();
    }
    
    private void SpawnArmies(Faction completingFaction)
    {
      var primaryPlaguePlayer = completingFaction.ScoreStatus != ScoreStatus.Defeated && completingFaction.Player != null
        ? completingFaction.Player
        : Player(PLAYER_NEUTRAL_AGGRESSIVE);
      
      var secondaryPlaguePlayer = _secondaryPlagueFaction.ScoreStatus != ScoreStatus.Defeated && _secondaryPlagueFaction.Player != null
        ? _secondaryPlagueFaction.Player
        : Player(PLAYER_NEUTRAL_AGGRESSIVE);

      foreach (var plagueRect in _plagueParameters.PlagueRects)
      {
        var position = plagueRect.GetRandomPoint();
        position.RemoveDestructablesInRadius(250f);

        CreateUnit(secondaryPlaguePlayer, UNIT_U00D_LEGION_HERALD_LEGION_WORKER, position.X, position.Y, 0);

        var attackTarget = _plagueParameters.AttackTargets
          .OrderBy(x => MathEx.GetDistanceBetweenPoints(position, x))
          .First();

        foreach (var parameter in _plagueParameters.PlagueArmySummonParameters)
        foreach (var unit in CreateUnits(primaryPlaguePlayer, parameter.SummonUnitTypeId,
                   position.X, position.Y, 0, parameter.SummonCount))
        {
          if (!unit.IsType(UNIT_TYPE_PEON))
            unit.IssueOrder(OrderId("attack"), attackTarget);
        }
      }
    }
    
    private void ResetVictimControlPointLevel()
    {
      if (_plagueVictim.Player == null) 
        return;
      
      foreach (var controlPoint in _plagueVictim.Player.GetControlPoints())
        controlPoint.ControlLevel = 0;
    }
  }
}