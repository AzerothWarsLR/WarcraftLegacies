using System;
using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Libraries;
using MacroTools.UnitTypeTraits;
using MacroTools.Utils;
using WCSharp.Effects;

namespace WarcraftLegacies.Source.PassiveAbilities;

/// <summary>
/// When the unit attacks, it deals extra damage in a radius around the attacked unit. Deals extra damage to demons.
/// </summary>
public sealed class WarglaivesOfAzzinoth : UnitTypeTrait, IAppliesEffectOnDamage
{
  /// <summary>
  /// The unit type ID which has this <see cref="UnitTypeTrait"/> should also have an ability with this ID.
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
  public damagetype DamageType { get; init; } = damagetype.Magic;

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
      var caster = @event.DamageSource;
      if (!@event.IsAttack || caster.GetAbilityLevel(AbilityTypeId) == 0)
      {
        return;
      }

      var target = @event.Unit;
      var targetX = target.X;
      var targetY = target.Y;

      effect effect = effect.Create(Effect, targetX, targetY);
      effect.Scale = EffectScale;
      effect.SetYaw(caster.Facing * MathEx.DegToRad);
      EffectSystem.Add(effect);

      foreach (var nearbyUnit in GlobalGroup.EnumUnitsInRange(targetX, targetY, Radius))
      {
        if (nearbyUnit.IsAllyTo(caster.Owner) || !nearbyUnit.Alive || nearbyUnit.IsInvulnerable ||
            nearbyUnit.IsUnitType(unittype.Structure) || nearbyUnit.IsUnitType(unittype.Ancient))
        {
          continue;
        }

        var damageAmount = DamageBase + DamageLevel * caster.GetAbilityLevel(AbilityTypeId);
        if (nearbyUnit.Race == race.Demon)
        {
          damageAmount *= DamageMultiplierAgainstDemons;
        }

        nearbyUnit.TakeDamage(caster, damageAmount, false, false, attacktype.Normal, DamageType);
      }
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Failed to execute {nameof(OnDealsDamage)} for {nameof(WarglaivesOfAzzinoth)}: {ex}");
    }
  }
}
