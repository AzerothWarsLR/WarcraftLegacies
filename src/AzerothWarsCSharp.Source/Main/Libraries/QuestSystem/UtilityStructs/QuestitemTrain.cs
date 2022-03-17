namespace AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs
{
  public class QuestItemTrain{


    private static int count = 0;
    private static thistype[] byIndex;
    private int objectId;
    private int trainFromId;
    private int currentTrainCount;
    private int targetTrainCount;

    private void operator CurrentTrainCount=(int value ){
      this.currentTrainCount = value;
      this.Description = "Train " + GetObjectName(objectId) + "s from the " + GetObjectName(trainFromId) + " (" + I2S(currentTrainCount) + "/" + I2S(targetTrainCount) + ")";
    }

    thistype (int objectId, int trainFromId, int targetTrainCount ){

      this.objectId = objectId;
      this.trainFromId = trainFromId;
      thistype.byIndex[thistype.count] = this;
      thistype.count = thistype.count + 1;
      this.targetTrainCount = targetTrainCount;
      this.CurrentTrainCount = 0;
      ;;
    }

    private static void OnAnyTrain( ){
      int i = 0;
      thistype loopQuestItem;
      unit triggerUnit = GetTrainedUnit();
      while(true){
        if ( i == thistype.count){ break; }
        loopQuestItem = thistype.byIndex[i];
        if (!loopQuestItem.ProgressLocked && loopQuestItem.objectId == GetUnitTypeId(triggerUnit) && loopQuestItem.Holder.Player == GetOwningPlayer(GetTrainedUnit())){
          loopQuestItem.CurrentTrainCount = loopQuestItem.currentTrainCount + 1;
          if (loopQuestItem.currentTrainCount == loopQuestItem.targetTrainCount){
            loopQuestItem.Progress = QUEST_PROGRESS_COMPLETE;
          }
        }
        i = i + 1;
      }
    }

    private static void onInit( ){
      PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_TRAIN_FINISH,  thistype.OnAnyTrain) ;//TODO: use filtered events
    }


  }
}
