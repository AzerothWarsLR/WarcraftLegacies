using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Sentinels
{
  public sealed class QuestAstranaar : QuestData{


    protected override string CompletionPopup => "Astranaar has been relieved && has joined the Sentinels in their war effort";

    protected override string CompletionDescription => "Control of all units in Astranaar Outpost && Darnassus";

    private void OnFail( ){
      GeneralHelpers.RescueNeutralUnitsInRect(Regions.AstranaarUnlock.Rect, Player(PLAYER_NEUTRAL_AGGRESSIVE));
      GeneralHelpers.RescueNeutralUnitsInRect(Regions.TeldrassilUnlock1.Rect, Player(PLAYER_NEUTRAL_AGGRESSIVE));
      GeneralHelpers.RescueNeutralUnitsInRect(Regions.TeldrassilUnlock2.Rect, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(){
      GeneralHelpers.RescueNeutralUnitsInRect(Regions.AstranaarUnlock.Rect, this.Holder.Player);
      GeneralHelpers.RescueNeutralUnitsInRect(Regions.TeldrassilUnlock1.Rect, this.Holder.Player);
      GeneralHelpers.RescueNeutralUnitsInRect(Regions.TeldrassilUnlock2.Rect, this.Holder.Player);
      AdjustPlayerStateBJ( 200, this.Holder.Player, PLAYER_STATE_RESOURCE_LUMBER );
      AdjustPlayerStateBJ( 100, this.Holder.Player, PLAYER_STATE_RESOURCE_GOLD );
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Astranaar Stronghold", "Darkshore is under attack by some Murloc. We should deal with them swiftly and){ make for the Astranaar Outpost. Clearing the Murlocs will also reestablish communication with Darnassus.", "ReplaceableTextures\\CommandButtons\\BTNMurloc.blp");
      this.AddQuestItem(new QuestItemLegendReachRect(LEGEND_TYRANDE, Regions.AstranaarUnlock.Rect, "Astranaar Outpost"));
      this.AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n02U"))));
      this.AddQuestItem(new QuestItemExpire(1430));
      this.AddQuestItem(new QuestItemSelfExists());
      ;;
    }


  }
}
