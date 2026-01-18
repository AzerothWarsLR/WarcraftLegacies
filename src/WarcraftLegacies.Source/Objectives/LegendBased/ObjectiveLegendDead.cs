using System;
using MacroTools.Legends;
using MacroTools.Quests;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Objectives.LegendBased;

/// <summary>
/// Completed when a specific <see cref="Legend"/> is dead.
/// </summary>
public sealed class ObjectiveLegendDead : Objective
{
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
    TargetWidget = target.Unit;
    Description = $"{target.Name} is dead";
    target.Died += OnDeath;

    if (target.Unit.Owner != null && target.Unit.Owner == player.NeutralAggressive)
    {
      DisplaysPosition = true;
      Position = new Point(target.Unit.X, target.Unit.Y);
    }
  }

  private void OnDeath(object? sender, LegendDiedEventArgs eventArgs)
  {
    if (!eventArgs.Permanent)
    {
      return;
    }

    if (DeathFilter(eventArgs.LegendaryHero))
    {
      Progress = QuestProgress.Complete;
    }
  }
}
