using MacroTools.Spells;
using MacroTools.UnitTraits;

namespace WarcraftLegacies.Source.Factions.Theramore.Spells;

/// <summary>While in sword stance, the unit's attacks heal it for part of the damage dealt.</summary>
public sealed class SwordStanceLifesteal : UnitTrait, IAppliesEffectOnDamage
{
  public required int AbilityTypeId { get; init; }
  public required LeveledAbilityField<float> LifestealFraction { get; init; }
  public required string HealEffectPath { get; init; }

  /// <inheritdoc />
  public void OnDealsDamage()
  {
    var attacker = @event.DamageSource;
    var level = attacker.GetAbilityLevel(AbilityTypeId);
    if (!@event.IsAttack || level == 0)
    {
      return;
    }

    attacker.Life += @event.Damage * LifestealFraction.GetValue(level);
    effect.Create(HealEffectPath, attacker, "origin").Dispose();
  }
}
