using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.RoC.Legends
{
  public class LegendStormwind{

  
    Legend LEGEND_VARIAN
    Legend LEGEND_KHADGAR
    Legend LEGEND_GALEN
    Legend LEGEND_BOLVAR

    Legend LEGEND_STORMWINDKEEP
    Legend LEGEND_DARKSHIRE
  

    private static void OnInit( ){
      LEGEND_VARIAN = Legend.create();
      LEGEND_VARIAN.UnitType = FourCC(H00R);
      LEGEND_VARIAN.AddUnitDependency(gg_unit_h00X_0007);
      LEGEND_VARIAN.DeathMessage = "The King of Stormwind dies a warrior’s death, defending hearth && family. The Wrynn Dynasty crumbles with his passing.";
      LEGEND_VARIAN.Essential = true;
      LEGEND_VARIAN.StartingXP = 1800;

      LEGEND_GALEN = Legend.create();
      LEGEND_GALEN.UnitType = FourCC(H00Z);
      LEGEND_GALEN.StartingXP = 1000;

      LEGEND_BOLVAR = Legend.create();
      LEGEND_BOLVAR.UnitType = FourCC(H017);

      LEGEND_KHADGAR = Legend.create();
      LEGEND_KHADGAR.UnitType = FourCC(H05Y);
      LEGEND_KHADGAR.StartingXP = 7000;

      LEGEND_STORMWINDKEEP = Legend.create();
      LEGEND_STORMWINDKEEP.Unit = gg_unit_h00X_0007;
      LEGEND_STORMWINDKEEP.DeathMessage = "Stormwind Keep, the capitol of the nation of Stormwind, has been destroyed!";
      LEGEND_STORMWINDKEEP.IsCapital = true;

      LEGEND_DARKSHIRE = Legend.create();
      LEGEND_DARKSHIRE.Unit = gg_unit_h03Y_0077;
    }

  }
}
