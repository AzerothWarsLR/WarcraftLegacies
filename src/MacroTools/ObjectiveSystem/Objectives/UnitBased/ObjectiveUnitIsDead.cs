using MacroTools.QuestSystem;


namespace MacroTools.ObjectiveSystem.Objectives.UnitBased
{
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
      CreateTrigger()
        .RegisterUnitEvent(unitToKill, EVENT_UNIT_DEATH)
        .AddAction(() =>
        {
          KillingUnit = GetKillingUnit();
          Progress = QuestProgress.Complete;
        });
      Target = unitToKill;
      TargetWidget = Target;
      InitializeDescription();
      DisplaysPosition = IsUnitType(Target, UNIT_TYPE_STRUCTURE) ||
                         GetOwningPlayer(Target) == Player(PLAYER_NEUTRAL_AGGRESSIVE);
      
      Position = new(GetUnitX(Target), GetUnitY(Target));
    }
    
    private void InitializeDescription()
    {
      if (IsUnitType(Target, UNIT_TYPE_STRUCTURE) || IsUnitType(Target, UNIT_TYPE_ANCIENT))
      {
        Description = $"{GetUnitName(Target)} has been destroyed";
        return;
      }

      Description = $"{GetUnitName(Target)} is dead";
    }
  }
}