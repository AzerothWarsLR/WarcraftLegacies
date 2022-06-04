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

    /// <summary>
    /// Fired when the unit finishes upgrading itself.
    /// </summary>
    public virtual void OnUpgrade()
    {
    }

    /// <summary>
    /// Fired when the unit finishes being constructed.
    /// </summary>
    public virtual void OnConstruction()
    {
    }

    public virtual void OnDealsDamage()
    {
    }

    public virtual void OnCreated()
    {
    }
  }
}