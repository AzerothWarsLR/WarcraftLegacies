using System;
using MacroTools.LegendSystem;
using MacroTools.QuestSystem;

namespace MacroTools.ObjectiveSystem.Objectives.LegendBased
{
  /// <summary>
  /// Completed when a specific <see cref="Legend"/> is dead.
  /// </summary>
  public sealed class ObjectiveLegendDead : Objective
  {
    private readonly Legend _target;

    /// <summary>
    /// An optional filter that is applied against the <see cref="LegendaryHero"/> when it dies. The <see cref="Objective"/>
    /// will only be completed if the filter passes.
    /// </summary>
    public Func<Legend, bool> DeathFilter { get; init; } = _ => true;

    /// <summary>
    /// Initializes a new instance of the <see cref="ObjectiveLegendDead"/> class.
    /// </summary>
    /// <param name="target">The <see cref="Legend"/> that has to die for this objective to be completed.</param>
    public ObjectiveLegendDead(LegendaryHero target)
    {
      _target = target;
      TargetWidget = target.Unit;
      Description = IsUnitType(target.Unit, UNIT_TYPE_STRUCTURE)
        ? $"{target.Name} is destroyed"
        : $"{target.Name} is dead";
      DisplaysPosition = IsUnitType(_target.Unit, UNIT_TYPE_STRUCTURE) ||
                         GetOwningPlayer(_target.Unit) == Player(PLAYER_NEUTRAL_AGGRESSIVE);
      target.PermanentlyDied += OnDeath;
      Position = new(GetUnitX(_target.Unit), GetUnitY(_target.Unit));
    }

    private void OnDeath(object? sender, Legend legend) =>
      Progress = DeathFilter(legend) ? QuestProgress.Complete : QuestProgress.Failed;
  }
}