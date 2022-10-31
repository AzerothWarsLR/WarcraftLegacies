using static War3Api.Common;

namespace MacroTools.PassiveAbilitySystem
{
  /// <summary>
  /// A passive ability attached to a specific unit type.
  /// </summary>
  public abstract class PassiveAbility
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="PassiveAbility"/> class.
    /// </summary>
    /// <param name="unitTypeId">The unit type to attach the effect to.</param>
    protected PassiveAbility(int unitTypeId)
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
    /// Fired when a unit of the matching unit type finishes being constructed.
    /// </summary>
    public virtual void OnConstruction()
    {
    }

    /// <summary>
    /// Fired when a unit of the matching unit type deals damage.
    /// </summary>
    public virtual void OnDealsDamage()
    {
    }

    /// <summary>
    /// Fired when a unit of the matching unit type is created.
    /// </summary>
    /// <param name="createdUnit"></param>
    public virtual void OnCreated(unit createdUnit)
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