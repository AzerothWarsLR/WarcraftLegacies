using System.Collections.Generic;

namespace MacroTools.UnitTypeTraits;

public abstract class TakeDamageUnitTypeTrait
{
  public IEnumerable<int> DamagedUnitTypeIds { get; }

  public int AbilityTypeId { get; }

  public abstract void OnTakesDamage();

  protected TakeDamageUnitTypeTrait(IEnumerable<int> damagedUnitTypeIds, int abilityTypeId)
  {
    DamagedUnitTypeIds = damagedUnitTypeIds;
    AbilityTypeId = abilityTypeId;
  }

  protected TakeDamageUnitTypeTrait(int damagedUnitTypeId, int abilityTypeId)
  {
    DamagedUnitTypeIds = new[] { damagedUnitTypeId };
    AbilityTypeId = abilityTypeId;
  }
}
