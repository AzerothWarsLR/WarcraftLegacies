using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs
{
  public class QuestItemLegendNotDead{


    private Legend target = 0;
    private static int count = 0;
    private static thistype[] byIndex;

    private void OnDeath( ){
      this.Progress = QuestProgress.Incomplete;
    }

    private static void OnAnyUnitDeath( ){
      var i = 0;
      thistype loopItem;
      Legend triggerLegend = GetTriggerLegend();
      while(true){
        if ( i == thistype.count){ break; }
        loopItem = thistype.byIndex[i];
        if (loopItem.target == triggerLegend){
          loopItem.OnDeath();
        }
        i = i + 1;
      }
    }

    static  OnAnyUnitTrain( ){//this will fuck up if a legend is already alive or another one is trained
      var i = 0;
      thistype loopQuestItem;
      unit triggerUnit = GetTrainedUnit();
      while(true){
        if ( i == thistype.count){ break; }
        loopQuestItem = thistype.byIndex[i];
        if (!loopQuestItem.ProgressLocked && loopQuestItem.target.UnitType == GetUnitTypeId(triggerUnit) && loopQuestItem.Holder.Player == GetOwningPlayer(GetTrainedUnit())){
          loopQuestItem.Progress = QuestProgress.Complete;
        }
        i = i + 1;
      }
    }

    static  OnAnyUnitRevive( ){//this will fuck up if a legend is already alive or another one is trained
      var i = 0;
      thistype loopQuestItem;
      unit triggerUnit = GetRevivingUnit();
      while(true){
        if ( i == thistype.count){ break; }
        loopQuestItem = thistype.byIndex[i];
        if (!loopQuestItem.ProgressLocked && loopQuestItem.target.UnitType == GetUnitTypeId(triggerUnit) && loopQuestItem.Holder.Player == GetOwningPlayer(GetRevivingUnit())){
          loopQuestItem.Progress = QuestProgress.Complete;
        }
        i = i + 1;
      }
    }

    void OnAdd( ){
      if (UnitAlive(target.Unit)){
        this.Progress = QuestProgress.Complete;
      }
    }

    thistype (Legend target ){

      this.target = target;
      if (IsUnitType(target.Unit, UNIT_TYPE_STRUCTURE)){
        this.Description = target.Name + " is intact";
      }else {
        this.Description = target.Name + " is alive";
      }
      thistype.byIndex[thistype.count] = this;
      thistype.count = thistype.count + 1;
      
    }

    private static void onInit( ){
      trigger trig = CreateTrigger();
      OnLegendDeath.register(trig);
      PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_TRAIN_FINISH,  thistype.OnAnyUnitTrain);
      PlayerUnitEventAddAction(EVENT_PLAYER_HERO_REVIVE_FINISH ,  thistype.OnAnyUnitRevive);
      TriggerAddAction(trig,  thistype.OnAnyUnitDeath);
    }


  }
}
