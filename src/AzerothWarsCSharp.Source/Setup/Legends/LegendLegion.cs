using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.Legends
{
  public static class LegendLegion
  {
    public static Legend LEGEND_ARCHIMONDE { get; private set; }
    public static Legend LEGEND_ANETHERON { get; private set; }
    public static Legend LEGEND_TICHONDRIUS { get; private set; }
    public static Legend LEGEND_MALGANIS { get; private set; }
    public static Legend LEGEND_LILIAN { get; private set; }
    public static Legend LEGION_NEXUS_NORTHREND { get; private set; }
    public static Legend LEGION_NEXUS_OUTLAND { get; private set; }

    public static void Setup()
    {
      LEGEND_ARCHIMONDE = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnit(FourCC("Uwar")),
        PermaDies = true,
        DeathMessage =
          "Archimonde the Defiler has been banished from Azeroth, marking the end of his second failed invasion.",
        StartingXp = 10800
      };
      Legend.Register(LEGEND_ARCHIMONDE);

      LEGEND_ANETHERON = new Legend
      {
        UnitType = FourCC("U00L"),
        PlayerColor = PLAYER_COLOR_ORANGE,
        StartingXp = 4000
      };
      Legend.Register(LEGEND_ANETHERON);

      LEGEND_LILIAN = new Legend
      {
        UnitType = FourCC("E01O"),
        StartingXp = 4000
      };
      Legend.Register(LEGEND_LILIAN);

      LEGEND_TICHONDRIUS = new Legend
      {
        UnitType = FourCC("Utic"),
        PlayerColor = PLAYER_COLOR_RED
      };
      Legend.Register(LEGEND_TICHONDRIUS);

      LEGEND_MALGANIS = new Legend
      {
        UnitType = FourCC("Umal"),
        PlayerColor = PLAYER_COLOR_GREEN
      };
      Legend.Register(LEGEND_MALGANIS);

      LEGION_NEXUS_OUTLAND = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnit(Constants.UNIT_N0BE_LEGION_NEXUS_LEGION, new Point(-3483, -21662))
      };
      Legend.Register(LEGION_NEXUS_OUTLAND);
      SetUnitInvulnerable(LEGION_NEXUS_OUTLAND.Unit, true);
      
      LEGION_NEXUS_NORTHREND = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnit(Constants.UNIT_N0BE_LEGION_NEXUS_LEGION, new Point(-3501, 20951))
      };
      Legend.Register(LEGION_NEXUS_NORTHREND);
      SetUnitInvulnerable(LEGION_NEXUS_NORTHREND.Unit, true);
    }
  }
}