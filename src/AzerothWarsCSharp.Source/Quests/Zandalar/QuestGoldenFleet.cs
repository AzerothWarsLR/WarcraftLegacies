using AzerothWarsCSharp.Source.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Zandalar
{
  public class QuestGoldenFleet{

  
    private const int QUEST_RESEARCH_ID = FourCC(R06W)   ;//This research is given when the quest is completed
  


    protected override string CompletionPopup => 
      return "Rastakhan is now trainable && Direhorn are available";
    }

    protected override string CompletionDescription => 
      return "Rastakhan is trainable at the altar && Direhorns are trainable";
    }

    protected override void OnComplete(){
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
}
