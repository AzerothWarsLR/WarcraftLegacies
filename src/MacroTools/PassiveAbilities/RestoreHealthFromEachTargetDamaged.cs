using System;
using System.Collections.Generic;
using MacroTools.ControlPointSystem;
using MacroTools.Data;
using MacroTools.Extensions;
using MacroTools.PassiveAbilitySystem;
using WCSharp.Effects;
using static War3Api.Common;

namespace MacroTools.PassiveAbilities
{
  /// <summary>
  /// The unit with this ability gains health based on each target it deals damage to.
  /// </summary>
  public sealed class RestoreHealthFromEachTargetDamaged : PassiveAbility, IAppliesEffectOnDamage
  {
    private readonly int _abilityTypeId;

    /// <summary>
    /// This effect appears on the unit when they restore health from this ability.
    /// </summary>
    public string? Effect { get; init; } = "";

    /// <summary>
    /// The amount of health this unit gains for each target damaged.
    /// </summary>
    public LeveledAbilityField<int> HealthPerTarget { get; init; } = new();

    /// <summary>
    /// The amount of health per hero level that is added to the health gained calculation.
    /// </summary>
    public int HealthPerLevel { get; init; } = 0;

    /// <summary>
    /// Initializes a new instance of the <see cref="RestoreHealthFromEachTargetDamaged"/> class.
    /// </summary>
    /// <param name="unitTypeId"><inheritdoc /></param>
    /// <param name="abilityTypeId">The Warcraft 3 ability representing this instance.</param>
    public RestoreHealthFromEachTargetDamaged(int unitTypeId, int abilityTypeId) : base(unitTypeId) => _abilityTypeId = abilityTypeId;

    /// <summary>
    /// Initializes a new instance of the <see cref="RestoreHealthFromEachTargetDamaged"/> class.
    /// </summary>
    /// <param name="unitTypeIds"><inheritdoc /></param>
    /// <param name="abilityTypeId">The Warcraft 3 ability representing this instance.</param>
    public RestoreHealthFromEachTargetDamaged(IEnumerable<int> unitTypeIds, int abilityTypeId) : base(unitTypeIds) => _abilityTypeId = abilityTypeId;

    /// <summary>
    /// The number of units required for diminishing returns to start.
    /// </summary>
    public int DiminishStartAfterUnits { get; set; } = 10;

    /// <summary>
    /// Effect is reduced by this percentage for each additional unit beyond the limit
    /// </summary>
    public float DiminishFactor { get; set; } = 0.2f;

    private List<unit> Units { get; init; } = new();

    private damagetype? LastDamageType { get; set; }

    private unit? LastUnit { get; set; }


    /// <inheritdoc />
    public void OnDealsDamage()
    {
      var triggerUnit = GetTriggerUnit();
      var caster = GetEventDamageSource();

      if (IsUnitType(triggerUnit, UNIT_TYPE_STRUCTURE) || ControlPointManager.Instance.UnitIsControlPoint(triggerUnit) ||
        IsUnitAlly(triggerUnit, caster.OwningPlayer()) || GetUnitAbilityLevel(caster, _abilityTypeId) == 0)
      {
        return;
      }

      var damagetype = BlzGetEventDamageType();
      var diminishMultiplier = 1.0f;

      if (BlzGetEventIsAttack() || damagetype != LastDamageType || caster != LastUnit)
      {
        Units.Clear();
        LastDamageType = damagetype;
        LastUnit = caster;
      }
      else
      {
        Units.Add(triggerUnit);
      }

      if (Units.Count > DiminishStartAfterUnits)
      {
        diminishMultiplier -= (Units.Count - DiminishStartAfterUnits) * DiminishFactor;
        _ = Math.Max(diminishMultiplier, 0.0f);
      }

      var healthPerTarget = ((caster.GetLevel() * HealthPerLevel) + (HealthPerTarget.Base + HealthPerTarget.PerLevel) * GetUnitAbilityLevel(caster, _abilityTypeId));
      caster.Heal(healthPerTarget);
      EffectSystem.Add(AddSpecialEffectTarget(Effect, caster, "origin"));
    }
  }
}