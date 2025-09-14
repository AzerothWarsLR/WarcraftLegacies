using System;
using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.PassiveAbilitySystem;

namespace MacroTools.PassiveAbilities
{
  /// <summary>
  /// The unit takes extra damage while on water.
  /// </summary>
  public sealed class TakeExtraDamageOnWater : PassiveAbility, IEffectOnTakesDamage
  {
    private readonly int _abilityTypeId;

    /// <summary>
    /// The unit's damage taken while on water is multiplied by this amount.
    /// </summary>
    public float DamageMultiplier { get; init; }

    /// <summary>
    /// Initializes a new instance of the <see cref="TakeExtraDamageOnWater"/> class.
    /// </summary>
    /// <param name="unitTypeIds"><inheritdoc /></param>
    /// <param name="abilityTypeId">A dummy ability that represents this <see cref="PassiveAbility"/>.<inheritdoc /></param>
    public TakeExtraDamageOnWater(IEnumerable<int> unitTypeIds, int abilityTypeId) : base(unitTypeIds)
    {
      if (abilityTypeId == 0)
        throw new ArgumentException($"{nameof(abilityTypeId)} cannot be 0.");
      _abilityTypeId = abilityTypeId;
    }

    /// <inheritdoc />
    public override void OnCreated(unit createdUnit)
    {
      createdUnit.AddAbility(_abilityTypeId);
    }

    /// <inheritdoc />
    public void OnTakesDamage()
    {
      var triggerUnit = GetTriggerUnit();
      if (!IsTerrainPathable(GetUnitX(triggerUnit), GetUnitY(triggerUnit), PATHING_TYPE_FLOATABILITY) 
          && IsTerrainPathable(GetUnitX(triggerUnit), GetUnitY(triggerUnit), PATHING_TYPE_WALKABILITY))
        BlzSetEventDamage(GetEventDamage() * DamageMultiplier);
    }
  }
}