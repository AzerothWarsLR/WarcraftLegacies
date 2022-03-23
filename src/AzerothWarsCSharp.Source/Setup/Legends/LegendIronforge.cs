using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.Source.Legends
{
  public static class LegendIronforge{

  
    public static Legend LEGEND_DAGRAN
    public static Legend LEGEND_FALSTAD
    public static Legend LEGEND_MAGNI

    public static Legend LEGEND_GREATFORGE
    public static Legend LEGEND_THELSAMAR
  

    public static void Setup( ){
      LEGEND_DAGRAN = new Legend();
      LEGEND_DAGRAN.UnitType = FourCC("H03G");
      LEGEND_DAGRAN.StartingXp = 1000;

      LEGEND_FALSTAD = new Legend();
      LEGEND_FALSTAD.UnitType = FourCC("H028");
      LEGEND_FALSTAD.StartingXp = 1000;

      LEGEND_MAGNI = new Legend();
      LEGEND_MAGNI.UnitType = FourCC("H00S");
      LEGEND_MAGNI.AddUnitDependency(gg_unit_h001_0180);
      LEGEND_MAGNI.DeathMessage = "King Magni Bronzebeard has died.";
      LEGEND_MAGNI.Essential = true;
      LEGEND_MAGNI.StartingXp = 1000;

      LEGEND_GREATFORGE = new Legend();
      LEGEND_GREATFORGE.Unit = gg_unit_h001_0180;
      LEGEND_GREATFORGE.DeathMessage = "The Great Forge has been extinguished.";
      LEGEND_GREATFORGE.IsCapital = true;

      LEGEND_THELSAMAR = new Legend();
      LEGEND_THELSAMAR.Unit = gg_unit_h05H_1847;
    }

  }
}
