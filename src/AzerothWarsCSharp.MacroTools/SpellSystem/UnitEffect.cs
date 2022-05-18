namespace AzerothWarsCSharp.MacroTools.SpellSystem
{
  public abstract class UnitEffect
  {
    protected UnitEffect(int unitTypeId)
    {
      UnitTypeId = unitTypeId;
    }

    /// <summary>
    ///   The unit type that gets this effect.
    /// </summary>
    public int UnitTypeId { get; }

    public virtual void OnDealsDamage()
    {
    }

    public virtual void OnCreated()
    {
    }
  }
}