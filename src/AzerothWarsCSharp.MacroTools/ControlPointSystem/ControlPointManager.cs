using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.Libraries;
using static War3Api.Common;
using static War3Api.Blizzard;

namespace AzerothWarsCSharp.MacroTools.ControlPointSystem
{
  public static class ControlPointManager
  {
    private const int MAX_HITPOINTS = 10000; //All Control Points get given this many hitpoints

    private static readonly Dictionary<int, ControlPoint> ByUnitType = new();
    private static readonly Dictionary<unit, ControlPoint> ByUnit = new();

    /// <summary>
    ///   Whether or not the given unit is a <see cref="ControlPoint" />.
    /// </summary>
    public static bool UnitIsControlPoint(unit unit)
    {
      return ByUnit.ContainsKey(unit);
    }

    /// <summary>
    ///   Returns the <see cref="ControlPoint" /> with the given unit type ID.
    /// </summary>
    public static ControlPoint GetFromUnitType(int unitType)
    {
      if (ByUnitType.TryGetValue(unitType, out var controlPoint)) return controlPoint;

      throw new KeyNotFoundException(
        $"There is no {nameof(ControlPoint)} with unit type ID {GeneralHelpers.DebugIdInteger2IdString(unitType)}");
    }

    /// <summary>
    ///   Registers a <see cref="ControlPoint" /> to the Control Point system.
    /// </summary>
    public static void Register(ControlPoint controlPoint)
    {
      ByUnit.Add(controlPoint.Unit, controlPoint);
      ByUnitType.Add(controlPoint.UnitType, controlPoint);
      BlzSetUnitMaxHP(controlPoint.Unit, MAX_HITPOINTS);
      SetUnitLifePercentBJ(controlPoint.Unit, 80);

      controlPoint.Owner.SetControlPointValue(controlPoint.Owner.GetControlPointValue() + controlPoint.Value);
      controlPoint.Owner.SetControlPointCount(controlPoint.Owner.GetControlPointCount() + 1);
    }
  }
}