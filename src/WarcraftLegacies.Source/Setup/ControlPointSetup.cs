using System.Collections.Generic;
using MacroTools.ControlPointSystem;
using MacroTools.Extensions;


namespace WarcraftLegacies.Source.Setup
{
  public static class ControlPointSetup
  {
    private static readonly Dictionary<int, int> ControlPointValues = new()
    {
      {BUFF_B025_COMMAND_POINT_10_GOLD_PER_MINUTE, 10},
      {BUFF_B050_COMMAND_POINT_15_GOLD_PER_MINUTE, 15},
      {BUFF_B051_COMMAND_POINT_20_GOLD_PER_MINUTE, 20},
      {BUFF_B052_COMMAND_POINT_25_GOLD_PER_MINUTE, 25},
      {BUFF_B053_COMMAND_POINT_30_GOLD_PER_MINUTE, 30},
      {BUFF_B054_COMMAND_POINT_50_GOLD_PER_MINUTE, 50},
    };

    private static void InitializeControlPoint(unit unit)
    {
      foreach (var (unitTypeId, goldValue) in ControlPointValues)
        if (GetUnitAbilityLevel(unit, unitTypeId) > 0)
          ControlPointManager.Instance.Register(new ControlPoint(unit, goldValue));
    }

    public static void Setup()
    {
      foreach (var unit in CreateGroup().EnumUnitsInRect(WCSharp.Shared.Data.Rectangle.WorldBounds).EmptyToList())
        InitializeControlPoint(unit);
    }
  }
}