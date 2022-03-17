public class LegendWarsong{

  
    Legend LEGEND_GROM
    Legend LEGEND_JERGOSH
    Legend LEGEND_MANNOROTH
    Legend LEGEND_STONEMAUL
    Legend LEGEND_ENCAMPMENT
    Legend LEGEND_CHEN
    Legend LEGEND_SAURFANG
  

  private static void OnInit( ){

    LEGEND_CHEN = Legend.create();
    LEGEND_CHEN.UnitType = FourCC(Nsjs);
    LEGEND_CHEN.StartingXP = 1000;

    LEGEND_SAURFANG = Legend.create();
    LEGEND_SAURFANG.UnitType = FourCC(Obla);
    LEGEND_SAURFANG.StartingXP = 2800;

    LEGEND_JERGOSH = Legend.create();
    LEGEND_JERGOSH.UnitType = FourCC(Oths);

    LEGEND_MANNOROTH = Legend.create();
    LEGEND_MANNOROTH.UnitType = FourCC(Nman);

    LEGEND_STONEMAUL = Legend.create();
    LEGEND_STONEMAUL.Unit = gg_unit_o004_0169;
    LEGEND_STONEMAUL.DeathMessage = "The fortress of the Stonemaul Clan has fallen.";
    LEGEND_STONEMAUL.IsCapital = true;

    LEGEND_ENCAMPMENT = Legend.create();

    LEGEND_GROM = Legend.create();
    LEGEND_GROM.UnitType = FourCC(Ogrh);
  }

}
