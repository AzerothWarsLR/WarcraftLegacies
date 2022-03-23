using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.Source.Legends
{
  public static class LegendTwilight{

  
    public static Legend LEGEND_DEATHWING
    public static Legend LEGEND_FELUDIUS
    public static Legend LEGEND_IGNACIOUS
    public static Legend LEGEND_AZIL

    public static Legend LEGEND_TWILIGHTCITADEL
  

    public static void Setup( ){
      LEGEND_TWILIGHTCITADEL = new Legend();
      LEGEND_TWILIGHTCITADEL.Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("h05U"));
      LEGEND_TWILIGHTCITADEL.DeathMessage = "The Twilight Citadel has been toppled. Already the land has begun to heal, but it may be decades before the permeating Old God stink fully dissipates from the Twilight Highlands.";
      LEGEND_TWILIGHTCITADEL.IsCapital = true;

      LEGEND_DEATHWING = new Legend();
      LEGEND_DEATHWING.Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("u01Y"));
      LEGEND_DEATHWING.PermaDies = true;
      LEGEND_DEATHWING.DeathMessage = "Deathwing, the Black Scourge, is no more. The Destroyer has finally been defeated.";

      LEGEND_AZIL = new Legend();
      LEGEND_AZIL.UnitType = FourCC("H08Q");
      LEGEND_AZIL.StartingXp = 1800;
      LEGEND_AZIL.AddUnitDependency(LEGEND_TWILIGHTCITADEL.Unit);

      LEGEND_FELUDIUS = new Legend();
      LEGEND_FELUDIUS.UnitType = FourCC("U01S");
      LEGEND_FELUDIUS.StartingXp = 2800;

      LEGEND_IGNACIOUS = new Legend();
      LEGEND_IGNACIOUS.UnitType = FourCC("O04H");
      LEGEND_IGNACIOUS.StartingXp = 2800;

    }

  }
}
