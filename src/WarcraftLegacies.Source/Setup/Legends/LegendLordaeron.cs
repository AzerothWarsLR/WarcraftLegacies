using MacroTools;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.Legends
{
  /// <summary>
  /// Responsible for creating and storing all Lordaeron <see cref="Legend"/>s.
  /// </summary>
  public static class LegendLordaeron
  {
    /// <summary>
    /// King of Lordaeron.
    /// </summary>
    public static LegendaryHero? Terenas { get; private set; }
    
    /// <summary>
    /// Leader of the Silver Hand.
    /// </summary>
    public static LegendaryHero? Uther { get; private set; }
    
    /// <summary>
    /// Prince of Lordaeron.
    /// </summary>
    public static LegendaryHero? Arthas { get; private set; }
    
    /// <summary>
    /// Legendary wielder of Ashbringer.
    /// </summary>
    public static LegendaryHero? Mograine { get; private set; }
    
    /// <summary>
    /// Xenophobic human general.
    /// </summary>
    public static LegendaryHero? Garithos { get; private set; }
    
    /// <summary>
    /// High Commander of the Scarlet Crusade.
    /// </summary>
    public static LegendaryHero? Goodchild { get; private set; }
    
    /// <summary>
    /// Capital of Lordaeron.
    /// </summary>
    public static Capital? CapitalPalace { get; private set; }
    
    /// <summary>
    /// The place Arthas culls in the Culling of Stratholme campaign mission.
    /// </summary>
    public static Capital? Stratholme { get; private set; }
    
    /// <summary>
    /// A well fortified city.
    /// </summary>
    public static Capital? TyrsHand { get; private set; }

    /// <summary>
    /// Sets up all Lordaeron <see cref="Legend"/>s.
    /// </summary>
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem, ArtifactSetup artifactSetup)
    {
      Terenas = new LegendaryHero("Terenas Menethil")
      {
        Unit = preplacedUnitSystem.GetUnit(Constants.UNIT_NEMI_KING_TERENAS_MENETHIL_LORDAERON)
      };
      LegendaryHeroManager.Register(Terenas);
      
      Mograine = new LegendaryHero("Alexandros Mograine")
      {
        UnitType = Constants.UNIT_H01J_THE_ASHBRINGER_LORDAERON,
        StartingXp = 2800
      };
      LegendaryHeroManager.Register(Mograine);

      Garithos = new LegendaryHero("Garithos")
      {
        UnitType = Constants.UNIT_HLGR_GRAND_MARSHAL_SCARLET,
        StartingXp = 2800
      };
      LegendaryHeroManager.Register(Garithos);

      Goodchild = new LegendaryHero("High Commander Goodchilde")
      {
        UnitType = Constants.UNIT_E000_IMPROVED_ANCIENT_PROTECTOR_DRUID_TOWER,
        StartingXp = 2800
      };
      LegendaryHeroManager.Register(Goodchild);

      CapitalPalace = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(Constants.UNIT_H000_CAPITAL_PALACE_LORDAERON),
        DeathMessage = "The capital city of Lordaeron has been razed, and King Terenas is dead."
      };
      CapitalManager.Register(CapitalPalace);
      CapitalPalace.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_H006_IMPROVED_GUARD_TOWER, new Point(8686, 8862)));
      CapitalPalace.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_H006_IMPROVED_GUARD_TOWER, new Point(9476, 8843)));
      CapitalPalace.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_H007_IMPROVED_CANNON_TOWER, new Point(8638, 9342)));
      CapitalPalace.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_H007_IMPROVED_CANNON_TOWER, new Point(9545, 9372)));
      CreateTrigger()
        .RegisterUnitEvent(CapitalPalace.Unit, EVENT_UNIT_DEATH)
        .AddAction(() =>
        {
          Terenas.Unit.Kill();
          artifactSetup.CrownOfLordaeron.Item.SetPosition(Regions.King_Arthas_crown.Center);
          SetDoodadAnimation(Regions.King_Arthas_crown.Center.X, Regions.King_Arthas_crown.Center.Y, 200,
            FourCC("Ysaw"), false, "hide", false);
          SetDoodadAnimation(Regions.King_Arthas_crown.Center.X, Regions.King_Arthas_crown.Center.Y, 200,
            FourCC("D044"), false, "hide", false);
          SetDoodadAnimation(Regions.King_Arthas_crown.Center.X, Regions.King_Arthas_crown.Center.Y, 200,
            FourCC("YObb"), false, "hide", false);
          SetDoodadAnimationRect(Regions.Terenas.Rect, FourCC("YScr"), "show", false);
          DestroyTrigger(GetTriggeringTrigger());
        });

      Stratholme = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(Constants.UNIT_H01G_STRATHOLME_CASTLE_LORDAERON_OTHER),
        DeathMessage = "The majestic city of Stratholme has been destroyed."
      };
      CapitalManager.Register(Stratholme);
      Stratholme.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_H006_IMPROVED_GUARD_TOWER, new Point(14067, 12242)));
      Stratholme.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_H006_IMPROVED_GUARD_TOWER, new Point(14553, 11593)));
      Stratholme.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_H006_IMPROVED_GUARD_TOWER, new Point(15359, 11612)));

      TyrsHand = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(Constants.UNIT_H030_TYR_S_HAND_CITADEL_LORDAERON_OTHER),
        DeathMessage = "Tyr's Hand, the bastion of human power in Lordaeron, has fallen."
      };
      CapitalManager.Register(TyrsHand);
      TyrsHand.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_HCTW_CANNON_TOWER, new Point(20652, 8057)));
      TyrsHand.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_H007_IMPROVED_CANNON_TOWER, new Point(20024, 8123)));
      TyrsHand.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_H007_IMPROVED_CANNON_TOWER, new Point(20042, 7420)));

      Uther = new LegendaryHero("Uther the Lightbringer")
      {
        UnitType = Constants.UNIT_HUTH_LEADER_OF_THE_SILVER_HAND_LORDAERON,
        DeathMessage =
          "Uther the Lightbringer makes his last stand, perishing in the defense of the light. Lordaeron, and humanity itself, has lost one of its finest exemplars in this dark hour.",
        PlayerColor = PLAYER_COLOR_LIGHT_BLUE,
        StartingXp = 1000
      };
      LegendaryHeroManager.Register(Uther);

      Arthas = new LegendaryHero("Arthas Menethil")
      {
        UnitType = Constants.UNIT_HART_CROWN_PRINCE_OF_LORDAERON_LORDAERON,
        PlayerColor = PLAYER_COLOR_BLUE
      };
      LegendaryHeroManager.Register(Arthas);
    }
  }
}