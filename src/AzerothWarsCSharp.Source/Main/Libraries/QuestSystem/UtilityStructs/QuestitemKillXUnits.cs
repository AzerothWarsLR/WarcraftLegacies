namespace AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs
{
  public class QuestItemKillXUnit{


    private static int count = 0;
    private static thistype[] byIndex;
    private int objectId;
    private int currentKillXUnitCount;
    private int targetKillXUnitCount;

    private void operator CurrentKillXUnitCount=(int value ){
      this.currentKillXUnitCount = value;
      this.Description = "Kill " + GetObjectName(objectId) + "s (" + I2S(currentKillXUnitCount) + "/" + I2S(targetKillXUnitCount) + ")";
    }

    thistype (int objectId, int targetKillXUnitCount ){

      this.objectId = objectId;
      thistype.byIndex[thistype.count] = this;
      thistype.count = thistype.count + 1;
      this.targetKillXUnitCount = targetKillXUnitCount;
      this.CurrentKillXUnitCount = 0;
      ;;
    }

    private static void OnAnyKillXUnit( ){
      int i = 0;
      thistype loopQuestItem;
      unit triggerUnit = GetDyingUnit();
      while(true){
        if ( i == thistype.count){ break; }
        loopQuestItem = thistype.byIndex[i];
        if (!loopQuestItem.ProgressLocked && loopQuestItem.objectId == GetUnitTypeId(triggerUnit)){
          loopQuestItem.CurrentKillXUnitCount = loopQuestItem.currentKillXUnitCount + 1;
          if (loopQuestItem.currentKillXUnitCount == loopQuestItem.targetKillXUnitCount){
            loopQuestItem.Progress = QUEST_PROGRESS_COMPLETE;
          }
        }
        i = i + 1;
      }
    }

    private static void onInit( ){
      PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_DEATH ,  thistype.OnAnyKillXUnit) ;//TODO: use filtered events
    }


  }
}
