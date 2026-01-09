using System;
using MacroTools.Extensions;
using MacroTools.Libraries;
using MacroTools.UnitTraits;
using MacroTools.Utils;
using WCSharp.Effects;

namespace WarcraftLegacies.Source.UnitTypeTraits;

/// <summary>
/// When the unit attacks, it deals extra damage in a radius around the attacked unit. Deals extra damage to demons.
/// </summary>
public sealed class WarglaivesOfAzzinoth : UnitTrait, IAppliesEffectOnDamage
{
  private readonly int _abilityTypeId;

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
  /// <param name="abilityTypeId">The ability the provided unit type has which represents this object.
  /// <remarks>If not set, the trait will be usable without a corresponding ability.</remarks>
  /// </param>
  public WarglaivesOfAzzinoth(int abilityTypeId = 0) => _abilityTypeId = abilityTypeId;

  /// <inheritdoc />
  public void OnDealsDamage()
  {
    try
    {
      var caster = @event.DamageSource;
      if (!@event.IsAttack || caster.GetAbilityLevel(_abilityTypeId) == 0 && _abilityTypeId != 0)
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

        var damageAmount = DamageBase + DamageLevel * caster.GetAbilityLevel(_abilityTypeId);
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
