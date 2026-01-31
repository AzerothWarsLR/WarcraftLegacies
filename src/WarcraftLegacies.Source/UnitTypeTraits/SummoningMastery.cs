using MacroTools.Extensions;
using MacroTools.Spells;
using MacroTools.UnitTraits;

namespace WarcraftLegacies.Source.UnitTypeTraits;

/// <summary>
/// Causes the holder's summoned units to get stronger.
/// </summary>
public sealed class SummoningMastery : UnitTrait, IEffectOnSummonedUnit
{
  private readonly int _abilityTypeId;

  public LeveledAbilityField<float> HitPointPercentageBonus { get; init; } = new();

  public LeveledAbilityField<float> AttackDamagePercentageBonus { get; init; } = new();

  public SummoningMastery(int abilityTypeId)
  {
    _abilityTypeId = abilityTypeId;
  }

  /// <inheritdoc />
  public void OnSummonedUnit()
  {
    var abilityLevel = @event.SummoningUnit.GetAbilityLevel(_abilityTypeId);
    var summonedUnit = @event.SummonedUnit;
    summonedUnit.MultiplyBaseDamage(1 + AttackDamagePercentageBonus.Base + AttackDamagePercentageBonus.PerLevel * abilityLevel, 0);
    summonedUnit.MultiplyMaxHitpoints(1 + HitPointPercentageBonus.Base + HitPointPercentageBonus.PerLevel * abilityLevel);
  }
}
