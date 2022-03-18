using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.RoC.Legends
{
  public static class LegendStormwind{

  
    public static Legend LEGEND_VARIAN
    public static Legend LEGEND_KHADGAR
    public static Legend LEGEND_GALEN
    public static Legend LEGEND_BOLVAR

    public static Legend LEGEND_STORMWINDKEEP
    public static Legend LEGEND_DARKSHIRE
  

    public static void Setup( ){
      LEGEND_VARIAN = new Legend();
      LEGEND_VARIAN.UnitType = FourCC(H00R);
      LEGEND_VARIAN.AddUnitDependency(gg_unit_h00X_0007);
      LEGEND_VARIAN.DeathMessage = "The King of Stormwind dies a warrior’s death, defending hearth && family. The Wrynn Dynasty crumbles with his passing.";
      LEGEND_VARIAN.Essential = true;
      LEGEND_VARIAN.StartingXp = 1800;

      LEGEND_GALEN = new Legend();
      LEGEND_GALEN.UnitType = FourCC(H00Z);
      LEGEND_GALEN.StartingXp = 1000;

      LEGEND_BOLVAR = new Legend();
      LEGEND_BOLVAR.UnitType = FourCC(H017);

      LEGEND_KHADGAR = new Legend();
      LEGEND_KHADGAR.UnitType = FourCC(H05Y);
      LEGEND_KHADGAR.StartingXp = 7000;

      LEGEND_STORMWINDKEEP = new Legend();
      LEGEND_STORMWINDKEEP.Unit = gg_unit_h00X_0007;
      LEGEND_STORMWINDKEEP.DeathMessage = "Stormwind Keep, the capitol of the nation of Stormwind, has been destroyed!";
      LEGEND_STORMWINDKEEP.IsCapital = true;

      LEGEND_DARKSHIRE = new Legend();
      LEGEND_DARKSHIRE.Unit = gg_unit_h03Y_0077;
    }

  }
}
