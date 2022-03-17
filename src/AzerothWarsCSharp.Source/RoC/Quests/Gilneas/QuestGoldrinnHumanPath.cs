public class QuestGoldrinnHumanPath{

  
    private const int QUEST_RESEARCH_ID = FourCC(R07U)   ;//This research is given when the quest is completed
  



    boolean operator Global( ){
      return true;
    }

    private string operator CompletionPopup( ){
      return "Goldrinn has joined Gilneas && they remain in the Alliance";
    }

    private string operator CompletionDescription( ){
      return "Goldrinn will be trainable at the altar";
    }

    private void OnComplete( ){
      GOLDRINNELVE_PATH.Progress = QUEST_PROGRESS_FAILED;
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The Twilight Grove", "To understand the plight of her people, Tess will go to the Shrine of Goldrinn in Duskwood to understand what it is to be a Worgen.", "ReplaceableTextures\\CommandButtons\\BTNWorgenHunger.blp");
      this.AddQuestItem(QuestItemLegendReachRect.create(LEGEND_TESS, gg_rct_GoldrinnDuskwood, "Shrine of Goldrinn in Duskwood"));
      this.AddQuestItem(QuestItemLegendNotPermanentlyDead.create(LEGEND_GENN));
      this.ResearchId = QUEST_RESEARCH_ID;
      ;;
    }


}
