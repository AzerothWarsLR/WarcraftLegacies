using System.Linq;
using MacroTools.ControlPoints;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Quests;
using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Objectives.UnitBased;

/// <summary>
/// Completed when an eligible player moves a unit into the specified <see cref="Rectangle"/>.
/// </summary>
public sealed class ObjectiveAnyUnitInRect : Objective, IHasCompletingUnit
{
  private readonly bool _heroOnly;
  private readonly rect _targetRect;

  /// <summary>
  /// Initializes a new instance of the <see cref="ObjectiveAnyUnitInRect"/> class.
  /// </summary>
  /// <param name="targetRect">Where the player has to move a unit.</param>
  /// <param name="rectName">A user-friendly name for the area.</param>
  /// <param name="heroOnly">If true, can only be completed with a hero.</param>
  public ObjectiveAnyUnitInRect(Rectangle targetRect, string rectName, bool heroOnly)
  {
    _targetRect = targetRect.Rect;
    Description = heroOnly ? $"You have a hero at {rectName}" : $"You have a unit at {rectName}";
    _heroOnly = heroOnly;
    DisplaysPosition = true;
    PingPath = "MinimapQuestTurnIn";

    var enterTrigger = trigger.Create();
    enterTrigger.RegisterEnterRegion(targetRect.Region);
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
    leaveTrigger.RegisterLeaveRegion(targetRect.Region);
    leaveTrigger.AddAction(() =>
    {
      if (!IsValidUnitInRect())
      {
        Progress = QuestProgress.Incomplete;
      }
    });
    Position = new(_targetRect.CenterX, _targetRect.CenterY);
  }

  /// <inheritdoc />
  public unit? CompletingUnit { get; private set; }

  /// <inheritdoc />
  public string CompletingUnitName => CompletingUnit != null ? CompletingUnit.GetProperName() : "an unknown hero";

  private bool IsUnitValid(unit whichUnit) => EligibleFactions.Contains(whichUnit.Owner) &&
                                              whichUnit.Alive &&
                                              (whichUnit.IsUnitType(unittype.Hero) || !_heroOnly) &&
                                              !whichUnit.IsControlPoint() && whichUnit.IsSelectable();

  private bool IsValidUnitInRect() => GlobalGroup.EnumUnitsInRect(_targetRect).Any(IsUnitValid);

  public override void OnAdd(Faction whichFaction)
  {
    Progress = IsValidUnitInRect() ? QuestProgress.Complete : QuestProgress.Incomplete;
  }
}
