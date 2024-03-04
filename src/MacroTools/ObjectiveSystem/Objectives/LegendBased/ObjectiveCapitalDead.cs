using MacroTools.Extensions;
using MacroTools.LegendSystem;
using MacroTools.QuestSystem;


namespace MacroTools.ObjectiveSystem.Objectives.LegendBased
{
  /// <summary>
  /// Completed when a specific <see cref="Capital"/> is dead.
  /// </summary>
  public sealed class ObjectiveCapitalDead : Objective
  {
    private readonly Capital _target;
    
    /// <summary>
    /// Initializes a new instance of the <see cref="ObjectiveCapitalDead"/> class.
    /// </summary>
    /// <param name="target">The <see cref="Capital"/> that has to die for this objective to be completed.</param>
    public ObjectiveCapitalDead(Capital target)
    {
      _target = target;
      if (target.Capturable)
        Logger.LogWarning(
          $"{target.Unit.Name} should not be a target of {nameof(ObjectiveCapitalDead)} because it is capturable.");

      TargetWidget = target.Unit;
      Description = $"{target.Unit.Name} is destroyed";
      DisplaysPosition = true;
      CreateTrigger()
        .RegisterUnitEvent(target.Unit, EVENT_UNIT_DEATH)
        .AddAction(() => Progress = QuestProgress.Complete);
      
      Position = new(GetUnitX(_target.Unit), GetUnitY(_target.Unit));
    }
  }
}