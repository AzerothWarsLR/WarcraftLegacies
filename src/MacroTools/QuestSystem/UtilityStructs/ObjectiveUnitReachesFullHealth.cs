using MacroTools.Extensions;
using MacroTools.FactionSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace MacroTools.QuestSystem.UtilityStructs
{
  /// <summary>
  /// An objective that completes when a unit reaches full health and fails if it dies
  /// </summary>
  public class ObjectiveUnitReachesFullHealth : Objective
  {
    private unit _objectiveUnit { get; }
    /// <summary>
    /// Initializes a new instance of the <see cref="ObjectiveUnitReachesFullHealth"/> class.
    /// </summary>
    /// <param name="objectiveUnit">The unit that must be brought to full hp for this objective to complete</param>
    public ObjectiveUnitReachesFullHealth(unit objectiveUnit)
    {
      _objectiveUnit = objectiveUnit;
      TargetWidget = objectiveUnit;
      Description = $"{GetUnitName(objectiveUnit)} brought to full health";
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
    }

    /// <inheritdoc/>
    public override Point Position => new(GetUnitX(_objectiveUnit), GetUnitY(_objectiveUnit));

    internal override void OnAdd(Faction faction)
    {
      if (!UnitAlive(_objectiveUnit))
        Progress = QuestProgress.Failed;
      else if (GetUnitState(_objectiveUnit, UNIT_STATE_LIFE) == GetUnitState(_objectiveUnit, UNIT_STATE_MAX_LIFE))
        Progress = QuestProgress.Complete;
    }
  }
}
