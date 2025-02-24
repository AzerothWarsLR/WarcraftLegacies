using System;
using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Libraries;
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
    /// The ability ID which represents this <see cref="PassiveAbility"/>.
    /// </summary>
    public int AbilityTypeId { get; }

    /// <summary>
    /// The area around the attacked unit in which to deal damage.
    /// </summary>
    public float Radius { get; init; }

    /// <summary>
    /// Initializes a new instance of the <see cref="UniversalCleave"/> class.
    /// </summary>
    /// <param name="abilityTypeId">The ability ID which represents this object.</param>
    public UniversalCleave(int abilityTypeId) : base(new List<int>()) // Pass an empty list for unitTypeIds
    {
      AbilityTypeId = abilityTypeId;
    }

    /// <inheritdoc />
    public void OnDealsDamage()
    {
      try
      {
        Console.WriteLine("OnDealsDamage called");
        var caster = GetEventDamageSource();
        if (!BlzGetEventIsAttack())
        {
          Console.WriteLine("Event is not an attack");
          return;
        }
        if (GetUnitAbilityLevel(caster, AbilityTypeId) == 0)
        {
          Console.WriteLine("Caster does not have the ability");
          return;
        }
        var target = GetTriggerUnit();

        var normalAttackDamage = GetEventDamage();
        Console.WriteLine($"Normal attack damage: {normalAttackDamage}");

        var cleaveDamage = normalAttackDamage * 0.35f;
        Console.WriteLine($"Cleave damage: {cleaveDamage}");

        foreach (var nearbyUnit in GlobalGroup.EnumUnitsInRange(target.GetPosition(), Radius))
        {
          if (IsUnitAlly(nearbyUnit, caster.OwningPlayer()) || !UnitAlive(nearbyUnit) || BlzIsUnitInvulnerable(nearbyUnit) ||
              IsUnitType(nearbyUnit, UNIT_TYPE_STRUCTURE) || IsUnitType(nearbyUnit, UNIT_TYPE_ANCIENT))
            continue;

          UnitDamageTarget(caster, nearbyUnit, cleaveDamage, false, false, ATTACK_TYPE_HERO, DAMAGE_TYPE_NORMAL, WEAPON_TYPE_WHOKNOWS);
          Console.WriteLine($"Dealt {cleaveDamage} cleave damage to unit: {GetUnitName(nearbyUnit)}");
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Failed to execute {nameof(OnDealsDamage)} for {nameof(UniversalCleave)}: {ex}");
      }
    }
  }
}
