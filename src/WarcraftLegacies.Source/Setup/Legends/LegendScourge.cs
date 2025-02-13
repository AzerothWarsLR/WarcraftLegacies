using System.Collections.Generic;
using MacroTools;
using MacroTools.ArtifactSystem;
using MacroTools.LegendSystem;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Setup.Legends
{
  /// <summary>
  /// Responsible for setting up and managing all Scourge <see cref="Legend"/>s.
  /// </summary>
  public sealed class LegendScourge
  {
    public LegendaryHero Kelthuzad { get; }
    public LegendaryHero Anubarak { get; }
    public LegendaryHero Rivendare { get; }
    public LegendaryHero Arthas { get; }
    public Capital TheFrozenThrone { get; }
    public Capital Utgarde { get; }

    /// <summary>
    /// Sets up <see cref="LegendScourge"/>.
    /// </summary>
    /// <param name="preplacedUnitSystem">A system for finding preplaced units on the map.</param>
    public LegendScourge(PreplacedUnitSystem preplacedUnitSystem)
    {
      Kelthuzad = new LegendaryHero("Kel'thuzad")
      {
        UnitType = FourCC("U001"),
        PermaDies = true,
        DeathSfx = @"Abilities\Spells\Undead\DeathCoil\DeathCoilSpecialArt.mdl",
        StartingXp = 2800
      };

      Anubarak = new LegendaryHero("Anub'arak")
      {
        UnitType = FourCC("Uanb")
      };

      Rivendare = new LegendaryHero("Baron Rivendare")
      {
        UnitType = FourCC("U00A"),
        StartingXp = 2800
      };

      Arthas = new LegendaryHero("Arthas Menethil")
      {
        UnitType = UNIT_UEAR_CHAMPION_OF_THE_SCOURGE_SCOURGE,
        StartingXp = 4000,
        StartingArtifacts = new List<Artifact>
        {
          new(CreateItem(ITEM_ZB07_FROSTMOURNE, Regions.ArtifactDummyInstance.Center.X, Regions.ArtifactDummyInstance.Center.Y))
        }
      };

      Utgarde = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("h00O")),
        Capturable = true
      };

      TheFrozenThrone = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(UNIT_U000_FROZEN_THRONE_SCOURGE_MAIN),
        Essential = true,
        Capturable = true
      };
    }
      
    public void RegisterLegends(PreplacedUnitSystem preplacedUnitSystem)
    {
      LegendaryHeroManager.Register(Kelthuzad);
      LegendaryHeroManager.Register(Anubarak);
      LegendaryHeroManager.Register(Rivendare);
      LegendaryHeroManager.Register(Arthas);
      CapitalManager.Register(TheFrozenThrone);
      TheFrozenThrone.AddProtector(preplacedUnitSystem.GetUnit(UNIT_N094_ICECROWN_OBELISK_RED, new Point(-3655, 20220)));
      TheFrozenThrone.AddProtector(preplacedUnitSystem.GetUnit(UNIT_N094_ICECROWN_OBELISK_RED, new Point(-3015, 20762)));
      TheFrozenThrone.AddProtector(preplacedUnitSystem.GetUnit(UNIT_N094_ICECROWN_OBELISK_RED, new Point(2165, 20583)));
      TheFrozenThrone.AddProtector(preplacedUnitSystem.GetUnit(UNIT_N094_ICECROWN_OBELISK_RED, new Point(-3638, 23374)));
      CapitalManager.Register(Utgarde);
    }
  }
}