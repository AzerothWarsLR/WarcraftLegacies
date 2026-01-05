using MacroTools.LegendSystem;
using MacroTools.PreplacedWidgetsSystem;

namespace WarcraftLegacies.Source.Setup.Legends;

public sealed class LegendLegion
{
  public LegendaryHero Archimonde { get; }
  public LegendaryHero Anetheron { get; }
  public LegendaryHero Tichondrius { get; }
  public LegendaryHero Malganis { get; }

  public Capital LegionStronghold { get; }

  public LegendLegion()
  {
    Archimonde = new LegendaryHero("Archimonde")
    {
      Unit = PreplacedWidgets.Units.Get(UNIT_UWAR_THE_DEFILER_LEGION),
      PermaDies = true,
      DeathMessage =
        "Archimonde the Defiler has been banished from Azeroth, marking the end of his second failed invasion.",
      StartingXp = 10800
    };

    Anetheron = new LegendaryHero("Anetheron")
    {
      UnitType = UNIT_U00L_ENVOY_OF_ARCHIMONDE_LEGION,
      PlayerColor = playercolor.Orange,
      StartingXp = 400
    };

    Tichondrius = new LegendaryHero("Tichondrius")
    {
      UnitType = UNIT_UTIC_THE_DARKENER_LEGION,
      PlayerColor = playercolor.Red,
      StartingXp = 1000
    };

    Malganis = new LegendaryHero("Mal'ganis")
    {
      UnitType = UNIT_UMAL_THE_CUNNING_LEGION,
      PlayerColor = playercolor.Green
    };

    LegionStronghold = new Capital
    {
      Unit = PreplacedWidgets.Units.Get(UNIT_U00G_LEGION_STRONGHOLD_LEGION_OTHER),
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
