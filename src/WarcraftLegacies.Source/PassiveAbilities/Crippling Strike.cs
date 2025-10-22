using MacroTools.Extensions;
using MacroTools.UnitTypeTraits;

namespace WarcraftLegacies.Source.PassiveAbilities;

/// <summary>
/// Applies a damage multiplier to attacks based on ability level (only affects attack damage).
/// </summary>
public sealed class DamageMultiplierOnAttack : UnitTypeTrait, IAppliesEffectOnDamage
{
  /// <summary>Unit type ID that triggers this effect</summary>
  public int CasterUnitTypeId { get; }

  /// <summary>Ability ID representing this passive effect</summary>
  public int AbilityTypeId { get; }

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

  public DamageMultiplierOnAttack(int casterUnitTypeId, int abilityTypeId)
      : base(casterUnitTypeId)
  {
    CasterUnitTypeId = casterUnitTypeId;
    AbilityTypeId = abilityTypeId;
  }

  public void OnDealsDamage()
  {
    var caster = @event.DamageSource;
    var target = @event.Unit;

    // Validate caster unit type and ability level
    if (caster.UnitType != CasterUnitTypeId ||
        caster.GetAbilityLevel(AbilityTypeId) == 0)
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

    var abilityLevel = caster.GetAbilityLevel(AbilityTypeId);
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
