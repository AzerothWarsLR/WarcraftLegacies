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
  /// The Draenei acquire some kind of power source to power their ship.
  /// </summary>
  public sealed class QuestRebuildBrill : QuestData
  {

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestRebuildBrill"/> class.
    /// </summary>
    public QuestRebuildBrill(Rectangle questRect) : base(
      "Rebuild Hearthglen",
      "The core of the Exodar is rebuilt, but it requires a great source of power to function again. Finding that source of power would make the Exodar a powerful asset for the Draenei.",
      @"ReplaceableTextures\CommandButtons\BTNArcaneEnergy.blp")
    {
      Required = true;
      AddObjective(new ObjectiveBuildInRect(questRect, "in Brill", Constants.UNIT_H0BM_TOWN_HALL_CRUSADE_T1, 1));
      AddObjective(new ObjectiveBuildInRect(questRect, "in Brill", Constants.UNIT_H0BP_HOUSEHOLD_CRUSADE_FARM, 3));
      AddObjective(new ObjectiveBuildInRect(questRect, "in Brill", Constants.UNIT_H09X_SHIPYARD_CRUSADE_SHIPYARD, 1));
      AddObjective(new ObjectiveBuildInRect(questRect, "in Brill", Constants.UNIT_N0D8_TRADE_HOUSE_CRUSADE_SHOP, 1));
      AddObjective(new ObjectiveControlLevel(
        ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N03H_BRILL), 2));
      ResearchId = Constants.UPGRADE_R09A_QUEST_COMPLETED_THE_DIMENSIONAL_SHIP;
    }

    /// <inheritdoc/>
    protected override void OnComplete(Faction whichFaction)
    {
  
    }

    /// <inheritdoc/>
    protected override string RewardFlavour =>
      "With the acquisition of a replacement power source, the Exodar's gemcrafters set to work reigniting the ship's dimensional portals. The Dimensional Generator can now now be used to travel the planes once more.";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      "The Dimensional Generator gains the ability to channel portals to Argus, Azuremyst, and Outland. The Lightforged units and A'dal will become available";
  }
}