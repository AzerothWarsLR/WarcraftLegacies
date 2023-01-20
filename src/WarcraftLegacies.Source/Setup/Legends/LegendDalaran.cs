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
  public sealed class LegendDalaran : IRegistersLegends
  {
    public LegendaryHero LegendAntonidas { get; }
    
    public LegendaryHero LegendMedivh { get; }
    
    public LegendaryHero LegendJaina { get; }
    
    public LegendaryHero LegendKalecgos { get; }
    
    public LegendaryHero LegendMalygos { get; }
    
    public Capital LegendDalaranCapital { get; }

    /// <summary>
    /// Sets up all Dalaran <see cref="Legend"/>s.
    /// </summary>
    public LegendDalaran(PreplacedUnitSystem preplacedUnitSystem)
    {
      LegendJaina = new LegendaryHero("Jaina Proudmoore")
      {
        UnitType = Constants.UNIT_HJAI_ARCHMAGE_OF_DALARAN_DALARAN
      };

      LegendMedivh = new LegendaryHero("Medivh")
      {
        UnitType = FourCC("Haah"),
        StartingXp = 2800
      };

      LegendKalecgos = new LegendaryHero("Kalecgos")
      {
        UnitType = FourCC("U027"),
        StartingXp = 9800
      };

      LegendMalygos = new LegendaryHero("Malygos")
      {
        UnitType = FourCC("U026"),
        StartingXp = 10900
      };

      LegendDalaranCapital = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(Constants.UNIT_H002_THE_VIOLET_CITADEL_DALARAN_OTHER),
        DeathMessage =
          "The Violet Citadel, the ultimate bastion of arcane knowledge in the Eastern Kingdoms, crumbles like a sand castle."
      };
      LegendDalaranCapital.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_N03G_VIOLET_TOWER, new Point(9084, 4979)));
      LegendDalaranCapital.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_N03G_VIOLET_TOWER, new Point(9008, 4092)));
      LegendDalaranCapital.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_N03G_VIOLET_TOWER, new Point(9864, 4086)));

      LegendAntonidas = new LegendaryHero("Antonidas")
      {
        UnitType = FourCC("Hant"),
        StartingXp = 1000,
        DeathMessage =
          "Archmage Antonidas has been cut down, his vast knowledge forever lost with his death. The mages of Dalaran have lost their brightest mind."
      };
      LegendAntonidas.AddUnitDependency(LegendDalaranCapital.Unit);
    }

    /// <inheritdoc />
    public void RegisterLegends()
    {
      LegendaryHeroManager.Register(LegendAntonidas);
      LegendaryHeroManager.Register(LegendJaina);
      LegendaryHeroManager.Register(LegendKalecgos);
      LegendaryHeroManager.Register(LegendMalygos);
      LegendaryHeroManager.Register(LegendMedivh);
      CapitalManager.Register(LegendDalaranCapital);
    }
  }
}