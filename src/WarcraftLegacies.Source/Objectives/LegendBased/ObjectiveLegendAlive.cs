using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Localization;
using MacroTools.Quests;
using WCSharp.Events;

namespace WarcraftLegacies.Source.Objectives.LegendBased;

/// <summary>
/// Completed while your team controls a <see cref="LegendaryHero"/> that is alive, failed if it dies permanently.
/// </summary>
public sealed class ObjectiveLegendAlive : Objective
{
  private readonly LegendaryHero _target;

  public ObjectiveLegendAlive(LegendaryHero target)
  {
    _target = target;
    SetDescription("{target} is alive", ("{target}", Loc.Get(target.Name)));
    target.Died += OnDied;
    target.ChangedOwner += _ => Recalculate();
    target.Revived += Recalculate;
    PlayerUnitEvents.Register(HeroTypeEvent.FinishesRevive, OnRevived, target.UnitType);
  }

  /// <inheritdoc />
  public override void OnAdd(Faction whichFaction) => Recalculate();

  private void OnDied(LegendDiedEventArgs eventArgs)
  {
    Progress = eventArgs.Permanent ? QuestProgress.Failed : QuestProgress.Incomplete;
  }

  private void OnRevived()
  {
    if (@event.Unit == _target.Unit)
    {
      Recalculate();
    }
  }

  private void Recalculate()
  {
    if (Progress == QuestProgress.Failed)
    {
      return;
    }

    var unit = _target.Unit;
    Progress = unit != null && unit.Alive && IsPlayerOnSameTeamAsAnyEligibleFaction(unit.Owner)
      ? QuestProgress.Complete
      : QuestProgress.Incomplete;
  }
}
