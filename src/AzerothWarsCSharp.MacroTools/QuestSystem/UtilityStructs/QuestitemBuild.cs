namespace AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs
{
  public class QuestItemBuild : QuestItemData{


    private static int count = 0;
    private static thistype[] byIndex;
    private int objectId;
    private int currentBuildCount;
    private int targetBuildCount;

    private void operator CurrentBuildCount=(int value ){
      currentBuildCount = value;
      this.Description = "Build " + GetObjectName(objectId) + "s (" + I2S(currentBuildCount) + "/" + I2S(targetBuildCount) + ")";
    }

    public QuestItemBuild(int objectId, int targetBuildCount ){
      this.objectId = objectId;
      thistype.byIndex[thistype.count] = this;
      thistype.count = thistype.count + 1;
      this.targetBuildCount = targetBuildCount;
      this.CurrentBuildCount = 0;
    }

    private static void OnAnyBuild( ){
      var i = 0;
      thistype loopQuestItem;

      while(true){
        if ( i == thistype.count){ break; }
        loopQuestItem = thistype.byIndex[i];

        loopQuestItem.CurrentBuildCount = loopQuestItem.currentBuildCount + 1;
        if (loopQuestItem.currentBuildCount == loopQuestItem.targetBuildCount){
          loopQuestItem.Progress = QUEST_PROGRESS_COMPLETE;
        }
      }
      i = i + 1;
    }
  }
}

    private static void onInit( ){
      PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_CONSTRUCT_FINISH,  thistype.OnAnyBuild) ;//TODO: use filtered events
    }


}
