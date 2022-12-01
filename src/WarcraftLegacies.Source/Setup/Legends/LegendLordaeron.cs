using MacroTools;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
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
    public static Legend? Terenas { get; private set; }
    
    /// <summary>
    /// Leader of the Silver Hand.
    /// </summary>
    public static Legend? Uther { get; private set; }
    
    /// <summary>
    /// Prince of Lordaeron.
    /// </summary>
    public static Legend? Arthas { get; private set; }
    
    /// <summary>
    /// Legendary wielder of Ashbringer.
    /// </summary>
    public static Legend? Mograine { get; private set; }
    
    /// <summary>
    /// Xenophobic human general.
    /// </summary>
    public static Legend? Garithos { get; private set; }
    
    /// <summary>
    /// High Commander of the Scarlet Crusade.
    /// </summary>
    public static Legend? Goodchild { get; private set; }
    
    /// <summary>
    /// Capital of Lordaeron.
    /// </summary>
    public static Legend? CapitalPalace { get; private set; }
    
    /// <summary>
    /// The place Arthas culls in the Culling of Stratholme campaign mission.
    /// </summary>
    public static Legend? Stratholme { get; private set; }
    
    /// <summary>
    /// A well fortified city.
    /// </summary>
    public static Legend? TyrsHand { get; private set; }

    /// <summary>
    /// Sets up all Lordaeron <see cref="Legend"/>s.
    /// </summary>
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem, ArtifactSetup artifactSetup)
    {
      Terenas = new Legend
      {
        Unit = preplacedUnitSystem.GetUnit(Constants.UNIT_NEMI_KING_TERENAS_MENETHIL_LORDAERON)
      };
      Legend.Register(Terenas);
      
      Mograine = new Legend
      {
        UnitType = Constants.UNIT_H01J_THE_ASHBRINGER_LORDAERON,
        StartingXp = 2800
      };
      Legend.Register(Mograine);

      Garithos = new Legend
      {
        UnitType = Constants.UNIT_HLGR_GRAND_MARSHAL_SCARLET,
        StartingXp = 2800
      };
      Legend.Register(Garithos);

      Goodchild = new Legend
      {
        UnitType = Constants.UNIT_E000_IMPROVED_ANCIENT_PROTECTOR_DRUIDS,
        StartingXp = 2800
      };
      Legend.Register(Goodchild);

      CapitalPalace = new Legend
      {
        Unit = preplacedUnitSystem.GetUnit(Constants.UNIT_H000_CAPITAL_PALACE_LORDAERON),
        DeathMessage = "The capital city of Lordaeron has been razed, and King Terenas is dead."
      };
      Legend.Register(CapitalPalace);
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

      Stratholme = new Legend
      {
        Unit = preplacedUnitSystem.GetUnit(Constants.UNIT_H01G_STRATHOLME_CASTLE_LORDAERON),
        DeathMessage = "The majestic city of Stratholme has been destroyed."
      };
      Legend.Register(Stratholme);
      Stratholme.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_H006_IMPROVED_GUARD_TOWER, new Point(14067, 12242)));
      Stratholme.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_H006_IMPROVED_GUARD_TOWER, new Point(14553, 11593)));
      Stratholme.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_H006_IMPROVED_GUARD_TOWER, new Point(15359, 11612)));

      TyrsHand = new Legend
      {
        Unit = preplacedUnitSystem.GetUnit(Constants.UNIT_H030_TYR_S_HAND_CITADEL_LORDAERON),
        DeathMessage = "Tyr's Hand, the bastion of human power in Lordaeron, has fallen."
      };
      Legend.Register(TyrsHand);
      TyrsHand.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_HCTW_CANNON_TOWER, new Point(20652, 8057)));
      TyrsHand.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_H007_IMPROVED_CANNON_TOWER, new Point(20024, 8123)));
      TyrsHand.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_H007_IMPROVED_CANNON_TOWER, new Point(20042, 7420)));

      Uther = new Legend
      {
        UnitType = Constants.UNIT_HUTH_LEADER_OF_THE_SILVER_HAND_LORDAERON,
        DeathMessage =
          "Uther the Lightbringer makes his last stand, perishing in the defense of the light. Lordaeron, and humanity itself, has lost one of its finest exemplars in this dark hour.",
        PlayerColor = PLAYER_COLOR_LIGHT_BLUE,
        StartingXp = 1000
      };
      Legend.Register(Uther);

      Arthas = new Legend
      {
        UnitType = Constants.UNIT_HART_CROWN_PRINCE_OF_LORDAERON_LORDAERON,
        PlayerColor = PLAYER_COLOR_BLUE
      };
      Legend.Register(Arthas);
    }
  }
}