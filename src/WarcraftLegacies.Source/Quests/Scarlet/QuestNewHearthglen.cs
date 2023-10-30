using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using MacroTools.LegendSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;

namespace WarcraftLegacies.Source.Quests.Scarlet
{
  /// <summary>
  /// Recapture Capital and rebuild it to empower all your heroes.
  /// </summary>
  public sealed class QuestNewHearthglen : QuestData
  {

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestNewHearthglen"/> class.
    /// </summary>
    public QuestNewHearthglen(Rectangle questRect) : base(
      "New Hearthglen",
      "TODO Flavor: The Scarlet Crusade zeal to destroy the undead has let them too far north, the dark energy of Northrend have been ocrrupting some of their most holy members.",
      @"ReplaceableTextures\CommandButtons\BTNVampire.blp")
    {
      AddObjective(new ObjectiveBuildInRect(questRect, "in Dragonblight", Constants.UNIT_H0AG_HALL_OF_SWORDS_CRUSADE_BARRACKS));
      AddObjective(new ObjectiveBuildInRect(questRect, "in Dragonblight", Constants.UNIT_H0BM_TOWN_HALL_CRUSADE_T1));
      AddObjective(new ObjectiveControlLevel(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N02Q_DRAGONBLIGHT), 5));
      ResearchId = Constants.UPGRADE_R040_QUEST_COMPLETED_NEW_HEARTHGLEN;
    }


    /// <inheritdoc/>
    protected override string RewardFlavour =>
      "TODO right flavor";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      $"Your {GetObjectName(Constants.UNIT_N09N_BISHOP_OF_THE_LIGHT_SCARLET)} gain the Unholy Archon ability.";
  }
}