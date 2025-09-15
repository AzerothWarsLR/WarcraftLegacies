using MacroTools.Extensions;
using MacroTools.PassiveAbilitySystem;
using WCSharp.Effects;

namespace MacroTools.PassiveAbilities
{
  /// <summary>
  /// Causes the unit to create a unit upon death.
  /// </summary>
  public sealed class CreateUnitOnDeath : PassiveAbility
  {
    /// <summary>
    /// How long the summoned unit should last.
    /// </summary>
    public float Duration { get; init; }
    
    /// <summary>
    /// The unit type to summon on death.
    /// </summary>
    public int CreateUnitTypeId { get; init; }

    /// <summary>
    /// How many units to summon.
    /// </summary>
    public int CreateCount { get; init; } = 1;

    /// <summary>
    /// The special effect that appears when the ability triggers.
    /// </summary>
    public string SpecialEffectPath { get; init; } = "";
    
    /// <summary>
    /// The player must have this research for the ability to take effect.
    /// </summary>
    public int RequiredResearch { get; init; }
    
    /// <inheritdoc />
    public CreateUnitOnDeath(int unitTypeId) : base(unitTypeId)
    {
    }
    
    /// <inheritdoc />
    public override void OnDeath()
    {
      var triggerUnit = GetTriggerUnit();
      if (GetPlayerTechCount(triggerUnit.OwningPlayer(), RequiredResearch, false) == 0 || IsUnitType(triggerUnit, UNIT_TYPE_SUMMONED))
        return;
      var pos = triggerUnit.GetPosition();
      for (var i = 0; i < CreateCount; i++)
        CreateUnit(triggerUnit.OwningPlayer(), CreateUnitTypeId, pos.X, pos.Y, GetUnitFacing(triggerUnit))
          .SetTimedLife(Duration);
      EffectSystem.Add(AddSpecialEffect(SpecialEffectPath, pos.X, pos.Y), 1);
      RemoveUnit(triggerUnit);
    }
  }
}