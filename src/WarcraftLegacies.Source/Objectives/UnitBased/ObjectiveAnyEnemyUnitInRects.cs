using System;
using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.Quests;
using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Objectives.UnitBased;

/// <summary>
/// /// Completed when an enemy of an eligible Faction moves a unit into the specified <see cref="Rectangle"/>.
/// </summary>
public sealed class ObjectiveAnyEnemyUnitInRects : Objective, IHasCompletingUnit
{
  private readonly IEnumerable<Rectangle> _targetRects;

  /// <summary>
  /// The condition that units need to pass to be eligible for quest objective.
  /// </summary>
  public Func<unit, bool> EligibilityCondition { get; init; } = _ => true;

  /// <summary>
  /// Initializes a new instance of the <see cref="ObjectiveAnyEnemyUnitInRects"/> class.
  /// </summary>
  /// <param name="targetRects">Where the player has to move a unit.</param>
  /// <param name="rectName">A user-friendly name for the area.</param>
  /// <param name="unitDescriptor">A user-friendly descriptor for the type of unit that can enter.</param>
  public ObjectiveAnyEnemyUnitInRects(IEnumerable<Rectangle> targetRects, string rectName, string unitDescriptor)
  {
    var rectangles = targetRects as Rectangle[] ?? targetRects.ToArray();
    _targetRects = rectangles;
    Description = $"Enemy {unitDescriptor} unit has entered {rectName}";
    DisplaysPosition = false;
    PingPath = "MinimapQuestTurnIn";
  }

  /// <inheritdoc />
  public unit? CompletingUnit { get; private set; }

  /// <inheritdoc />
  public string CompletingUnitName => CompletingUnit != null ? CompletingUnit.GetProperName() : "an unknown hero";

  private bool IsUnitValid(unit whichUnit) =>
    !IsPlayerOnSameTeamAsAnyEligibleFaction(whichUnit.Owner) && whichUnit.Alive &&
    whichUnit.Owner != player.NeutralAggressive &&
    whichUnit.Owner != player.NeutralPassive &&
    EligibilityCondition(whichUnit);

  private bool IsValidUnitInRects()
  {
    return _targetRects.Select(targetRect => GlobalGroup
        .EnumUnitsInRect(targetRect)
      .Any(IsUnitValid))
      .Any(any => any);
  }

  /// <inheritdoc />
  public override void OnAdd(Faction whichFaction)
  {
    Progress = IsValidUnitInRects() ? QuestProgress.Complete : QuestProgress.Incomplete;

    var enterTrigger = trigger.Create();
    enterTrigger.RegisterEnterRegions(_targetRects);
    enterTrigger.AddAction(() =>
    {
      var triggerUnit = @event.Unit;
      if (!IsUnitValid(triggerUnit))
      {
        return;
      }

      CompletingUnit = triggerUnit;
      Progress = QuestProgress.Complete;
    });
    var leaveTrigger = trigger.Create();
    leaveTrigger.RegisterLeaveRegions(_targetRects);
    leaveTrigger.AddAction(() =>
    {
      if (!IsValidUnitInRects())
      {
        Progress = QuestProgress.Incomplete;
      }
    });
  }
}
