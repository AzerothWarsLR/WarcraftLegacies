using System;
using System.Collections.Generic;
using WCSharp.Shared.Data;

namespace MacroTools.Utils;

/// <summary>
/// Provides a useful set of methods for interacting with the Warcraft 3 engine.
/// </summary>
public static class GeneralHelpers
{
  private static readonly rect _tempRect = rect.Create(0, 0, 0, 0);

  private static Point? _enumDestructableCenter;
  private static float _enumDestructableRadius;

  private static bool EnumDestructablesInCircleFilter()
  {
    return MathEx.GetDistanceBetweenPoints(
      new Point(GetFilterDestructable().X, GetFilterDestructable().Y),
      _enumDestructableCenter!) <= _enumDestructableRadius;
  }

  /// <summary>
  /// Creates and returns a rectangle with the given radius at its widest point.
  /// </summary>
  public static Rectangle GetRectFromCircle(Point center, float radius) =>
    new(center.X - radius, center.Y - radius, center.X + radius, center.Y + radius);

  /// <summary>
  /// Performs an action on all destructables in a circle.
  /// </summary>
  public static void EnumDestructablesInCircle(float radius, Point center, Action actionFunc)
  {
    if (radius < 0)
    {
      return;
    }

    _enumDestructableCenter = center;
    _enumDestructableRadius = radius;
    var circleAsRectangle = GetRectFromCircle(center, radius);
    circleAsRectangle.Rect.EnumerateDestructables(Condition(EnumDestructablesInCircleFilter), actionFunc);
  }

  /// <summary>
  /// Creates blight in a circular radius.
  /// </summary>
  public static void SetBlightRadius(player whichPlayer, Point position, float radius, bool addBlight)
  {
    var location = Location(position.X, position.Y);
    SetBlightLoc(whichPlayer, location, radius, addBlight);
    location.Dispose();
  }

  /// <summary>
  /// Kills all neutral hostile units in an circular radius.
  /// </summary>
  public static void KillNeutralHostileUnitsInRadius(float x, float y, float radius)
  {
    var neutralAggressive = player.NeutralAggressive;

    foreach (var unit in GlobalGroup.EnumUnitsInRange(x, y, radius))
    {
      if (unit.Owner == neutralAggressive && !unit.IsUnitType(unittype.Sapper) && !unit.IsUnitType(unittype.Structure))
      {
        unit.Kill();
      }
    }
  }

  /// <summary>
  /// Creates a structure at a location, killing any existing structures there to make room.
  /// </summary>
  public static unit CreateStructureForced(player whichPlayer, int unitId, float x, float y, float face, float size)
  {
    SetRect(_tempRect, x - size / 2, y - size / 2, x + size / 2, y + size / 2);
    foreach (var unit in GlobalGroup.EnumUnitsInRect(_tempRect))
    {
      if (unit.IsUnitType(unittype.Structure))
      {
        unit.Owner.Gold += unit.GoldCostOf(unit.UnitType);
        unit.Owner.Lumber += unit.WoodCostOf(unit.UnitType);
        unit.Kill();
      }
    }

    return unit.Create(whichPlayer, unitId, x, y, face);
  }

  /// <summary>
  /// Creates several units of the same type at the same location.
  /// </summary>
  /// <returns>The units that were created.</returns>
  public static IEnumerable<unit> CreateUnits(player whichPlayer, int unitId, float x, float y, float face, int count)
  {
    var createdUnits = new List<unit>();
    var i = 0;
    while (true)
    {
      if (i == count)
      {
        break;
      }

      createdUnits.Add(unit.Create(whichPlayer, unitId, x, y, face));
      i += 1;
    }

    return createdUnits;
  }

  public static region RectToRegion(rect whichRect)
  {
    var rectRegion = region.Create();
    rectRegion.AddRect(whichRect);
    return rectRegion;
  }
}
