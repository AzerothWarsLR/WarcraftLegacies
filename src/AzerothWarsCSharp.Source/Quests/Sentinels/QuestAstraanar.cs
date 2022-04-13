using AzerothWarsCSharp.MacroTools.FactionSystem;
using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup.Legends;
using static War3Api.Common; using static War3Api.Blizzard;

namespace AzerothWarsCSharp.Source.Quests.Sentinels
{
  public sealed class QuestAstranaar : QuestData
  {
    public QuestAstranaar() : base("Astranaar Stronghold",
      "Darkshore is under attack by some Murloc. We should deal with them swiftly and){ make for the Astranaar Outpost. Clearing the Murlocs will also reestablish communication with Darnassus.",
      "ReplaceableTextures\\CommandButtons\\BTNMurloc.blp")
    {
      AddQuestItem(new QuestItemLegendReachRect(LegendSentinels.legendTyrande, Regions.AstranaarUnlock,
        "Astranaar Outpost"));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n02U"))));
      AddQuestItem(new QuestItemExpire(1430));
      AddQuestItem(new QuestItemSelfExists());
    }

    protected override string CompletionPopup =>
      "Astranaar has been relieved and has joined the Sentinels in their war effort";

    protected override string RewardDescription => "Control of all units in Astranaar Outpost and Darnassus";

    protected override void OnFail()
    {
      RescueNeutralUnitsInRect(Regions.AstranaarUnlock.Rect, Player(PLAYER_NEUTRAL_AGGRESSIVE));
      RescueNeutralUnitsInRect(Regions.TeldrassilUnlock1.Rect, Player(PLAYER_NEUTRAL_AGGRESSIVE));
      RescueNeutralUnitsInRect(Regions.TeldrassilUnlock2.Rect, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete()
    {
      RescueNeutralUnitsInRect(Regions.AstranaarUnlock.Rect, Holder.Player);
      RescueNeutralUnitsInRect(Regions.TeldrassilUnlock1.Rect, Holder.Player);
      RescueNeutralUnitsInRect(Regions.TeldrassilUnlock2.Rect, Holder.Player);
      AdjustPlayerStateBJ(200, Holder.Player, PLAYER_STATE_RESOURCE_LUMBER);
      AdjustPlayerStateBJ(100, Holder.Player, PLAYER_STATE_RESOURCE_GOLD);
    }
  }
}