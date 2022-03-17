public class LegendDalaran{

  
    Legend LEGEND_ANTONIDAS
    Legend LEGEND_MEDIVH
    Legend LEGEND_JAINA
    Legend LEGEND_KALECGOS
    Legend LEGEND_MALYGOS

    Legend LEGEND_DALARAN
  

  private static void OnInit( ){
    LEGEND_JAINA = Legend.create();
    LEGEND_JAINA.UnitType = FourCC(Hjai);
    LEGEND_JAINA.Essential = true;

    LEGEND_MEDIVH = Legend.create();
    LEGEND_MEDIVH.UnitType = FourCC(Haah);
    LEGEND_MEDIVH.StartingXP = 2800;

    LEGEND_KALECGOS = Legend.create();
    LEGEND_KALECGOS.UnitType = FourCC(U027);
    LEGEND_KALECGOS.StartingXP = 9800;

    LEGEND_MALYGOS = Legend.create();
    LEGEND_MALYGOS.UnitType = FourCC(U026);
    LEGEND_MALYGOS.StartingXP = 10900;

    LEGEND_DALARAN = Legend.create();
    LEGEND_DALARAN.Unit = gg_unit_h002_0230;
    LEGEND_DALARAN.DeathMessage = "The Violet Citadel, the ultimate bastion of arcane knowledge in the Eastern Kingdoms, crumbles like a sand castle.";
    LEGEND_DALARAN.IsCapital = true;

    LEGEND_ANTONIDAS = Legend.create();
    LEGEND_ANTONIDAS.UnitType = FourCC(Hant);
    LEGEND_ANTONIDAS.StartingXP = 1000;
    LEGEND_ANTONIDAS.AddUnitDependency(LEGEND_DALARAN.Unit);
    LEGEND_ANTONIDAS.DeathMessage = "Archmage Antonidas has been cut down, his vast knowledge forever lost with his death. The mages of Dalaran have lost their brightest mind.";
  }

}
