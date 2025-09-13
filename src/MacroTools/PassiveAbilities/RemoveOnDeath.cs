using MacroTools.Extensions;
using MacroTools.PassiveAbilitySystem;

namespace MacroTools.PassiveAbilities
{
  /// <summary>Causes the unit to be removed when it dies, instead of leaving a corpse.</summary>
  public sealed class RemoveOnDeath : PassiveAbility
  {
    /// <summary>An effect that appears when the unit dies.</summary>
    public string? DeathEffectPath { get; init; }
    
    /// <inheritdoc />
    public RemoveOnDeath(int unitTypeId) : base(unitTypeId)
    {
    }

    /// <inheritdoc />
    public override void OnDeath()
    {
      var triggerUnit = GetTriggerUnit();
      var position = triggerUnit.GetPosition();
      GetTriggerUnit().Remove();
      
      if (DeathEffectPath != null)
        AddSpecialEffect(DeathEffectPath, position.X, position.Y)
          .SetLifespan();
    }
  }
}