using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.Factions;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Legends
{
  public static class LegendDraenei{

  
    public static Legend LegendVelen { get; private set; }
    public static Legend LegendMaraad { get; private set; }
    public static Legend LegendNobundo { get; private set; }
    public static Legend LegendExodar { get; private set; }
    public static Legend LegendExodarship { get; private set; }
  

    public static void Setup( ){

      LegendNobundo = new Legend();
      LegendNobundo.UnitType = FourCC("E01J");
      LegendNobundo.StartingXp = 1800;

      LegendExodar = new Legend();
      LegendExodar.Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("o05E"));
      LegendExodar.IsCapital = true;

      LegendExodarship = new Legend();
      LegendExodarship.Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("h09W"));

      LegendMaraad = new Legend();
      LegendMaraad.UnitType = FourCC("H09S");

      LegendVelen = new Legend();
      LegendVelen.UnitType = FourCC("E01I");
      LegendVelen.AddUnitDependency(LegendExodar.Unit);
      LegendVelen.AddUnitDependency(LegendExodarship.Unit);
    }

  }
}
