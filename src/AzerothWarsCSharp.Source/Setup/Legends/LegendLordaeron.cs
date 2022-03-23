using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.Source.Legends
{
  public static class LegendLordaeron{

  
    public static Legend LEGEND_UTHER
    public static Legend LEGEND_ARTHAS
    public static Legend LEGEND_MOGRAINE
    public static Legend LEGEND_GARITHOS
    public static Legend LEGEND_GOODCHILD

    public static Legend LEGEND_CAPITALPALACE
    public static Legend LEGEND_STRATHOLME
    public static Legend LEGEND_TYRSHAND
  

    public static void Setup( ){
      LEGEND_MOGRAINE = new Legend();
      LEGEND_MOGRAINE.UnitType = FourCC("H01J");
      LEGEND_MOGRAINE.StartingXp = 2800;

      LEGEND_GARITHOS = new Legend();
      LEGEND_GARITHOS.UnitType = FourCC("Hlgr");
      LEGEND_GARITHOS.StartingXp = 2800;

      LEGEND_GOODCHILD = new Legend();
      LEGEND_GOODCHILD.UnitType = FourCC("E00O");
      LEGEND_GOODCHILD.StartingXp = 2800;

      LEGEND_CAPITALPALACE = new Legend();
      LEGEND_CAPITALPALACE.Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("h000"));
      LEGEND_CAPITALPALACE.DeathMessage = "The capital city of Lordaeron has been razed, && King Terenas is dead.";
      LEGEND_CAPITALPALACE.IsCapital = true;

      LEGEND_STRATHOLME = new Legend();
      LEGEND_STRATHOLME.Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("h01G"));
      LEGEND_STRATHOLME.DeathMessage = "The majestic city of Stratholme has been destroyed.";
      LEGEND_STRATHOLME.IsCapital = true;

      LEGEND_TYRSHAND = new Legend();
      LEGEND_TYRSHAND.Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("h030"));
      LEGEND_TYRSHAND.DeathMessage = "TyrFourCC(s Hand, the bastion of human power in Lordaeron, has fallen.";
      LEGEND_TYRSHAND.IsCapital = true;

      LEGEND_UTHER = new Legend();
      LEGEND_UTHER.UnitType = FourCC("Huth");
      LEGEND_UTHER.AddUnitDependency(PreplacedUnitSystem.GetUnitByUnitType(FourCC("h000")));
      LEGEND_UTHER.AddUnitDependency(PreplacedUnitSystem.GetUnitByUnitType(FourCC("nico")));
      LEGEND_UTHER.DeathMessage = "Uther the Lightbringer makes his last stand, perishing in the defense of the light. Lordaeron, && humanity itself, has lost one of its finest exemplars in this dark hour.";
      LEGEND_UTHER.PlayerColor = PLAYER_COLOR_LIGHT_BLUE;
      LEGEND_UTHER.StartingXp = 1000;

      LEGEND_ARTHAS = new Legend();
      LEGEND_ARTHAS.UnitType = FourCC("Hart");
      LEGEND_ARTHAS.PlayerColor = PLAYER_COLOR_BLUE;
      LEGEND_ARTHAS.AddUnitDependency(LEGEND_STRATHOLME.Unit);
      LEGEND_ARTHAS.AddUnitDependency(PreplacedUnitSystem.GetUnitByUnitType(FourCC("nico")));
      LEGEND_ARTHAS.Essential = true;

    }

  }
}
