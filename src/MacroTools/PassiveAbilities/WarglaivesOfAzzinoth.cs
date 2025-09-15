using System;
using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Libraries;
using MacroTools.PassiveAbilitySystem;
using MacroTools.Utils;
using WCSharp.Effects;
using static War3Api.Common;

namespace MacroTools.PassiveAbilities
{
  /// <summary>
  /// When the unit attacks, it deals extra damage in a radius around the attacked unit. Deals extra damage to demons.
  /// </summary>
  public sealed class WarglaivesOfAzzinoth : PassiveAbility, IAppliesEffectOnDamage
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
    /// How much damage to deal.
    /// </summary>
    public float DamageBase { get; init; }
    
    /// <summary>
    /// How much extra damage to deal per ability level.
    /// </summary>
    public float DamageLevel { get; init; }

    /// <summary>
    /// A damage multiplier to be applied against demons.
    /// </summary>
    public float DamageMultiplierAgainstDemons { get; init; } = 1;

    /// <summary>
    /// The effect that briefly appears upon attack.
    /// </summary>
    public string Effect { get; init; } = "";

    /// <summary>
    /// The size of the effect that appears on attack.
    /// </summary>
    public float EffectScale { get; init; } = 1;

    /// <summary>
    /// The damage type to deal.
    /// </summary>
    public damagetype DamageType { get; init; } = DAMAGE_TYPE_MAGIC;
    
    /// <summary>
    /// Initializes a new instance of the <see cref="WarglaivesOfAzzinoth"/> class.
    /// </summary>
    /// <param name="unitTypeId"><inheritdoc /></param>
    /// <param name="abilityTypeId">The ability the provided unit type has which represents this object.</param>
    public WarglaivesOfAzzinoth(int unitTypeId, int abilityTypeId) : base(unitTypeId)
    {
      AbilityTypeId = abilityTypeId;
    }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="WarglaivesOfAzzinoth"/> class.
    /// </summary>
    /// <param name="unitTypeIds"><inheritdoc /></param>
    /// <param name="abilityTypeId">The ability the provided unit type has which represents this object.</param>
    public WarglaivesOfAzzinoth(IEnumerable<int> unitTypeIds, int abilityTypeId) : base(unitTypeIds)
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

        var effect = AddSpecialEffect(Effect, GetUnitX(target), GetUnitY(target));
        BlzSetSpecialEffectScale(effect, EffectScale);
        BlzSetSpecialEffectYaw(effect, GetUnitFacing(caster) * MathEx.DegToRad);
        EffectSystem.Add(effect);

        foreach (var nearbyUnit in GlobalGroup.EnumUnitsInRange(target.GetPosition(), Radius))
        {
          if (IsUnitAlly(nearbyUnit, caster.OwningPlayer()) || !UnitAlive(nearbyUnit) || BlzIsUnitInvulnerable(nearbyUnit) ||
              IsUnitType(nearbyUnit, UNIT_TYPE_STRUCTURE) || IsUnitType(nearbyUnit, UNIT_TYPE_ANCIENT))
            continue;

          var damageAmount = DamageBase + DamageLevel * GetUnitAbilityLevel(caster, AbilityTypeId);
          if (GetUnitRace(nearbyUnit) == RACE_DEMON) 
            damageAmount *= DamageMultiplierAgainstDemons;
          nearbyUnit.TakeDamage(caster, damageAmount, false, false, ATTACK_TYPE_NORMAL, DamageType);
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Failed to execute {nameof(OnDealsDamage)} for {nameof(WarglaivesOfAzzinoth)}: {ex}");
      }
    }
  }
}