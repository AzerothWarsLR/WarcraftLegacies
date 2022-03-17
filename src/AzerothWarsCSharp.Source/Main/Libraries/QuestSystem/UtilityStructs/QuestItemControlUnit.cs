namespace AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs
{
  public class QuestItemControlUnit{


    private static thistype[] byHandleId;
    private unit target = null;

    float operator X( ){
      return GetUnitX(target);
    }

    float operator Y( ){
      return GetUnitY(target);
    }

    private void OnUnitChangeOwner( ){
      if (this.Holder.Team.ContainsFaction(Person.ByHandle(GetOwningPlayer(this.target)))){
        this.Progress = QUEST_PROGRESS_COMPLETE;
      }
    }

    private static void OnAnyUnitChangeOwner( ){
      thistype.byHandleId[GetHandleId(GetTriggerUnit())].OnUnitChangeOwner();
    }

    thistype (unit target ){

      trigger trig = CreateTrigger();
      TriggerRegisterUnitEvent(trig, target, EVENT_UNIT_CHANGE_OWNER);
      TriggerAddAction(trig,  thistype.OnAnyUnitChangeOwner);
      this.Description = "Your team controls " + GetUnitName(target);
      this.target = target;
      this.targetWidget = target;
      thistype.byHandleId[GetHandleId(target)] = this;
      ;;
    }



  }
}
