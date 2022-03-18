namespace AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs
{
  public class QuestItemUpgrade{


    private static int count = 0;
    private static thistype[] byIndex;
    private int objectId;
    private unit triggerUnit;

    unit operator TriggerUnit( ){
      ;.triggerUnit;
    }

    thistype (int objectId, int upgradeFromId ){

      this.Description = "Upgrade your " + GetObjectName(upgradeFromId) + " to a " + GetObjectName(objectId);
      this.objectId = objectId;
      thistype.byIndex[thistype.count] = this;
      thistype.count = thistype.count + 1;
      ;;
    }

    private static void OnAnyUpgrade( ){
      var i = 0;
      thistype loopQuestItem;
      unit triggerUnit = GetTriggerUnit();
      while(true){
        if ( i == thistype.count){ break; }
        loopQuestItem = thistype.byIndex[i];
        if (!loopQuestItem.ProgressLocked && loopQuestItem.objectId == GetUnitTypeId(triggerUnit) && loopQuestItem.Holder.Player == GetOwningPlayer(GetTriggerUnit())){
          loopQuestItem.triggerUnit = triggerUnit;
          loopQuestItem.Progress = QUEST_PROGRESS_COMPLETE;
        }
        i = i + 1;
      }
    }

    private static void onInit( ){
      PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_UPGRADE_FINISH,  thistype.OnAnyUpgrade) ;//TODO: use filtered events
    }


  }
}
