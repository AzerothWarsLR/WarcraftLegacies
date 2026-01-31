using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.UnitBased;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Draenei;

/// <summary>
/// Take control of Darkshore
/// </summary>
public sealed class QuestRebuildCivilisation : QuestData
{
  private readonly List<unit> _rescueUnits;
  /// <summary>
  /// Initializes a new instance of the <see cref="QuestRebuildCivilisation"/> class.
  /// </summary>
  public QuestRebuildCivilisation(Rectangle rescueRect) : base("The Way Forward", "The Draenei will need to rebuild their civilisation in Azeroth. Darkshore seems like a perfect place for the birth of the second Draenei settlement.", @"ReplaceableTextures\CommandButtons\BTNDraeneiDivineCitadel.blp")
  {

    AddObjective(new ObjectiveHostilesInAreaAreDead(new List<Rectangle> { Regions.Darkshore }, "in Darkshore"));
    AddObjective(new ObjectiveSelfExists());
    _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideAll);
    ResearchId = UPGRADE_R082_QUEST_COMPLETED_THE_WAY_FORWARD;
  }

  /// <inheritdoc/>
  protected override void OnComplete(Faction whichFaction)
  {
    if (whichFaction.Player != null)
    {
      whichFaction.Player.RescueGroup(_rescueUnits);
    }
    else
    {
      player.NeutralAggressive.RescueGroup(_rescueUnits);
    }
  }

  /// <inheritdoc/>
  protected override string RewardDescription =>
    "Gain an Outpost in Darkshore and Maraad is now trainable at the altar.";
}
