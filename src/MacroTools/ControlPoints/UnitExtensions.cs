namespace MacroTools.ControlPoints;

/// <summary>
/// A set of extension methods to bridge the gap between units and <see cref="ControlPoint"/>s.
/// </summary>
public static class UnitExtensions
{
  /// <summary>
  /// Converts the unit to a <see cref="ControlPoint"/>.
  /// </summary>
  /// <returns></returns>
  public static ControlPoint AsControlPoint(this unit whichUnit) =>
    ControlPointManager.Instance.GetFromUnitType(whichUnit.UnitType);

  /// <summary>
  /// Returns true if the unit is a <see cref="ControlPoint"/>.
  /// </summary>
  public static bool IsControlPoint(this unit whichUnit) => ControlPointManager.Instance.UnitIsControlPoint(whichUnit);
}
