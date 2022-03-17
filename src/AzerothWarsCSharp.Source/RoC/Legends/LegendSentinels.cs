public class LegendSentinels{

  
    Legend LEGEND_MAIEV
    Legend LEGEND_TYRANDE
    Legend LEGEND_SHANDRIS
    Legend LEGEND_JAROD

    Legend LEGEND_AUBERDINE
    Legend LEGEND_FEATHERMOON
  

  private static void OnInit( ){
    LEGEND_MAIEV = Legend.create();
    LEGEND_MAIEV.UnitType = FourCC(Ewrd);

    LEGEND_AUBERDINE = Legend.create();
    LEGEND_AUBERDINE.Unit = gg_unit_e00J_0320;
    LEGEND_AUBERDINE.IsCapital = true;

    LEGEND_FEATHERMOON = Legend.create();
    LEGEND_FEATHERMOON.Unit = gg_unit_e00M_2545;
    LEGEND_FEATHERMOON.IsCapital = true;

    LEGEND_TYRANDE = Legend.create();
    LEGEND_TYRANDE.UnitType = FourCC(Etyr);
    LEGEND_TYRANDE.PlayerColor = PLAYER_COLOR_CYAN;
    LEGEND_TYRANDE.Essential = true;

    LEGEND_SHANDRIS = Legend.create();
    LEGEND_SHANDRIS.UnitType = FourCC(E002);
    LEGEND_SHANDRIS.StartingXP = 1000;

    LEGEND_JAROD = Legend.create();
    LEGEND_JAROD.UnitType = FourCC(O02E);
    LEGEND_JAROD.StartingXP = 4000;
  }

}
