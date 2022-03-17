namespace AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs
{
  public class QuestItemDontCompleteQuest{


    private QuestData target = 0;
    private static int count = 0;
    private static thistype[] byIndex;

    private void OnAdd( ){
      this.Progress = QUEST_PROGRESS_COMPLETE;
    }

    public void OnQuestProgressChanged( ){
      if (this.target.Progress == QUEST_PROGRESS_COMPLETE){
        this.Progress = QUEST_PROGRESS_FAILED;
      }
    }

    public static void OnAnyQuestProgressChanged( ){
      int i = 0;
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
        BJDebugMsg("Parameter target of QuestItemDontCompleteQuest can!be 0");
      }

      this.target = target;
      this.Description = "Do !complete the quest " + target.Title;
      thistype.byIndex[thistype.count] = this;
      thistype.count = thistype.count + 1;
      ;;
    }



    private static void OnInit( ){
      trigger trig = CreateTrigger();
      QuestProgressChanged.register(trig);
      TriggerAddAction(trig,  QuestItemDontCompleteQuest.OnAnyQuestProgressChanged);
    }

  }
}
