using System.Collections.Generic;
using MacroTools.Extensions;
using WCSharp.Shared.Data;

namespace MacroTools.Utils
{
  public static class GroupUtils
  {
    private static readonly group UniversalGroup = CreateGroup();

    /// <summary>
    /// Adds all units selected by the provided player to the group.
    /// </summary> 
    public static List<unit> GetSelectedUnits(player whichPlayer)
    {
      SyncSelections();
      GroupEnumUnitsSelected(UniversalGroup, whichPlayer, null);
      return UniversalGroup.EmptyToList();
    }

    /// <summary>
    /// Adds all units of the provided type to the group.
    /// </summary>
    public static List<unit> GetUnitsOfType(int unitType)
    {
      GroupEnumUnitsOfType(UniversalGroup, GetObjectName(unitType), null);
      return UniversalGroup.EmptyToList();
    }

    /// <summary>
    /// Adds all units owned by the provided player to the group.
    /// </summary>
    public static List<unit> GetUnitsOfPlayer(player player)
    {
      GroupEnumUnitsOfPlayer(UniversalGroup, player, null);
      return UniversalGroup.EmptyToList();
    }

    /// <summary>
    /// Adds all units positioned in the provided <see cref="Rectangle"/> to the group>.
    /// </summary>
    public static List<unit> GetUnitsInRect(Rectangle rect)
    {
      return GetUnitsInRect(rect.Rect);
    }

    /// <summary>
    /// Adds all units positioned in the provided <see cref="rect"/> to the group.
    /// </summary>
    public static List<unit> GetUnitsInRect(rect rect)
    {
      GroupEnumUnitsInRect(UniversalGroup, rect, null);
      return UniversalGroup.EmptyToList();
    }

    /// <summary>
    /// Adds all units within range of the specified <see cref="Point"/> to the group.
    /// </summary>
    public static List<unit> GetUnitsInRange(Point point, float radius)
    {
      GroupEnumUnitsInRange(UniversalGroup, point.X, point.Y, radius, null);
      return UniversalGroup.EmptyToList();
    }
  }
}