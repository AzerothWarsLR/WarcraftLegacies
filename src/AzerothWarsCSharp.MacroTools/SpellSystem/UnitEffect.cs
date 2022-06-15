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

    /// <summary>
    /// Fired when the unit is trained from a building.
    /// </summary>
    public virtual void OnTrained()
    {
    }

    /// <summary>
    /// Fired when the unit trains another unit from itself.
    /// </summary>
    public virtual void OnTrainedUnit()
    {
      
    }
  }
}