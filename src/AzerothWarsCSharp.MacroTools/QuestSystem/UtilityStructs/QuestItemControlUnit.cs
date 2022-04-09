using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs
{
  public class QuestItemControlUnit{


    private static thistype[] byHandleId;
    private unit target;

    float operator X( ){
      return GetUnitX(target);
    }

    float operator Y( ){
      return GetUnitY(target);
    }

    private void OnUnitChangeOwner( ){
      if (this.Holder.Team.ContainsFaction(Person.ByHandle(GetOwningPlayer(target)))){
        this.Progress = QuestProgress.Complete;
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
      
    }



  }
}
