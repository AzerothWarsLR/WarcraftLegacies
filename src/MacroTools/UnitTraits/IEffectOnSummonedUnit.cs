namespace MacroTools.UnitTraits;

/// <summary>
/// Provides methods for responding to a unit summoning another unit.
/// </summary>
public interface IEffectOnSummonedUnit
{
  /// <summary>
  /// A response to a unit dealing damage.
  /// </summary>
  public void OnSummonedUnit();
}
