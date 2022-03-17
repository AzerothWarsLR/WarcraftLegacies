public class LegendCthun{

  
    Legend LEGEND_SKERAM
    Legend LEGEND_GATESAHNQIRAJ
    Legend LEGEND_CTHUN
    Legend LEGEND_YOR

  

  private static void OnInit( ){

    LEGEND_CTHUN = Legend.create();
    LEGEND_CTHUN.Unit = gg_unit_U00R_0609;
    LEGEND_CTHUN.PermaDies = true;
    LEGEND_CTHUN.DeathMessage = "CFourCC(thun, God of the Qiraji, was once defeated by the Titans, and){ again by the combined Dragonflights. Today he experiences his third defeat && his first true death.";

    LEGEND_SKERAM = Legend.create();
    LEGEND_SKERAM.UnitType = FourCC(E005);
    LEGEND_SKERAM.PlayerColor = PLAYER_COLOR_RED;
    LEGEND_SKERAM.Name = "Prophet Skeram";

    LEGEND_GATESAHNQIRAJ = Legend.create();
    LEGEND_GATESAHNQIRAJ.Unit = gg_unit_h02U_2413;

    LEGEND_YOR = Legend.create();
    LEGEND_YOR.UnitType = FourCC(U02A);
    LEGEND_YOR.StartingXP = 8800;

  }

}
