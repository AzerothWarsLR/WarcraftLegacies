using System.Collections.Generic;
using MacroTools.ControlPointSystem;
using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Setup;

public static class ControlPointSetup
{
  private static readonly List<ControlPointInitData> _controlPointValues = new()
  {
    new(BUFF_B025_COMMAND_POINT_10_GOLD_PER_MINUTE, 10, true),
    new(BUFF_B050_COMMAND_POINT_15_GOLD_PER_MINUTE, 15, true),
    new(BUFF_B051_COMMAND_POINT_20_GOLD_PER_MINUTE, 20, true),
    new(BUFF_B052_COMMAND_POINT_25_GOLD_PER_MINUTE, 25, true),
    new(BUFF_B053_COMMAND_POINT_30_GOLD_PER_MINUTE, 30, true),
    new(BUFF_B054_COMMAND_POINT_50_GOLD_PER_MINUTE, 50, true),
    new(BUFF_B06A_COMMAND_POINT_25_GOLD_PER_MINUTE, 25, false)
  };

  public static void Setup()
  {
    foreach (var unit in GlobalGroup.EnumUnitsInRect(Rectangle.WorldBounds))
    {
      InitializeControlPoint(unit);
    }
  }

  private static void InitializeControlPoint(unit unit)
  {
    foreach (var initData in _controlPointValues)
    {
      if (unit.GetAbilityLevel(initData.BuffId) > 0)
      {
        ControlPointManager.Instance.Register(new ControlPoint(unit, initData.Income, initData.UseControlLevels));
      }
    }
  }

  private sealed class ControlPointInitData
  {
    public int BuffId { get; }
    public int Income { get; }
    public bool UseControlLevels { get; }

    public ControlPointInitData(int buffId, int income, bool useControlLevels)
    {
      BuffId = buffId;
      Income = income;
      UseControlLevels = useControlLevels;
    }
  }
}
