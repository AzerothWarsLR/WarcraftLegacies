using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.UnitTraits;

namespace WarcraftLegacies.Source.UnitTypeTraits;

/// <summary>
/// Causes the unit to instantly kill enemies who drop below a certain threshold.
/// </summary>
public sealed class Execute : UnitTrait, IAppliesEffectOnDamage
{
  private const string Effect = "Objects\\Spawnmodels\\Human\\HumanLargeDeathExplode\\HumanLargeDeathExplode.mdl";

  /// <summary>
  /// Non-resistant enemies are instantly killed when their hit points drop below the caster's attack damage multiplied by this value.
  /// </summary>
  public float DamageMultNonResistant { get; init; }

  /// <summary>
  /// Resistant enemies are instantly killed when their hit points drop below the caster's attack damage multiplied by this value.
  /// </summary>
  public float DamageMultResistant { get; init; }

  /// <summary>
  /// Structures are instantly killed when their hit points drop below the caster's attack damage multiplied by this value.
  /// </summary>
  public float DamageMultStructure { get; init; }

  /// <inheritdoc />
  public void OnDealsDamage()
  {
    var triggerUnit = @event.Unit;

    var damageMult = 1f;
    if (triggerUnit.IsUnitType(unittype.Structure) || ControlPointManager.Instance.UnitIsControlPoint(triggerUnit))
    {
      damageMult = DamageMultStructure;
    }
    else if (triggerUnit.IsResistant())
    {
      damageMult = DamageMultResistant;
    }
    else if (!triggerUnit.IsResistant())
    {
      damageMult = DamageMultNonResistant;
    }

    if (damageMult == 1f)
    {
      return;
    }

    if (!@event.IsAttack || !(triggerUnit.Life < @event.Damage + @event.DamageSource.GetAverageDamage(0) * damageMult))
    {
      return;
    }

    @event.Damage = triggerUnit.Life + 1;
    @event.DamageType = damagetype.Universal;
    effect.Create(Effect, triggerUnit, "origin").Dispose();
  }
}
