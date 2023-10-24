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
  /// Rebuild Andhoral to buff your air units
  /// </summary>
  public sealed class QuestRebuildAndorhal : QuestData
  {

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestRebuildAndorhal"/> class.
    /// </summary>
    public QuestRebuildAndorhal(Rectangle questRect) : base(
      "Rebuild Andorhal",
      "Andorhal was completly destroyed by the scourge, the city should be rebuilt; it's proximity to Aerie Peak will enable the Scarlet Crusade to breed powerful Eagles and Gryphons. ",
      @"ReplaceableTextures\CommandButtons\BTNAlteracGryphonAviary.blp")
    {
      Required = true;
      AddObjective(new ObjectiveBuildInRect(questRect, "in Andorhal", Constants.UNIT_H0BM_TOWN_HALL_CRUSADE_T1, 1));
      AddObjective(new ObjectiveBuildInRect(questRect, "in Andorhal", Constants.UNIT_H0BP_HOUSEHOLD_CRUSADE_FARM, 4));
      AddObjective(new ObjectiveBuildInRect(questRect, "in Andorhal", Constants.UNIT_H0AG_HALL_OF_SWORDS_CRUSADE_BARRACKS, 1));
      AddObjective(new ObjectiveBuildInRect(questRect, "in Andorhal", Constants.UNIT_H0BL_ROOKERY_CRUSADE_BEAST, 1));
      AddObjective(new ObjectiveBuildInRect(questRect, "in Andorhal", Constants.UNIT_N0D8_TRADE_HOUSE_CRUSADE_SHOP, 1));
      AddObjective(new ObjectiveControlLevel(
        ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N01H_ANDORHAL), 2));
      ResearchId = Constants.UPGRADE_R09A_QUEST_COMPLETED_THE_DIMENSIONAL_SHIP; //TODO create the reserach with the new title that buffs air units
    }

    /// <inheritdoc/>
    protected override string RewardFlavour =>
      "With the proximity to Aerie Peak, New Andhoral can start training a new breed of Eagle and Grypgons, stronger than before";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      $"Your {GetObjectName(Constants.UNIT_O06V_EAGLE_RIDER_SCARLET)}s and {GetObjectName(Constants.UNIT_E01L_GRYPHON_MARKSMAN_SCARLET)} gain 400 hit points";
  }
}