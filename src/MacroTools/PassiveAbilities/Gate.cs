using MacroTools.Extensions;
using MacroTools.PassiveAbilitySystem;
using MacroTools.Systems;
using static War3Api.Common;

namespace MacroTools.PassiveAbilities
{
  /// <summary>
  /// Gates are buildings that can open and close.
  /// </summary>
  public sealed class Gate : PassiveAbility
  {
    /// <summary>Gates will gain this many hit points, as a percentage of their maximum, per turn.</summary>
    public const float HitPointPercentagePerTurn = 0.05f;
    
    private readonly int _openedId;
    private readonly int _deadId;
    
    /// <summary>
    /// Constructs a new <see cref="Gate"/>.
    /// </summary>
    /// <param name="openedId">The unit type ID of the gate while open.</param>
    /// <param name="closedId">The unit type ID of the gate while closed.</param>
    /// <param name="deadId">The unit type ID of the gate while dead.</param>
    public Gate(int openedId, int closedId, int deadId) : base(new[]{openedId, closedId, deadId})
    {
      _openedId = openedId;
      _deadId = deadId;
    }

    /// <inheritdoc/>
    public override void OnDeath()
    {
      var dyingGate = GetTriggerUnit();
      var dyingGatePos = dyingGate.GetPosition();
      var dyingGateFacing = GetUnitFacing(dyingGate);
      RemoveUnit(dyingGate);
      TurnBasedHitpointsManager.UnRegister(dyingGate);
      SetUnitAnimation(
        CreateUnit(GetOwningPlayer(GetKillingUnit()), _deadId, dyingGatePos.X, dyingGatePos.Y, dyingGateFacing),
        "death");
    }

    /// <inheritdoc/>
    public override void OnSpellFinish()
    {
      if (GetUnitTypeId(GetTriggerUnit()) == _openedId) 
        SetUnitAnimation(GetTriggerUnit(), "death alternate");
    }
    
    /// <inheritdoc/>
    public override void OnCreated(unit createdUnit)
    {
      if (GetUnitTypeId(createdUnit) == _openedId) 
        SetUnitAnimation(createdUnit, "death alternate");

      TurnBasedHitpointsManager.Register(createdUnit, HitPointPercentagePerTurn);
    }

    /// <inheritdoc />
    public override void OnCancelUpgrade() => SetUnitAnimation(GetTriggerUnit(), "death");

    /// <inheritdoc />
    public override void OnUpgrade()
    {
      TurnBasedHitpointsManager.UnRegister(GetTriggerUnit());
      TurnBasedHitpointsManager.Register(GetTriggerUnit(), HitPointPercentagePerTurn);
    }
  }
}