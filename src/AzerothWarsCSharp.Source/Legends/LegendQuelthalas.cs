using AzerothWarsCSharp.Source.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.Legends
{
  public static class LegendQuelthalas{

  
    public static Legend LEGEND_ANASTERIAN
    public static Legend LEGEND_ROMMATH
    public static Legend LEGEND_JENNALLA
    public static Legend LEGEND_SYLVANAS
    public static Legend LEGEND_KORIALSTRASZ
    public static Legend LEGEND_KAEL
    public static Legend LEGEND_LORTHEMAR
    public static Legend LEGEND_KILJAEDEN
    public static Legend LEGEND_PATHALEON

    public static Legend LEGEND_SILVERMOON
    public static Legend LEGEND_SUNWELL
  

    public static void Setup( ){
      LEGEND_SILVERMOON = new Legend();
      LEGEND_SILVERMOON.Unit = gg_unit_h003_0418;
      LEGEND_SILVERMOON.DeathMessage = "The grand city of the high elves, Silvermoon, has been crushed by her enemies.";
      LEGEND_SILVERMOON.IsCapital = true;

      LEGEND_SUNWELL = new Legend();
      LEGEND_SUNWELL.Unit = gg_unit_n001_0165;
      LEGEND_SUNWELL.Capturable = true;
      LEGEND_SUNWELL.IsCapital = true;

      LEGEND_ANASTERIAN = new Legend();
      LEGEND_ANASTERIAN.UnitType = FourCC(H00Q);
      LEGEND_ANASTERIAN.PlayerColor = PLAYER_COLOR_MAROON;
      LEGEND_ANASTERIAN.AddUnitDependency(LEGEND_SUNWELL.Unit);
      LEGEND_ANASTERIAN.Essential = true;
      LEGEND_ANASTERIAN.StartingXp = 1000;

      LEGEND_ROMMATH = new Legend();
      LEGEND_ROMMATH.UnitType = FourCC(H04F);
      LEGEND_ROMMATH.StartingXp = 1800;

      LEGEND_JENNALLA = new Legend();
      LEGEND_JENNALLA.UnitType = FourCC(H02B);

      LEGEND_PATHALEON = new Legend();
      LEGEND_PATHALEON.UnitType = FourCC(H098);
      LEGEND_PATHALEON.StartingXp = 1800;

      LEGEND_SYLVANAS = new Legend();
      LEGEND_SYLVANAS.UnitType = FourCC(Hvwd);
      LEGEND_SYLVANAS.PlayerColor = PLAYER_COLOR_GREEN;

      LEGEND_KAEL = new Legend();
      LEGEND_KAEL.PlayerColor = PLAYER_COLOR_RED;
      LEGEND_KAEL.UnitType = FourCC(Hkal);
      LEGEND_KAEL.StartingXp = 1800;

      LEGEND_LORTHEMAR = new Legend();
      LEGEND_LORTHEMAR.UnitType = FourCC(H02E);
      LEGEND_LORTHEMAR.StartingXp = 2800;

      LEGEND_KILJAEDEN = new Legend();
      LEGEND_KILJAEDEN.UnitType = FourCC(U004);
      LEGEND_KILJAEDEN.PermaDies = true;
      LEGEND_KILJAEDEN.StartingXp = 10800;
      LEGEND_KILJAEDEN.DeathMessage = "KilFourCC(jaeden the Deceiver has been annihilated, but it is too late for the Blood Elves, who will continue to live && die with demonic taint coursing through their veins.";
    }

  }
}
