using MacroTools;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.Legends
{
  /// <summary>
  /// Responsible for setting up and storing all Dalaran <see cref="Legend"/>s.
  /// </summary>
  public static class LegendDalaran
  {
    /// <summary>
    /// Archmage of Dalaran.
    /// </summary>
    public static LegendaryHero? LegendAntonidas { get; private set; }
    
    /// <summary>
    /// Former Guardian of Tirisfal.
    /// </summary>
    public static LegendaryHero? LegendMedivh { get; private set; }
    
    /// <summary>
    /// Antonidas' best student.
    /// </summary>
    public static LegendaryHero? LegendJaina { get; private set; }
    
    /// <summary>
    /// Powerful Blue Dragon and sorcerer.
    /// </summary>
    public static LegendaryHero? LegendKalecgos { get; private set; }
    
    /// <summary>
    /// Aspect of the Blue Dragonflight.
    /// </summary>
    public static LegendaryHero? LegendMalygos { get; private set; }
    
    /// <summary>
    /// Dalaran city capital.l
    /// </summary>
    public static Capital? LegendDalaranCapital { get; private set; }

    /// <summary>
    /// Sets up all Dalaran <see cref="Legend"/>s.
    /// </summary>
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem)
    {
      LegendJaina = new LegendaryHero
      {
        UnitType = Constants.UNIT_HJAI_ARCHMAGE_OF_DALARAN_DALARAN,
        Name = "Jaina Proudmoore"
      };
      LegendaryHeroManager.Register(LegendJaina);

      LegendMedivh = new LegendaryHero
      {
        UnitType = FourCC("Haah"),
        StartingXp = 2800
      };
      LegendaryHeroManager.Register(LegendMedivh);

      LegendKalecgos = new LegendaryHero
      {
        UnitType = FourCC("U027"),
        StartingXp = 9800
      };
      LegendaryHeroManager.Register(LegendKalecgos);

      LegendMalygos = new LegendaryHero
      {
        UnitType = FourCC("U026"),
        StartingXp = 10900
      };
      LegendaryHeroManager.Register(LegendMalygos);

      LegendDalaranCapital = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(Constants.UNIT_H002_THE_VIOLET_CITADEL_DALARAN),
        DeathMessage =
          "The Violet Citadel, the ultimate bastion of arcane knowledge in the Eastern Kingdoms, crumbles like a sand castle."
      };
      CapitalManager.Register(LegendDalaranCapital);
      LegendDalaranCapital.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_N03G_VIOLET_TOWER, new Point(9084, 4979)));
      LegendDalaranCapital.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_N03G_VIOLET_TOWER, new Point(9008, 4092)));
      LegendDalaranCapital.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_N03G_VIOLET_TOWER, new Point(9864, 4086)));

      LegendAntonidas = new LegendaryHero
      {
        UnitType = FourCC("Hant"),
        StartingXp = 1000,
        DeathMessage =
          "Archmage Antonidas has been cut down, his vast knowledge forever lost with his death. The mages of Dalaran have lost their brightest mind."
      };
      LegendAntonidas.AddUnitDependency(LegendDalaranCapital.Unit);
      LegendaryHeroManager.Register(LegendAntonidas);
    }
  }
}