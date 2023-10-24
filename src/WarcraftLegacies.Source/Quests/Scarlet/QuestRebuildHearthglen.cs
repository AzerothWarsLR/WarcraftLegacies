using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.QuestBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using System.Collections.Generic;
using MacroTools.LegendSystem;
using WarcraftLegacies.Source.Objectives;
using WCSharp.Shared.Data;
using static War3Api.Common;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;

namespace WarcraftLegacies.Source.Quests.Scarlet
{
  /// <summary>
  /// rebuild Hearthglen and control the monastery to train Sally.
  /// </summary>
  public sealed class QuestRebuildHearthglen : QuestData
  {

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestRebuildHearthglen"/> class.
    /// </summary>
    public QuestRebuildHearthglen(Rectangle questRect, Capital monastery) : base(
      "Rebuild Hearthglen",
      "Heartglen and the Scarlet Monastery are holy ground for the Scarlet Crusade, it is primordial to capture them",
      @"ReplaceableTextures\CommandButtons\BTNAlteracWizardTower.blp")
    {
      Required = true;
      AddObjective(new ObjectiveBuildInRect(questRect, "in Hearthglen", Constants.UNIT_H0BM_TOWN_HALL_CRUSADE_T1, 1));
      AddObjective(new ObjectiveBuildInRect(questRect, "in Hearthglen", Constants.UNIT_H0BP_HOUSEHOLD_CRUSADE_FARM, 3));
      AddObjective(new ObjectiveBuildInRect(questRect, "in Hearthglen", Constants.UNIT_H0AG_HALL_OF_SWORDS_CRUSADE_BARRACKS, 1));
      AddObjective(new ObjectiveControlCapital(monastery, false));
      AddObjective(new ObjectiveControlLevel(
        ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N044_HEARTHGLEN), 2));
      ResearchId = Constants.UPGRADE_R09A_QUEST_COMPLETED_THE_DIMENSIONAL_SHIP; //TODO new research with better title by the writters
    }

    /// <inheritdoc/>
    protected override void OnComplete(Faction whichFaction)
    {
  
    }

    /// <inheritdoc/>
    protected override string RewardFlavour =>
      "With the Monastery under the Scarlet control, Sally Whitemane can start training a new generation of Scarlet adepts.";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      $"Learn to train Sally Whitemane from the {GetObjectName(Constants.UNIT_H0BQ_ALTAR_OF_CRUSADERS_CRUSADE_ALTAR)}";
  }
}