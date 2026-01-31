using MacroTools.Legends;
using MacroTools.PreplacedWidgets;

namespace WarcraftLegacies.Source.Setup.Legends;

/// <summary>
/// Responsible for setting up and storing all Dalaran <see cref="Legend"/>s.
/// </summary>
public sealed class LegendDalaran
{
  public LegendaryHero Antonidas { get; }
  public LegendaryHero Medivh { get; }
  public LegendaryHero Jaina { get; }
  public LegendaryHero Kalecgos { get; }
  public LegendaryHero Aegwynn { get; }
  public Capital Dalaran { get; }
  public Capital Shadowfang { get; }

  /// <summary>
  /// Sets up all Dalaran <see cref="Legend"/>s.
  /// </summary>
  public LegendDalaran()
  {
    Jaina = new LegendaryHero("Jaina Proudmoore")
    {
      UnitType = UNIT_HJAI_ARCHMAGE_OF_DALARAN_DALARAN
    };

    Medivh = new LegendaryHero("Medivh")
    {
      UnitType = UNIT_HAAH_THE_FALLEN_GUARDIAN_DALARAN,
      StartingXp = 2800
    };

    Kalecgos = new LegendaryHero("Kalecgos")
    {
      UnitType = UNIT_U027_STEWARD_OF_MAGIC_NEXUS,
      StartingXp = 5400
    };

    Aegwynn = new LegendaryHero("Aegwynn")
    {
      UnitType = UNIT_H09N_MATRIARCH_OF_TIRISFAL_DALARAN,
      StartingXp = 5400
    };

    Dalaran = new Capital
    {
      Unit = AllPreplacedWidgets.Units.Get(UNIT_H002_THE_VIOLET_CITADEL_DALARAN_OTHER),
      DeathMessage =
        "The Violet Citadel, the ultimate bastion of arcane knowledge in the Eastern Kingdoms, crumbles like a sand castle.",
      Essential = true
    };

    Antonidas = new LegendaryHero("Antonidas")
    {
      UnitType = UNIT_HANT_GRAND_MAGUS_OF_THE_KIRIN_TOR_DALARAN,
      StartingXp = 2800,
      DeathMessage =
        "Archmage Antonidas has been cut down, his vast knowledge forever lost with his death. The mages of Dalaran have lost their brightest mind."
    };

    Shadowfang = new Capital
    {
      Unit = AllPreplacedWidgets.Units.Get(UNIT_H058_SHADOWFANG_KEEP_DALARAN_OTHER),
      Capturable = true
    };
  }

  public void RegisterLegends()
  {
    LegendaryHeroManager.Register(Antonidas);
    LegendaryHeroManager.Register(Jaina);
    LegendaryHeroManager.Register(Kalecgos);
    LegendaryHeroManager.Register(Medivh);
    LegendaryHeroManager.Register(Aegwynn);
    CapitalManager.Register(Dalaran);
    CapitalManager.Register(Shadowfang);
  }
}
