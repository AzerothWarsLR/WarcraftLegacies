using System.Collections.Generic;


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
      UnitTypeIds = new[] { unitTypeId };
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PassiveAbility"/> class.
    /// </summary>
    /// <param name="unitTypeIds">A list of unit types to attach the effect to.</param>
    protected PassiveAbility(IEnumerable<int> unitTypeIds)
    {
      UnitTypeIds = unitTypeIds;
    }

    /// <summary>
    ///   The unit types that gets this effect.
    /// </summary>
    public IEnumerable<int> UnitTypeIds { get; }

    /// <summary>
    /// Fired when the unit finishes upgrading itself.
    /// </summary>
    public virtual void OnUpgrade()
    {
    }
    
    /// <summary>
    /// Fired when the unit dies.
    /// </summary>
    public virtual void OnDeath()
    {
    }
    
    /// <summary>
    /// Fired when the unit finishes casting a spell.
    /// </summary>
    public virtual void OnSpellFinish()
    {
    }
    
    /// <summary>
    /// Fired when the unit starts the effect of a spell.
    /// </summary>
    public virtual void OnSpellEffect()
    {
    }
    
    /// <summary>
    /// Fired when a unit of the matching unit type finishes being constructed.
    /// </summary>
    public virtual void OnConstruction()
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

    /// <summary>
    /// Fired when the unit cancels a research.
    /// </summary>
    public virtual void OnCancelUpgrade()
    {
    }

    /// <summary>
    /// Fired when the unit is issued a point order.
    /// </summary>
    public virtual void OnOrderIssued()
    {
    }
  }
}