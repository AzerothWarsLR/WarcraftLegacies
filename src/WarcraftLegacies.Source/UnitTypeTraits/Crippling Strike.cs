using MacroTools.Extensions;
using MacroTools.UnitTraits;

namespace WarcraftLegacies.Source.UnitTypeTraits;

/// <summary>
/// Applies a damage multiplier to attacks based on ability level (only affects attack damage).
/// </summary>
public sealed class DamageMultiplierOnAttack : UnitTrait, IAppliesEffectOnDamage
{
  private readonly int _abilityTypeId;

  /// <summary>Base damage multiplier for non-hero units</summary>
  public float BaseUnitMultiplier { get; init; } = 1.4f;

  /// <summary>Per-level increase to damage multiplier for non-hero units</summary>
  public float LevelUnitMultiplier { get; init; } = 0.25f;

  /// <summary>Base damage multiplier for hero units</summary>
  public float BaseHeroMultiplier { get; init; } = 1.2f;

  /// <summary>Per-level increase to damage multiplier for hero units</summary>
  public float LevelHeroMultiplier { get; init; } = 0.15f;

  /// <summary>Only apply multiplier to attack damage (not spell damage)</summary>
  public bool OnlyAttackDamage { get; init; } = true;

  public DamageMultiplierOnAttack(int abilityTypeId) => _abilityTypeId = abilityTypeId;

  public void OnDealsDamage()
  {
    var caster = @event.DamageSource;
    var target = @event.Unit;

    if (caster.GetAbilityLevel(_abilityTypeId) == 0)
    {
      return;
    }

    // Filter out non-attack damage if configured
    if (OnlyAttackDamage && !@event.IsAttack)
    {
      return;
    }

    // Get the original damage value
    var originalDamage = @event.Damage;

    var abilityLevel = caster.GetAbilityLevel(_abilityTypeId);
    var isTargetHero = target.IsUnitType(unittype.Hero);

    // Calculate damage multiplier based on target type and ability level
    var multiplier = isTargetHero
        ? BaseHeroMultiplier + (abilityLevel - 1) * LevelHeroMultiplier
        : BaseUnitMultiplier + (abilityLevel - 1) * LevelUnitMultiplier;

    // Apply bonus damage (original damage * (multiplier - 1))
    var bonusDamage = originalDamage * (multiplier - 1);
    target.TakeDamage(caster, bonusDamage, false, false,
        @event.AttackType, @event.DamageType);
  }
}
