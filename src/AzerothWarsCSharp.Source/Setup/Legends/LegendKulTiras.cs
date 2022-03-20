using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.Source.Legends
{
  public static class LegendKultiras{

  
    public static Legend LEGEND_ADMIRAL
    public static Legend LEGEND_LUCILLE
    public static Legend LEGEND_KATHERINE

    public static Legend LEGEND_BORALUS
  

    public static void Setup( ){
      LEGEND_ADMIRAL = new Legend();
      LEGEND_ADMIRAL.UnitType = FourCC(Hapm);
      LEGEND_ADMIRAL.Essential = true;

      LEGEND_LUCILLE = new Legend();
      LEGEND_LUCILLE.UnitType = FourCC(E016);
      LEGEND_LUCILLE.StartingXp = 2800;

      LEGEND_KATHERINE = new Legend();
      LEGEND_KATHERINE.UnitType = FourCC(H05L);
      LEGEND_KATHERINE.StartingXp = 1200;

      LEGEND_BORALUS = new Legend();
      LEGEND_BORALUS.Unit = gg_unit_h046_0409;
      LEGEND_BORALUS.DeathMessage = "Boralus Keep has fallen";

    }

  }
}
