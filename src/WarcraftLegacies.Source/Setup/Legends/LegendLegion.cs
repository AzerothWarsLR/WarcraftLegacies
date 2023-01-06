using MacroTools;
using MacroTools.LegendSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.Legends
{
  public static class LegendLegion
  {
    public static LegendaryHero LEGEND_ARCHIMONDE { get; private set; }
    public static LegendaryHero LEGEND_ANETHERON { get; private set; }
    public static LegendaryHero LEGEND_TICHONDRIUS { get; private set; }
    public static LegendaryHero LEGEND_MALGANIS { get; private set; }
    public static LegendaryHero LEGEND_LILIAN { get; private set; }
    public static Capital LegionNexusNorthrend { get; private set; }
    public static Capital LegionNexusAlterac { get; private set; }

    public static void Setup(PreplacedUnitSystem preplacedUnitSystem)
    {
      LEGEND_ARCHIMONDE = new LegendaryHero("Archimonde")
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("Uwar")),
        PermaDies = true,
        DeathMessage =
          "Archimonde the Defiler has been banished from Azeroth, marking the end of his second failed invasion.",
        StartingXp = 10800
      };
      LegendaryHeroManager.Register(LEGEND_ARCHIMONDE);

      LEGEND_ANETHERON = new LegendaryHero("Anetheron")
      {
        UnitType = FourCC("U00L"),
        PlayerColor = PLAYER_COLOR_ORANGE,
        StartingXp = 4000
      };
      LegendaryHeroManager.Register(LEGEND_ANETHERON);

      LEGEND_LILIAN = new LegendaryHero("Lilian Voss")
      {
        UnitType = FourCC("E01O"),
        StartingXp = 4000
      };
      LegendaryHeroManager.Register(LEGEND_LILIAN);

      LEGEND_TICHONDRIUS = new LegendaryHero("Tichondrius")
      {
        UnitType = FourCC("Utic"),
        PlayerColor = PLAYER_COLOR_RED
      };
      LegendaryHeroManager.Register(LEGEND_TICHONDRIUS);

      LEGEND_MALGANIS = new LegendaryHero("Mal'ganis")
      {
        UnitType = FourCC("Umal"),
        PlayerColor = PLAYER_COLOR_GREEN
      };
      LegendaryHeroManager.Register(LEGEND_MALGANIS);

      LegionNexusAlterac = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(Constants.UNIT_N0BE_LEGION_NEXUS_LEGION_OTHER, new Point(11035f, 5348f))
      };
      CapitalManager.Register(LegionNexusAlterac);
      SetUnitInvulnerable(LegionNexusAlterac.Unit, true);
      
      LegionNexusNorthrend = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(Constants.UNIT_N0BE_LEGION_NEXUS_LEGION_OTHER, new Point(3544, 20780))
      };
      CapitalManager.Register(LegionNexusNorthrend);
      SetUnitInvulnerable(LegionNexusNorthrend.Unit, true);
    }
  }
}