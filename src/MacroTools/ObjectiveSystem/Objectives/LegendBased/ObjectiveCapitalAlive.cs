using MacroTools.Extensions;
using MacroTools.LegendSystem;
using MacroTools.QuestSystem;
using static War3Api.Common;

namespace MacroTools.ObjectiveSystem.Objectives.LegendBased
{
  /// <summary>
  /// Failed when a specific <see cref="Capital"/> is dead.
  /// </summary>
  public sealed class ObjectiveCapitalAlive : Objective
  {
    private readonly Capital _target;

    /// <summary>
    /// Initializes a new instance of the <see cref="ObjectiveCapitalAlive"/> class.
    /// </summary>
    /// <param name="target">The <see cref="Capital"/> that should be alive for this objective to be completed.</param>
    public ObjectiveCapitalAlive(Capital target)
    {
      _target = target;
      if (target.Capturable)
        Logger.LogWarning($"{target.Unit.GetName()} should not be a target of {nameof(ObjectiveCapitalAlive)} because it is capturable.");

      TargetWidget = target.Unit;
      Description = $"{target.Unit.GetName()} is alive";
      DisplaysPosition = true;
      CreateTrigger()
          .RegisterUnitEvent(target.Unit, EVENT_UNIT_DEATH)
          .AddAction(() => Progress = QuestProgress.Failed);

      Position = new(GetUnitX(_target.Unit), GetUnitY(_target.Unit));
    }
  }
}