using System.Collections.Generic;

namespace MacroTools.UnitTypeTraits;

/// <summary>
/// A set of event-based functionalities attached to one or more Warcraft 3 unit types.
/// </summary>
public abstract class UnitTypeTrait
{
  /// <summary>
  /// Initializes a new instance of the <see cref="UnitTypeTrait"/> class.
  /// </summary>
  /// <param name="unitTypeId">The unit type to attach the effect to.</param>
  protected UnitTypeTrait(int unitTypeId)
  {
    UnitTypeIds = new[] { unitTypeId };
  }

  /// <summary>
  /// Initializes a new instance of the <see cref="UnitTypeTrait"/> class.
  /// </summary>
  /// <param name="unitTypeIds">A list of unit types to attach the effect to.</param>
  protected UnitTypeTrait(IEnumerable<int> unitTypeIds)
  {
    UnitTypeIds = unitTypeIds;
  }

  /// <summary>
  ///   The unit types that gets this effect.
  /// </summary>
  public IEnumerable<int> UnitTypeIds { get; }

  /// <summary>
  /// Fired when the <see cref="UnitTypeTrait"/> is registered.
  /// </summary>
  public virtual void OnRegistered()
  {
  }
}
