public class LegendForsaken{

  
    Legend LEGEND_SYLVANASV
    Legend LEGEND_SCHOLOMANCE
    Legend LEGEND_VARIMATHRAS
    Legend LEGEND_NATHANOS
  

  private static void OnInit( ){
    LEGEND_SYLVANASV = Legend.create();
    LEGEND_SYLVANASV.UnitType = FourCC(Usyl);
    LEGEND_SYLVANASV.StartingXP = 15400;

    LEGEND_NATHANOS = Legend.create();
    LEGEND_NATHANOS.UnitType = FourCC(H049);
    LEGEND_NATHANOS.StartingXP = 4000;

    LEGEND_VARIMATHRAS = Legend.create();
    LEGEND_VARIMATHRAS.UnitType = FourCC(Uvar);
    LEGEND_VARIMATHRAS.PlayerColor = PLAYER_COLOR_RED;

    LEGEND_SCHOLOMANCE = Legend.create();
    LEGEND_SCHOLOMANCE.Unit = gg_unit_u012_1149;
    LEGEND_SCHOLOMANCE.DeathMessage = "Scholomance, the center of the ScourgeFourCC(s operations in Lordaeron, has been destroyed.";
}

}
