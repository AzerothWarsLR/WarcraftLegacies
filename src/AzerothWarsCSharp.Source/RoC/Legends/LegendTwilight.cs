using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.RoC.Legends
{
  public class LegendTwilight{

  
    Legend LEGEND_DEATHWING
    Legend LEGEND_FELUDIUS
    Legend LEGEND_IGNACIOUS
    Legend LEGEND_AZIL

    Legend LEGEND_TWILIGHTCITADEL
  

    private static void OnInit( ){
      LEGEND_TWILIGHTCITADEL = Legend.create();
      LEGEND_TWILIGHTCITADEL.Unit = gg_unit_h05U_0015;
      LEGEND_TWILIGHTCITADEL.DeathMessage = "The Twilight Citadel has been toppled. Already the land has begun to heal, but it may be decades before the permeating Old God stink fully dissipates from the Twilight Highlands.";
      LEGEND_TWILIGHTCITADEL.IsCapital = true;

      LEGEND_DEATHWING = Legend.create();
      LEGEND_DEATHWING.Unit = gg_unit_u01Y_0071;
      LEGEND_DEATHWING.PermaDies = true;
      LEGEND_DEATHWING.DeathMessage = "Deathwing, the Black Scourge, is no more. The Destroyer has finally been defeated.";

      LEGEND_AZIL = Legend.create();
      LEGEND_AZIL.UnitType = FourCC(H08Q);
      LEGEND_AZIL.StartingXP = 1800;
      LEGEND_AZIL.AddUnitDependency(LEGEND_TWILIGHTCITADEL.Unit);

      LEGEND_FELUDIUS = Legend.create();
      LEGEND_FELUDIUS.UnitType = FourCC(U01S);
      LEGEND_FELUDIUS.StartingXP = 2800;

      LEGEND_IGNACIOUS = Legend.create();
      LEGEND_IGNACIOUS.UnitType = FourCC(O04H);
      LEGEND_IGNACIOUS.StartingXP = 2800;

    }

  }
}
