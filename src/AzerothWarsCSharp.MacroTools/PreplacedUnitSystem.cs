using System;
using System.Collections.Generic;
using System.Linq;
using AzerothWarsCSharp.MacroTools.Libraries;
using AzerothWarsCSharp.MacroTools.Wrappers;
using WCSharp.Shared.Data;
using static War3Api.Common;


namespace AzerothWarsCSharp.MacroTools
{
  /// <summary>
  ///   Once initialized, the system contains a reference to all preplaced units on the map.
  ///   Shutdown should be called once game has finished initializing.
  /// </summary>
  public static class PreplacedUnitSystem
  {
    private static readonly Dictionary<int, List<unit>> UnitsByTypeId = new();
    private static bool _initialized;
    private static bool _shutdown;

    /// <summary>
    ///   Gets a preplaced unit.
    /// </summary>
    /// <param name="unitTypeId">The unit type id the unit must have to be retrieved.</param>
    /// <param name="location">If there are multiple matching units, the one closest to this location will be retrieved.</param>
    /// <exception cref="KeyNotFoundException">Thrown if there is no preplaced unit with the given unit type id.</exception>
    public static unit GetUnit(int unitTypeId, Point location)
    {
      if (_shutdown) throw new Exception("PreplacedUnitSystem has already been shutdown.");
      if (!_initialized) throw new Exception("PreplacedUnitSystem has not been initialized.");
      if (!UnitsByTypeId.ContainsKey(unitTypeId))
        throw new KeyNotFoundException(
          $"There is no preplaced unit with Unit Type Id {GeneralHelpers.DebugIdInteger2IdString(unitTypeId)}.");
      return GetClosestUnitToPoint(UnitsByTypeId[unitTypeId], location);
    }

    /// <summary>
    ///   Gets a preplaced unit.
    /// </summary>
    /// <param name="unitTypeId">The unit type id the unit must have to be retrieved.</param>
    /// <exception cref="Exception">Thrown if there are multiple preplaced units with the given unit type id.</exception>
    /// <exception cref="KeyNotFoundException">Thrown if there is no preplaced unit with the given unit type id.</exception>
    public static unit GetUnit(int unitTypeId)
    {
      if (_shutdown) throw new Exception("PreplacedUnitSystem has already been shutdown.");
      if (!_initialized) throw new Exception("PreplacedUnitSystem has not been initialized.");
      if (!UnitsByTypeId.ContainsKey(unitTypeId))
        throw new KeyNotFoundException(
          $"There is no preplaced unit with Unit Type Id {GeneralHelpers.DebugIdInteger2IdString(unitTypeId)}.");

      if (UnitsByTypeId[unitTypeId].Count > 1)
        throw new Exception(
          $"There are multiple preplaced units with Unit Type Id {GeneralHelpers.DebugIdInteger2IdString(unitTypeId)}. Use the overload that requires a position instead.");

      return UnitsByTypeId[unitTypeId].First();
    }

    /// <summary>
    ///   Shuts down the PreplacedUnitSystem, freeing up memory and preventing further use.
    /// </summary>
    /// <exception cref="Exception">Thrown if the system has already been shutdown.</exception>
    public static void Shutdown()
    {
      if (_shutdown) throw new Exception("PreplacedUnitSystem has already been shutdown.");
      _shutdown = true;
      UnitsByTypeId.Clear();
    }

    /// <summary>
    ///   Initializes the PreplacedUnitSystem.
    /// </summary>
    /// <exception cref="Exception">Thrown if the system has already been initialized.</exception>
    public static void Initialize()
    {
      if (_initialized) throw new Exception("PreplacedUnitSystem has already been initialized.");
      _initialized = true;
      ReadAllUnits();
    }

    private static void ReadAllUnits()
    {
      foreach (var unit in new GroupWrapper().EnumUnitsInRect(GeneralHelpers.GetPlayableMapArea()).EmptyToList())
      {
        var unitTypeId = GetUnitTypeId(unit);
        if (!UnitsByTypeId.ContainsKey(unitTypeId)) UnitsByTypeId[unitTypeId] = new List<unit>();
        UnitsByTypeId[unitTypeId].Add(unit);
      }
    }
    
    private static unit GetClosestUnitToPoint(List<unit> units, Point location)
    {
      var closestDistance = float.MaxValue;
      var closestUnit = units.First();
      foreach (var unit in units)
      {
        var distance = MathEx.GetDistanceBetweenPoints(location, new Point(GetUnitX(unit), GetUnitY(unit)));
        if (distance < closestDistance)
        {
          closestDistance = distance;
          closestUnit = unit;
        }
      }

      return closestUnit;
    }
  }
}