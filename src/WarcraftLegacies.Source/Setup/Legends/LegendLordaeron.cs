using MacroTools;
using MacroTools.FactionSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.Legends
{
  public static class LegendLordaeron
  {
    public static Legend? Uther { get; private set; }
    public static Legend? Arthas { get; private set; }
    public static Legend? Mograine { get; private set; }
    public static Legend? Garithos { get; private set; }
    public static Legend? Goodchild { get; private set; }
    public static Legend? CapitalPalace { get; private set; }
    public static Legend? Stratholme { get; private set; }
    public static Legend? TyrsHand { get; private set; }

    public static void Setup()
    {
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
        Unit = PreplacedUnitSystem.GetUnit(Constants.UNIT_H000_CAPITAL_PALACE_LORDAERON),
        DeathMessage = "The capital city of Lordaeron has been razed, and King Terenas is dead."
      };
      Legend.Register(CapitalPalace);
      CapitalPalace.AddProtector(PreplacedUnitSystem.GetUnit(Constants.UNIT_H006_IMPROVED_GUARD_TOWER, new Point(8686, 8862)));
      CapitalPalace.AddProtector(PreplacedUnitSystem.GetUnit(Constants.UNIT_H006_IMPROVED_GUARD_TOWER, new Point(9476, 8843)));
      CapitalPalace.AddProtector(PreplacedUnitSystem.GetUnit(Constants.UNIT_H007_IMPROVED_CANNON_TOWER, new Point(8638, 9342)));
      CapitalPalace.AddProtector(PreplacedUnitSystem.GetUnit(Constants.UNIT_H007_IMPROVED_CANNON_TOWER, new Point(9545, 9372)));

      Stratholme = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnit(Constants.UNIT_H01G_STRATHOLME_CASTLE_LORDAERON),
        DeathMessage = "The majestic city of Stratholme has been destroyed."
      };
      Legend.Register(Stratholme);
      Stratholme.AddProtector(PreplacedUnitSystem.GetUnit(Constants.UNIT_H006_IMPROVED_GUARD_TOWER, new Point(14067, 12242)));
      Stratholme.AddProtector(PreplacedUnitSystem.GetUnit(Constants.UNIT_H006_IMPROVED_GUARD_TOWER, new Point(14553, 11593)));
      Stratholme.AddProtector(PreplacedUnitSystem.GetUnit(Constants.UNIT_H006_IMPROVED_GUARD_TOWER, new Point(15359, 11612)));

      TyrsHand = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnit(Constants.UNIT_H030_TYR_S_HAND_CITADEL_LORDAERON),
        DeathMessage = "Tyr's Hand, the bastion of human power in Lordaeron, has fallen."
      };
      Legend.Register(TyrsHand);
      TyrsHand.AddProtector(PreplacedUnitSystem.GetUnit(Constants.UNIT_HCTW_CANNON_TOWER, new Point(20652, 8057)));
      TyrsHand.AddProtector(PreplacedUnitSystem.GetUnit(Constants.UNIT_H007_IMPROVED_CANNON_TOWER, new Point(20024, 8123)));
      TyrsHand.AddProtector(PreplacedUnitSystem.GetUnit(Constants.UNIT_H007_IMPROVED_CANNON_TOWER, new Point(20042, 7420)));

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