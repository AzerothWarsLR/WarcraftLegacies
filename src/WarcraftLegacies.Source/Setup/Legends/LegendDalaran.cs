using MacroTools;
using MacroTools.LegendSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;
#pragma warning disable CS1591

namespace WarcraftLegacies.Source.Setup.Legends
{
  /// <summary>
  /// Responsible for setting up and storing all Dalaran <see cref="Legend"/>s.
  /// </summary>
  public sealed class LegendDalaran
  {
    public LegendaryHero Antonidas { get; }
    public LegendaryHero Medivh { get; }
    public LegendaryHero Jaina { get; }
    public LegendaryHero Kalecgos { get; }
    public Capital Dalaran { get; }

    /// <summary>
    /// Sets up all Dalaran <see cref="Legend"/>s.
    /// </summary>
    public LegendDalaran(PreplacedUnitSystem preplacedUnitSystem)
    {
      Jaina = new LegendaryHero("Jaina Proudmoore")
      {
        UnitType = Constants.UNIT_HJAI_ARCHMAGE_OF_DALARAN_DALARAN
      };

      Medivh = new LegendaryHero("Medivh")
      {
        UnitType = FourCC("Haah"),
        StartingXp = 2800
      };

      Kalecgos = new LegendaryHero("Kalecgos")
      {
        UnitType = FourCC("U027"),
        StartingXp = 9800
      };

      Dalaran = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(Constants.UNIT_H002_THE_VIOLET_CITADEL_DALARAN_OTHER),
        DeathMessage =
          "The Violet Citadel, the ultimate bastion of arcane knowledge in the Eastern Kingdoms, crumbles like a sand castle."
      };
      Dalaran.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_N03G_VIOLET_TOWER, new Point(9084, 4979)));
      Dalaran.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_N03G_VIOLET_TOWER, new Point(9008, 4092)));
      Dalaran.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_N03G_VIOLET_TOWER, new Point(9864, 4086)));

      Antonidas = new LegendaryHero("Antonidas")
      {
        UnitType = FourCC("Hant"),
        StartingXp = 1000,
        DeathMessage =
          "Archmage Antonidas has been cut down, his vast knowledge forever lost with his death. The mages of Dalaran have lost their brightest mind."
      };
      Antonidas.AddUnitDependency(Dalaran.Unit);
    }
    
    public void RegisterLegends()
    {
      LegendaryHeroManager.Register(Antonidas);
      LegendaryHeroManager.Register(Jaina);
      LegendaryHeroManager.Register(Kalecgos);
      LegendaryHeroManager.Register(Medivh);
      CapitalManager.Register(Dalaran);
    }
  }
}