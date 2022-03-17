using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.RoC.Legends
{
  public class LegendDraenei{

  
    Legend LEGEND_VELEN
    Legend LEGEND_MARAAD
    Legend LEGEND_NOBUNDO

    Legend LEGEND_EXODAR
    Legend LEGEND_EXODARSHIP
  

    private static void OnInit( ){

      LEGEND_NOBUNDO = Legend.create();
      LEGEND_NOBUNDO.UnitType = FourCC(E01J);
      LEGEND_NOBUNDO.StartingXP = 1800;

      LEGEND_EXODAR = Legend.create();
      LEGEND_EXODAR.Unit = gg_unit_o05E_1583;
      LEGEND_EXODAR.IsCapital = true;

      LEGEND_EXODARSHIP = Legend.create();
      LEGEND_EXODARSHIP.Unit = gg_unit_h09W_3303;

      LEGEND_MARAAD = Legend.create();
      LEGEND_MARAAD.UnitType = FourCC(H09S);

      LEGEND_VELEN = Legend.create();
      LEGEND_VELEN.UnitType = FourCC(E01I);
      LEGEND_VELEN.AddUnitDependency(LEGEND_EXODAR.Unit);
      LEGEND_VELEN.AddUnitDependency(LEGEND_EXODARSHIP.Unit);
    }

  }
}
