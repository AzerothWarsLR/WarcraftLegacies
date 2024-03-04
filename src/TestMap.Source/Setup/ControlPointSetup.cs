using System.Collections.Generic;
using MacroTools.ControlPointSystem;
using MacroTools.Extensions;



namespace TestMap.Source.Setup
{
  public static class ControlPointSetup
  {
    private static readonly Dictionary<int, int> ControlPointValues = new()
    {
      {FourCC("A001"), 5},
      {FourCC("A000"), 10},
      {FourCC("A002"), 15}
    };

    private static void InitializeControlPoint(unit unit)
    {
      foreach (var (unitTypeId, goldValue) in ControlPointValues)
        if (GetUnitAbilityLevel(unit, unitTypeId) > 0)
          ControlPointManager.Instance.Register(new ControlPoint(unit, goldValue));
    }

    public static void Setup()
    {
      var playableMapArea = WCSharp.Shared.Data.Rectangle.WorldBounds;
      foreach (var unit in CreateGroup().EnumUnitsInRect(playableMapArea).EmptyToList())
        InitializeControlPoint(unit);
    }
  }
}