using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.Factions;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Legends
{
  public static class LegendStormwind{

  
    public static Legend LegendVarian { get; private set; }
    public static Legend LegendKhadgar { get; private set; }
    public static Legend LegendGalen { get; private set; }
    public static Legend LegendBolvar { get; private set; }
    public static Legend LegendStormwindkeep { get; private set; }
    public static Legend LegendDarkshire { get; private set; }
  

    public static void Setup( ){
      LegendVarian = new Legend
      {
        UnitType = FourCC("H00R")
      };
      LegendVarian.AddUnitDependency(PreplacedUnitSystem.GetUnitByUnitType(FourCC("h00X")));
      LegendVarian.DeathMessage = "The King of Stormwind dies a warrior’s death, defending hearth && family. The Wrynn Dynasty crumbles with his passing.";
      LegendVarian.Essential = true;
      LegendVarian.StartingXp = 1800;

      LegendGalen = new Legend
      {
        UnitType = FourCC("H00Z"),
        StartingXp = 1000
      };

      LegendBolvar = new Legend
      {
        UnitType = FourCC("H017")
      };

      LegendKhadgar = new Legend
      {
        UnitType = FourCC("H05Y"),
        StartingXp = 7000
      };

      LegendStormwindkeep = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("h00X")),
        DeathMessage = "Stormwind Keep, the capitol of the nation of Stormwind, has been destroyed!",
        IsCapital = true
      };

      LegendDarkshire = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("h03Y"))
      };
    }

  }
}
