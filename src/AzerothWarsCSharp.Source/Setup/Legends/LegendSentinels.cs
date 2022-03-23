using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.Source.Legends
{
  public static class LegendSentinels
  {


    public static Legend legendMaiev;
    public static Legend legendTyrande;
    public static Legend legendShandris;
    public static Legend legendJarod;

    public static Legend legendAuberdine;
    public static Legend legendFeathermoon;
  

    public static void Setup( ){
      legendMaiev = new Legend();
      legendMaiev.UnitType = FourCC("Ewrd");

      legendAuberdine = new Legend();
      legendAuberdine.Unit = gg_unit_e00J_0320;
      legendAuberdine.IsCapital = true;

      legendFeathermoon = new Legend();
      legendFeathermoon.Unit = gg_unit_e00M_2545;
      legendFeathermoon.IsCapital = true;

      legendTyrande = new Legend();
      legendTyrande.UnitType = FourCC("Etyr");
      legendTyrande.PlayerColor = PLAYER_COLOR_CYAN;
      legendTyrande.Essential = true;

      legendShandris = new Legend();
      legendShandris.UnitType = FourCC("E002");
      legendShandris.StartingXp = 1000;

      legendJarod = new Legend();
      legendJarod.UnitType = FourCC("O02E");
      legendJarod.StartingXp = 4000;
    }

  }
}
