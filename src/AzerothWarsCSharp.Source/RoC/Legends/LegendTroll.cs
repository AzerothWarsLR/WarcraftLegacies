public class LegendTroll{

  
    Legend LEGEND_PRIEST
    Legend LEGEND_RASTAKHAN
    Legend LEGEND_HAKKAR
  

  private static void OnInit( ){
    LEGEND_PRIEST = Legend.create();
    LEGEND_PRIEST.UnitType = FourCC(O01J);
    LEGEND_PRIEST.Essential = true;

    LEGEND_HAKKAR = Legend.create();
    LEGEND_HAKKAR.UnitType = FourCC(U023);

    LEGEND_RASTAKHAN = Legend.create();
    LEGEND_RASTAKHAN.UnitType = FourCC(O026);
    LEGEND_RASTAKHAN.StartingXP = 2800;

  }

}
