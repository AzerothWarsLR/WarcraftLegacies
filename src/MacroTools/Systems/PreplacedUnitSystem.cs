using System;
using System.Collections.Generic;
using System.Linq;
using MacroTools.Libraries;
using MacroTools.Utils;
using WCSharp.Shared.Data;


namespace MacroTools.Systems;

/// <summary>
///   Once initialized, the system contains a reference to all preplaced units on the map.
///   Shutdown should be called once game has finished initializing.
/// </summary>
public sealed class PreplacedUnitSystem
{
  private readonly Dictionary<int, List<unit>> _unitsByTypeId = new();
  private readonly Dictionary<int, List<destructable>> _destructablesByTypeId = new();
  private const float MaximumDistanceToFind = 1000;

  /// <summary>
  /// Initializes a new instance of the <see cref="PreplacedUnitSystem"/> class.
  /// </summary>
  public PreplacedUnitSystem()
  {
    ReadAllUnits();
  }

  /// <summary>
  ///   Gets a preplaced unit.
  /// </summary>
  /// <param name="unitTypeId">The unit type id the unit must have to be retrieved.</param>
  /// <param name="location">If there are multiple matching units, the one closest to this location will be retrieved.</param>
  /// <exception cref="KeyNotFoundException">Thrown if there is no preplaced unit with the given unit type id.</exception>
  public unit GetUnit(int unitTypeId, Point location)
  {
    if (!_unitsByTypeId.TryGetValue(unitTypeId, out var unit))
    {
      throw new KeyNotFoundException(
        $"There is no preplaced unit with Unit Type Id {GeneralHelpers.DebugIdInteger2IdString(unitTypeId)}.");
    }

    return GetClosestUnitToPoint(unit, location);
  }


  /// <summary>
  ///   Gets a preplaced unit.
  /// </summary>
  /// <param name="unitTypeId">The unit type id the unit must have to be retrieved.</param>
  /// <exception cref="Exception">Thrown if there are multiple preplaced units with the given unit type id.</exception>
  /// <exception cref="KeyNotFoundException">Thrown if there is no preplaced unit with the given unit type id.</exception>
  public unit GetUnit(int unitTypeId)
  {
    if (!_unitsByTypeId.TryGetValue(unitTypeId, out var unit))
    {
      throw new KeyNotFoundException(
        $"There is no preplaced unit with Unit Type Id {GeneralHelpers.DebugIdInteger2IdString(unitTypeId)}.");
    }

    if (unit.Count > 1)
    {
      throw new Exception(
        $"There are multiple preplaced units with Unit Type Id {GeneralHelpers.DebugIdInteger2IdString(unitTypeId)}. Use the overload that requires a position instead.");
    }

    return unit.First();
  }

  /// <summary>
  ///   Gets a list of preplaced units.
  /// </summary>
  /// <param name="unitTypeId">The unit type id the units must have to be retrieved.</param>
  /// <exception cref="KeyNotFoundException">Thrown if there is no preplaced units with the given unit type id.</exception>
  public List<unit> GetUnits(int unitTypeId)
  {
    if (!_unitsByTypeId.TryGetValue(unitTypeId, out var unit))
    {
      throw new KeyNotFoundException(
        $"There is no preplaced unit with Unit Type Id {GeneralHelpers.DebugIdInteger2IdString(unitTypeId)}.");
    }

    return unit;
  }

  /// <summary>
  ///   Gets a preplaced destructable.
  /// </summary>
  /// <param name="destructableTypeId">The destructable type id the destructable must have to be retrieved.</param>
  /// <param name="location">If there are multiple matching destructables, the one closest to this location will be retrieved.</param>
  /// <exception cref="KeyNotFoundException">Thrown if there is no preplaced destructable with the given destructable type id.</exception>
  public destructable GetDestructable(int destructableTypeId, Point location)
  {
    if (!_destructablesByTypeId.TryGetValue(destructableTypeId, out var destructable))
    {
      throw new KeyNotFoundException(
        $"There is no preplaced unit with Unit Type Id {GeneralHelpers.DebugIdInteger2IdString(destructableTypeId)}.");
    }

    return GetClosestDestructableToPoint(destructable, location);
  }

  /// <summary>
  ///   Gets a preplaced destructable.
  /// </summary>
  /// <param name="destructableTypeId">The destructable type id the destructable must have to be retrieved.</param>
  /// <exception cref="Exception">Thrown if there are multiple preplaced destructables with the given unit type id.</exception>
  /// <exception cref="KeyNotFoundException">Thrown if there is no preplaced destructable with the given unit type id.</exception>
  public destructable GetDestructable(int destructableTypeId)
  {
    if (!_destructablesByTypeId.TryGetValue(destructableTypeId, out var destructable))
    {
      throw new KeyNotFoundException(
        $"There is no preplaced unit with Unit Type Id {GeneralHelpers.DebugIdInteger2IdString(destructableTypeId)}.");
    }

    if (destructable.Count > 1)
    {
      throw new Exception(
        $"There are multiple preplaced units with Unit Type Id {GeneralHelpers.DebugIdInteger2IdString(destructableTypeId)}. Use the overload that requires a position instead.");
    }

    return destructable.First();
  }

  private void ReadDestructable()
  {
    var destructable = GetEnumDestructable();
    var destructableId = destructable.Type;
    if (!_destructablesByTypeId.TryGetValue(destructableId, out var destructables))
    {
      destructables = _destructablesByTypeId[destructableId] = new List<destructable>();
    }

    destructables.Add(destructable);
    DestructibleHider.Register(destructable);
  }

  private void ReadAllUnits()
  {
    foreach (var unit in GlobalGroup.EnumUnitsInRect(Rectangle.WorldBounds.Rect))
    {
      var unitTypeId = unit.UnitType;
      if (!_unitsByTypeId.TryGetValue(unitTypeId, out var units))
      {
        units = _unitsByTypeId[unitTypeId] = new List<unit>();
      }

      units.Add(unit);
    }

    Rectangle.WorldBounds.Rect.EnumerateDestructables(null, ReadDestructable);
  }

  private static destructable GetClosestDestructableToPoint(List<destructable> destructables, Point location)
  {
    var closestDistance = float.MaxValue;
    var closestDestructable = destructables.First();
    foreach (var destructable in destructables)
    {
      var distance = MathEx.GetDistanceBetweenPoints(location,
        new Point(destructable.X, destructable.Y));
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
      var distance = MathEx.GetDistanceBetweenPoints(location, new Point(unit.X, unit.Y));
      if (distance < closestDistance)
      {
        closestDistance = distance;
        closestUnit = unit;
      }
    }

    if (closestDistance > MaximumDistanceToFind)
    {
      var unit = units.FirstOrDefault();
      Logger.LogWarning($"Could not find a {(unit != null ? unit.Name : null)}({GeneralHelpers.DebugIdInteger2IdString(unit.UnitType)}) within {MaximumDistanceToFind} of Point {location.X}, {location.Y}.");
    }


    return closestUnit;
  }
}
