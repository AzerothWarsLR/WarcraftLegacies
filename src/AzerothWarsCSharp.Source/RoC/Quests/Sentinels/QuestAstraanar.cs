public class QuestAstranaar{


    private string operator CompletionPopup( ){
      return "Astranaar has been relieved && has joined the Sentinels in their war effort";
    }

    private string operator CompletionDescription( ){
      return "Control of all units in Astranaar Outpost && Darnassus";
    }

    private void OnFail( ){
      RescueNeutralUnitsInRect(gg_rct_AstranaarUnlock, Player(PLAYER_NEUTRAL_AGGRESSIVE));
      RescueNeutralUnitsInRect(gg_rct_TeldrassilUnlock1, Player(PLAYER_NEUTRAL_AGGRESSIVE));
      RescueNeutralUnitsInRect(gg_rct_TeldrassilUnlock2, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    private void OnComplete( ){
      RescueNeutralUnitsInRect(gg_rct_AstranaarUnlock, this.Holder.Player);
      RescueNeutralUnitsInRect(gg_rct_TeldrassilUnlock1, this.Holder.Player);
      RescueNeutralUnitsInRect(gg_rct_TeldrassilUnlock2, this.Holder.Player);
      AdjustPlayerStateBJ( 200, this.Holder.Player, PLAYER_STATE_RESOURCE_LUMBER );
      AdjustPlayerStateBJ( 100, this.Holder.Player, PLAYER_STATE_RESOURCE_GOLD );
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Astranaar Stronghold", "Darkshore is under attack by some Murloc. We should deal with them swiftly and){ make for the Astranaar Outpost. Clearing the Murlocs will also reestablish communication with Darnassus.", "ReplaceableTextures\\CommandButtons\\BTNMurloc.blp");
      this.AddQuestItem(QuestItemLegendReachRect.create(LEGEND_TYRANDE, gg_rct_AstranaarUnlock, "Astranaar Outpost"));
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType(FourCC(n02U))));
      this.AddQuestItem(QuestItemExpire.create(1430));
      this.AddQuestItem(QuestItemSelfExists.create());
      ;;
    }


}
