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
      RescueNeutralUnitsInRect(Regions.AstranaarUnlock.Rect, Player(PLAYER_NEUTRAL_AGGRESSIVE));
      RescueNeutralUnitsInRect(Regions.TeldrassilUnlock1.Rect, Player(PLAYER_NEUTRAL_AGGRESSIVE));
      RescueNeutralUnitsInRect(Regions.TeldrassilUnlock2.Rect, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(){
      RescueNeutralUnitsInRect(Regions.AstranaarUnlock.Rect, Holder.Player);
      RescueNeutralUnitsInRect(Regions.TeldrassilUnlock1.Rect, Holder.Player);
      RescueNeutralUnitsInRect(Regions.TeldrassilUnlock2.Rect, Holder.Player);
      AdjustPlayerStateBJ( 200, Holder.Player, PLAYER_STATE_RESOURCE_LUMBER );
      AdjustPlayerStateBJ( 100, Holder.Player, PLAYER_STATE_RESOURCE_GOLD );
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Astranaar Stronghold", "Darkshore is under attack by some Murloc. We should deal with them swiftly and){ make for the Astranaar Outpost. Clearing the Murlocs will also reestablish communication with Darnassus.", "ReplaceableTextures\\CommandButtons\\BTNMurloc.blp");
      this.AddQuestItem(new QuestItemLegendReachRect(LEGEND_TYRANDE, Regions.AstranaarUnlock.Rect, "Astranaar Outpost"));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n02U"))));
      AddQuestItem(new QuestItemExpire(1430));
      AddQuestItem(new QuestItemSelfExists());
      ;;
    }


  }
}
