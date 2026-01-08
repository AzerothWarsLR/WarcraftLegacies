using System;
using System.Collections.Generic;
using WCSharp.Events;

namespace WarcraftLegacies.Source.UniqueUnitNames;

/// <summary>
/// Handles assigning unique names to elite units when they are created,
/// and returning the name to the pool when the unit dies.
/// </summary>
public static class EliteNameSystem
{
    private static readonly Random Random = new Random();
    private static readonly Dictionary<int, HashSet<string>> NamesInUse = new();

    /// <summary>
    /// Sets up the system to automatically apply elite names when elite units are created or die.
    /// Only registers events for unit types that have names defined.
    /// </summary>
    public static void Setup()
    {
        EliteNames.Init();

        foreach (var unitType in EliteNames.NamePool.Keys)
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

        if (!NamesInUse.ContainsKey(unit.UnitType))
        {
            return;
        }

        NamesInUse[unit.UnitType].Remove(unit.Name);
    }

    private static void AssignName(unit unit)
    {
        if (!EliteNames.NamePool.ContainsKey(unit.UnitType))
        {
            return;
        }

        if (!NamesInUse.ContainsKey(unit.UnitType))
        {
            NamesInUse[unit.UnitType] = new HashSet<string>();
        }

        var availableNames = new List<string>();

        foreach (var name in EliteNames.NamePool[unit.UnitType])
        {
            if (!NamesInUse[unit.UnitType].Contains(name))
            {
                availableNames.Add(name);
            }
        }

        if (availableNames.Count == 0)
        {
            unit.Name = "";
            return;
        }

        var chosenName = availableNames[Random.Next(availableNames.Count)];
        unit.Name = chosenName;
        NamesInUse[unit.UnitType].Add(chosenName);
    }
}
