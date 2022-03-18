using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.RoC.Legends
{
  public static class LegendGilneas{

  
    public static Legend LEGEND_TESS
    public static Legend LEGEND_GENN
    public static Legend LEGEND_DARIUS
    public static Legend LEGEND_GOLDRINN

    public static Legend LEGEND_LIGHTDAWN
    public static Legend LEGEND_GILNEASCASTLE

  

    public static void Setup( ){
      LEGEND_TESS = new Legend();
      LEGEND_TESS.Unit = gg_unit_Ewar_0424;

      LEGEND_GOLDRINN = new Legend();
      LEGEND_GOLDRINN.UnitType = FourCC(E01E);
      LEGEND_GOLDRINN.StartingXp = 8800;

      LEGEND_GENN = new Legend();
      LEGEND_GENN.Unit = gg_unit_Hhkl_1500;

      LEGEND_DARIUS = new Legend();
      LEGEND_DARIUS.Unit = gg_unit_Hpb2_3787;

      LEGEND_LIGHTDAWN = new Legend();
      LEGEND_LIGHTDAWN.Unit = gg_unit_h057_3921;
      LEGEND_LIGHTDAWN.DeathMessage = "The LightFourCC(s Dawn Capital has been destroyed.";
      LEGEND_LIGHTDAWN.IsCapital = true;

      LEGEND_GILNEASCASTLE = new Legend();
      LEGEND_GILNEASCASTLE.Unit = gg_unit_h04I_0101;
      LEGEND_GILNEASCASTLE.DeathMessage = "The Gilneas castle has fallen";
      LEGEND_GILNEASCASTLE.IsCapital = true;
    }

  }
}
