using MacroTools.UnitTypeTraits;
using MacroTools.Utils;
using WCSharp.Effects;

namespace WarcraftLegacies.Source.Spells;

/// <summary>
/// When a unit with this ability deals physical/normal damage, it heals allies in a radius around itself.
/// </summary>
public sealed class ResoluteHeart : UnitTypeTrait, IAppliesEffectOnDamage
{
  private readonly int _abilityTypeId;

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
  /// <param name="abilityTypeId">The ability ID possessed by the unit.</param>
  public ResoluteHeart(int abilityTypeId) => _abilityTypeId = abilityTypeId;

  /// <inheritdoc />
  public void OnDealsDamage()
  {
    var caster = @event.DamageSource;
    var damagedUnit = @event.DamageTarget;

    if (!@event.IsAttack || caster.GetAbilityLevel(_abilityTypeId) == 0 || damagedUnit == null)
    {
      return;
    }

    var owner = caster.Owner;

    if (!damagedUnit.IsEnemyTo(owner) || damagedUnit.IsUnitType(unittype.Structure) ||
        damagedUnit.IsUnitType(unittype.Ancient))
    {
      return;
    }

    var damageDealt = @event.Damage;
    var level = caster.GetAbilityLevel(_abilityTypeId);
    var procChance = BaseProcChance + (0.1f * (level - 1));

    if (GetRandomReal(0.0f, 1.0f) > procChance)
    {
      return;
    }

    var healAmount = damageDealt * 0.2f;

    // Heal nearby allies
    foreach (var nearbyUnit in GlobalGroup.EnumUnitsInRange(caster.X, caster.Y, Radius))
    {
      if (nearbyUnit == caster || !nearbyUnit.IsAllyTo(owner) || !nearbyUnit.Alive)
      {
        continue;
      }

      if (!string.IsNullOrEmpty(EffectPath))
      {
        EffectSystem.Add(effect.Create(EffectPath, nearbyUnit.X, nearbyUnit.Y));
      }

      nearbyUnit.Life += healAmount;
    }
  }
}
