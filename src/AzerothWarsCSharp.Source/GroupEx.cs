using System;
using System.Collections.Generic;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source
{
  /// <summary>
  /// A wrapper for a Warcraft 3 unit group.
  /// Manages the creation and destruction of the internal group automatically,
  /// preventing memory leak issues.
  /// </summary>
  public class GroupEx
  {
    private readonly group _group;
    
    /// <summary>
    /// Empties the units in this group into a C# List.
    /// </summary>
    public List<unit> EmptyToList()
    {
      var list = new List<unit>();
      var firstOfGroup = FirstOfGroup(_group);
      while (firstOfGroup != null)
      {
        list.Add(firstOfGroup);
        GroupRemoveUnit(_group, firstOfGroup);
        firstOfGroup = FirstOfGroup(_group);
      }
      return list;
    }
    
    public GroupEx EnumUnitsInRange(float x, float y, float radius)
    {
      GroupEnumUnitsInRange(_group, x, y, radius, null);
      return this;
    }

    ~GroupEx()
    {
      DestroyGroup(_group);
    }
    
    public GroupEx()
    {
      _group = CreateGroup();
    }
  }
}