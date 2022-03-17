public class QuestLumberQuota{

  
    private const int RESEARCH_ID = FourCC(R05O)         ;//This research is required to complete the quest
    private const int QUEST_RESEARCH_ID = FourCC(R05R)   ;//This research is given when the quest is completed
  


    private string operator CompletionPopup( ){
      return "Orgrimmar has been founded && has joined us && the " + this.Holder.Team.Name + ".";
    }

    private string operator CompletionDescription( ){
      return "Control of all units in Orgrimmar, able to train Varok";
    }

    private void OnFail( ){
      RescueNeutralUnitsInRect(gg_rct_Orgrimmar, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    private void OnComplete( ){
      RescueNeutralUnitsInRect(gg_rct_Orgrimmar, this.Holder.Player);
      if (GetLocalPlayer() == this.Holder.Player){
        PlayThematicMusicBJ("war3mapImported\\OrgrimmarTheme.mp3");
      }
    }

    private void OnAdd( ){
      this.Holder.ModObjectLimit(RESEARCH_ID, 1);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("To Tame a Land", "This new continent is ripe for opportunity, if (the Horde is going to survive, a new city needs to be built.", "ReplaceableTextures\\CommandButtons\\BTNFortress.blp");
      this.AddQuestItem(QuestItemResearch.create(RESEARCH_ID, FourCC(o02S)));
      this.AddQuestItem(QuestItemExpire.create(1500));
      this.AddQuestItem(QuestItemSelfExists.create());
      this.ResearchId = QUEST_RESEARCH_ID;
      ;;
    }


}
