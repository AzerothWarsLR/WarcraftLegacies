public class LegendScarlet{

  
    Legend LEGEND_BRIGITTE
    Legend LEGEND_TIRION
  

  private static void OnInit( ){

    LEGEND_BRIGITTE = Legend.create();
    LEGEND_BRIGITTE.UnitType = FourCC(H00Y);
    LEGEND_BRIGITTE.StartingXP = 7000;

    LEGEND_TIRION = Legend.create();
    LEGEND_TIRION.UnitType = FourCC(H09Z);
    LEGEND_TIRION.StartingXP = 7000;

}

}
