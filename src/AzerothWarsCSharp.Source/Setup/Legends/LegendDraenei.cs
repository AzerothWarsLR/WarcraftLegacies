using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.Legends
{
  public static class LegendDraenei
  {
    public static Legend LegendVelen { get; private set; }
    public static Legend LegendMaraad { get; private set; }
    public static Legend LegendNobundo { get; private set; }
    public static Legend LegendExodar { get; private set; }
    public static Legend LegendExodarship { get; private set; }


    public static void Setup()
    {
      LegendNobundo = new Legend
      {
        UnitType = FourCC("E01J"),
        StartingXp = 1800
      };
      Legend.Register(LegendNobundo);

      LegendExodar = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("o05E")),
        IsCapital = true
      };
      Legend.Register(LegendExodar);

      LegendExodarship = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("h09W"))
      };
      Legend.Register(LegendExodarship);

      LegendMaraad = new Legend
      {
        UnitType = FourCC("H09S")
      };
      Legend.Register(LegendMaraad);

      LegendVelen = new Legend
      {
        UnitType = FourCC("E01I")
      };
      LegendVelen.AddUnitDependency(LegendExodar.Unit);
      LegendVelen.AddUnitDependency(LegendExodarship.Unit);
      Legend.Register(LegendVelen);
    }
  }
}