using MacroTools.Extensions;
using MacroTools.QuestSystem;
using static War3Api.Common;

namespace MacroTools.ObjectiveSystem.Objectives.UnitBased
{
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
      Description = objectiveUnit.IsType(UNIT_TYPE_STRUCTURE)
        ? $"Fully repair {GetUnitName(objectiveUnit)}"
        : $"{GetUnitName(objectiveUnit)} brought to full health";
      DisplaysPosition = IsUnitType(objectiveUnit, UNIT_TYPE_STRUCTURE);
      CreateTrigger()
        .RegisterUnitEvent(objectiveUnit, EVENT_UNIT_SELECTED)
        .AddAction(() =>
        {
          if (GetUnitState(_objectiveUnit, UNIT_STATE_LIFE) == GetUnitState(_objectiveUnit, UNIT_STATE_MAX_LIFE))
            Progress = QuestProgress.Complete;
        });
      CreateTrigger()
        .RegisterUnitEvent(objectiveUnit, EVENT_UNIT_DESELECTED)
        .AddAction(() =>
        {
          if (GetUnitState(_objectiveUnit, UNIT_STATE_LIFE) == GetUnitState(_objectiveUnit, UNIT_STATE_MAX_LIFE))
            Progress = QuestProgress.Complete;
        });
      
      Position = new(GetUnitX(_objectiveUnit), GetUnitY(_objectiveUnit));
    }

    internal override void OnAdd(FactionSystem.Faction faction)
    {
      if (!UnitAlive(_objectiveUnit))
        Progress = QuestProgress.Failed;
      else if (GetUnitState(_objectiveUnit, UNIT_STATE_LIFE) == GetUnitState(_objectiveUnit, UNIT_STATE_MAX_LIFE))
        Progress = QuestProgress.Complete;
    }
  }
}
