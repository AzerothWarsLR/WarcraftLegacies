using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.RoC.Legends
{
  public class LegendGilneas{

  
    Legend LEGEND_TESS
    Legend LEGEND_GENN
    Legend LEGEND_DARIUS
    Legend LEGEND_GOLDRINN

    Legend LEGEND_LIGHTDAWN
    Legend LEGEND_GILNEASCASTLE

  

    private static void OnInit( ){
      LEGEND_TESS = Legend.create();
      LEGEND_TESS.Unit = gg_unit_Ewar_0424;

      LEGEND_GOLDRINN = Legend.create();
      LEGEND_GOLDRINN.UnitType = FourCC(E01E);
      LEGEND_GOLDRINN.StartingXP = 8800;

      LEGEND_GENN = Legend.create();
      LEGEND_GENN.Unit = gg_unit_Hhkl_1500;

      LEGEND_DARIUS = Legend.create();
      LEGEND_DARIUS.Unit = gg_unit_Hpb2_3787;

      LEGEND_LIGHTDAWN = Legend.create();
      LEGEND_LIGHTDAWN.Unit = gg_unit_h057_3921;
      LEGEND_LIGHTDAWN.DeathMessage = "The LightFourCC(s Dawn Capital has been destroyed.";
      LEGEND_LIGHTDAWN.IsCapital = true;

      LEGEND_GILNEASCASTLE = Legend.create();
      LEGEND_GILNEASCASTLE.Unit = gg_unit_h04I_0101;
      LEGEND_GILNEASCASTLE.DeathMessage = "The Gilneas castle has fallen";
      LEGEND_GILNEASCASTLE.IsCapital = true;
    }

  }
}
