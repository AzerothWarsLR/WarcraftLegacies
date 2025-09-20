using System;
using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.PassiveAbilitySystem;
using MacroTools.Utils;

namespace WarcraftLegacies.Source.Spells;

/// <summary>
/// When a unit with this ability deals physical/normal damage, it heals allies in a radius around itself.
/// </summary>
public sealed class ResoluteHeart : PassiveAbility, IAppliesEffectOnDamage
{
  /// <summary>
  /// The unit type ID which has this <see cref="PassiveAbility"/> should also have an ability with this ID.
  /// </summary>
  public int AbilityTypeId { get; }

  /// <summary>
  /// The area around the unit to heal allies.
  /// </summary>
  public float Radius { get; init; }

  /// <summary>
  /// Base chance for the healing effect to trigger (increases with level).
  /// </summary>
  public float BaseProcChance { get; init; } = 0.2f;

  /// <summary>
  /// Visual effect path to display when the ability is triggered.
  /// </summary>
  public string? EffectPath { get; init; }

  /// <summary>
  /// Initializes a new instance of the <see cref="ResoluteHeart"/> class.
  /// </summary>
  /// <param name="unitTypeId">The unit type ID that possesses this ability.</param>
  /// <param name="abilityTypeId">The ability ID possessed by the unit.</param>
  public ResoluteHeart(int unitTypeId, int abilityTypeId) : base(unitTypeId)
  {
    AbilityTypeId = abilityTypeId;
  }

  /// <summary>
  /// Initializes a new instance of the <see cref="ResoluteHeart"/> class.
  /// </summary>
  /// <param name="unitTypeIds">The unit type IDs that possess this ability.</param>
  /// <param name="abilityTypeId">The ability ID possessed by the unit(s).</param>
  public ResoluteHeart(IEnumerable<int> unitTypeIds, int abilityTypeId) : base(unitTypeIds)
  {
    AbilityTypeId = abilityTypeId;
  }

  /// <inheritdoc />
  public void OnDealsDamage()
  {
    try
    {
      var caster = GetEventDamageSource();
      var damagedUnit = BlzGetEventDamageTarget();


      if (!BlzGetEventIsAttack() || GetUnitAbilityLevel(caster, AbilityTypeId) == 0 || damagedUnit == null)
      {
        return;
      }

      if (!IsUnitEnemy(damagedUnit, GetOwningPlayer(caster)) || IsUnitType(damagedUnit, UNIT_TYPE_STRUCTURE) || IsUnitType(damagedUnit, UNIT_TYPE_ANCIENT))
      {
        return;
      }

      var damageDealt = GetEventDamage();
      var level = GetUnitAbilityLevel(caster, AbilityTypeId);
      var procChance = BaseProcChance + (0.1f * (level - 1));

      if (GetRandomReal(0.0f, 1.0f) > procChance)
      {
        return;
      }

      var healAmount = damageDealt * 0.2f;

      // Heal nearby allies
      foreach (var nearbyUnit in GlobalGroup.EnumUnitsInRange(caster.GetPosition(), Radius))
      {
        if (nearbyUnit == caster || !IsUnitAlly(nearbyUnit, GetOwningPlayer(caster)) || !UnitAlive(nearbyUnit))
        {
          continue;
        }

        if (!string.IsNullOrEmpty(EffectPath))
        {
          AddSpecialEffect(EffectPath, nearbyUnit.GetPosition().X, nearbyUnit.GetPosition().Y);
        }

        nearbyUnit.Heal(healAmount);
      }
    }
    catch (Exception)
    {

    }
  }
}
