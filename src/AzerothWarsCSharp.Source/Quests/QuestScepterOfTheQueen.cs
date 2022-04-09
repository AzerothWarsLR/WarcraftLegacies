using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests
{
  public sealed class QuestScepterOfTheQueen : QuestData
  {
    private static int _researchId = FourCC("R02O");

    public thistype()
    {
      thistype this = thistype.allocate("Royal Plunder",
        "Remnants of the ancient Highborne survive within the ruins of Dire Maul. If Feathermoon Stronghold falls, it would become a simple matter to slaughter the Highborne && plunder their artifacts.",
        "ReplaceableTextures\\CommandButtons\\BTNNagaWeaponUp2blp");
      this.AddQuestItem(new QuestItemLegendNotPermanentlyDead(LEGEND_STONEMAUL));
      AddQuestItem(new QuestItemLegendDead(LEGEND_FEATHERMOON));
      this.AddQuestItem(new QuestItemAnyUnitInRect(Regions.HighBourne, "Dire Maul".Rect, true));
      ;
      ;
    }

    public QuestScepterOfTheQueen() : base("Return to the Fold",
      "Remnants of the ancient Highborne survive within the ruins of Dire Maul. If Stonemaul falls, it would be safe for them to come out.",
      "ReplaceableTextures\\CommandButtons\\BTNNagaWeaponUp2blp")
    {
      this.AddQuestItem(new QuestItemLegendNotPermanentlyDead(LEGEND_FEATHERMOON));
      AddQuestItem(new QuestItemLegendDead(LEGEND_STONEMAUL));
      this.AddQuestItem(new QuestItemAnyUnitInRect(Regions.HighBourne, "Dire Maul".Rect, true));
      ;
      ;
    }


    protected override string CompletionPopup =>
      "The Highborne are no longer implicitly defended by the Night Elven presence at Feathermoon Stronghold. The Horde unleashes their full might against these Night Elven arcanists.";

    protected override string RewardDescription =>
      "Gain the Scepter of the Queen && turn all units in Dire Maul hostile";

    protected override string CompletionPopup =>
      "The ShenFourCC(dralar, the Highborne survivors of the Sundering, swear allegiance to their fellow Night Elves. As a sign of their loyalty, they offer up an artifact they have guarded for thousands of years: the Scepter of the Queen.";

    protected override string RewardDescription =>
      "Gain the Scepter of the Queen && control of all units in Dire Maul";

    protected override void OnComplete()
    {
      SetItemPosition(ARTIFACT_SCEPTEROFTHEQUEEN.Item, GetRectCenterX(Regions.HighBourne).Rect,
        GetRectCenterY(gg_rct_HighBourne));
      RescueNeutralUnitsInRect(Regions.HighBourne.Rect, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnFail()
    {
      Holder.ModObjectLimit(thistype.researchId, -Faction.UNLIMITED);
    }

    protected override void OnComplete()
    {
      SetItemPosition(ARTIFACT_SCEPTEROFTHEQUEEN.Item, GetRectCenterX(Regions.HighBourne).Rect,
        GetRectCenterY(gg_rct_HighBourne));
      RescueNeutralUnitsInRect(Regions.HighBourne.Rect, Holder.Player);
      SetPlayerTechResearched(Holder.Player, thistype.researchId, 1);
    }

    protected override void OnAdd()
    {
      Holder.ModObjectLimit(thistype.researchId, Faction.UNLIMITED);
    }


    public static void Setup()
    {
      //Make the Shen)dralar starting units invulnerable
      group tempGroup = CreateGroup();
      unit u;
      GroupEnumUnitsInRect(tempGroup, Regions.HighBourne.Rect, null);
      while (true)
      {
        u = FirstOfGroup(tempGroup);
        if (u == null) break;
        if (GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE)) SetUnitInvulnerable(u, true);
        GroupRemoveUnit(tempGroup, u);
      }
    }
  }
}