using System.Collections.Generic;
using MacroTools.Data;
using MacroTools.UnitTypeTraits;
using WCSharp.Effects;

namespace WarcraftLegacies.Source.UnitTypeTraits;

/// <summary>
/// The unit with this ability gains mana based on the damage they deal.
/// </summary>
public sealed class RestoreManaFromDamage : UnitTypeTrait, IAppliesEffectOnDamage
{
  private readonly int _abilityTypeId;

  /// <summary>
  /// This effect appears on the unit when they restore mana from this ability.
  /// </summary>
  public string? Effect { get; init; } = "";

  /// <summary>
  /// The amount of mana this unit gains per point of damage they deal.
  /// </summary>
  public LeveledAbilityField<float> ManaPerDamage { get; init; } = new();

  /// <summary>
  /// Initializes a new instance of the <see cref="RestoreManaFromDamage"/> class.
  /// </summary>
  /// <param name="unitTypeId"><inheritdoc /></param>
  /// <param name="abilityTypeId">The Warcraft 3 ability representing this instance.</param>
  public RestoreManaFromDamage(int unitTypeId, int abilityTypeId) : base(unitTypeId) => _abilityTypeId = abilityTypeId;

  /// <summary>
  /// Initializes a new instance of the <see cref="RestoreManaFromDamage"/> class.
  /// </summary>
  /// <param name="unitTypeIds"><inheritdoc /></param>
  /// <param name="abilityTypeId">The Warcraft 3 ability representing this instance.</param>
  public RestoreManaFromDamage(IEnumerable<int> unitTypeIds, int abilityTypeId) : base(unitTypeIds) => _abilityTypeId = abilityTypeId;

  /// <inheritdoc />
  public void OnDealsDamage()
  {
    var damager = @event.DamageSource;
    var manaPerDamage = @event.Damage * (ManaPerDamage.Base + ManaPerDamage.PerLevel * damager.GetAbilityLevel(_abilityTypeId));
    damager.Mana += manaPerDamage;
    EffectSystem.Add(effect.Create(Effect, damager, "origin"));
  }
}
