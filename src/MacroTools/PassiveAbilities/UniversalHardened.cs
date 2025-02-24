using System;
using System.Collections.Generic;
using MacroTools.PassiveAbilitySystem;
using static War3Api.Common;

namespace MacroTools.PassiveAbilities
{
  /// <summary>
  /// Reduces the damage of all incoming attacks by a set amount, which increases with the hero's level.
  /// </summary>
  public sealed class UniversalHardened : PassiveAbility, IAppliesEffectOnDamage
  {
    /// <summary>
    /// The unit type ID which has this <see cref="PassiveAbility"/> should also have an ability with this ID.
    /// </summary>
    public int AbilityTypeId { get; }

    /// <summary>
    /// The minimum amount of damage that can be dealt after reduction.
    /// </summary>
    public float MinimumDamage { get; init; } = 1.0f;

    /// <summary>
    /// Initializes a new instance of the <see cref="UniversalHardened"/> class.
    /// </summary>
    /// <param name="unitTypeId"><inheritdoc /></param>
    /// <param name="abilityTypeId">The ability the provided unit type has which represents this object.</param>
    public UniversalHardened(int unitTypeId, int abilityTypeId) : base(unitTypeId)
    {
      AbilityTypeId = abilityTypeId;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="UniversalHardened"/> class.
    /// </summary>
    /// <param name="unitTypeIds"><inheritdoc /></param>
    /// <param name="abilityTypeId">The ability the provided unit type has which represents this object.</param>
    public UniversalHardened(IEnumerable<int> unitTypeIds, int abilityTypeId) : base(unitTypeIds)
    {
      AbilityTypeId = abilityTypeId;
    }

    /// <inheritdoc />
    public void OnDealsDamage()
    {
    }

    /// <inheritdoc />
    public void OnTakesDamage()
    {
      try
      {
        var target = GetTriggerUnit();
        var caster = GetEventDamageSource();
        if (GetUnitAbilityLevel(target, AbilityTypeId) == 0)
          return;

        // Get the hero's level
        var heroLevel = GetHeroLevel(target);

        // Calculate the damage reduction based on the hero's level
        var damageReduction = heroLevel * 2.0f; 

        // Get the amount of damage the unit is taking
        var incomingDamage = GetEventDamage();

        // Calcuate the reduced damage
        var reducedDamage = Math.Max(incomingDamage - damageReduction, MinimumDamage);

        // Set the event damage to the reduced damage
        BlzSetEventDamage(reducedDamage);

        // Debugging damage reduction
        Console.WriteLine($"Target: {GetUnitName(target)}, Incoming Damage: {incomingDamage}, Reduced Damage: {reducedDamage}, Damage Reduction: {damageReduction}");
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Failed to execute {nameof(OnTakesDamage)} for {nameof(UniversalHardened)}: {ex}");
      }
    }
  }
}
