using MacroTools.QuestSystem;

namespace MacroTools.ObjectiveSystem.Objectives.UnitBased;

/// <summary>
/// An <see cref="Objective"/> that starts completed and fails when the specified unit dies.
/// </summary>
public sealed class ObjectiveUnitAlive : Objective
{
  /// <summary>
  /// Initializes a new instance of the <see cref="ObjectiveUnitAlive"/> class.
  /// </summary>
  /// <param name="whichUnit">The unit that must stay alive for this objective to be completed.</param>
  public ObjectiveUnitAlive(unit whichUnit)
  {
    Description = whichUnit.IsUnitType(unittype.Structure)
      ? $"{whichUnit.Name} is intact"
      : $"{whichUnit.Name} is alive";
    Progress = QuestProgress.Complete;
    var deathTrigger = trigger.Create();
    deathTrigger.RegisterUnitEvent(whichUnit, unitevent.Death);
    deathTrigger.AddAction(() => { Progress = QuestProgress.Failed; });
  }
}
