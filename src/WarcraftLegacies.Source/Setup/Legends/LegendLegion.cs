using MacroTools;
using MacroTools.LegendSystem;
using static War3Api.Common;
#pragma warning disable CS1591

namespace WarcraftLegacies.Source.Setup.Legends
{
  public sealed class LegendLegion : IRegistersLegends
  {
    public LegendaryHero Archimonde { get; }
    public LegendaryHero Anetheron { get; }
    public LegendaryHero Tichondrius { get; }
    public LegendaryHero Malganis { get; }

    public LegendLegion(PreplacedUnitSystem preplacedUnitSystem)
    {
      Archimonde = new LegendaryHero("Archimonde")
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("Uwar")),
        PermaDies = true,
        DeathMessage =
          "Archimonde the Defiler has been banished from Azeroth, marking the end of his second failed invasion.",
        StartingXp = 10800
      };

      Anetheron = new LegendaryHero("Anetheron")
      {
        UnitType = FourCC("U00L"),
        PlayerColor = PLAYER_COLOR_ORANGE,
        StartingXp = 4000
      };

      Tichondrius = new LegendaryHero("Tichondrius")
      {
        UnitType = FourCC("Utic"),
        PlayerColor = PLAYER_COLOR_RED
      };

      Malganis = new LegendaryHero("Mal'ganis")
      {
        UnitType = FourCC("Umal"),
        PlayerColor = PLAYER_COLOR_GREEN
      };
    }

    /// <inheritdoc />
    public void RegisterLegends()
    {
      LegendaryHeroManager.Register(Archimonde);
      LegendaryHeroManager.Register(Anetheron);
      LegendaryHeroManager.Register(Tichondrius);
      LegendaryHeroManager.Register(Malganis);
    }
  }
}