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
      PlayerUnitEvents.Register(UnitTypeEvent.IsSummoned, OnUnitSummoned, kvp.Key);

      AssignNamesToPreplacedUnits(kvp.Key, pool);
    }
  }

  private static void OnUnitSummoned()
  {
    var illusion = @event.SummonedUnit;
    var source = @event.SummoningUnit;
    if (illusion == null || source == null || !illusion.IsIllusion || source.UnitType != illusion.UnitType)
    {
      return;
    }

    var name = source.Name;
    var copyNameTimer = timer.Create();
    copyNameTimer.Start(0, false, () =>
    {
      if (illusion.Alive)
      {
        illusion.Name = name;
      }

      copyNameTimer.Dispose();
    });
  }

  private static void OnUnitCreated()
  {
    var unit = @event.Unit;
    if (unit != null && !unit.IsIllusion && _pools.TryGetValue(unit.UnitType, out var pool))
    {
      pool.TryAssign(unit);
    }
  }

  private static void OnUnitDeath()
  {
    var unit = @event.Unit;
    if (unit != null && !unit.IsIllusion && _pools.TryGetValue(unit.UnitType, out var pool))
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

