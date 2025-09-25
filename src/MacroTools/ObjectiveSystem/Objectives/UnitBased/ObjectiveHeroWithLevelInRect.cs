using System.Linq;
using MacroTools.Extensions;
using MacroTools.QuestSystem;
using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace MacroTools.ObjectiveSystem.Objectives.UnitBased;

/// <summary>
/// Completed when an eligible player enters the provided <see cref="Rectangle"/> with a hero of the appropriate level.
/// </summary>
public sealed class ObjectiveHeroWithLevelInRect : Objective, IHasCompletingUnit
{
  private readonly rect _targetRect;
  private readonly int _targetLevel;

  /// <summary>
  /// Initializes a new instance of the <see cref="ObjectiveHeroWithLevelInRect"/> class.
  /// </summary>
  /// <param name="targetLevel">Minimum required level to complete the objective</param>
  /// <param name="targetRect">Region that the unit has to enter in order to complete the objective</param>
  /// <param name="rectName">Display name of the region the unit has to enter. Used for flavor only.</param>
  public ObjectiveHeroWithLevelInRect(int targetLevel, Rectangle targetRect, string rectName)
  {
    _targetRect = targetRect.Rect;
    _targetLevel = targetLevel;
    Description = $"Reach {rectName} with a level {targetLevel}+ hero";
    PingPath = "MinimapQuestTurnIn";
    DisplaysPosition = true;

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

  private bool IsUnitValid(unit whichUnit) =>
    EligibleFactions.Contains(whichUnit.Owner) && whichUnit.Alive && whichUnit.IsUnitType(unittype.Hero) &&
    whichUnit.HeroLevel >= _targetLevel;

  private bool IsValidUnitInRect() => GlobalGroup.EnumUnitsInRect(_targetRect).Any(IsUnitValid);
}
