using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Zandalar
{
  public sealed class QuestGoldenFleet : QuestData{

  
    private const int QUEST_RESEARCH_ID = FourCC("R06W")   ;//This research is given when the quest is completed
  


    protected override string CompletionPopup => "Rastakhan is now trainable && Direhorn are available";

    protected override string CompletionDescription => "Rastakhan is trainable at the altar && Direhorns are trainable";

    protected override void OnComplete(){
    }

    protected override void OnAdd( ){
      Holder.ModObjectLimit(QUEST_RESEARCH_ID, 1);
    }

    public  thistype ( ){

      this.AddQuestItem(new QuestItemTrain(FourCC("o04W"),)o049), 5));
      ResearchId = QUEST_RESEARCH_ID;
      ;;
    }


  }
}
