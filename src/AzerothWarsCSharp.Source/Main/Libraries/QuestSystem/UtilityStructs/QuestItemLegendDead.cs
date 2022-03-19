using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs
{
  public class QuestItemLegendDead : QuestItemData{


    private Legend target = 0;
    private static int count = 0;
    private static thistype[] byIndex;

    float operator X( ){
      if (IsUnitType(target.Unit, UNIT_TYPE_STRUCTURE) || GetOwningPlayer(target.Unit) == Player(PLAYER_NEUTRAL_AGGRESSIVE)){
        return GetUnitX(target.Unit);
      }
      return 0;
    }

    float operator Y( ){
      if (IsUnitType(target.Unit, UNIT_TYPE_STRUCTURE) || GetOwningPlayer(target.Unit) == Player(PLAYER_NEUTRAL_AGGRESSIVE)){
        return GetUnitY(target.Unit);
      }
      return 0;
    }

    private void OnDeath( ){
      this.Progress = QUEST_PROGRESS_COMPLETE;
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

    public QuestItemLegendDead(Legend target ){

      this.target = target;
      this.targetWidget = target.Unit;
      if (IsUnitType(target.Unit, UNIT_TYPE_STRUCTURE)){
        this.Description = target.Name + " is destroyed";
      }else {
        this.Description = target.Name + " is dead";
      }
      thistype.byIndex[thistype.count] = this;
      thistype.count = thistype.count + 1;
      ;;
    }

    private static void onInit( ){
      trigger trig = CreateTrigger();
      OnLegendPermaDeath.register(trig);
      TriggerAddAction(trig,  thistype.OnAnyUnitDeath);
    }



  }
}
