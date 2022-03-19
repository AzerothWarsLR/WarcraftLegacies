using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.RoC.Legends
{
  public static class LegendSentinels
  {


    public static Legend LEGEND_MAIEV;
    public static Legend LEGEND_TYRANDE;
    public static Legend LEGEND_SHANDRIS;
    public static Legend LEGEND_JAROD;

    public static Legend LEGEND_AUBERDINE;
    public static Legend LEGEND_FEATHERMOON;
  

    public static void Setup( ){
      LEGEND_MAIEV = new Legend();
      LEGEND_MAIEV.UnitType = FourCC(Ewrd);

      LEGEND_AUBERDINE = new Legend();
      LEGEND_AUBERDINE.Unit = gg_unit_e00J_0320;
      LEGEND_AUBERDINE.IsCapital = true;

      LEGEND_FEATHERMOON = new Legend();
      LEGEND_FEATHERMOON.Unit = gg_unit_e00M_2545;
      LEGEND_FEATHERMOON.IsCapital = true;

      LEGEND_TYRANDE = new Legend();
      LEGEND_TYRANDE.UnitType = FourCC(Etyr);
      LEGEND_TYRANDE.PlayerColor = PLAYER_COLOR_CYAN;
      LEGEND_TYRANDE.Essential = true;

      LEGEND_SHANDRIS = new Legend();
      LEGEND_SHANDRIS.UnitType = FourCC(E002);
      LEGEND_SHANDRIS.StartingXp = 1000;

      LEGEND_JAROD = new Legend();
      LEGEND_JAROD.UnitType = FourCC(O02E);
      LEGEND_JAROD.StartingXp = 4000;
    }

  }
}
