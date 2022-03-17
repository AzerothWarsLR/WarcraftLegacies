public class LegendQuelthalas{

  
    Legend LEGEND_ANASTERIAN
    Legend LEGEND_ROMMATH
    Legend LEGEND_JENNALLA
    Legend LEGEND_SYLVANAS
    Legend LEGEND_KORIALSTRASZ
    Legend LEGEND_KAEL
    Legend LEGEND_LORTHEMAR
    Legend LEGEND_KILJAEDEN
    Legend LEGEND_PATHALEON

    Legend LEGEND_SILVERMOON
    Legend LEGEND_SUNWELL
  

  private static void OnInit( ){
    LEGEND_SILVERMOON = Legend.create();
    LEGEND_SILVERMOON.Unit = gg_unit_h003_0418;
    LEGEND_SILVERMOON.DeathMessage = "The grand city of the high elves, Silvermoon, has been crushed by her enemies.";
    LEGEND_SILVERMOON.IsCapital = true;

    LEGEND_SUNWELL = Legend.create();
    LEGEND_SUNWELL.Unit = gg_unit_n001_0165;
    LEGEND_SUNWELL.Capturable = true;
    LEGEND_SUNWELL.IsCapital = true;

    LEGEND_ANASTERIAN = Legend.create();
    LEGEND_ANASTERIAN.UnitType = FourCC(H00Q);
    LEGEND_ANASTERIAN.PlayerColor = PLAYER_COLOR_MAROON;
    LEGEND_ANASTERIAN.AddUnitDependency(LEGEND_SUNWELL.Unit);
    LEGEND_ANASTERIAN.Essential = true;
    LEGEND_ANASTERIAN.StartingXP = 1000;

    LEGEND_ROMMATH = Legend.create();
    LEGEND_ROMMATH.UnitType = FourCC(H04F);
    LEGEND_ROMMATH.StartingXP = 1800;

    LEGEND_JENNALLA = Legend.create();
    LEGEND_JENNALLA.UnitType = FourCC(H02B);

    LEGEND_PATHALEON = Legend.create();
    LEGEND_PATHALEON.UnitType = FourCC(H098);
    LEGEND_PATHALEON.StartingXP = 1800;

    LEGEND_SYLVANAS = Legend.create();
    LEGEND_SYLVANAS.UnitType = FourCC(Hvwd);
    LEGEND_SYLVANAS.PlayerColor = PLAYER_COLOR_GREEN;

    LEGEND_KAEL = Legend.create();
    LEGEND_KAEL.PlayerColor = PLAYER_COLOR_RED;
    LEGEND_KAEL.UnitType = FourCC(Hkal);
    LEGEND_KAEL.StartingXP = 1800;

    LEGEND_LORTHEMAR = Legend.create();
    LEGEND_LORTHEMAR.UnitType = FourCC(H02E);
    LEGEND_LORTHEMAR.StartingXP = 2800;

    LEGEND_KILJAEDEN = Legend.create();
    LEGEND_KILJAEDEN.UnitType = FourCC(U004);
    LEGEND_KILJAEDEN.PermaDies = true;
    LEGEND_KILJAEDEN.StartingXP = 10800;
    LEGEND_KILJAEDEN.DeathMessage = "KilFourCC(jaeden the Deceiver has been annihilated, but it is too late for the Blood Elves, who will continue to live && die with demonic taint coursing through their veins.";
  }

}
