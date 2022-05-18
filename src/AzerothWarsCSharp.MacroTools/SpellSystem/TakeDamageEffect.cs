namespace AzerothWarsCSharp.MacroTools.SpellSystem
{
  public abstract class TakeDamageEffect
  {
    public int DamagedUnitTypeId { get; }
    
    public int AbilityTypeId { get; }
  
    public abstract void OnTakesDamage();

    protected TakeDamageEffect(int damagedUnitTypeId, int abilityTypeId)
    {
      DamagedUnitTypeId = damagedUnitTypeId;
      AbilityTypeId = abilityTypeId;
    }
  }
}