using System;
using System.Collections.Generic;
using System.Linq;
using MacroTools.Libraries;
using MacroTools.Wrappers;
using WCSharp.Shared.Data;
using static War3Api.Common;


namespace MacroTools
{
  /// <summary>
  ///   Once initialized, the system contains a reference to all preplaced units on the map.
  ///   Shutdown should be called once game has finished initializing.
  /// </summary>
  public static class PreplacedUnitSystem
  {
    private static readonly Dictionary<int, List<unit>> UnitsByTypeId = new();
    private static readonly Dictionary<int, List<destructable>> DestructablesByTypeId = new();
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
      if (_shutdown) throw new Exception($"{nameof(PreplacedUnitSystem)} has already been shutdown.");
      if (!_initialized) throw new Exception($"{nameof(PreplacedUnitSystem)} has not been initialized.");
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
      if (_shutdown) throw new Exception($"{nameof(PreplacedUnitSystem)} has already been shutdown.");
      if (!_initialized) throw new Exception($"{nameof(PreplacedUnitSystem)} has not been initialized.");
      if (!UnitsByTypeId.ContainsKey(unitTypeId))
        throw new KeyNotFoundException(
          $"There is no preplaced unit with Unit Type Id {GeneralHelpers.DebugIdInteger2IdString(unitTypeId)}.");

      if (UnitsByTypeId[unitTypeId].Count > 1)
        throw new Exception(
          $"There are multiple preplaced units with Unit Type Id {GeneralHelpers.DebugIdInteger2IdString(unitTypeId)}. Use the overload that requires a position instead.");

      return UnitsByTypeId[unitTypeId].First();
    }

    /// <summary>
    ///   Gets a preplaced destructable.
    /// </summary>
    /// <param name="destructableTypeId">The destructable type id the destructable must have to be retrieved.</param>
    /// <param name="location">If there are multiple matching destructables, the one closest to this location will be retrieved.</param>
    /// <exception cref="KeyNotFoundException">Thrown if there is no preplaced destructable with the given destructable type id.</exception>
    public static destructable GetDestructable(int destructableTypeId, Point location)
    {
      if (_shutdown) throw new Exception($"{nameof(PreplacedUnitSystem)} has already been shutdown.");
      if (!_initialized) throw new Exception($"{nameof(PreplacedUnitSystem)} has not been initialized.");
      if (!DestructablesByTypeId.ContainsKey(destructableTypeId))
        throw new KeyNotFoundException(
          $"There is no preplaced unit with Unit Type Id {GeneralHelpers.DebugIdInteger2IdString(destructableTypeId)}.");
      return GetClosestDestructableToPoint(DestructablesByTypeId[destructableTypeId], location);
    }

    /// <summary>
    ///   Gets a preplaced destructable.
    /// </summary>
    /// <param name="destructableTypeId">The destructable type id the destructable must have to be retrieved.</param>
    /// <exception cref="Exception">Thrown if there are multiple preplaced destructables with the given unit type id.</exception>
    /// <exception cref="KeyNotFoundException">Thrown if there is no preplaced destructable with the given unit type id.</exception>
    public static destructable GetDestructable(int destructableTypeId)
    {
      if (_shutdown) throw new Exception($"{nameof(PreplacedUnitSystem)} has already been shutdown.");
      if (!_initialized) throw new Exception($"{nameof(PreplacedUnitSystem)} has not been initialized.");
      if (!DestructablesByTypeId.ContainsKey(destructableTypeId))
        throw new KeyNotFoundException(
          $"There is no preplaced unit with Unit Type Id {GeneralHelpers.DebugIdInteger2IdString(destructableTypeId)}.");

      if (DestructablesByTypeId[destructableTypeId].Count > 1)
        throw new Exception(
          $"There are multiple preplaced units with Unit Type Id {GeneralHelpers.DebugIdInteger2IdString(destructableTypeId)}. Use the overload that requires a position instead.");

      return DestructablesByTypeId[destructableTypeId].First();
    }

    /// <summary>
    ///   Shuts down the PreplacedUnitSystem, freeing up memory and preventing further use.
    /// </summary>
    /// <exception cref="Exception">Thrown if the system has already been shutdown.</exception>
    public static void Shutdown()
    {
      if (_shutdown) throw new Exception($"{nameof(PreplacedUnitSystem)} has already been shutdown.");
      _shutdown = true;
      UnitsByTypeId.Clear();
    }

    /// <summary>
    ///   Initializes the PreplacedUnitSystem.
    /// </summary>
    /// <exception cref="Exception">Thrown if the system has already been initialized.</exception>
    public static void Initialize()
    {
      if (_initialized) throw new Exception($"{nameof(PreplacedUnitSystem)} has already been initialized.");
      _initialized = true;
      ReadAllUnits();
    }

    private static void ReadDestructable()
    {
      var destructable = GetEnumDestructable();
      var destructableId = GetDestructableTypeId(destructable);
      if (!DestructablesByTypeId.ContainsKey(destructableId))
        DestructablesByTypeId[destructableId] = new List<destructable>();
      DestructablesByTypeId[destructableId].Add(destructable);
    }

    private static void ReadAllUnits()
    {
      foreach (var unit in new GroupWrapper().EnumUnitsInRect(Rectangle.WorldBounds.Rect).EmptyToList())
      {
        var unitTypeId = GetUnitTypeId(unit);
        if (!UnitsByTypeId.ContainsKey(unitTypeId)) UnitsByTypeId[unitTypeId] = new List<unit>();
        UnitsByTypeId[unitTypeId].Add(unit);
      }

      EnumDestructablesInRect(Rectangle.WorldBounds.Rect, null, ReadDestructable);
    }

    private static destructable GetClosestDestructableToPoint(List<destructable> destructables, Point location)
    {
      var closestDistance = float.MaxValue;
      var closestDestructable = destructables.First();
      foreach (var destructable in destructables)
      {
        var distance = MathEx.GetDistanceBetweenPoints(location,
          new Point(GetDestructableX(destructable), GetDestructableY(destructable)));
        if (distance < closestDistance)
        {
          closestDistance = distance;
          closestDestructable = destructable;
        }
      }

      return closestDestructable;
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