namespace MacroTools.Extensions;

/// <summary>
/// Describes the mode by which units should be cleaned up.
/// </summary>
public enum NeutralPassiveCleanupType
{
  /// <summary>
  /// Turn neutral passive units hostile, but still remove buildings.
  /// </summary>
  TurnUnitsHostile,

  /// <summary>
  /// Remove all neutral passive units.
  /// </summary>
  RemoveUnits
}
