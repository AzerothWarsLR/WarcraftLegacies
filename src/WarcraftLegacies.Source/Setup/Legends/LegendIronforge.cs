using MacroTools;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.Legends
{
  public static class LegendIronforge
  {
    public static LegendaryHero LegendDagran { get; private set; }
    public static LegendaryHero LegendFalstad { get; private set; }
    public static LegendaryHero LegendMagni { get; private set; }
    public static Capital LegendGreatforge { get; private set; }
    public static Capital LegendThelsamar { get; private set; }
    public static Capital LegendMenethilHarbor { get; private set; }

    public static void Setup(PreplacedUnitSystem preplacedUnitSystem)
    {
      LegendDagran = new LegendaryHero
      {
        UnitType = FourCC("H03G"),
        StartingXp = 1000
      };
      Legend.Register(LegendDagran);

      LegendFalstad = new LegendaryHero
      {
        UnitType = FourCC("H028"),
        StartingXp = 1000
      };
      Legend.Register(LegendFalstad);

      LegendMagni = new LegendaryHero
      {
        UnitType = FourCC("H00S"),
        DeathMessage = "King Magni Bronzebeard has died.", //Todo: bad flavour
        StartingXp = 1000
      };
      LegendMagni.AddUnitDependency(preplacedUnitSystem.GetUnit(FourCC("h001")));
      Legend.Register(LegendMagni);

      LegendGreatforge = new Capital()
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("h001")),
        DeathMessage = "The Great Forge has been extinguished." //Todo: mediocre flavour
      };
      Legend.Register(LegendGreatforge);
      LegendGreatforge.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_H07K_IMPROVED_CANNON_TOWER_IRONFORGE, new Point(10509, -5976)));
      LegendGreatforge.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_H07K_IMPROVED_CANNON_TOWER_IRONFORGE, new Point(10710, -5974)));

      LegendThelsamar = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("h05H"))
      };
      Legend.Register(LegendThelsamar);

      LegendMenethilHarbor = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("h0AK"))
      };
      Legend.Register(LegendMenethilHarbor);
    }
  }
}