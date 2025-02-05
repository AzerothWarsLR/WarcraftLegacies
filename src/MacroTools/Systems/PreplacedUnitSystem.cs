using System;
using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.Libraries;
using MacroTools.Utils;
using WCSharp.Shared.Data;
using static War3Api.Common;


namespace MacroTools.Systems
{
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
      if (!_unitsByTypeId.ContainsKey(unitTypeId))
        throw new KeyNotFoundException(
          $"There is no preplaced unit with Unit Type Id {GeneralHelpers.DebugIdInteger2IdString(unitTypeId)}.");
      return GetClosestUnitToPoint(_unitsByTypeId[unitTypeId], location);
    }
    

    /// <summary>
    ///   Gets a preplaced unit.
    /// </summary>
    /// <param name="unitTypeId">The unit type id the unit must have to be retrieved.</param>
    /// <exception cref="Exception">Thrown if there are multiple preplaced units with the given unit type id.</exception>
    /// <exception cref="KeyNotFoundException">Thrown if there is no preplaced unit with the given unit type id.</exception>
    public unit GetUnit(int unitTypeId)
    {
      if (!_unitsByTypeId.ContainsKey(unitTypeId))
        throw new KeyNotFoundException(
          $"There is no preplaced unit with Unit Type Id {GeneralHelpers.DebugIdInteger2IdString(unitTypeId)}.");

      if (_unitsByTypeId[unitTypeId].Count > 1)
        throw new Exception(
          $"There are multiple preplaced units with Unit Type Id {GeneralHelpers.DebugIdInteger2IdString(unitTypeId)}. Use the overload that requires a position instead.");

      return _unitsByTypeId[unitTypeId].First();
    }
    
    /// <summary>
    ///   Gets a list of preplaced units.
    /// </summary>
    /// <param name="unitTypeId">The unit type id the units must have to be retrieved.</param>
    /// <exception cref="KeyNotFoundException">Thrown if there is no preplaced units with the given unit type id.</exception>
    public List<unit> GetUnits(int unitTypeId)
    {
      if (!_unitsByTypeId.ContainsKey(unitTypeId))
        throw new KeyNotFoundException(
          $"There is no preplaced unit with Unit Type Id {GeneralHelpers.DebugIdInteger2IdString(unitTypeId)}.");
      return _unitsByTypeId[unitTypeId];
    }

    /// <summary>
    ///   Gets a preplaced destructable.
    /// </summary>
    /// <param name="destructableTypeId">The destructable type id the destructable must have to be retrieved.</param>
    /// <param name="location">If there are multiple matching destructables, the one closest to this location will be retrieved.</param>
    /// <exception cref="KeyNotFoundException">Thrown if there is no preplaced destructable with the given destructable type id.</exception>
    public destructable GetDestructable(int destructableTypeId, Point location)
    {
      if (!_destructablesByTypeId.ContainsKey(destructableTypeId))
        throw new KeyNotFoundException(
          $"There is no preplaced unit with Unit Type Id {GeneralHelpers.DebugIdInteger2IdString(destructableTypeId)}.");
      return GetClosestDestructableToPoint(_destructablesByTypeId[destructableTypeId], location);
    }

    /// <summary>
    ///   Gets a preplaced destructable.
    /// </summary>
    /// <param name="destructableTypeId">The destructable type id the destructable must have to be retrieved.</param>
    /// <exception cref="Exception">Thrown if there are multiple preplaced destructables with the given unit type id.</exception>
    /// <exception cref="KeyNotFoundException">Thrown if there is no preplaced destructable with the given unit type id.</exception>
    public destructable GetDestructable(int destructableTypeId)
    {
      if (!_destructablesByTypeId.ContainsKey(destructableTypeId))
        throw new KeyNotFoundException(
          $"There is no preplaced unit with Unit Type Id {GeneralHelpers.DebugIdInteger2IdString(destructableTypeId)}.");

      if (_destructablesByTypeId[destructableTypeId].Count > 1)
        throw new Exception(
          $"There are multiple preplaced units with Unit Type Id {GeneralHelpers.DebugIdInteger2IdString(destructableTypeId)}. Use the overload that requires a position instead.");

      return _destructablesByTypeId[destructableTypeId].First();
    }

    private void ReadDestructable()
    {
      var destructable = GetEnumDestructable();
      var destructableId = GetDestructableTypeId(destructable);
      if (!_destructablesByTypeId.ContainsKey(destructableId))
        _destructablesByTypeId[destructableId] = new List<destructable>();
      _destructablesByTypeId[destructableId].Add(destructable);
      DestructibleHider.Register(destructable);
    }

    private void ReadAllUnits()
    {
      foreach (var unit in CreateGroup().EnumUnitsInRect(Rectangle.WorldBounds.Rect).EmptyToList())
      {
        var unitTypeId = GetUnitTypeId(unit);
        if (!_unitsByTypeId.ContainsKey(unitTypeId)) _unitsByTypeId[unitTypeId] = new List<unit>();
        _unitsByTypeId[unitTypeId].Add(unit);
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

      if (closestDistance > MaximumDistanceToFind)
      {
        var unit = units.FirstOrDefault();
        Logger.LogWarning($"Could not find a {unit?.GetName()}({GeneralHelpers.DebugIdInteger2IdString(unit.GetTypeId())}) within {MaximumDistanceToFind} of Point {location.X}, {location.Y}.");
      }
        

      return closestUnit;
    }
  }
}