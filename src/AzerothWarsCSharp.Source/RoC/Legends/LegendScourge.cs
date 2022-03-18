using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.RoC.Legends
{
  public static class LegendScourge{

  
    public static Legend LEGEND_KELTHUZAD
    public static Legend LEGEND_ANUBARAK
    public static Legend LEGEND_RIVENDARE
    public static Legend LEGEND_LICHKING
    public static Legend LEGEND_UTGARDE

    const int UNITTYPE_KELTHUZAD_NECROMANCER = FourCC(U001);
    const int UNITTYPE_KELTHUZAD_GHOST = FourCC(U00M);
    const int UNITTYPE_KELTHUZAD_LICH = FourCC(Uktl);
  

    public static void Setup( ){
      LEGEND_KELTHUZAD = new Legend();
      LEGEND_KELTHUZAD.UnitType = FourCC(U001);
      LEGEND_KELTHUZAD.PermaDies = true;
      LEGEND_KELTHUZAD.DeathMessage = "KelFourCC(thuzad has been slain. He lives on in spectral form, && may yet return if (he is brought to the Sunwell.";
      LEGEND_KELTHUZAD.DeathSfx = "Abilities\\Spells\\Undead\\DeathCoil\\DeathCoilSpecialArt.mdl";
      LEGEND_KELTHUZAD.Essential = true;
      LEGEND_KELTHUZAD.StartingXp = 1000;
      LEGEND_KELTHUZAD.Name = "KelFourCC(thuzad";

      LEGEND_ANUBARAK = new Legend();
      LEGEND_ANUBARAK.UnitType = FourCC(Uanb);

      LEGEND_RIVENDARE = new Legend();
      LEGEND_RIVENDARE.UnitType = FourCC(U00A);
      LEGEND_RIVENDARE.StartingXp = 1000;

      LEGEND_UTGARDE = new Legend();
      LEGEND_UTGARDE.Unit = gg_unit_h00O_2516;
      LEGEND_UTGARDE.Capturable = true;

      LEGEND_LICHKING = new Legend();
      LEGEND_LICHKING.Unit = gg_unit_u000_0649;
      LEGEND_LICHKING.Hivemind = true;
      LEGEND_LICHKING.DeathMessage = "The great Lich King has been destroyed. With no central mind to command them, the forces of the Undead have gone rogue.";
    }

  }
}
