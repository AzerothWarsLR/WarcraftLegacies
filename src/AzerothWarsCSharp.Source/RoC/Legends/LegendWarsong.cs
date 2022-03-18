using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.RoC.Legends
{
  public static class LegendWarsong{

  
    public static Legend LEGEND_GROM
    public static Legend LEGEND_JERGOSH
    public static Legend LEGEND_MANNOROTH
    public static Legend LEGEND_STONEMAUL
    public static Legend LEGEND_ENCAMPMENT
    public static Legend LEGEND_CHEN
    public static Legend LEGEND_SAURFANG
  

    public static void Setup( ){

      LEGEND_CHEN = new Legend();
      LEGEND_CHEN.UnitType = FourCC(Nsjs);
      LEGEND_CHEN.StartingXp = 1000;

      LEGEND_SAURFANG = new Legend();
      LEGEND_SAURFANG.UnitType = FourCC(Obla);
      LEGEND_SAURFANG.StartingXp = 2800;

      LEGEND_JERGOSH = new Legend();
      LEGEND_JERGOSH.UnitType = FourCC(Oths);

      LEGEND_MANNOROTH = new Legend();
      LEGEND_MANNOROTH.UnitType = FourCC(Nman);

      LEGEND_STONEMAUL = new Legend();
      LEGEND_STONEMAUL.Unit = gg_unit_o004_0169;
      LEGEND_STONEMAUL.DeathMessage = "The fortress of the Stonemaul Clan has fallen.";
      LEGEND_STONEMAUL.IsCapital = true;

      LEGEND_ENCAMPMENT = new Legend();

      LEGEND_GROM = new Legend();
      LEGEND_GROM.UnitType = FourCC(Ogrh);
    }

  }
}
