using MacroTools.Legends;
using MacroTools.PreplacedWidgets;

namespace WarcraftLegacies.Source.Factions.Ironforge;

public sealed class IronforgeLegends
{
  public LegendaryHero Dagran { get; }
  public LegendaryHero Falstad { get; }
  public LegendaryHero Magni { get; }
  public LegendaryHero Muradin { get; }
  public LegendaryHero Moira { get; }
  public LegendaryHero Angerforge { get; }
  public LegendaryHero Ragnaros { get; }
  public LegendaryHero Kurdran { get; }
  public LegendaryHero Talonaxe { get; }
  public Capital GreatForge { get; }
  public Capital Thelsamar { get; }
  public Capital MenethilHarbor { get; }

  public IronforgeLegends()
  {
    Dagran = new LegendaryHero("Dagran Thaurissan")
    {
      UnitType = UNIT_H03G_EMPEROR_OF_BLACKROCK_IRONFORGE,
      StartingXp = 2800
    };

    Falstad = new LegendaryHero("Falstad Wildhammer")
    {
      UnitType = UNIT_H028_THANE_OF_AERIE_PEAK_IRONFORGE,
      StartingXp = 2800
    };

    Magni = new LegendaryHero("Magni Bronzebeard")
    {
      UnitType = UNIT_H00S_KING_OF_KHAZ_MODAN_IRONFORGE,
      DeathMessage = "King Magni Bronzebeard has died.", //Todo: bad flavour
      StartingXp = 1000
    };

    Muradin = new LegendaryHero("Muradin Bronzebeard")
    {
      UnitType = UNIT_HMBR_HIGH_THANE_OF_THE_BRONZEBEARDS_IRONFORGE,
      StartingXp = 2800
    };

    Moira = new LegendaryHero("Moira Thaurissan")
    {
      UnitType = UNIT_H0CU_QUEEN_OF_THE_DARK_IRON_DARKIRON
    };

    Angerforge = new LegendaryHero("General Angerforge")
    {
      UnitType = UNIT_H0CV_GENERAL_OF_THE_DARK_IRON_DARKIRON
    };

    Ragnaros = new LegendaryHero("Ragnaros")
    {
      UnitType = UNIT_U02K_LORD_OF_THE_FIRELANDS_DARKIRON,
      StartingXp = 2800
    };

    Kurdran = new LegendaryHero("Kurdran Wildhammer")
    {
      UnitType = UNIT_H0CW_SKY_THANE_OF_THE_WILDHAMMER_WILDHAMMER
    };

    Talonaxe = new LegendaryHero("Gryphon Master Talonaxe")
    {
      UnitType = UNIT_H0CX_GRYPHON_MASTER_OF_AERIE_PEAK_WILDHAMMER
    };

    GreatForge = new Capital
    {
      Unit = AllPreplacedWidgets.Units.Get(UNIT_H001_THE_GREAT_FORGE_IRONFORGE_OTHER),
      DeathMessage = "The Great Forge has been extinguished.", //Todo: mediocre flavour
      Essential = true
    };
    GreatForge.AddProtector(AllPreplacedWidgets.Units.GetClosest(UNIT_H07K_IMPROVED_CANNON_TOWER_IRONFORGE_TOWER, 10509, -5976));
    GreatForge.AddProtector(AllPreplacedWidgets.Units.GetClosest(UNIT_H07K_IMPROVED_CANNON_TOWER_IRONFORGE_TOWER, 10710, -5974));

    Thelsamar = new Capital
    {
      Unit = AllPreplacedWidgets.Units.Get(UNIT_H05H_THELSAMAR_IRONFORGE_OTHER)
    };

    MenethilHarbor = new Capital
    {
      Unit = AllPreplacedWidgets.Units.Get(UNIT_H0AK_MENETHIL_HARBOR_IRONFORGE_OTHER)
    };
  }

  public void RegisterLegends()
  {
    LegendaryHeroManager.Register(Dagran);
    LegendaryHeroManager.Register(Falstad);
    LegendaryHeroManager.Register(Magni);
    LegendaryHeroManager.Register(Muradin);
    LegendaryHeroManager.Register(Moira);
    LegendaryHeroManager.Register(Angerforge);
    LegendaryHeroManager.Register(Ragnaros);
    LegendaryHeroManager.Register(Kurdran);
    LegendaryHeroManager.Register(Talonaxe);
    CapitalManager.Register(GreatForge);
    CapitalManager.Register(Thelsamar);
    CapitalManager.Register(MenethilHarbor);
  }
}
