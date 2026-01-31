using System.Collections.Generic;
using MacroTools.ArtifactSystem;
using MacroTools.Legends;
using MacroTools.PreplacedWidgetsSystem;

namespace WarcraftLegacies.Source.Setup.Legends;

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
  public LegendScourge()
  {
    Kelthuzad = new LegendaryHero("Kel'thuzad")
    {
      UnitType = UNIT_U001_MASTER_OF_THE_CULT_OF_THE_DAMNED_SCOURGE_NECROMANCER,
      PermaDies = true,
      DeathSfx = @"Abilities\Spells\Undead\DeathCoil\DeathCoilSpecialArt.mdl",
      StartingXp = 2800
    };

    Anubarak = new LegendaryHero("Anub'arak")
    {
      UnitType = UNIT_UANB_KING_OF_AZJOL_NERUB_SCOURGE
    };

    Rivendare = new LegendaryHero("Baron Rivendare")
    {
      UnitType = UNIT_U00A_SCOURGE_COMMANDER_SCOURGE,
      StartingXp = 2800
    };

    Arthas = new LegendaryHero("Arthas Menethil")
    {
      UnitType = UNIT_UEAR_CHAMPION_OF_THE_SCOURGE_SCOURGE,
      StartingXp = 4000,
      StartingArtifacts = new List<Artifact>
      {
        new(item.Create(ITEM_ZB07_FROSTMOURNE, Regions.ArtifactDummyInstance.Center.X, Regions.ArtifactDummyInstance.Center.Y))
      }
    };

    Utgarde = new Capital
    {
      Unit = PreplacedWidgets.Units.Get(UNIT_H00O_UTGARDE_KEEP_SCOURGE_OTHER),
      Capturable = true
    };

    TheFrozenThrone = new Capital
    {
      Unit = PreplacedWidgets.Units.Get(UNIT_U000_FROZEN_THRONE_SCOURGE_MAIN),
      Essential = true,
      Capturable = true
    };
  }

  public void RegisterLegends()
  {
    LegendaryHeroManager.Register(Kelthuzad);
    LegendaryHeroManager.Register(Anubarak);
    LegendaryHeroManager.Register(Rivendare);
    LegendaryHeroManager.Register(Arthas);
    CapitalManager.Register(TheFrozenThrone);
    TheFrozenThrone.AddProtector(PreplacedWidgets.Units.GetClosest(UNIT_N094_ICECROWN_OBELISK_SCOURGE, -3655, 20220));
    TheFrozenThrone.AddProtector(PreplacedWidgets.Units.GetClosest(UNIT_N094_ICECROWN_OBELISK_SCOURGE, -3015, 20762));
    TheFrozenThrone.AddProtector(PreplacedWidgets.Units.GetClosest(UNIT_N094_ICECROWN_OBELISK_SCOURGE, 2165, 20583));
    TheFrozenThrone.AddProtector(PreplacedWidgets.Units.GetClosest(UNIT_N094_ICECROWN_OBELISK_SCOURGE, -3638, 23374));
    CapitalManager.Register(Utgarde);
  }
}
