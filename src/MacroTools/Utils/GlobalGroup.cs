using System.Collections.Generic;
using WCSharp.Shared.Data;

namespace MacroTools.Utils;

/// <summary>
/// Provides unit enumeration functions powered by a single, globally shared group for improved performance.
/// <para>Using a single group avoids spending cycles creating and destroying a group per enumeration.</para>
/// </summary>
public static class GlobalGroup
{
  private static readonly group _group = group.Create();

  /// <summary>
  /// Adds all units selected by the provided player to the group.
  /// </summary>
  public static List<unit> EnumSelectedUnits(player whichPlayer)
  {
    SyncSelections();
    _group.EnumUnitsSelected(whichPlayer, null);
    return EmptyToList(_group);
  }

  /// <summary>
  /// Adds all units owned by the provided player to the group.
  /// </summary>
  public static List<unit> EnumUnitsOfPlayer(player player)
  {
    _group.EnumUnitsOfPlayer(player, null);
    return EmptyToList(_group);
  }

  /// <summary>
  /// Adds all units positioned in the provided <see cref="Rectangle"/> to the group>.
  /// </summary>
  public static List<unit> EnumUnitsInRect(Rectangle rect) =>
    EnumUnitsInRect(rect.Rect);

  /// <summary>
  /// Adds all units positioned in the provided <see cref="rect"/> to the group.
  /// </summary>
  public static List<unit> EnumUnitsInRect(rect rect)
  {
    _group.EnumUnitsInRect(rect, null);
    return EmptyToList(_group);
  }

  /// <summary>
  /// Adds all units within range of the specified <see cref="Point"/> to the group.
  /// </summary>
  public static List<unit> EnumUnitsInRange(Point point, float radius)
  {
    _group.EnumUnitsInRange(point.X, point.Y, radius, null);
    return EmptyToList(_group);
  }

  /// <summary>
  ///   Destructively empties the units in this group into a List,
  ///   leaving nothing behind.
  /// </summary>
  private static List<unit> EmptyToList(group whichGroup)
  {
    var list = new List<unit>();
    var firstOfGroup = whichGroup.First;
    while (firstOfGroup != null)
    {
      list.Add(firstOfGroup);
      whichGroup.Remove(firstOfGroup);
      firstOfGroup = whichGroup.First;
    }
    return list;
  }
}
