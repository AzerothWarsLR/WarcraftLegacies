namespace WarcraftLegacies.MacroTools.PassiveAbilitySystem
{
  public abstract class TakeDamagePassiveAbility
  {
    public int DamagedUnitTypeId { get; }
    
    public int AbilityTypeId { get; }
  
    public abstract void OnTakesDamage();

    protected TakeDamagePassiveAbility(int damagedUnitTypeId, int abilityTypeId)
    {
      DamagedUnitTypeId = damagedUnitTypeId;
      AbilityTypeId = abilityTypeId;
    }
  }
}