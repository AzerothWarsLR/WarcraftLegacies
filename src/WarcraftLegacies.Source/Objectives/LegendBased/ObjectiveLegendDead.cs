using System;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Quests;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Objectives.LegendBased;

/// <summary>
/// Completed when a specific <see cref="Legend"/> is dead.
/// </summary>
public sealed class ObjectiveLegendDead : Objective
{
  private readonly LegendaryHero _target;

  /// <summary>
  /// An optional filter that is applied against the <see cref="LegendaryHero"/> when it dies. The <see cref="Objective"/>
  /// will only be completed if the filter passes.
  /// </summary>
  public Func<Legend, bool> DeathFilter { get; init; } = _ => true;

  /// <summary>
  /// If set, the objective will only be completed if the target permanently dies.
  /// </summary>
  public bool PermanentOnly { get; init; } = true;

  /// <summary>
  /// If true, the objective will only be completed if the killer is one of the objective holders.
  /// </summary>
  public bool OnlyCreditKiller { get; init; } = false;

  /// <summary>
  /// Initializes a new instance of the <see cref="ObjectiveLegendDead"/> class.
  /// </summary>
  /// <param name="target">The <see cref="Legend"/> that has to die for this objective to be completed.</param>
  public ObjectiveLegendDead(LegendaryHero target)
  {
    _target = target;
    TargetWidget = target.Unit;

    target.Died += OnDeath;

    if (target.Unit.Owner != null && target.Unit.Owner == player.NeutralAggressive)
    {
      DisplaysPosition = true;
      Position = new Point(target.Unit.X, target.Unit.Y);
    }
  }

  /// <inheritdoc />
  public override void OnAdd(Faction faction)
  {
    Description = CalculateDescription(_target);
  }

  private void OnDeath(object? sender, LegendDiedEventArgs eventArgs)
  {
    if (PermanentOnly && !eventArgs.Permanent)
    {
      return;
    }

    if (OnlyCreditKiller && !EligibleFactions.Contains(@event.KillingUnit.Owner))
    {
      return;
    }

    if (DeathFilter(eventArgs.LegendaryHero))
    {
      Progress = QuestProgress.Complete;
    }
  }

  private string CalculateDescription(LegendaryHero target)
  {
    if (PermanentOnly)
    {
      return OnlyCreditKiller ? $"Permanently kill {target.Name}" : $"{target.Name} is permanently dead";
    }

    return OnlyCreditKiller ? $"Kill {target.Name}" : $"{target.Name} is dead";
  }
}
