using System;
using System.Collections.Generic;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Wrappers
{
  /// <summary>
  ///   A wrapper for a Warcraft 3 <see cref="group"/>.
  ///   Manages the creation and destruction of the internal group automatically,
  ///   preventing memory leak issues.
  /// </summary>
  public sealed class GroupWrapper : IDisposable
  {
    private readonly group _group;
    private bool _disposed;

    /// <summary>
    /// Initializes a new instance of the <see cref="GroupWrapper"/> class.
    /// </summary>
    public GroupWrapper()
    {
      _group = CreateGroup();
    }

    public void Dispose()
    {
      Dispose(true);
    }

    /// <summary>
    ///   Empties the units in this group into a List,
    ///   then disposes the <see cref="GroupWrapper"/>.
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
      Dispose();
      return list;
    }

    /// <summary>
    /// Adds an additional unit to the <see cref="GroupWrapper"/>.
    /// </summary>
    public void Add(unit unit)
    {
      GroupAddUnit(_group, unit);
    }

    /// <summary>
    /// Adds all units selected by the provided player to the <see cref="GroupWrapper"/>.
    /// </summary>
    public GroupWrapper EnumSelectedUnits(player whichPlayer)
    {
      SyncSelections();
      GroupEnumUnitsSelected(_group, whichPlayer, null);
      return this;
    }

    /// <summary>
    /// Adds all units of the provided type to the <see cref="GroupWrapper"/>.
    /// </summary>
    public GroupWrapper EnumUnitsOfType(int unitType)
    {
      GroupEnumUnitsOfType(_group, GetObjectName(unitType), null);
      return this;
    }

    /// <summary>
    /// Adds all units owned by the provided player to the <see cref="GroupWrapper"/>.
    /// </summary>
    public GroupWrapper EnumUnitsOfPlayer(player player)
    {
      GroupEnumUnitsOfPlayer(_group, player, null);
      return this;
    }

    /// <summary>
    /// Adds all units positioned in the provided <see cref="Rectangle"/> to the <see cref="GroupWrapper"/>.
    /// </summary>
    public GroupWrapper EnumUnitsInRect(Rectangle rect)
    {
      return EnumUnitsInRect(rect.Rect);
    }

    /// <summary>
    /// Adds all units positioned in the provided <see cref="rect"/> to the <see cref="GroupWrapper"/>.
    /// </summary>
    public GroupWrapper EnumUnitsInRect(rect rect)
    {
      GroupEnumUnitsInRect(_group, rect, null);
      return this;
    }

    /// <summary>
    /// Adds all units within range of the specified <see cref="Point"/> to the <see cref="GroupWrapper"/>.
    /// </summary>
    public GroupWrapper EnumUnitsInRange(Point point, float radius)
    {
      GroupEnumUnitsInRange(_group, point.X, point.Y, radius, null);
      return this;
    }

    ~GroupWrapper()
    {
      Dispose(false);
    }

    private void Dispose(bool disposing)
    {
      if (_disposed) return;

      if (disposing) DestroyGroup(_group);
      _disposed = true;
    }
  }
}