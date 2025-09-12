using MacroTools.Extensions;
using MacroTools.PassiveAbilitySystem;
using static War3Api.Common;

namespace MacroTools.PassiveAbilities
{
  /// <summary>Causes the unit to be removed when it dies, instead of leaving a corpse.</summary>
  public sealed class RemoveOnDeath : PassiveAbility, IEffectOnDeath
  {
    /// <summary>An effect that appears when the unit dies.</summary>
    public string? DeathEffectPath { get; init; }
    
    /// <inheritdoc />
    public RemoveOnDeath(int unitTypeId) : base(unitTypeId)
    {
    }

    /// <inheritdoc />
    public void OnDeath()
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