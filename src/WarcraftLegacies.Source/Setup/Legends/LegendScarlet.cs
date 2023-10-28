using System.Collections.Generic;
using MacroTools;
using MacroTools.ArtifactSystem;
using MacroTools.Extensions;
using MacroTools.LegendSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

#pragma warning disable CS1591

namespace WarcraftLegacies.Source.Setup.Legends
{
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
        UnitType = Constants.UNIT_H08G_GRAND_CRUSADER_SCARLET,
        StartingXp = 4000
      };

      Renault = new LegendaryHero("Renault Mograine")
      {
        UnitType = Constants.UNIT_H0A2_SCARLET_COMMANDER_SCARLET,
        StartingXp = 4000
      };

      Brigitte = new LegendaryHero("Brigitte Abendis")
      {
        UnitType = Constants.UNIT_H00Y_HIGH_GENERAL_SCARLET,
        StartingXp = 4000
      };

      Sally = new LegendaryHero("Sally Whitemane")
      {
        UnitType = Constants.UNIT_H08H_HIGH_INQUISITOR_SCARLET,
        StartingXp = 8800
      };

      CrimsonCathedral = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(Constants.UNIT_H09L_CRIMSON_CATHEDRAL_SCARLET),
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
}