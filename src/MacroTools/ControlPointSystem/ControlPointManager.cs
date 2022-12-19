using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.Libraries;
using static War3Api.Common;

namespace MacroTools.ControlPointSystem
{
  /// <summary>
  /// Responsible for managing all <see cref="ControlPoint"/>s.
  /// </summary>
  public static class ControlPointManager
  {
    /// <summary>
    /// When <see cref="ControlPoint"/>s have a <see cref="ControlPoint.ControlLevel"/> greater than 0, they spawn a
    /// unit with this ID to defend them.
    /// </summary>
    public static int DefenderUnitTypeId { get; private set; }
    
    /// <summary>
    ///   How often players receive income.
    ///   Changing this will not affect the total amount of income they receive.
    /// </summary>
    private const float Period = 1;

    private static bool _initialized;

    private static readonly Dictionary<int, ControlPoint> ByUnitType = new();
    private static readonly Dictionary<unit, ControlPoint> ByUnit = new();

    /// <summary>
    /// Sets up the <see cref="ControlPointManager"/>.
    /// </summary>
    /// <param name="defenderUnitTypeId">The unit type ID that gets used to defend <see cref="ControlPoint"/>s.</param>
    public static void Setup(int defenderUnitTypeId)
    {
      DefenderUnitTypeId = defenderUnitTypeId;
    }
    
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
      if (ByUnitType.ContainsKey(controlPoint.UnitType))
        WarningLogger.Log(
          $"There are two Control Points with the same ID of {GeneralHelpers.DebugIdInteger2IdString(controlPoint.UnitType)}.");
      else
        ByUnitType.Add(controlPoint.UnitType, controlPoint);
      
      controlPoint.Unit.SetLifePercent(80);

      controlPoint.Owner.SetBaseIncome(controlPoint.Owner.GetBaseIncome() + controlPoint.Value);
      controlPoint.Owner.SetControlPointCount(controlPoint.Owner.GetControlPointCount() + 1);

      if (_initialized) 
        return;
      _initialized = true;
      var incomeTimer = CreateTimer();
      TimerStart(incomeTimer, Period, true, () =>
      {
        foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
          if (player.GetFaction() != null)
          {
            var goldPerSecond = player.GetTotalIncome() * Period / 60;
            player.AddGold(goldPerSecond);
            var lumberPerSecond = player.GetLumberIncome() * Period / 60;
            player.AddLumber(lumberPerSecond);
          }
      });
    }
  }
}