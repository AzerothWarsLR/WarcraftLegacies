using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Localization;
using MacroTools.Quests;

namespace WarcraftLegacies.Source.Objectives.LegendBased;

/// <summary>
/// Completed the first time a <see cref="Capital"/> is destroyed or captured by a player outside your team.
/// </summary>
public sealed class ObjectiveCapitalLost : Objective
{
  private readonly Capital _target;

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
    deathTrigger.AddAction(() => Progress = QuestProgress.Complete);
    _target.ChangedOwner += _ => CheckOwner();
    CheckOwner();
  }

  private void CheckOwner()
  {
    if (Progress == QuestProgress.Complete || _target.Unit == null)
    {
      return;
    }

    if (!IsPlayerOnSameTeamAsAnyEligibleFaction(_target.Unit.Owner))
    {
      Progress = QuestProgress.Complete;
    }
  }
}
