public class LegendGoblin{

  
    Legend LEGEND_GALLYWIX
    Legend LEGEND_NOGGENFOGGER
    Legend LEGEND_GAZLOWE

  

  private static void OnInit( ){

    LEGEND_GALLYWIX = Legend.create();
    LEGEND_GALLYWIX.UnitType = FourCC(O04N);

    LEGEND_NOGGENFOGGER = Legend.create();
    LEGEND_NOGGENFOGGER.UnitType = FourCC(Nalc);
    LEGEND_NOGGENFOGGER.StartingXP = 800;

    LEGEND_GAZLOWE = Legend.create();
    LEGEND_GAZLOWE.UnitType = FourCC(Ntin);
    LEGEND_GAZLOWE.StartingXP = 1800;

  }

}
