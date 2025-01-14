using MacroTools.Extensions;
using MacroTools.LegendSystem;
using MacroTools.QuestSystem;
using static War3Api.Common;

namespace MacroTools.ObjectiveSystem.Objectives.LegendBased
{
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
      Description = $"{target.Unit.GetName()} is destroyed";
      DisplaysPosition = true;
      CreateTrigger()
        .RegisterUnitEvent(target.Unit, EVENT_UNIT_DEATH)
        .AddAction(() => Progress = QuestProgress.Complete);
      
      Position = new(GetUnitX(target.Unit), GetUnitY(target.Unit));
    }
  }
}