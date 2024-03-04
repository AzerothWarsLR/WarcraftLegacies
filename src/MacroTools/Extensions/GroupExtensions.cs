using System.Collections.Generic;
using WCSharp.Shared.Data;


namespace MacroTools.Extensions
{
  /// <summary>
  /// Provides a useful set of extension methods for Warcraft 3 groups.
  /// </summary>
  public static class GroupExtensions
  {
    /// <summary>
    ///   Empties the units in this group into a List,
    ///   then destroys it.
    /// </summary>
    public static List<unit> EmptyToList(this group whichGroup)
    {
      var list = new List<unit>();
      var firstOfGroup = FirstOfGroup(whichGroup);
      while (firstOfGroup != null)
      {
        list.Add(firstOfGroup);
        GroupRemoveUnit(whichGroup, firstOfGroup);
        firstOfGroup = FirstOfGroup(whichGroup);
      }
      DestroyGroup(whichGroup);
      return list;
    }

    /// <summary>
    /// Adds an additional unit to the group.
    /// </summary>
    public static group Add(group whichGroup, unit unit)
    {
      GroupAddUnit(whichGroup, unit);
      return whichGroup;
    }

    /// <summary>
    /// Adds all units selected by the provided player to the group.
    /// </summary> 
    public static  group EnumSelectedUnits(this group whichGroup, player whichPlayer)
    {
      SyncSelections();
      GroupEnumUnitsSelected(whichGroup, whichPlayer, null);
      return whichGroup;
    }

    /// <summary>
    /// Adds all units of the provided type to the group.
    /// </summary>
    public static  group EnumUnitsOfType(this group whichGroup, int unitType)
    {
      GroupEnumUnitsOfType(whichGroup, GetObjectName(unitType), null);
      return whichGroup;
    }

    /// <summary>
    /// Adds all units owned by the provided player to the group.
    /// </summary>
    public static  group EnumUnitsOfPlayer(this group whichGroup, player player)
    {
      GroupEnumUnitsOfPlayer(whichGroup, player, null);
      return whichGroup;
    }

    /// <summary>
    /// Adds all units positioned in the provided <see cref="Rectangle"/> to the group>.
    /// </summary>
    public static  group EnumUnitsInRect(this group whichGroup, Rectangle rect)
    {
      return EnumUnitsInRect(whichGroup, rect.Rect);
    }

    /// <summary>
    /// Adds all units positioned in the provided <see cref="rect"/> to the group.
    /// </summary>
    public static  group EnumUnitsInRect(this group whichGroup, rect rect)
    {
      GroupEnumUnitsInRect(whichGroup, rect, null);
      return whichGroup;
    }

    /// <summary>
    /// Adds all units within range of the specified <see cref="Point"/> to the group.
    /// </summary>
    public static  group EnumUnitsInRange(this group whichGroup, Point point, float radius)
    {
      GroupEnumUnitsInRange(whichGroup, point.X, point.Y, radius, null);
      return whichGroup;
    }

    /// <summary>
    /// Returns an exact copy of the group.
    /// </summary>
    public static group Copy(this group sourceGroup)
    {
      var newGroup = CreateGroup();
      BlzGroupAddGroupFast(sourceGroup, newGroup);
      return newGroup;
    }
  }
}