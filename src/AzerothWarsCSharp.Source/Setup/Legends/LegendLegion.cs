using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.Source.Legends
{
  public static class LegendLegion
  {
    public static Legend LEGEND_ARCHIMONDE { get; private set; }
    public static Legend LEGEND_ANETHERON { get; private set; }
    public static Legend LEGEND_TICHONDRIUS { get; private set; }
    public static Legend LEGEND_MALGANIS { get; private set; }
    public static Legend LEGEND_LILIAN { get; private set; }


    public static void Setup()
    {
      LEGEND_ARCHIMONDE = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("Uwar")),
        PermaDies = true,
        DeathMessage =
          "Archimonde the Defiler has been banished from Azeroth, marking the end of his second failed invasion.",
        StartingXp = 10800,
        Essential = true
      };

      LEGEND_ANETHERON = new Legend
      {
        UnitType = FourCC("U00L"),
        PlayerColor = PLAYER_COLOR_ORANGE,
        StartingXp = 4000
      };

      LEGEND_LILIAN = new Legend
      {
        UnitType = FourCC("E01O"),
        StartingXp = 4000
      };

      LEGEND_TICHONDRIUS = new Legend
      {
        UnitType = FourCC("Utic"),
        PlayerColor = PLAYER_COLOR_RED
      };

      LEGEND_MALGANIS = new Legend
      {
        UnitType = FourCC("Umal"),
        PlayerColor = PLAYER_COLOR_GREEN
      };
    }
  }
}