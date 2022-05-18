using System.Collections.Generic;
using WCSharp.Shared.Data;

using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Wrappers
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

    public GroupWrapper EnumUnitsOfType(int unitType)
    {
      GroupEnumUnitsOfType(_group, GetObjectName(unitType), null);
      return this;
    }
    
    public GroupWrapper EnumUnitsOfPlayer(player player)
    {
      GroupEnumUnitsOfPlayer(_group, player, null);
      return this;
    }

    public GroupWrapper EnumUnitsInRect(Rectangle rect)
    {
      return EnumUnitsInRect(rect.Rect);
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