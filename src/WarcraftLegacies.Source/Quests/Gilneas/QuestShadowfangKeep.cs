using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.ControlPointBased;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.TimeBased;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Gilneas;

/// <summary>
/// Capture control points close to Keel Harbor to gain control of it.
/// </summary>
public sealed class QuestShadowfangKeep : QuestData
{
  private readonly List<unit> _rescueUnits;

  public QuestShadowfangKeep(Rectangle rescueRect) : base("Shadowfang Keep",
    "Shadowfang and Ambermill are under seige by hostile creatures we must clear them out so that they can help us secure our lost lands.",
    @"ReplaceableTextures\CommandButtons\BTNworgen.blp")
  {
    AddObjective(new ObjectiveControlPoint(UNIT_N01D_SILVERPINE_FOREST));
    AddObjective(new ObjectiveExpire(660, Title));
    AddObjective(new ObjectiveSelfExists());
    _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);

  }

  /// <inheritdoc/>
  protected override string RewardDescription => "Control of all buildings and units in Shadowfang.";

  /// <inheritdoc/>
  protected override void OnComplete(Faction completingFaction)
  {
    foreach (var unit in _rescueUnits)
    {
      unit.Rescue(completingFaction.Player);
    }
  }

  /// <inheritdoc/>
  protected override void OnFail(Faction completingFaction)
  {
    var rescuer = completingFaction.ScoreStatus == ScoreStatus.Defeated
      ? player.NeutralAggressive
      : completingFaction.Player;

    rescuer.RescueGroup(_rescueUnits);
  }
}
