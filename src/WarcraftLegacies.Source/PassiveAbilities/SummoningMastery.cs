using System.Collections.Generic;
using MacroTools;
using MacroTools.Extensions;
using MacroTools.PassiveAbilitySystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.PassiveAbilities
{
  /// <summary>
  /// Causes the holder's summoned units to get stronger.
  /// </summary>
  public sealed class SummoningMastery : PassiveAbility, IEffectOnSummonedUnit
  {
    private readonly int _abilityTypeId;
    
    public LeveledAbilityField<float> HitPointPercentageBonus { get; init; } = new();

    public LeveledAbilityField<float> AttackDamagePercentageBonus { get; init; } = new();
    
    /// <inheritdoc />
    public SummoningMastery(IEnumerable<int> unitTypeIds, int abilityTypeId) : base(unitTypeIds)
    {
      _abilityTypeId = abilityTypeId;
    }

    /// <inheritdoc />
    public void OnSummonedUnit()
    {
      var abilityLevel = GetUnitAbilityLevel(GetTriggerUnit(), _abilityTypeId);
      GetSummonedUnit()
        .MultiplyBaseDamage(1 + AttackDamagePercentageBonus.Base + AttackDamagePercentageBonus.PerLevel * abilityLevel,0)
        .MultiplyMaxHitpoints(1 + HitPointPercentageBonus.Base + HitPointPercentageBonus.PerLevel * abilityLevel);
    }
  }
}