using MacroTools;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.Legends
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
        Unit = PreplacedUnitSystem.GetUnit(FourCC("o05E"))
      };
      Legend.Register(LegendExodar);

      LegendExodarship = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnit(FourCC("h09W"))
      };
      Legend.Register(LegendExodarship);
      LegendExodarship.Unit.SetInvulnerable(true);

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