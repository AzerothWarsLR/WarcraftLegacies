using MacroTools.Legends;
using MacroTools.PreplacedWidgetsSystem;

namespace WarcraftLegacies.Source.Setup.Legends;

public sealed class LegendIronforge
{
  public LegendaryHero Dagran { get; }
  public LegendaryHero Falstad { get; }
  public LegendaryHero Magni { get; }
  public Capital GreatForge { get; }
  public Capital Thelsamar { get; }
  public Capital MenethilHarbor { get; }

  public LegendIronforge()
  {
    Dagran = new LegendaryHero("Dagran Thaurissan")
    {
      UnitType = UNIT_H03G_EMPEROR_OF_BLACKROCK_RAGNAROS,
      StartingXp = 7000
    };

    Falstad = new LegendaryHero("Falstad Wildhammer")
    {
      UnitType = UNIT_H028_THANE_OF_AERIE_PEAK_IRONFORGE,
      StartingXp = 5400
    };

    Magni = new LegendaryHero("Magni Bronzebeard")
    {
      UnitType = UNIT_H00S_KING_OF_KHAZ_MODAN_IRONFORGE,
      DeathMessage = "King Magni Bronzebeard has died.", //Todo: bad flavour
      StartingXp = 1000
    };

    GreatForge = new Capital
    {
      Unit = PreplacedWidgets.Units.Get(UNIT_H001_THE_GREAT_FORGE_IRONFORGE_OTHER),
      DeathMessage = "The Great Forge has been extinguished.", //Todo: mediocre flavour
      Essential = true
    };
    GreatForge.AddProtector(PreplacedWidgets.Units.GetClosest(UNIT_H07K_IMPROVED_CANNON_TOWER_IRONFORGE_TOWER, 10509, -5976));
    GreatForge.AddProtector(PreplacedWidgets.Units.GetClosest(UNIT_H07K_IMPROVED_CANNON_TOWER_IRONFORGE_TOWER, 10710, -5974));

    Thelsamar = new Capital
    {
      Unit = PreplacedWidgets.Units.Get(UNIT_H05H_THELSAMAR_IRONFORGE_OTHER)
    };

    MenethilHarbor = new Capital
    {
      Unit = PreplacedWidgets.Units.Get(UNIT_H0AK_MENETHIL_HARBOR_IRONFORGE_OTHER)
    };
  }

  public void RegisterLegends()
  {
    LegendaryHeroManager.Register(Dagran);
    LegendaryHeroManager.Register(Falstad);
    LegendaryHeroManager.Register(Magni);
    CapitalManager.Register(GreatForge);
    CapitalManager.Register(Thelsamar);
    CapitalManager.Register(MenethilHarbor);
  }
}
