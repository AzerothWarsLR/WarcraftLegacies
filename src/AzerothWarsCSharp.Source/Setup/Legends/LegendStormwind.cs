using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.Source.Legends
{
  public static class LegendStormwind{

  
    public static Legend LEGEND_VARIAN { get; private set; }
    public static Legend LEGEND_KHADGAR { get; private set; }
    public static Legend LEGEND_GALEN { get; private set; }
    public static Legend LEGEND_BOLVAR { get; private set; }
    public static Legend LEGEND_STORMWINDKEEP { get; private set; }
    public static Legend LEGEND_DARKSHIRE { get; private set; }
  

    public static void Setup( ){
      LEGEND_VARIAN = new Legend();
      LEGEND_VARIAN.UnitType = FourCC("H00R");
      LEGEND_VARIAN.AddUnitDependency(PreplacedUnitSystem.GetUnitByUnitType(FourCC("h00X")));
      LEGEND_VARIAN.DeathMessage = "The King of Stormwind dies a warrior’s death, defending hearth && family. The Wrynn Dynasty crumbles with his passing.";
      LEGEND_VARIAN.Essential = true;
      LEGEND_VARIAN.StartingXp = 1800;

      LEGEND_GALEN = new Legend();
      LEGEND_GALEN.UnitType = FourCC("H00Z");
      LEGEND_GALEN.StartingXp = 1000;

      LEGEND_BOLVAR = new Legend();
      LEGEND_BOLVAR.UnitType = FourCC("H017");

      LEGEND_KHADGAR = new Legend();
      LEGEND_KHADGAR.UnitType = FourCC("H05Y");
      LEGEND_KHADGAR.StartingXp = 7000;

      LEGEND_STORMWINDKEEP = new Legend();
      LEGEND_STORMWINDKEEP.Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("h00X"));
      LEGEND_STORMWINDKEEP.DeathMessage = "Stormwind Keep, the capitol of the nation of Stormwind, has been destroyed!";
      LEGEND_STORMWINDKEEP.IsCapital = true;

      LEGEND_DARKSHIRE = new Legend();
      LEGEND_DARKSHIRE.Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("h03Y"));
    }

  }
}
