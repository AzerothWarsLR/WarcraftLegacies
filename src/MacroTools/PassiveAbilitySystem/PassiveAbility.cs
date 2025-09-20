using System.Collections.Generic;

namespace MacroTools.PassiveAbilitySystem;

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
  /// Fired when the <see cref="PassiveAbility"/> is registered.
  /// </summary>
  public virtual void OnRegistered()
  {
  }
}
