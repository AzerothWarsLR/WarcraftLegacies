namespace AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs
{
  public class QuestItemCompleteQuest{


    private QuestData target = 0;
    private static int count = 0;
    private static thistype[] byIndex;

    public void OnQuestProgressChanged( ){
      if (target.Progress == QUEST_PROGRESS_COMPLETE){
        this.Progress = QUEST_PROGRESS_COMPLETE;
      }else if (target.Progress == QUEST_PROGRESS_FAILED){
        this.Progress = QUEST_PROGRESS_FAILED;
      }
    }

    public static void OnAnyQuestProgressChanged( ){
      var i = 0;
      thistype loopItem;
      while(true){
        if ( i == thistype.count){ break; }
        loopItem = thistype.byIndex[i];
        if (loopItem.target == GetTriggerQuest()){
          loopItem.OnQuestProgressChanged();
        }
        i = i + 1;
      }
    }

    thistype (QuestData target ){


      if (target == 0){
        BJDebugMsg("Parameter target of QuestItemCompleteQuest can!be 0");
      }

      this.target = target;
      this.Description = "Complete the quest " + target.Title;
      thistype.byIndex[thistype.count] = this;
      thistype.count = thistype.count + 1;
      
    }



    public static void Setup( ){
      trigger trig = CreateTrigger();
      QuestProgressChanged.register(trig);
      TriggerAddAction(trig,  OnAnyQuestProgressChanged);
    }

  }
}
