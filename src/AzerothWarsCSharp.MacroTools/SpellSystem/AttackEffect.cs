namespace AzerothWarsCSharp.MacroTools.SpellSystem
{
  public abstract class AttackEffect
  {
    public int AttackerUnitTypeId { get; }
  
    public abstract void OnDealsDamage();

    protected AttackEffect(int attackerUnitTypeId)
    {
      AttackerUnitTypeId = attackerUnitTypeId;
    }
  }
}