public class LegendLegion{

  
    Legend LEGEND_ARCHIMONDE
    Legend LEGEND_ANETHERON
    Legend LEGEND_TICHONDRIUS
    Legend LEGEND_MALGANIS
    Legend LEGEND_LILIAN

  

  private static void OnInit( ){
    LEGEND_ARCHIMONDE = Legend.create();
    LEGEND_ARCHIMONDE.Unit = gg_unit_Uwar_2344;
    LEGEND_ARCHIMONDE.PermaDies = true;
    LEGEND_ARCHIMONDE.DeathMessage = "Archimonde the Defiler has been banished from Azeroth, marking the end of his second failed invasion.";
    LEGEND_ARCHIMONDE.StartingXP = 10800;
    LEGEND_ARCHIMONDE.Essential = true;

    LEGEND_ANETHERON = Legend.create();
    LEGEND_ANETHERON.UnitType = FourCC(U00L);
    LEGEND_ANETHERON.PlayerColor = PLAYER_COLOR_ORANGE;
    LEGEND_ANETHERON.StartingXP = 4000;

    LEGEND_LILIAN = Legend.create();
    LEGEND_LILIAN.UnitType = FourCC(E01O);
    LEGEND_LILIAN.StartingXP = 4000;

    LEGEND_TICHONDRIUS = Legend.create();
    LEGEND_TICHONDRIUS.UnitType = FourCC(Utic);
    LEGEND_TICHONDRIUS.PlayerColor = PLAYER_COLOR_RED;

    LEGEND_MALGANIS = Legend.create();
    LEGEND_MALGANIS.UnitType = FourCC(Umal);
    LEGEND_MALGANIS.PlayerColor = PLAYER_COLOR_GREEN;

  }

}
