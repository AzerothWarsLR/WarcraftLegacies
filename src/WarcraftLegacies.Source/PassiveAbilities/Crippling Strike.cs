using MacroTools.Extensions;
using MacroTools.PassiveAbilitySystem;
using static War3Api.Common;

namespace MacroTools.PassiveAbilities
{
  /// <summary>
  /// Applies a damage multiplier to attacks based on ability level (only affects attack damage).
  /// </summary>
  public sealed class DamageMultiplierOnAttack : PassiveAbility, IAppliesEffectOnDamage
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
      var caster = GetEventDamageSource();
      var target = GetTriggerUnit();

      // Validate caster unit type and ability level
      if (GetUnitTypeId(caster) != CasterUnitTypeId ||
          GetUnitAbilityLevel(caster, AbilityTypeId) == 0)
        return;

      // Filter out non-attack damage if configured
      if (OnlyAttackDamage && !BlzGetEventIsAttack())
        return;

      // Get the original damage value
      var originalDamage = GetEventDamage();

      var abilityLevel = GetUnitAbilityLevel(caster, AbilityTypeId);
      var isTargetHero = IsUnitType(target, UNIT_TYPE_HERO);

      // Calculate damage multiplier based on target type and ability level
      var multiplier = isTargetHero
          ? BaseHeroMultiplier + (abilityLevel - 1) * LevelHeroMultiplier
          : BaseUnitMultiplier + (abilityLevel - 1) * LevelUnitMultiplier;

      // Apply bonus damage (original damage * (multiplier - 1))
      var bonusDamage = originalDamage * (multiplier - 1);
      target.TakeDamage(caster, bonusDamage, false, false,
          BlzGetEventAttackType(), BlzGetEventDamageType());
    }
  }
}