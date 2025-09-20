using MacroTools.LegendSystem;
using MacroTools.Systems;

namespace WarcraftLegacies.Source.Setup.Legends;

public sealed class LegendLegion
{
  public LegendaryHero Archimonde { get; }
  public LegendaryHero Anetheron { get; }
  public LegendaryHero Tichondrius { get; }
  public LegendaryHero Malganis { get; }

  public Capital LegionStronghold { get; }

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
      StartingXp = 400
    };

    Tichondrius = new LegendaryHero("Tichondrius")
    {
      UnitType = FourCC("Utic"),
      PlayerColor = PLAYER_COLOR_RED,
      StartingXp = 1000
    };

    Malganis = new LegendaryHero("Mal'ganis")
    {
      UnitType = FourCC("Umal"),
      PlayerColor = PLAYER_COLOR_GREEN
    };

    LegionStronghold = new Capital
    {
      Unit = preplacedUnitSystem.GetUnit(UNIT_U00G_LEGION_STRONGHOLD_LEGION_OTHER),
      DeathMessage =
        "The great Stronghold of the Legian has fallen",
      Essential = true
    };
  }

  public void RegisterLegends()
  {
    LegendaryHeroManager.Register(Archimonde);
    LegendaryHeroManager.Register(Anetheron);
    LegendaryHeroManager.Register(Tichondrius);
    LegendaryHeroManager.Register(Malganis);
    CapitalManager.Register(LegionStronghold);
  }
}
