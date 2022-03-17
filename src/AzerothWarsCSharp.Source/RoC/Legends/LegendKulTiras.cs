using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.RoC.Legends
{
  public class LegendKultiras{

  
    Legend LEGEND_ADMIRAL
    Legend LEGEND_LUCILLE
    Legend LEGEND_KATHERINE

    Legend LEGEND_BORALUS
  

    private static void OnInit( ){
      LEGEND_ADMIRAL = Legend.create();
      LEGEND_ADMIRAL.UnitType = FourCC(Hapm);
      LEGEND_ADMIRAL.Essential = true;

      LEGEND_LUCILLE = Legend.create();
      LEGEND_LUCILLE.UnitType = FourCC(E016);
      LEGEND_LUCILLE.StartingXP = 2800;

      LEGEND_KATHERINE = Legend.create();
      LEGEND_KATHERINE.UnitType = FourCC(H05L);
      LEGEND_KATHERINE.StartingXP = 1200;

      LEGEND_BORALUS = Legend.create();
      LEGEND_BORALUS.Unit = gg_unit_h046_0409;
      LEGEND_BORALUS.DeathMessage = "Boralus Keep has fallen";

    }

  }
}
