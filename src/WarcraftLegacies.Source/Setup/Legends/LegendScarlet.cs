using MacroTools.LegendSystem;
using MacroTools.Systems;

#pragma warning disable CS1591

namespace WarcraftLegacies.Source.Setup.Legends;

/// <summary>
/// Responsible for creating and storing all Lordaeron <see cref="Legend"/>s.
/// </summary>
public sealed class LegendScarlet
{
  public LegendaryHero Saiden { get; }
  public LegendaryHero Renault { get; }
  public LegendaryHero Brigitte { get; }
  public LegendaryHero Sally { get; }
  public Capital CrimsonCathedral { get; }

  /// <summary>
  /// Sets up all Lordaeron <see cref="Legend"/>s.
  /// </summary>
  public LegendScarlet(PreplacedUnitSystem preplacedUnitSystem)
  {

    Saiden = new LegendaryHero("Saiden Dethrotan")
    {
      UnitType = UNIT_H08G_GRAND_CRUSADER_SCARLET,
      StartingXp = 5400
    };

    Renault = new LegendaryHero("Renault Mograine")
    {
      UnitType = UNIT_H0A2_SCARLET_COMMANDER_SCARLET,
      StartingXp = 4000
    };

    Brigitte = new LegendaryHero("Brigitte Abendis")
    {
      UnitType = UNIT_H00Y_HIGH_GENERAL_SCARLET,
      StartingXp = 4000
    };

    Sally = new LegendaryHero("Sally Whitemane")
    {
      UnitType = UNIT_H08H_HIGH_INQUISITOR_SCARLET,
      StartingXp = 8800
    };

    CrimsonCathedral = new Capital
    {
      Unit = preplacedUnitSystem.GetUnit(UNIT_H09L_CRIMSON_CATHEDRAL_SCARLET),
      DeathMessage = "The Crimson Cathedral has been destroyed",
    };

  }

  public void RegisterLegends()
  {
    LegendaryHeroManager.Register(Saiden);
    LegendaryHeroManager.Register(Renault);
    LegendaryHeroManager.Register(Brigitte);
    LegendaryHeroManager.Register(Sally);
    CapitalManager.Register(CrimsonCathedral);
  }
}
