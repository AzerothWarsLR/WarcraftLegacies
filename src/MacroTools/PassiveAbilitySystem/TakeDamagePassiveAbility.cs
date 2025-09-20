using System.Collections.Generic;

namespace MacroTools.PassiveAbilitySystem;

public abstract class TakeDamagePassiveAbility
{
  public IEnumerable<int> DamagedUnitTypeIds { get; }

  public int AbilityTypeId { get; }

  public abstract void OnTakesDamage();

  protected TakeDamagePassiveAbility(IEnumerable<int> damagedUnitTypeIds, int abilityTypeId)
  {
    DamagedUnitTypeIds = damagedUnitTypeIds;
    AbilityTypeId = abilityTypeId;
  }

  protected TakeDamagePassiveAbility(int damagedUnitTypeId, int abilityTypeId)
  {
    DamagedUnitTypeIds = new[] { damagedUnitTypeId };
    AbilityTypeId = abilityTypeId;
  }
}
