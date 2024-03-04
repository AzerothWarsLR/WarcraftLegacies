using System.Collections.Generic;
using WCSharp.Shared.Data;
using WCSharp.Shared.Extensions;


namespace MacroTools.Extensions
{
  /// <summary>
  /// Provides a useful set of extension methods for Warcraft 3 groups.
  /// </summary>
  public static class GroupExtensions
  {
    /// <summary>
    ///   Empties the units in this group into a List,
    ///   then clears it.
    /// </summary>
    public static List<unit> EmptyToList(this group whichGroup)
    {
      var list = whichGroup.ToList();
      list.Clear();
      return list;
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