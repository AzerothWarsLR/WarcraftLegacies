public class QuestExplosiveEngineering{

  
    private const int QUEST_RESEARCH_ID = FourCC(R01F)   ;//This research is given when the quest is completed
  


    private string operator CompletionPopup( ){
      return "Gazlowee is now trainable";
    }

    private string operator CompletionDescription( ){
      return "Gazlowee is trainable at the altar";
    }

    private void OnComplete( ){
    }

    public  thistype ( ){

      this.AddQuestItem(QuestItemTrain.create(FourCC(n0AQ),)h04Z), 4));
      this.ResearchId = QUEST_RESEARCH_ID;
      ;;
    }


}
