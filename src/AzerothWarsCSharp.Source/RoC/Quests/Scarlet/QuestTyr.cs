public class QuestTyr{

 
    private const int RESEARCH_ID = FourCC(R03R)   ;//This research is given when the quest is completed
  


    private string operator CompletionPopup( ){
      return "TyrFourCC(s Hand has joined the war && its military is now free to assist the " + this.Holder.Team.Name + ".";
    }

    private string operator CompletionDescription( ){
      return "Control of all units in TyrFourCC(s Hand";
    }

    private void OnFail( ){
      RescueNeutralUnitsInRect(gg_rct_TyrUnlock, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    private void OnComplete( ){
      RescueNeutralUnitsInRect(gg_rct_TyrUnlock, this.Holder.Player);
    }

    private void OnAdd( ){
      this.Holder.ModObjectLimit(RESEARCH_ID, 1);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The Scarlet Enclave", "The legions at TyrFourCC(s Hand remain neutral for the moment, but when the time is right, they will align themselves with the Scarlet Crusade.", "ReplaceableTextures\\CommandButtons\\BTNCastle.blp");
      this.AddQuestItem(QuestItemTime.create(1000));
      this.AddQuestItem(QuestItemSelfExists.create());
      this.ResearchId = RESEARCH_ID;
      ;;
    }


}
