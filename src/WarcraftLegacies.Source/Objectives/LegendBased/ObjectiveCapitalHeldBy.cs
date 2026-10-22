using System;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Localization;
using MacroTools.Quests;

namespace WarcraftLegacies.Source.Objectives.LegendBased;

/// <summary>Completed while a specific <see cref="Capital"/> is held by a certain player.</summary>
public sealed class ObjectiveCapitalHeldBy : Objective
{
  private readonly Capital _target;
  private readonly Func<player, bool> _isHolder;

  /// <param name="target">The capital that has to be held.</param>
  /// <param name="holderName">Who has to hold it, as shown in the description.</param>
  /// <param name="isHolder">Whether the owner of the capital counts.</param>
  public ObjectiveCapitalHeldBy(Capital target, string holderName, Func<player, bool> isHolder)
  {
    _target = target;
    _isHolder = isHolder;
    TargetWidget = target.Unit;
    SetDescription("{holder} controls {target}", ("{target}", Loc.Get(target.Name)), ("{holder}", Loc.Get(holderName)));
    DisplaysPosition = true;
    if (target.Unit != null)
    {
      Position = target.Unit.GetPosition();
    }

    target.ChangedOwner += _ => RecalculateProgress();
  }

  /// <inheritdoc />
  public override void OnAdd(Faction whichFaction) => RecalculateProgress();

  private void RecalculateProgress()
  {
    var capital = _target.Unit;
    Progress = capital != null && capital.Alive && _isHolder(capital.Owner)
      ? QuestProgress.Complete
      : QuestProgress.Incomplete;
  }
}
