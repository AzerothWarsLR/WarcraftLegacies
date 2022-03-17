public class QuestGoldenFleet{

  
    private const int QUEST_RESEARCH_ID = FourCC(R06W)   ;//This research is given when the quest is completed
  


    private string operator CompletionPopup( ){
      return "Rastakhan is now trainable && Direhorn are available";
    }

    private string operator CompletionDescription( ){
      return "Rastakhan is trainable at the altar && Direhorns are trainable";
    }

    private void OnComplete( ){
    }

    private void OnAdd( ){
      this.Holder.ModObjectLimit(QUEST_RESEARCH_ID, 1);
    }

    public  thistype ( ){

      this.AddQuestItem(QuestItemTrain.create(FourCC(o04W),)o049), 5));
      this.ResearchId = QUEST_RESEARCH_ID;
      ;;
    }


}
