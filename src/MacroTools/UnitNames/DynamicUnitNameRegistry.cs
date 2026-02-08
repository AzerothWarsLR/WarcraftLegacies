using System.Collections.Generic;
using MacroTools.PreplacedWidgets;
using WCSharp.Events;

namespace MacroTools.UnitNames;

public static class DynamicUnitNameRegistry
{
  private static readonly Dictionary<int, NamePool> _pools = new();

  public static void Setup(Dictionary<int, List<string>> nameData)
  {
    foreach (var kvp in nameData)
    {
      _pools[kvp.Key] = new NamePool(kvp.Value);
      PlayerUnitEvents.Register(UnitTypeEvent.IsCreated, OnUnitCreated, kvp.Key);
      PlayerUnitEvents.Register(UnitTypeEvent.Dies, OnUnitDeath, kvp.Key);
    }

    AssignNamesToPreplacedUnits();
  }

  private static void OnUnitCreated()
  {
    var unit = @event.Unit;
    if (unit != null && _pools.TryGetValue(unit.UnitType, out var pool))
    {
      pool.TryAssign(unit);
    }
  }

  private static void OnUnitDeath()
  {
    var unit = @event.Unit;
    if (unit != null && _pools.TryGetValue(unit.UnitType, out var pool))
    {
      pool.TryRelease(unit);
    }
  }

  private static void AssignNamesToPreplacedUnits()
  {
    foreach (var kvp in _pools)
    {
      var unitType = kvp.Key;
      NamePool pool = kvp.Value;

      List<unit> preplacedUnits;
      try
      {
        preplacedUnits = AllPreplacedWidgets.Units.GetAll(unitType);
      }
      catch (KeyNotFoundException)
      {
        continue;
      }

      foreach (var unit in preplacedUnits)
      {
        if (true)
        {
          pool.TryAssign(unit);
        }
      }
    }
  }
}
