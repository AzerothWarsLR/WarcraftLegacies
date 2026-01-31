using System.Collections.Generic;
using MacroTools.Artifacts;
using MacroTools.Extensions;
using MacroTools.Legends;
using MacroTools.PreplacedWidgetsSystem;

namespace WarcraftLegacies.Source.Setup.Legends;

/// <summary>
/// Responsible for creating and storing all Lordaeron <see cref="Legend"/>s.
/// </summary>
public sealed class LegendLordaeron
{
  public LegendaryHero Terenas { get; }
  public LegendaryHero Uther { get; }
  public LegendaryHero Arthas { get; }
  public LegendaryHero Mograine { get; }
  public LegendaryHero Garithos { get; }
  public Capital CapitalPalace { get; }
  public Capital Stratholme { get; }
  public Capital TyrsHand { get; }
  public Capital Monastery { get; }

  /// <summary>
  /// Sets up all Lordaeron <see cref="Legend"/>s.
  /// </summary>
  public LegendLordaeron()
  {
    Terenas = new LegendaryHero("Terenas Menethil")
    {
      Unit = PreplacedWidgets.Units.Get(UNIT_NEMI_KING_TERENAS_MENETHIL_LORDAERON)
    };
    var deathTrigger = trigger.Create();
    deathTrigger.RegisterUnitEvent(Terenas.Unit, unitevent.Death);
    deathTrigger.AddAction(() =>
    {
      if (Artifacts.CrownOfLordaeron.OwningUnit == Terenas.Unit)
      {
        Artifacts.CrownOfLordaeron.Item.SetPosition(Regions.King_Arthas_crown.Center);
      }
    });

    Mograine = new LegendaryHero("Alexandros Mograine")
    {
      UnitType = UNIT_H01J_THE_ASHBRINGER_LORDAERON,
      StartingXp = 2800,
      StartingArtifacts = new List<Artifact>
      {
        new(item.Create(ITEM_I012_ASHBRINGER, Regions.ArtifactDummyInstance.Center.X, Regions.ArtifactDummyInstance.Center.Y))
      }
    };

    Garithos = new LegendaryHero("Garithos")
    {
      UnitType = UNIT_HLGR_GRAND_MARSHAL_SCARLET,
      StartingXp = 2800
    };

    CapitalPalace = new Capital
    {
      Unit = PreplacedWidgets.Units.Get(UNIT_H000_CAPITAL_PALACE_LORDAERON),
      Capturable = true,
      Essential = true
    };
    CapitalPalace.AddProtector(PreplacedWidgets.Units.GetClosest(UNIT_H006_IMPROVED_GUARD_TOWER_LORDAERON_TOWER,
      8686, 8862));
    CapitalPalace.AddProtector(PreplacedWidgets.Units.GetClosest(UNIT_H006_IMPROVED_GUARD_TOWER_LORDAERON_TOWER,
      9476, 8843));
    CapitalPalace.AddProtector(PreplacedWidgets.Units.GetClosest(UNIT_H007_IMPROVED_CANNON_TOWER_LORDAERON_TOWER,
      8638, 9342));
    CapitalPalace.AddProtector(PreplacedWidgets.Units.GetClosest(UNIT_H007_IMPROVED_CANNON_TOWER_LORDAERON_TOWER,
      9545, 9372));

    Stratholme = new Capital
    {
      Unit = PreplacedWidgets.Units.Get(UNIT_H01G_STRATHOLME_CASTLE_LORDAERON_OTHER),
      DeathMessage = "The majestic city of Stratholme has been destroyed.",
      Essential = true
    };
    Stratholme.AddProtector(PreplacedWidgets.Units.GetClosest(UNIT_H007_IMPROVED_CANNON_TOWER_LORDAERON_TOWER,
      14587, 14172));
    Stratholme.AddProtector(PreplacedWidgets.Units.GetClosest(UNIT_H006_IMPROVED_GUARD_TOWER_LORDAERON_TOWER,
      15800, 13242));

    TyrsHand = new Capital
    {
      Unit = PreplacedWidgets.Units.Get(UNIT_H030_TYR_S_HAND_CITADEL_LORDAERON_OTHER),
      DeathMessage = "Tyr's Hand, the bastion of human power in Lordaeron, has fallen.",
      Essential = true
    };
    TyrsHand.AddProtector(PreplacedWidgets.Units.GetClosest(UNIT_HCTW_CANNON_TOWER_LORDAERON_TOWER,
      20652, 8057));
    TyrsHand.AddProtector(PreplacedWidgets.Units.GetClosest(UNIT_H007_IMPROVED_CANNON_TOWER_LORDAERON_TOWER,
      20024, 8123));
    TyrsHand.AddProtector(PreplacedWidgets.Units.GetClosest(UNIT_H007_IMPROVED_CANNON_TOWER_LORDAERON_TOWER,
      20042, 7420));

    Uther = new LegendaryHero("Uther the Lightbringer")
    {
      UnitType = UNIT_HUTH_LEADER_OF_THE_SILVER_HAND_LORDAERON,
      DeathMessage =
        "Uther the Lightbringer makes his last stand, perishing in the defense of the light. Lordaeron, and humanity itself, has lost one of its finest exemplars in this dark hour.",
      PlayerColor = playercolor.LightBlue,
      StartingXp = 2800
    };

    Arthas = new LegendaryHero("Arthas Menethil")
    {
      UnitType = UNIT_HART_CROWN_PRINCE_OF_LORDAERON_LORDAERON,
      PlayerColor = playercolor.Blue,
    };

    Monastery = new Capital
    {
      Unit = PreplacedWidgets.Units.Get(UNIT_H00T_SCARLET_MONASTERY_SCARLET_LORDAERON),
      Capturable = true
    };
  }


  public void RegisterLegends()
  {
    LegendaryHeroManager.Register(Terenas);
    LegendaryHeroManager.Register(Uther);
    LegendaryHeroManager.Register(Arthas);
    LegendaryHeroManager.Register(Mograine);
    LegendaryHeroManager.Register(Garithos);
    CapitalManager.Register(CapitalPalace);
    CapitalManager.Register(Stratholme);
    CapitalManager.Register(TyrsHand);
    CapitalManager.Register(Monastery);
  }
}
