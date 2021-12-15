using System;
using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools.Wrappers;
using static War3Api.Common;
using static War3Api.Blizzard;

namespace AzerothWarsCSharp.MacroTools
{
  /// <summary>
  /// Once initialized, the system contains a reference to all preplaced units on the map.
  /// Shutdown should be called once game has finished initializing.
  /// </summary>
  public static class PreplacedUnitSystem
  {
    private static readonly Dictionary<int, unit> UnitsByTypeId = new();
    private static bool _initialized;
    private static bool _shutdown;

    /// <summary>
    /// Gets a preplaced unit with a given Unit Type Id.
    /// </summary>
    public static unit GetUnitByUnitType(int unitTypeId)
    {
      if (_shutdown) throw new Exception("PreplacedUnitSystem has already been shutdown.");
      if (!_initialized) throw new Exception("PreplacedUnitSystem has not been initialized.");
      if (!UnitsByTypeId.ContainsKey(unitTypeId))
      {
        throw new KeyNotFoundException($"There is no preplaced unit with Unit Type Id {GetObjectName(unitTypeId)}.");
      }
      return UnitsByTypeId[unitTypeId];
    }

    /// <summary>
    /// Shuts down the PreplacedUnitSystem, freeing up memory and preventing further use.
    /// </summary>
    /// <exception cref="Exception"></exception>
    public static void Shutdown()
    {
      if (_shutdown) throw new Exception("PreplacedUnitSystem has already been shutdown.");
      _shutdown = true;
      UnitsByTypeId.Clear();
    }

    /// <summary>
    /// Initializes the PreplacedUnitSystem.
    /// </summary>
    /// <exception cref="Exception"></exception>
    public static void Initialize()
    {
      if (_initialized) throw new Exception("PreplacedUnitSystem has already been initialized.");
      _initialized = true;
      ReadAllUnits();
    }
    
    private static void ReadAllUnits()
    {
      foreach (var unit in new GroupWrapper().EnumUnitsInRect(GetPlayableMapRect()).EmptyToList())
      {
        var unitTypeId = GetUnitTypeId(unit);
        if (!UnitsByTypeId.ContainsKey(unitTypeId)) UnitsByTypeId[unitTypeId] = unit;
      }
    }
  }
}