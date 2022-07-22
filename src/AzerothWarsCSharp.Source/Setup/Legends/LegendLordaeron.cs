using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.Legends
{
  public static class LegendLordaeron
  {
    public static Legend LegendUther { get; private set; }
    public static Legend LegendArthas { get; private set; }
    public static Legend LegendMograine { get; private set; }
    public static Legend LegendGarithos { get; private set; }
    public static Legend LegendGoodchild { get; private set; }
    public static Legend LegendCapitalpalace { get; private set; }
    public static Legend LegendStratholme { get; private set; }
    public static Legend LegendTyrshand { get; private set; }

    public static void Setup()
    {
      LegendMograine = new Legend
      {
        UnitType = Constants.UNIT_H01J_THE_ASHBRINGER_LORDAERON,
        StartingXp = 2800
      };
      Legend.Register(LegendMograine);

      LegendGarithos = new Legend
      {
        UnitType = Constants.UNIT_HLGR_GRAND_MARSHAL_SCARLET,
        StartingXp = 2800
      };
      Legend.Register(LegendGarithos);

      LegendGoodchild = new Legend
      {
        UnitType = Constants.UNIT_E000_IMPROVED_ANCIENT_PROTECTOR_DRUIDS,
        StartingXp = 2800
      };
      Legend.Register(LegendGoodchild);

      LegendCapitalpalace = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnit(Constants.UNIT_H000_CAPITAL_PALACE_LORDAERON),
        DeathMessage = "The capital city of Lordaeron has been razed, and King Terenas is dead."
      };
      Legend.Register(LegendCapitalpalace);
      LegendCapitalpalace.AddProtector(PreplacedUnitSystem.GetUnit(Constants.UNIT_H006_IMPROVED_GUARD_TOWER, new Point(8686, 8862)));
      LegendCapitalpalace.AddProtector(PreplacedUnitSystem.GetUnit(Constants.UNIT_H006_IMPROVED_GUARD_TOWER, new Point(9476, 8843)));
      LegendCapitalpalace.AddProtector(PreplacedUnitSystem.GetUnit(Constants.UNIT_H007_IMPROVED_CANNON_TOWER, new Point(8638, 9342)));
      LegendCapitalpalace.AddProtector(PreplacedUnitSystem.GetUnit(Constants.UNIT_H007_IMPROVED_CANNON_TOWER, new Point(9545, 9372)));

      LegendStratholme = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnit(Constants.UNIT_H01G_STRATHOLME_CASTLE_LORDAERON),
        DeathMessage = "The majestic city of Stratholme has been destroyed."
      };
      Legend.Register(LegendStratholme);
      LegendStratholme.Unit.SetInvulnerable(true);

      LegendTyrshand = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnit(Constants.UNIT_H030_TYR_S_HAND_CITADEL_LORDAERON),
        DeathMessage = "Tyr's Hand, the bastion of human power in Lordaeron, has fallen."
      };
      Legend.Register(LegendTyrshand);
      LegendTyrshand.Unit.SetInvulnerable(true);

      LegendUther = new Legend
      {
        UnitType = Constants.UNIT_HUTH_LEADER_OF_THE_SILVER_HAND_LORDAERON,
        DeathMessage =
          "Uther the Lightbringer makes his last stand, perishing in the defense of the light. Lordaeron, and humanity itself, has lost one of its finest exemplars in this dark hour.",
        PlayerColor = PLAYER_COLOR_LIGHT_BLUE,
        StartingXp = 1000
      };
      Legend.Register(LegendUther);

      LegendArthas = new Legend
      {
        UnitType = Constants.UNIT_HART_CROWN_PRINCE_OF_LORDAERON_LORDAERON,
        PlayerColor = PLAYER_COLOR_BLUE
      };
      Legend.Register(LegendArthas);
    }
  }
}