using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;

namespace MacroTools.ObjectiveSystem.Objectives.UnitBased;

/// <summary>
/// An objective that completes when a unit reaches full health and fails if it dies
/// </summary>
public sealed class ObjectiveUnitReachesFullHealth : Objective
{
  private readonly unit _objectiveUnit;

  /// <summary>
  /// Initializes a new instance of the <see cref="ObjectiveUnitReachesFullHealth"/> class.
  /// </summary>
  /// <param name="objectiveUnit">The unit that must be brought to full hit points.</param>
  public ObjectiveUnitReachesFullHealth(unit objectiveUnit)
  {
    _objectiveUnit = objectiveUnit;
    TargetWidget = objectiveUnit;
    var hitPointRequirement = BlzGetUnitMaxHP(objectiveUnit);
    Description = IsUnitType(objectiveUnit, UNIT_TYPE_STRUCTURE)
      ? $"Repair {GetUnitName(objectiveUnit)} to {hitPointRequirement} hit points"
      : $"Bring {GetUnitName(objectiveUnit)} to {hitPointRequirement} hit points";
    DisplaysPosition = IsUnitType(objectiveUnit, UNIT_TYPE_STRUCTURE);
    var lifeTrigger = CreateTrigger();
    float limitValue = hitPointRequirement - 1;
    TriggerRegisterUnitStateEvent(lifeTrigger, objectiveUnit, UNIT_STATE_LIFE, GREATER_THAN, limitValue);
    TriggerAddAction(lifeTrigger, () =>
    {
      Progress = QuestProgress.Complete;
      DestroyTrigger(GetTriggeringTrigger());
    });

    Position = _objectiveUnit.GetPosition();
  }

  public override void OnAdd(Faction faction)
  {
    if (!UnitAlive(_objectiveUnit))
    {
      Progress = QuestProgress.Failed;
    }
    else if (GetUnitState(_objectiveUnit, UNIT_STATE_LIFE) == GetUnitState(_objectiveUnit, UNIT_STATE_MAX_LIFE))
    {
      Progress = QuestProgress.Complete;
    }
  }
}
