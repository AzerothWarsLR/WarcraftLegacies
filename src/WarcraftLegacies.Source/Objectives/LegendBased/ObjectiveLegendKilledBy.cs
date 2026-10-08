using System;
using MacroTools.Legends;
using MacroTools.Localization;
using MacroTools.Quests;

namespace WarcraftLegacies.Source.Objectives.LegendBased;

/// <summary>
/// Completed when a specific <see cref="LegendaryHero"/> is killed by a player that passes <c>isKiller</c>. Any death
/// counts, not just a permanent one.
/// </summary>
public sealed class ObjectiveLegendKilledBy : Objective
{
  private readonly Func<player, bool> _isKiller;

  /// <param name="target">The hero that has to be killed.</param>
  /// <param name="killerName">Who has to kill it, as shown in the description.</param>
  /// <param name="isKiller">Whether the owner of the killing unit counts.</param>
  public ObjectiveLegendKilledBy(LegendaryHero target, string killerName, Func<player, bool> isKiller)
  {
    _isKiller = isKiller;
    TargetWidget = target.Unit;
    SetDescription("{target} is killed by {killer}", ("{target}", Loc.Get(target.Name)), ("{killer}", Loc.Get(killerName)));
    target.Died += OnDeath;
  }

  private void OnDeath(LegendDiedEventArgs eventArgs)
  {
    if (eventArgs.Permanent)
    {
      return;
    }

    var killingUnit = @event.KillingUnit;
    if (killingUnit != null && _isKiller(killingUnit.Owner))
    {
      Progress = QuestProgress.Complete;
    }
  }
}
