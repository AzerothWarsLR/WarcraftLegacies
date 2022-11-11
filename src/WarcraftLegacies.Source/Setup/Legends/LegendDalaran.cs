using MacroTools;
using MacroTools.FactionSystem;
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
    public static Legend? LegendAntonidas { get; private set; }
    
    /// <summary>
    /// Former Guardian of Tirisfal.
    /// </summary>
    public static Legend? LegendMedivh { get; private set; }
    
    /// <summary>
    /// Antonidas' best student.
    /// </summary>
    public static Legend? LegendJaina { get; private set; }
    
    /// <summary>
    /// Powerful Blue Dragon and sorcerer.
    /// </summary>
    public static Legend? LegendKalecgos { get; private set; }
    
    /// <summary>
    /// Aspect of the Blue Dragonflight.
    /// </summary>
    public static Legend? LegendMalygos { get; private set; }
    
    /// <summary>
    /// Dalaran city capital.l
    /// </summary>
    public static Legend? LegendDalaranCapital { get; private set; }

    /// <summary>
    /// Sets up all Dalaran <see cref="Legend"/>s.
    /// </summary>
    public static void Setup()
    {
      LegendJaina = new Legend
      {
        UnitType = Constants.UNIT_HJAI_ARCHMAGE_OF_DALARAN_DALARAN,
        Name = "Jaina Proudmoore"
      };
      Legend.Register(LegendJaina);

      LegendMedivh = new Legend
      {
        UnitType = FourCC("Haah"),
        StartingXp = 2800
      };
      Legend.Register(LegendMedivh);

      LegendKalecgos = new Legend
      {
        UnitType = FourCC("U027"),
        StartingXp = 9800
      };
      Legend.Register(LegendKalecgos);

      LegendMalygos = new Legend
      {
        UnitType = FourCC("U026"),
        StartingXp = 10900
      };
      Legend.Register(LegendMalygos);

      LegendDalaranCapital = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnit(Constants.UNIT_H002_THE_VIOLET_CITADEL_DALARAN),
        DeathMessage =
          "The Violet Citadel, the ultimate bastion of arcane knowledge in the Eastern Kingdoms, crumbles like a sand castle."
      };
      Legend.Register(LegendDalaranCapital);
      LegendDalaranCapital.AddProtector(PreplacedUnitSystem.GetUnit(Constants.UNIT_N03G_VIOLET_TOWER, new Point(9084, 4979)));
      LegendDalaranCapital.AddProtector(PreplacedUnitSystem.GetUnit(Constants.UNIT_N03G_VIOLET_TOWER, new Point(9008, 4092)));
      LegendDalaranCapital.AddProtector(PreplacedUnitSystem.GetUnit(Constants.UNIT_N03G_VIOLET_TOWER, new Point(9864, 4086)));

      LegendAntonidas = new Legend
      {
        UnitType = FourCC("Hant"),
        StartingXp = 1000,
        DeathMessage =
          "Archmage Antonidas has been cut down, his vast knowledge forever lost with his death. The mages of Dalaran have lost their brightest mind."
      };
      LegendAntonidas.AddUnitDependency(LegendDalaranCapital.Unit);
      Legend.Register(LegendAntonidas);
    }
  }
}