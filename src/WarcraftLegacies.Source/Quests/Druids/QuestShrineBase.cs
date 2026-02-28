using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.ControlPointBased;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.TurnBased;
using WarcraftLegacies.Source.Objectives.UnitBased;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Druids;

public sealed class QuestShrineBase : QuestData
{
  private readonly List<unit> _rescueUnits;

  public QuestShrineBase(Rectangle rescueRect) : base("Hyjal's Rest",
    "Mount Hyjal has been invaded by the corruption already affecting Felwood. Clear them out to awaken the Ancients",
    @"ReplaceableTextures\CommandButtons\BTNAncientOfTheMoon.blp")
  {
    AddObjective(new ObjectiveControlPoint(UNIT_N0BI_SHRINE_TO_MALORNE, 0));
    AddObjective(new ObjectiveHostilesInAreaAreDead(new List<Rectangle> { Regions.ShrineBaseUnlock }, "in Hyjal"));
    AddObjective(new ObjectiveExpire(8, Title));
    AddObjective(new ObjectiveSelfExists());

    _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
  }

  /// <inheritdoc />
  protected override string RewardDescription =>
    "Control of all units in the Shrine of Malorne base";

  /// <inheritdoc />
  protected override void OnFail(Faction completingFaction)
  {
    var rescuer = completingFaction.ScoreStatus == ScoreStatus.Defeated
      ? player.NeutralAggressive
      : completingFaction.Player;

    rescuer.RescueGroup(_rescueUnits);
  }

  /// <inheritdoc />
  protected override void OnComplete(Faction completingFaction)
  {
    completingFaction.Player.RescueGroup(_rescueUnits);
  }
}
