using MacroTools;
using MacroTools.LegendSystem;
using static War3Api.Common;
#pragma warning disable CS1591

namespace WarcraftLegacies.Source.Setup.Legends
{
  public sealed class LegendLegion : IRegistersLegends
  {
    public LegendaryHero LEGEND_ARCHIMONDE { get; }
    public LegendaryHero LEGEND_ANETHERON { get; }
    public LegendaryHero LEGEND_TICHONDRIUS { get; }
    public LegendaryHero LEGEND_MALGANIS { get; }

    public LegendLegion(PreplacedUnitSystem preplacedUnitSystem)
    {
      LEGEND_ARCHIMONDE = new LegendaryHero("Archimonde")
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("Uwar")),
        PermaDies = true,
        DeathMessage =
          "Archimonde the Defiler has been banished from Azeroth, marking the end of his second failed invasion.",
        StartingXp = 10800
      };

      LEGEND_ANETHERON = new LegendaryHero("Anetheron")
      {
        UnitType = FourCC("U00L"),
        PlayerColor = PLAYER_COLOR_ORANGE,
        StartingXp = 4000
      };

      LEGEND_TICHONDRIUS = new LegendaryHero("Tichondrius")
      {
        UnitType = FourCC("Utic"),
        PlayerColor = PLAYER_COLOR_RED
      };

      LEGEND_MALGANIS = new LegendaryHero("Mal'ganis")
      {
        UnitType = FourCC("Umal"),
        PlayerColor = PLAYER_COLOR_GREEN
      };
    }

    /// <inheritdoc />
    public void RegisterLegends()
    {
      LegendaryHeroManager.Register(LEGEND_ARCHIMONDE);
      LegendaryHeroManager.Register(LEGEND_ANETHERON);
      LegendaryHeroManager.Register(LEGEND_TICHONDRIUS);
      LegendaryHeroManager.Register(LEGEND_MALGANIS);
    }
  }
}