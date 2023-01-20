using MacroTools;
using MacroTools.LegendSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.Legends
{
  public sealed class LegendIronforge
  {
    public LegendaryHero LegendDagran { get; private set; }
    public LegendaryHero LegendFalstad { get; private set; }
    public LegendaryHero LegendMagni { get; private set; }
    public Capital LegendGreatforge { get; private set; }
    public Capital LegendThelsamar { get; private set; }
    public Capital LegendMenethilHarbor { get; private set; }

    public LegendIronforge Setup(PreplacedUnitSystem preplacedUnitSystem)
    {
      LegendDagran = new LegendaryHero("Dagran Thaurissan")
      {
        UnitType = FourCC("H03G"),
        StartingXp = 1000
      };
      LegendaryHeroManager.Register(LegendDagran);

      LegendFalstad = new LegendaryHero("Falstad Wildhammer")
      {
        UnitType = FourCC("H028"),
        StartingXp = 1000
      };
      LegendaryHeroManager.Register(LegendFalstad);

      LegendMagni = new LegendaryHero("Magni Bronzebeard")
      {
        UnitType = FourCC("H00S"),
        DeathMessage = "King Magni Bronzebeard has died.", //Todo: bad flavour
        StartingXp = 1000
      };
      LegendMagni.AddUnitDependency(preplacedUnitSystem.GetUnit(FourCC("h001")));
      LegendaryHeroManager.Register(LegendMagni);

      LegendGreatforge = new Capital()
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("h001")),
        DeathMessage = "The Great Forge has been extinguished." //Todo: mediocre flavour
      };
      CapitalManager.Register(LegendGreatforge);
      LegendGreatforge.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_H07K_IMPROVED_CANNON_TOWER_IRONFORGE_TOWER, new Point(10509, -5976)));
      LegendGreatforge.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_H07K_IMPROVED_CANNON_TOWER_IRONFORGE_TOWER, new Point(10710, -5974)));

      LegendThelsamar = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("h05H"))
      };
      CapitalManager.Register(LegendThelsamar);

      LegendMenethilHarbor = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("h0AK"))
      };
      CapitalManager.Register(LegendMenethilHarbor);
    }
  }
}