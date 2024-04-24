using MacroTools.PassiveAbilitySystem;
using WCSharp.Buffs;

namespace WarcraftLegacies.Source.PassiveAbilities.Incubate
{
  /// <summary>
  /// Causes the egg to mature after some time, allowing it to hatch.
  /// </summary>
  public sealed class ImmatureEggAbility : PassiveAbility
  {
    /// <summary>The unit type ID of the unit that gets hatched.</summary>
    public required int HatchedUnitTypeId { get; init; }
    
    /// <inheritdoc />
    public ImmatureEggAbility(int unitTypeId) : base(unitTypeId)
    {
    }
    
    /// <inheritdoc />
    public override void OnCreated(unit createdUnit)
    {
      UnitRemoveType(createdUnit, UNIT_TYPE_SUMMONED);
      var immatureEggBuff = new ImmatureEggBuff(createdUnit)
      {
        Duration = 15,
        HatchedUnitTypeId = HatchedUnitTypeId
      };
      BuffSystem.Add(immatureEggBuff);
    }
  }
}