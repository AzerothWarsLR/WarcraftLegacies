using WCSharp.Shared.Data;
using static MacroTools.Utils.GeneralHelpers;

namespace MacroTools.Extensions;

/// <summary>
/// A useful set of extension methods for <see cref="Point"/>s.
/// </summary>
public static class PointExtensions
{
  /// <summary>
  /// Returns true if units can path over the <see cref="Point"/>.
  /// </summary>
  public static bool IsPathable(this Point whichPoint, pathingtype pathingType) =>
    !pathingType.GetPathable(whichPoint.X, whichPoint.Y);

  /// <summary>
  /// Returns the terrain type at the <see cref="Point"/>.
  /// </summary>
  public static int TerrainType(this Point whichPoint) => GetTerrainType(whichPoint.X, whichPoint.Y);

  /// <summary>
  /// Removes trees in a radius around a unit
  /// </summary>
  public static void RemoveDestructablesInRadius(this Point whichPoint, float radius)
  {
    EnumDestructablesInCircle(radius, whichPoint,
      () =>
      {
        GetEnumDestructable().Dispose();
      });
  }
}
