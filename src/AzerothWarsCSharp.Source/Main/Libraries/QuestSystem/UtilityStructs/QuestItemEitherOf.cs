namespace AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs
{
  public class QuestItemEitherOf{


    private static int count = 0;
    private static thistype[] byIndex;

    private QuestItemData questItemA;
    private QuestItemData questItemB;

    float operator X( ){
      return questItemA.X;
    }

    float operator Y( ){
      return questItemA.Y;
    }

    thistype (QuestItemData questItemA, QuestItemData questItemB ){

      this.questItemA = questItemA;
      this.questItemB = questItemB;
      questItemA.ParentQuestItem = this;
      questItemB.ParentQuestItem = this;
      this.Description = questItemA.Description + " || " + questItemB.Description;
      thistype.byIndex[thistype.count] = this;
      thistype.count = thistype.count + 1;
      ;;
    }

    void OnAdd( ){
      this.questItemA.OnAdd();
      this.questItemB.OnAdd();
      CheckChildStatus();
    }

    private void CheckChildStatus( ){
      if (this.questItemA.Progress == QUEST_PROGRESS_COMPLETE || this.questItemB.Progress == QUEST_PROGRESS_COMPLETE){
        this.Progress = QUEST_PROGRESS_COMPLETE;
        return;
      }
      if (this.questItemA.Progress == QUEST_PROGRESS_FAILED && this.questItemB.Progress == QUEST_PROGRESS_FAILED){
        this.Progress = QUEST_PROGRESS_FAILED;
        return;
      }
    }

    public static void OnAnyQuestItemProgressChanged( ){
      QuestItemData triggerQuestItemData = QuestItemData.TriggerQuestItemData;
      int i = 0;
      while(true){
        if ( i == thistype.count){ break; }
        if (triggerQuestItemData == thistype.byIndex[i].questItemA || triggerQuestItemData == thistype.byIndex[i].questItemB){
          thistype.byIndex[i].CheckChildStatus();
        }
        i = i + 1;
      }
    }


    private static void OnInit( ){
      trigger trig = CreateTrigger();
      QuestItemData.ProgressChanged.register(trig);
      TriggerAddAction(trig,  QuestItemEitherOf.OnAnyQuestItemProgressChanged);
    }

  }
}
