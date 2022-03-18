using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.RoC.Legends
{
  public static class LegendForsaken{

  
    public static Legend LEGEND_SYLVANASV
    public static Legend LEGEND_SCHOLOMANCE
    public static Legend LEGEND_VARIMATHRAS
    public static Legend LEGEND_NATHANOS
  

    public static void Setup( ){
      LEGEND_SYLVANASV = new Legend();
      LEGEND_SYLVANASV.UnitType = FourCC(Usyl);
      LEGEND_SYLVANASV.StartingXp = 15400;

      LEGEND_NATHANOS = new Legend();
      LEGEND_NATHANOS.UnitType = FourCC(H049);
      LEGEND_NATHANOS.StartingXp = 4000;

      LEGEND_VARIMATHRAS = new Legend();
      LEGEND_VARIMATHRAS.UnitType = FourCC(Uvar);
      LEGEND_VARIMATHRAS.PlayerColor = PLAYER_COLOR_RED;

      LEGEND_SCHOLOMANCE = new Legend();
      LEGEND_SCHOLOMANCE.Unit = gg_unit_u012_1149;
      LEGEND_SCHOLOMANCE.DeathMessage = "Scholomance, the center of the ScourgeFourCC(s operations in Lordaeron, has been destroyed.";
    }

  }
}
