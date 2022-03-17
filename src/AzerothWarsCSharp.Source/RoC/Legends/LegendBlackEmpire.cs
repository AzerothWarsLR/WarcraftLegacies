using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.RoC.Legends
{
  public class LegendBlackEmpire{

  
    Legend LEGEND_YOGG
    Legend LEGEND_VOLAZJ
    Legend LEGEND_ZAKAJZ
  

    private static void OnInit( ){

      LEGEND_YOGG = Legend.create();
      LEGEND_YOGG.Unit = gg_unit_U02C_2829;
      LEGEND_YOGG.PermaDies = true;
      LEGEND_YOGG.DeathMessage = "Yogg-Saron, the Fiend of a Thousand Faces, has been vanquished. The countless souls consigned to his maw have finally been avenged.";

      LEGEND_VOLAZJ = Legend.create();
      LEGEND_VOLAZJ.UnitType = FourCC(E01D);

      LEGEND_ZAKAJZ = Legend.create();
      LEGEND_ZAKAJZ.UnitType = FourCC(U00P);
      LEGEND_ZAKAJZ.StartingXP = 8800;

    }

  }
}
