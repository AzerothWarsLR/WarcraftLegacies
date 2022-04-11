using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.Factions;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Legends
{
  public static class LegendDalaran{
    public static Legend LegendAntonidas { get; private set; }
    public static Legend LegendMedivh { get; private set; }
    public static Legend LegendJaina { get; private set; }
    public static Legend LegendKalecgos { get; private set; }
    public static Legend LegendMalygos { get; private set; }
    public static Legend LegendDalaranCapital { get; private set; }
    
    public static void Setup( ){
      LegendJaina = new Legend
      {
        UnitType = FourCC("Hjai"),
        Essential = true
      };

      LegendMedivh = new Legend
      {
        UnitType = FourCC("Haah"),
        StartingXp = 2800
      };

      LegendKalecgos = new Legend
      {
        UnitType = FourCC("U027"),
        StartingXp = 9800
      };

      LegendMalygos = new Legend
      {
        UnitType = FourCC("U026"),
        StartingXp = 10900
      };

      LegendDalaranCapital = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("h002")),
        DeathMessage = "The Violet Citadel, the ultimate bastion of arcane knowledge in the Eastern Kingdoms, crumbles like a sand castle.",
        IsCapital = true
      };

      LegendAntonidas = new Legend
      {
        UnitType = FourCC("Hant"),
        StartingXp = 1000
      };
      LegendAntonidas.AddUnitDependency(LegendDalaranCapital.Unit);
      LegendAntonidas.DeathMessage = "Archmage Antonidas has been cut down, his vast knowledge forever lost with his death. The mages of Dalaran have lost their brightest mind.";
    }

  }
}
