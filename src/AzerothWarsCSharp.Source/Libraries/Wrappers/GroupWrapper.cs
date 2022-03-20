using System.Collections.Generic;

namespace AzerothWarsCSharp.Source.Libraries.Wrappers
{
  /// <summary>
  ///   A wrapper for a Warcraft 3 unit group.
  ///   Manages the creation and destruction of the internal group automatically,
  ///   preventing memory leak issues.
  /// </summary>
  public sealed class GroupWrapper
  {
    private readonly group _group;

    public GroupWrapper()
    {
      _group = CreateGroup();
    }

    /// <summary>
    ///   Empties the units in this group into a C# List.
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

    public void Add(unit unit)
    {
      GroupAddUnit(_group, unit);
    }
    
    public GroupWrapper EnumUnitsOfPlayer(player player)
    {
      GroupEnumUnitsOfPlayer(_group, player, null);
      return this;
    }
    
    public GroupWrapper EnumUnitsInRect(rect rect)
    {
      GroupEnumUnitsInRect(_group, rect, null);
      return this;
    }
    
    public GroupWrapper EnumUnitsInRange(float x, float y, float radius)
    {
      GroupEnumUnitsInRange(_group, x, y, radius, null);
      return this;
    }

    ~GroupWrapper()
    {
      DestroyGroup(_group);
    }
  }
}