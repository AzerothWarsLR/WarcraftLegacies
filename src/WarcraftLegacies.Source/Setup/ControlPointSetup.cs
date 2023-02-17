using System.Collections.Generic;
using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using static War3Api.Common;


namespace WarcraftLegacies.Source.Setup
{
  public static class ControlPointSetup
  {
    private static readonly Dictionary<int, int> ControlPointValues = new()
    {
      {FourCC("B025"), 10},
      {FourCC("B050"), 15},
      {FourCC("B051"), 20},
      {FourCC("B052"), 25},
      {FourCC("B053"), 30},
      {FourCC("B054"), 50}
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