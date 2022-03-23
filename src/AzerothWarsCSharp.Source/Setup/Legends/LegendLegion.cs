using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.Source.Legends
{
  public static class LegendLegion{

  
    public static Legend LEGEND_ARCHIMONDE
    public static Legend LEGEND_ANETHERON
    public static Legend LEGEND_TICHONDRIUS
    public static Legend LEGEND_MALGANIS
    public static Legend LEGEND_LILIAN

  

    public static void Setup( ){
      LEGEND_ARCHIMONDE = new Legend();
      LEGEND_ARCHIMONDE.Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("Uwar"));
      LEGEND_ARCHIMONDE.PermaDies = true;
      LEGEND_ARCHIMONDE.DeathMessage = "Archimonde the Defiler has been banished from Azeroth, marking the end of his second failed invasion.";
      LEGEND_ARCHIMONDE.StartingXp = 10800;
      LEGEND_ARCHIMONDE.Essential = true;

      LEGEND_ANETHERON = new Legend();
      LEGEND_ANETHERON.UnitType = FourCC("U00L");
      LEGEND_ANETHERON.PlayerColor = PLAYER_COLOR_ORANGE;
      LEGEND_ANETHERON.StartingXp = 4000;

      LEGEND_LILIAN = new Legend();
      LEGEND_LILIAN.UnitType = FourCC("E01O");
      LEGEND_LILIAN.StartingXp = 4000;

      LEGEND_TICHONDRIUS = new Legend();
      LEGEND_TICHONDRIUS.UnitType = FourCC("Utic");
      LEGEND_TICHONDRIUS.PlayerColor = PLAYER_COLOR_RED;

      LEGEND_MALGANIS = new Legend();
      LEGEND_MALGANIS.UnitType = FourCC("Umal");
      LEGEND_MALGANIS.PlayerColor = PLAYER_COLOR_GREEN;

    }

  }
}
