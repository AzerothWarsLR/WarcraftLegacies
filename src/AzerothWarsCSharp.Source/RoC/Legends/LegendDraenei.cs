using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.RoC.Legends
{
  public static class LegendDraenei{

  
    public static Legend LEGEND_VELEN
    public static Legend LEGEND_MARAAD
    public static Legend LEGEND_NOBUNDO

    public static Legend LEGEND_EXODAR
    public static Legend LEGEND_EXODARSHIP
  

    public static void Setup( ){

      LEGEND_NOBUNDO = new Legend();
      LEGEND_NOBUNDO.UnitType = FourCC(E01J);
      LEGEND_NOBUNDO.StartingXp = 1800;

      LEGEND_EXODAR = new Legend();
      LEGEND_EXODAR.Unit = gg_unit_o05E_1583;
      LEGEND_EXODAR.IsCapital = true;

      LEGEND_EXODARSHIP = new Legend();
      LEGEND_EXODARSHIP.Unit = gg_unit_h09W_3303;

      LEGEND_MARAAD = new Legend();
      LEGEND_MARAAD.UnitType = FourCC(H09S);

      LEGEND_VELEN = new Legend();
      LEGEND_VELEN.UnitType = FourCC(E01I);
      LEGEND_VELEN.AddUnitDependency(LEGEND_EXODAR.Unit);
      LEGEND_VELEN.AddUnitDependency(LEGEND_EXODARSHIP.Unit);
    }

  }
}
