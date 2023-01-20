using MacroTools;
using MacroTools.LegendSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;
#pragma warning disable CS1591

namespace WarcraftLegacies.Source.Setup.Legends
{
  public sealed class LegendIronforge : IRegistersLegends
  {
    public LegendaryHero LegendDagran { get; }
    public LegendaryHero LegendFalstad { get; }
    public LegendaryHero LegendMagni { get; }
    public Capital LegendGreatforge { get; }
    public Capital LegendThelsamar { get; }
    public Capital LegendMenethilHarbor { get; }

    public LegendIronforge(PreplacedUnitSystem preplacedUnitSystem)
    {
      LegendDagran = new LegendaryHero("Dagran Thaurissan")
      {
        UnitType = FourCC("H03G"),
        StartingXp = 1000
      };

      LegendFalstad = new LegendaryHero("Falstad Wildhammer")
      {
        UnitType = FourCC("H028"),
        StartingXp = 1000
      };

      LegendMagni = new LegendaryHero("Magni Bronzebeard")
      {
        UnitType = FourCC("H00S"),
        DeathMessage = "King Magni Bronzebeard has died.", //Todo: bad flavour
        StartingXp = 1000
      };
      LegendMagni.AddUnitDependency(preplacedUnitSystem.GetUnit(FourCC("h001")));

      LegendGreatforge = new Capital()
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("h001")),
        DeathMessage = "The Great Forge has been extinguished." //Todo: mediocre flavour
      };
      LegendGreatforge.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_H07K_IMPROVED_CANNON_TOWER_IRONFORGE_TOWER, new Point(10509, -5976)));
      LegendGreatforge.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_H07K_IMPROVED_CANNON_TOWER_IRONFORGE_TOWER, new Point(10710, -5974)));

      LegendThelsamar = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("h05H"))
      };

      LegendMenethilHarbor = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("h0AK"))
      };
    }

    /// <inheritdoc />
    public void RegisterLegends()
    {
      LegendaryHeroManager.Register(LegendDagran);
      LegendaryHeroManager.Register(LegendFalstad);
      LegendaryHeroManager.Register(LegendMagni);
      CapitalManager.Register(LegendGreatforge);
      CapitalManager.Register(LegendThelsamar);
      CapitalManager.Register(LegendMenethilHarbor);
    }
  }
}