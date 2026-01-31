using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.Quests;

namespace WarcraftLegacies.Source.Objectives.UnitBased;

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
    var hitPointRequirement = objectiveUnit.MaxLife;
    Description = objectiveUnit.IsUnitType(unittype.Structure)
      ? $"Repair {objectiveUnit.Name} to {hitPointRequirement} hit points"
      : $"Bring {objectiveUnit.Name} to {hitPointRequirement} hit points";
    DisplaysPosition = objectiveUnit.IsUnitType(unittype.Structure);
    var lifeTrigger = trigger.Create();
    float limitValue = hitPointRequirement - 1;
    lifeTrigger.RegisterUnitStateEvent(objectiveUnit, unitstate.Life, limitop.GreaterThan, limitValue);
    lifeTrigger.AddAction(() =>
    {
      Progress = QuestProgress.Complete;
      @event.Trigger.Dispose();
    });

    Position = _objectiveUnit.GetPosition();
  }

  public override void OnAdd(Faction faction)
  {
    if (!_objectiveUnit.Alive)
    {
      Progress = QuestProgress.Failed;
    }
    else if (_objectiveUnit.Life == _objectiveUnit.MaxLife)
    {
      Progress = QuestProgress.Complete;
    }
  }
}
