using System;
using System.Collections.Generic;

namespace MacroTools.Extensions;

/// <summary>
/// Provides a useful set of extension methods for Warcraft 3 groups.
/// </summary>
[Obsolete("Use GlobalGroup class instead; it is more performant.")]
public static class GroupExtensions
{
  /// <summary>
  ///   Empties the units in this group into a List,
  ///   then destroys it.
  /// </summary>
  [Obsolete("Use GlobalGroup class instead; it is more performant.")]
  public static List<unit> EmptyToList(this group whichGroup)
  {
    var list = new List<unit>();
    var firstOfGroup = whichGroup.First;
    while (firstOfGroup != null)
    {
      list.Add(firstOfGroup);
      whichGroup.Remove(firstOfGroup);
      firstOfGroup = whichGroup.First;
    }
    whichGroup.Dispose();
    return list;
  }

  /// <summary>
  /// Returns an exact copy of the group.
  /// </summary>
  [Obsolete("Use GlobalGroup class instead; it is more performant.")]
  public static group Copy(this group sourceGroup)
  {
    var newGroup = group.Create();
    sourceGroup.Add(newGroup);
    return newGroup;
  }
}
