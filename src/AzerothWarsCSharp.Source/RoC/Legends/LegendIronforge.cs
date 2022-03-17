using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.RoC.Legends
{
  public class LegendIronforge{

  
    Legend LEGEND_DAGRAN
    Legend LEGEND_FALSTAD
    Legend LEGEND_MAGNI

    Legend LEGEND_GREATFORGE
    Legend LEGEND_THELSAMAR
  

    private static void OnInit( ){
      LEGEND_DAGRAN = Legend.create();
      LEGEND_DAGRAN.UnitType = FourCC(H03G);
      LEGEND_DAGRAN.StartingXP = 1000;

      LEGEND_FALSTAD = Legend.create();
      LEGEND_FALSTAD.UnitType = FourCC(H028);
      LEGEND_FALSTAD.StartingXP = 1000;

      LEGEND_MAGNI = Legend.create();
      LEGEND_MAGNI.UnitType = FourCC(H00S);
      LEGEND_MAGNI.AddUnitDependency(gg_unit_h001_0180);
      LEGEND_MAGNI.DeathMessage = "King Magni Bronzebeard has died.";
      LEGEND_MAGNI.Essential = true;
      LEGEND_MAGNI.StartingXP = 1000;

      LEGEND_GREATFORGE = Legend.create();
      LEGEND_GREATFORGE.Unit = gg_unit_h001_0180;
      LEGEND_GREATFORGE.DeathMessage = "The Great Forge has been extinguished.";
      LEGEND_GREATFORGE.IsCapital = true;

      LEGEND_THELSAMAR = Legend.create();
      LEGEND_THELSAMAR.Unit = gg_unit_h05H_1847;
    }

  }
}
