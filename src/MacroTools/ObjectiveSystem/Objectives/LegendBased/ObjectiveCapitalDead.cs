using MacroTools.LegendSystem;
using MacroTools.QuestSystem;

namespace MacroTools.ObjectiveSystem.Objectives.LegendBased;

/// <summary>
/// Completed when a specific <see cref="Capital"/> is dead.
/// </summary>
public sealed class ObjectiveCapitalDead : Objective
{
  /// <summary>
  /// Initializes a new instance of the <see cref="ObjectiveCapitalDead"/> class.
  /// </summary>
  /// <param name="target">The <see cref="Capital"/> that has to die for this objective to be completed.</param>
  public ObjectiveCapitalDead(Capital target)
  {
    TargetWidget = target.Unit;
    Description = $"{target.Unit.Name} is destroyed";
    DisplaysPosition = true;
    var deathTrigger = trigger.Create();
    deathTrigger.RegisterUnitEvent(target.Unit, unitevent.Death);
    deathTrigger.AddAction(() => Progress = QuestProgress.Complete);

    Position = new(target.Unit.X, target.Unit.Y);
  }
}
