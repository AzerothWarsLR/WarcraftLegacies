using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools.ControlPointSystem;
using AzerothWarsCSharp.MacroTools.Libraries;
using AzerothWarsCSharp.MacroTools.Wrappers;
using static War3Api.Common;


namespace AzerothWarsCSharp.TestSource.Setup
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
          ControlPointManager.Register(new ControlPoint(unit, goldValue));
    }

    public static void Setup()
    {
      var playableMapArea = GeneralHelpers.GetPlayableMapArea();
      foreach (var unit in new GroupWrapper().EnumUnitsInRect(playableMapArea).EmptyToList())
        InitializeControlPoint(unit);
    }
  }
}