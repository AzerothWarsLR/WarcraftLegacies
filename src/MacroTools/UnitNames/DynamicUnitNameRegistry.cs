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
      var pool = new NamePool(kvp.Value);
      _pools[kvp.Key] = pool;

      PlayerUnitEvents.Register(UnitTypeEvent.IsCreated, OnUnitCreated, kvp.Key);
      PlayerUnitEvents.Register(UnitTypeEvent.Dies, OnUnitDeath, kvp.Key);

      AssignNamesToPreplacedUnits(kvp.Key, pool);
    }
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

  private static void AssignNamesToPreplacedUnits(int unitType, NamePool pool)
  {

    if (!AllPreplacedWidgets.Units.TryGetAll(unitType, out var preplacedUnits))
    {
      return;
    }

    foreach (var preplacedUnit in preplacedUnits)
    {
      pool.TryAssign(preplacedUnit);
    }
  }

}

