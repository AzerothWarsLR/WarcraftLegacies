using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Localization;
using MacroTools.Quests;

namespace WarcraftLegacies.Source.Objectives.LegendBased;

/// <summary>Completed while neither you nor your allies control a particular <see cref="Capital"/>.</summary>
public sealed class ObjectiveCapitalNotControlled : Objective
{
  private readonly Capital _target;

  public ObjectiveCapitalNotControlled(Capital target)
  {
    _target = target;
    SetDescription("You don't control {target}", ("{target}", Loc.Get(target.Name)));
    DisplaysPosition = true;
    if (target.Unit != null)
    {
      TargetWidget = target.Unit;
      Position = target.Unit.GetPosition();
    }
  }

  /// <inheritdoc />
  public override void OnAdd(Faction whichFaction)
  {
    _target.ChangedOwner += _ => RecalculateProgress();
    _target.UnitChanged += _ => RecalculateProgress();
    RecalculateProgress();
  }

  private void RecalculateProgress()
  {
    var capital = _target.Unit;
    Progress = capital != null && capital.Alive && IsPlayerOnSameTeamAsAnyEligibleFaction(capital.Owner)
      ? QuestProgress.Incomplete
      : QuestProgress.Complete;
  }
}
