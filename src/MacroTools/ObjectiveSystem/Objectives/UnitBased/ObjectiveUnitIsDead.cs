using MacroTools.QuestSystem;

namespace MacroTools.ObjectiveSystem.Objectives.UnitBased;

/// <summary>
/// An <see cref="Objective"/> that is completed when a specific unit dies.
/// </summary>
public sealed class ObjectiveUnitIsDead : Objective
{
  /// <summary>
  /// The unit that has to die to complete the objective.
  /// </summary>
  public unit Target { get; }

  /// <summary>
  /// The unit that killed the <see cref="Target"/>.
  /// </summary>
  public unit? KillingUnit { get; private set; }

  /// <summary>
  /// Initializes a new instance of the <see cref="ObjectiveUnitIsDead"/> class.
  /// </summary>
  /// <param name="unitToKill"></param>
  public ObjectiveUnitIsDead(unit unitToKill)
  {
    var deathTrigger = trigger.Create();
    deathTrigger.RegisterUnitEvent(unitToKill, unitevent.Death);
    deathTrigger.AddAction(() =>
    {
      KillingUnit = @event.KillingUnit;
      Progress = QuestProgress.Complete;
    });
    Target = unitToKill;
    TargetWidget = Target;
    InitializeDescription();
    DisplaysPosition = Target.IsUnitType(unittype.Structure) ||
                       Target.Owner == player.NeutralAggressive;

    Position = new(Target.X, Target.Y);
  }

  private void InitializeDescription()
  {
    if (Target.IsUnitType(unittype.Structure) || Target.IsUnitType(unittype.Ancient))
    {
      Description = $"{Target.Name} has been destroyed";
      return;
    }

    Description = $"{Target.Name} is dead";
  }
}
