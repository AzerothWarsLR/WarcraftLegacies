using System.Collections.Generic;
using WCSharp.Shared.Data;
using WCSharp.Shared.Extensions;

namespace MacroTools.Utils;

/// <summary>
/// Provides unit enumeration utilities backed by a shared, reusable group for better performance.
/// <para>
/// Using a single group avoids the overhead of creating and destroying a group for each enumeration,
/// and because groups are automatically cleared before each use, they're safe to reuse.
/// </para>
/// </summary>
public static class GlobalGroup
{
  private static readonly group _group = group.Create();

  /// <summary>
  /// Returns a list of units currently selected by the specified player.
  /// <para>
  /// Invokes <see cref="SyncSelections"/> before enumeration to ensure the selection state is up to date.
  /// </para>
  /// </summary>
  public static List<unit> EnumSelectedUnits(player whichPlayer)
  {
    SyncSelections();
    _group.EnumUnitsSelected(whichPlayer);
    return _group.ToList();
  }

  /// <summary>
  /// Returns a list of all units owned by the specified player.
  /// </summary>
  public static List<unit> EnumUnitsOfPlayer(player whichPlayer)
  {
    _group.EnumUnitsOfPlayer(whichPlayer);
    return _group.ToList();
  }

  /// <summary>
  /// Returns a list of units located within the specified <see cref="Rectangle"/>.
  /// </summary>
  public static List<unit> EnumUnitsInRect(Rectangle rect) =>
    EnumUnitsInRect(rect.Rect);

  /// <summary>
  /// Returns a list of units located within the specified <see cref="rect"/>.
  /// </summary>
  public static List<unit> EnumUnitsInRect(rect rect)
  {
    _group.EnumUnitsInRect(rect);
    return _group.ToList();
  }

  /// <summary>
  /// Returns a list of units within a specified radius of the given <see cref="Point"/>.
  /// </summary>
  public static List<unit> EnumUnitsInRange(Point point, float radius)
  {
    _group.EnumUnitsInRange(point.X, point.Y, radius);
    return _group.ToList();
  }

  /// <summary>
  /// Returns a list of units within a specified radius of the given point.
  /// </summary>
  public static List<unit> EnumUnitsInRange(float x, float y, float radius)
  {
    _group.EnumUnitsInRange(x, y, radius);
    return _group.ToList();
  }
}
