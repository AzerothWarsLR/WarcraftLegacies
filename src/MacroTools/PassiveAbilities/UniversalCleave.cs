using System;
using System.Collections.Generic;
using MacroTools.Extensions;

using MacroTools.PassiveAbilitySystem;
using MacroTools.Utils;
using static War3Api.Common;

namespace MacroTools.PassiveAbilities
{
  /// <summary>
  /// When the unit attacks, it deals extra damage in a radius around the attacked unit.
  /// </summary>
  public sealed class UniversalCleave : PassiveAbility, IAppliesEffectOnDamage
  {
    /// <summary>
    /// The unit type ID which has this <see cref="PassiveAbility"/> should also have an ability with this ID.
    /// </summary>
    public int AbilityTypeId { get; }

    /// <summary>
    /// The area around the attacked unit in which to deal damage.
    /// </summary>
    public float Radius { get; init; }

    /// <summary>
    /// The damage type to deal.
    /// </summary>
    public damagetype DamageType { get; init; } = DAMAGE_TYPE_NORMAL;

    /// <summary>
    /// Initializes a new instance of the <see cref="UniversalCleave"/> class.
    /// </summary>
    /// <param name="unitTypeId"><inheritdoc /></param>
    /// <param name="abilityTypeId">The ability the provided unit type has which represents this object.</param>
    public UniversalCleave(int unitTypeId, int abilityTypeId) : base(unitTypeId)
    {
      AbilityTypeId = abilityTypeId;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="UniversalCleave"/> class.
    /// </summary>
    /// <param name="unitTypeIds"><inheritdoc /></param>
    /// <param name="abilityTypeId">The ability the provided unit type has which represents this object.</param>
    public UniversalCleave(IEnumerable<int> unitTypeIds, int abilityTypeId) : base(unitTypeIds)
    {
      AbilityTypeId = abilityTypeId;
    }

    /// <inheritdoc />
    public void OnDealsDamage()
    {
      try
      {
        var caster = GetEventDamageSource();
        if (!BlzGetEventIsAttack() || GetUnitAbilityLevel(caster, AbilityTypeId) == 0)
          return;
        var target = GetTriggerUnit();

        // Get the amount of damage the unit does with its normal attack
        var normalAttackDamage = GetEventDamage();

        // Calculate 35% of the normal attack damage
        var cleaveDamage = normalAttackDamage * 0.35f;

        // Debugging initial target damage
        Console.WriteLine($"Initial target: {GetUnitName(target)}, Normal Attack Damage: {normalAttackDamage}, Cleave Damage: {cleaveDamage}, DamageType: {DamageType}");

        foreach (var nearbyUnit in GlobalGroup.EnumUnitsInRange(target.GetPosition(), Radius))
        {
          if (IsUnitAlly(nearbyUnit, caster.OwningPlayer()) || !UnitAlive(nearbyUnit) || BlzIsUnitInvulnerable(nearbyUnit) ||
              IsUnitType(nearbyUnit, UNIT_TYPE_STRUCTURE) || IsUnitType(nearbyUnit, UNIT_TYPE_ANCIENT))
            continue;

          // Debugging damage to units in radius
          Console.WriteLine($"Nearby unit: {GetUnitName(nearbyUnit)}, Cleave Damage: {cleaveDamage}, DamageType: {DamageType}");

          nearbyUnit.TakeDamage(caster, cleaveDamage, false, false, ATTACK_TYPE_NORMAL, DamageType);
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Failed to execute {nameof(OnDealsDamage)} for {nameof(UniversalCleave)}: {ex}");
      }
    }
  }
}
