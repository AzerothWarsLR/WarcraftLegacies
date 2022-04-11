using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.Factions;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Legends
{
  public static class LegendTwilight{

  
    public static Legend LEGEND_DEATHWING { get; private set; }
    public static Legend LEGEND_FELUDIUS { get; private set; }
    public static Legend LEGEND_IGNACIOUS { get; private set; }
    public static Legend LEGEND_AZIL { get; private set; }
    public static Legend LegendTwilightcitadel { get; private set; }
  

    public static void Setup( ){
      LegendTwilight.LegendTwilightcitadel = new Legend();
      LegendTwilight.LegendTwilightcitadel.Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("h05U"));
      LegendTwilight.LegendTwilightcitadel.DeathMessage = "The Twilight Citadel has been toppled. Already the land has begun to heal, but it may be decades before the permeating Old God stink fully dissipates from the Twilight Highlands.";
      LegendTwilight.LegendTwilightcitadel.IsCapital = true;

      LEGEND_DEATHWING = new Legend();
      LEGEND_DEATHWING.Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("u01Y"));
      LEGEND_DEATHWING.PermaDies = true;
      LEGEND_DEATHWING.DeathMessage = "Deathwing, the Black Scourge, is no more. The Destroyer has finally been defeated.";

      LEGEND_AZIL = new Legend();
      LEGEND_AZIL.UnitType = FourCC("H08Q");
      LEGEND_AZIL.StartingXp = 1800;
      LEGEND_AZIL.AddUnitDependency(LegendTwilight.LegendTwilightcitadel.Unit);

      LEGEND_FELUDIUS = new Legend();
      LEGEND_FELUDIUS.UnitType = FourCC("U01S");
      LEGEND_FELUDIUS.StartingXp = 2800;

      LEGEND_IGNACIOUS = new Legend();
      LEGEND_IGNACIOUS.UnitType = FourCC("O04H");
      LEGEND_IGNACIOUS.StartingXp = 2800;

    }

  }
}
