namespace AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs
{
  public class QuestItemKillUnit{


    private static group targets = CreateGroup();
    private unit target;
    private static int count = 0;
    private static thistype[] byIndex;

    float operator X( ){
      if (IsUnitType(target, UNIT_TYPE_STRUCTURE) || IsPlayerNeutralHostile(GetOwningPlayer(target))){
        return GetUnitX(target);
      }
      return 0;
    }

    float operator Y( ){
      if (IsUnitType(target, UNIT_TYPE_STRUCTURE) || IsPlayerNeutralHostile(GetOwningPlayer(target))){
        return GetUnitY(target);
      }
      return 0;
    }

    unit operator Target( ){
      ;.target;
    }

    private void OnUnitDeath( ){
      if (this.Holder.Team.ContainsPlayer(GetOwningPlayer(GetKillingUnit()))){
        this.Progress = QUEST_PROGRESS_COMPLETE;
      }else {
        this.Progress = QUEST_PROGRESS_FAILED;
      }
    }

    private void InitializeDescription( ){
      if (IsUnitType(target, UNIT_TYPE_STRUCTURE) || IsUnitType(target, UNIT_TYPE_ANCIENT)){
        this.Description = "Destroy " + GetUnitName(target);
        return;
      }
      this.Description = "Kill " + GetUnitName(target);
    }

    private static void OnAnyUnitDeath( ){
      var i = 0;
      thistype loopItem;
      while(true){
        if ( i == thistype.count){ break; }
        loopItem = thistype.byIndex[i];
        if (loopItem.target == GetTriggerUnit()){
          loopItem.OnUnitDeath();
        }
        i = i + 1;
      }
    }

    thistype (unit unitToKill ){

      trigger trig = CreateTrigger();
      TriggerRegisterUnitEvent(trig, unitToKill, EVENT_UNIT_DEATH);
      TriggerAddAction(trig,  thistype.OnAnyUnitDeath);
      target = unitToKill;
      InitializeDescription();
      GroupAddUnit(thistype.targets, unitToKill);
      this.targetWidget = unitToKill;
      thistype.byIndex[thistype.count] = this;
      thistype.count = thistype.count + 1;
      ;;
    }



  }
}
