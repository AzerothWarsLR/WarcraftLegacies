using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.Source.Legends
{
  public static class LegendKultiras{

  
    public static Legend LEGEND_ADMIRAL { get; private set; }
    public static Legend LEGEND_LUCILLE { get; private set; }
    public static Legend LEGEND_KATHERINE { get; private set; }

    public static Legend LEGEND_BORALUS { get; private set; }
  

    public static void Setup( ){
      LEGEND_ADMIRAL = new Legend();
      LEGEND_ADMIRAL.UnitType = FourCC("Hapm");
      LEGEND_ADMIRAL.Essential = true;

      LEGEND_LUCILLE = new Legend();
      LEGEND_LUCILLE.UnitType = FourCC("E016");
      LEGEND_LUCILLE.StartingXp = 2800;

      LEGEND_KATHERINE = new Legend();
      LEGEND_KATHERINE.UnitType = FourCC("H05L");
      LEGEND_KATHERINE.StartingXp = 1200;

      LEGEND_BORALUS = new Legend();
      LEGEND_BORALUS.Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("h046"));
      LEGEND_BORALUS.DeathMessage = "Boralus Keep has fallen";

    }

  }
}
