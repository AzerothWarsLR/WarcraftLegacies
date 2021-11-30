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
  public class GroupEx : IDisposable
  {
    private group _group;
    
    public List<unit> ToList()
    {
      var list = new List<unit>();
      if (_group == null)
      {
        throw new NullReferenceException(nameof(_group));
      }

      var firstOfGroup = FirstOfGroup(_group);
      while (firstOfGroup != null)
      {
        list.Add(firstOfGroup);
        GroupRemoveUnit(_group, firstOfGroup);
        firstOfGroup = FirstOfGroup(_group);
      }
      
      return list;
    }
    
    public void EnumUnitsInRange(float x, float y, float radius)
    {
      GroupEnumUnitsInRange(_group, x, y, radius, null);
    }

    public void Dispose()
    {
      DestroyGroup(_group);
      GC.SuppressFinalize(this);
    }

    public GroupEx()
    {
      _group = CreateGroup();
    }
  }
}