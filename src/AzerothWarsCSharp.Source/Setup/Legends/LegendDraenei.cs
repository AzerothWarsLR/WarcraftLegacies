using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.Source.Legends
{
  public static class LegendDraenei{

  
    public static Legend LEGEND_VELEN
    public static Legend LEGEND_MARAAD
    public static Legend LEGEND_NOBUNDO

    public static Legend LEGEND_EXODAR
    public static Legend LEGEND_EXODARSHIP
  

    public static void Setup( ){

      LEGEND_NOBUNDO = new Legend();
      LEGEND_NOBUNDO.UnitType = FourCC("E01J");
      LEGEND_NOBUNDO.StartingXp = 1800;

      LEGEND_EXODAR = new Legend();
      LEGEND_EXODAR.Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("o05E"));
      LEGEND_EXODAR.IsCapital = true;

      LEGEND_EXODARSHIP = new Legend();
      LEGEND_EXODARSHIP.Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("h09W"));

      LEGEND_MARAAD = new Legend();
      LEGEND_MARAAD.UnitType = FourCC("H09S");

      LEGEND_VELEN = new Legend();
      LEGEND_VELEN.UnitType = FourCC("E01I");
      LEGEND_VELEN.AddUnitDependency(LEGEND_EXODAR.Unit);
      LEGEND_VELEN.AddUnitDependency(LEGEND_EXODARSHIP.Unit);
    }

  }
}
