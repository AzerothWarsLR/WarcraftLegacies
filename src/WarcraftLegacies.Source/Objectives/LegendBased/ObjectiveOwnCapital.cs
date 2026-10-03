using System.Linq;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Localization;
using MacroTools.Quests;

namespace WarcraftLegacies.Source.Objectives.LegendBased;

/// <summary>
/// Completed while the faction itself owns a particular <see cref="Capital"/>, not just its team.
/// </summary>
public sealed class ObjectiveOwnCapital : Objective
{
  private readonly Capital _target;

  public ObjectiveOwnCapital(Capital target)
  {
    _target = target;
    SetDescription("You own {target}", ("{target}", Loc.Get(target.Name)));
    if (target.Unit != null)
    {
      TargetWidget = target.Unit;
    }

    DisplaysPosition = true;
    Position = _target.Unit?.GetPosition();
  }

  public override void OnAdd(Faction whichFaction)
  {
    _target.ChangedOwner += _ => RecalculateProgress();
    _target.UnitChanged += _ => RecalculateProgress();
    RecalculateProgress();
  }

  private void RecalculateProgress()
  {
    var unit = _target.Unit;
    var owned = unit != null && unit.Alive && EligibleFactions.Any(x => x.Player == unit.Owner);
    Progress = owned ? QuestProgress.Complete : QuestProgress.Incomplete;
  }
}
