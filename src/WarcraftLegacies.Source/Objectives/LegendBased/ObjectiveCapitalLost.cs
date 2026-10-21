using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Localization;
using MacroTools.Quests;

namespace WarcraftLegacies.Source.Objectives.LegendBased;

/// <summary>
/// Completed while a <see cref="Capital"/> your team has held is in the hands of a player outside your team, and for good
/// once it's destroyed. Retaking it makes the objective incomplete again.
/// </summary>
public sealed class ObjectiveCapitalLost : Objective
{
  private readonly Capital _target;
  private bool _heldByTeam;
  private bool _destroyed;

  /// <summary>
  /// Initializes a new instance of the <see cref="ObjectiveCapitalLost"/> class.
  /// </summary>
  /// <param name="target">The <see cref="Capital"/> that has to be lost for this objective to be completed.</param>
  public ObjectiveCapitalLost(Capital target)
  {
    _target = target;
    SetDescription("{target} is lost", ("{target}", Loc.Get(target.Unit.Name)));
    TargetWidget = target.Unit;
    DisplaysPosition = true;
    Position = new(target.Unit.X, target.Unit.Y);
  }

  public override void OnAdd(Faction whichFaction)
  {
    var deathTrigger = trigger.Create();
    deathTrigger.RegisterUnitEvent(_target.Unit, unitevent.Death);
    deathTrigger.AddAction(() =>
    {
      _destroyed = true;
      Progress = QuestProgress.Complete;
    });
    _target.ChangedOwner += _ => CheckOwner();
    CheckOwner();
  }

  private void CheckOwner()
  {
    if (_destroyed || _target.Unit == null)
    {
      return;
    }

    if (IsPlayerOnSameTeamAsAnyEligibleFaction(_target.Unit.Owner))
    {
      _heldByTeam = true;
      Progress = QuestProgress.Incomplete;
      return;
    }

    if (_heldByTeam)
    {
      Progress = QuestProgress.Complete;
    }
  }
}
