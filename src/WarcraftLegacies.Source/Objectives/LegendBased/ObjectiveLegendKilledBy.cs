using System;
using MacroTools.Legends;
using MacroTools.Localization;
using MacroTools.Quests;

namespace WarcraftLegacies.Source.Objectives.LegendBased;

/// <summary>Completed when a specific <see cref="LegendaryHero"/> is killed by a certain player.</summary>
public sealed class ObjectiveLegendKilledBy : Objective
{
  private readonly Func<player, bool> _isKiller;
  private readonly bool _permanentOnly;
  private bool _lastKillerCounts;

  /// <param name="target">The hero that has to be killed.</param>
  /// <param name="killerName">Who has to kill it, as shown in the description.</param>
  /// <param name="isKiller">Whether the owner of the killing unit counts.</param>
  /// <param name="permanentOnly">If true, only a death the hero can't be revived from counts.</param>
  public ObjectiveLegendKilledBy(LegendaryHero target, string killerName, Func<player, bool> isKiller,
    bool permanentOnly = false)
  {
    _isKiller = isKiller;
    _permanentOnly = permanentOnly;
    TargetWidget = target.Unit;
    SetDescription(permanentOnly ? "{target} is killed for good by {killer}" : "{target} is killed by {killer}",
      ("{target}", Loc.Get(target.Name)), ("{killer}", Loc.Get(killerName)));
    target.Died += OnDeath;
  }

  private void OnDeath(LegendDiedEventArgs eventArgs)
  {
    if (eventArgs.Permanent)
    {
      if (_permanentOnly && _lastKillerCounts)
      {
        Progress = QuestProgress.Complete;
      }

      return;
    }

    var killingUnit = @event.KillingUnit;
    _lastKillerCounts = killingUnit != null && _isKiller(killingUnit.Owner);
    if (!_permanentOnly && _lastKillerCounts)
    {
      Progress = QuestProgress.Complete;
    }
  }
}
