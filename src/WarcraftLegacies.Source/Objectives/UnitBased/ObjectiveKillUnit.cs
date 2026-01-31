using MacroTools.Extensions;
using MacroTools.Quests;

namespace WarcraftLegacies.Source.Objectives.UnitBased;

/// <summary>
/// An <see cref="Objective"/> in which the objective holder must kill a specific unit.
/// </summary>
public sealed class ObjectiveKillUnit : Objective
{
  /// <summary>
  /// Initializes a new instance of the <see cref="ObjectiveKillUnit"/> class.
  /// </summary>
  public ObjectiveKillUnit(unit unitToKill)
  {
    var trig = trigger.Create();
    trig.RegisterUnitEvent(unitToKill, unitevent.Death);
    trig.AddAction(OnUnitDeath);
    Target = unitToKill;
    TargetWidget = Target;
    InitializeDescription();
    DisplaysPosition = Target.IsUnitType(unittype.Structure) ||
                       Target.Owner == player.NeutralAggressive;

    Position = new(Target.X, Target.Y);
  }

  /// <summary>
  /// The unit that has to die for the objective to be completed.
  /// </summary>
  public unit Target { get; }

  private void OnUnitDeath()
  {
    Progress = IsPlayerOnSameTeamAsAnyEligibleFaction(@event.KillingUnit.Owner)
      ? QuestProgress.Complete
      : QuestProgress.Failed;
  }

  private void InitializeDescription()
  {
    var killVerb = Target.IsUnitType(unittype.Structure) || Target.IsUnitType(unittype.Ancient)
      ? "Destroy"
      : "Kill";

    Description = $"{killVerb} {Target.GetProperName()}";
  }
}
