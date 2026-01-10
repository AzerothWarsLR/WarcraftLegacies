using System.Collections.Generic;
using WCSharp.Events;

namespace WarcraftLegacies.Source.UniqueUnitNames;

public static class UnitNameManager
{
  private static readonly Dictionary<int, NamePool> _pools = new();

  public static void Setup()
  {
    UniqueNames.Init();

    foreach (var kvp in UniqueNames.Names)
    {
      _pools[kvp.Key] = new NamePool(kvp.Value);
      PlayerUnitEvents.Register(UnitTypeEvent.IsCreated, OnUnitCreated, kvp.Key);
      PlayerUnitEvents.Register(UnitTypeEvent.Dies, OnUnitDeath, kvp.Key);
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
}
