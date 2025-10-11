using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Dalaran;

/// <summary>
/// Kill a wolf to unlock a base.
/// </summary>
public sealed class QuestShadowfang : QuestData
{
  private readonly List<unit> _rescueUnits;

  public QuestShadowfang(Rectangle rescueRect) : base("Shadows of Silverpine Forest",
    "Shadowfang and Ambermill are under seige by hostile creatures we must clear them out so that they can help us secure our lands",
    @"ReplaceableTextures\CommandButtons\BTNworgen.blp")
  {
    AddObjective(new ObjectiveControlPoint(UNIT_N01D_SILVERPINE_FOREST));
    AddObjective(new ObjectiveExpire(660, Title));
    AddObjective(new ObjectiveSelfExists());
    _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
  }

  /// <inheritdoc />
  protected override string RewardDescription => "Control of all Buildings and units in Shadowfang";

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
    foreach (var unit in _rescueUnits)
    {
      unit.Rescue(completingFaction.Player);
    }
  }
}
