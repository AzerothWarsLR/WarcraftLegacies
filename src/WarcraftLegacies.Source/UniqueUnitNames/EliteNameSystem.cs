using System.Collections.Generic;
using WCSharp.Events;

namespace WarcraftLegacies.Source.UniqueUnitNames;

public static class EliteNameSystem
{
  private static readonly Dictionary<int, HashSet<string>> _namesInUse = new Dictionary<int, HashSet<string>>();

  /// <summary>
  /// Sets up the system to automatically apply elite names when elite units are created or die.
  /// Only registers events for unit types that have names defined.
  /// </summary>
  public static void Setup()
  {
    EliteNames.Init();

    foreach (var unitType in EliteNames._namePool.Keys)
    {
      PlayerUnitEvents.Register(UnitTypeEvent.IsCreated, OnUnitCreated, unitType);
      PlayerUnitEvents.Register(UnitTypeEvent.Dies, OnUnitDeath, unitType);
    }
  }

  private static void OnUnitCreated()
  {
    var unit = @event.Unit;
    if (unit == null)
    {
      return;
    }

    AssignName(unit);
  }

  private static void OnUnitDeath()
  {
    var unit = @event.Unit;
    if (unit == null)
    {
      return;
    }

    if (_namesInUse.TryGetValue(unit.UnitType, out var names))
    {
      names.Remove(unit.Name);
    }
  }

  private static void AssignName(unit unit)
  {
    if (!EliteNames._namePool.TryGetValue(unit.UnitType, out var pool))
    {
      return;
    }

    if (!_namesInUse.TryGetValue(unit.UnitType, out var used))
    {
      used = new HashSet<string>();
      _namesInUse[unit.UnitType] = used;
    }

    var available = new List<string>();

    foreach (var name in pool)
    {
      if (!used.Contains(name))
      {
        available.Add(name);
      }
    }

    if (available.Count == 0)
    {
      unit.Name = "";
      return;
    }

    var index = GetRandomInt(0, available.Count - 1);
    var chosenName = available[index];
    unit.Name = chosenName;
    used.Add(chosenName);
  }
}
