using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.QuestSystem;
using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Stormwind;

public sealed class QuestLakeshire : QuestData
{
  private readonly List<unit> _rescueUnits = new();

  public QuestLakeshire(Rectangle rescueRect) : base("Marauding Ogres",
    "The town of Lakeshire is invaded by Ogres, wipe them out!",
    @"ReplaceableTextures\CommandButtons\BTNOgreLord.blp")
  {
    AddObjective(new ObjectiveControlPoint(UNIT_N011_REDRIDGE_MOUNTAINS));
    AddObjective(new ObjectiveExpire(660, Title));
    AddObjective(new ObjectiveSelfExists());
    foreach (var unit in GlobalGroup.EnumUnitsInRect(rescueRect))
    {
      if (unit.Owner == player.NeutralPassive)
      {
        unit.IsInvulnerable = true;
        _rescueUnits.Add(unit);
      }
    }
  }

  /// <inheritdoc/>
  protected override string RewardDescription => "Control of all units in Lakeshire";

  /// <inheritdoc/>
  protected override void OnFail(Faction completingFaction)
  {
    var rescuer = completingFaction.ScoreStatus == ScoreStatus.Defeated
      ? player.NeutralAggressive
      : completingFaction.Player;

    rescuer.RescueGroup(_rescueUnits);
  }

  /// <inheritdoc/>
  protected override void OnComplete(Faction completingFaction)
  {
    foreach (var unit in _rescueUnits)
    {
      unit.Rescue(completingFaction.Player);
    }
  }
}
