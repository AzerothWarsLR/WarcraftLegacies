using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.RoC.Legends
{
  public class LegendScourge{

  
    Legend LEGEND_KELTHUZAD
    Legend LEGEND_ANUBARAK
    Legend LEGEND_RIVENDARE
    Legend LEGEND_LICHKING
    Legend LEGEND_UTGARDE

    const int UNITTYPE_KELTHUZAD_NECROMANCER = FourCC(U001);
    const int UNITTYPE_KELTHUZAD_GHOST = FourCC(U00M);
    const int UNITTYPE_KELTHUZAD_LICH = FourCC(Uktl);
  

    private static void OnInit( ){
      LEGEND_KELTHUZAD = Legend.create();
      LEGEND_KELTHUZAD.UnitType = FourCC(U001);
      LEGEND_KELTHUZAD.PermaDies = true;
      LEGEND_KELTHUZAD.DeathMessage = "KelFourCC(thuzad has been slain. He lives on in spectral form, && may yet return if (he is brought to the Sunwell.";
      LEGEND_KELTHUZAD.DeathSfx = "Abilities\\Spells\\Undead\\DeathCoil\\DeathCoilSpecialArt.mdl";
      LEGEND_KELTHUZAD.Essential = true;
      LEGEND_KELTHUZAD.StartingXP = 1000;
      LEGEND_KELTHUZAD.Name = "KelFourCC(thuzad";

      LEGEND_ANUBARAK = Legend.create();
      LEGEND_ANUBARAK.UnitType = FourCC(Uanb);

      LEGEND_RIVENDARE = Legend.create();
      LEGEND_RIVENDARE.UnitType = FourCC(U00A);
      LEGEND_RIVENDARE.StartingXP = 1000;

      LEGEND_UTGARDE = Legend.create();
      LEGEND_UTGARDE.Unit = gg_unit_h00O_2516;
      LEGEND_UTGARDE.Capturable = true;

      LEGEND_LICHKING = Legend.create();
      LEGEND_LICHKING.Unit = gg_unit_u000_0649;
      LEGEND_LICHKING.Hivemind = true;
      LEGEND_LICHKING.DeathMessage = "The great Lich King has been destroyed. With no central mind to command them, the forces of the Undead have gone rogue.";
    }

  }
}
