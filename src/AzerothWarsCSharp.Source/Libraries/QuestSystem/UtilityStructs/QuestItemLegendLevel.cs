using AzerothWarsCSharp.Source.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.Libraries.QuestSystem.UtilityStructs
{
  public class QuestItemLegendLevel{


    private Legend target = 0;
    private int level;
    private static int count = 0;
    private static thistype[] byIndex;

    thistype (Legend target, int level ){

      this.Description = target.Name + " is level " + I2S(level);
      this.target = target;
      this.level = level;
      thistype.byIndex[thistype.count] = this;
      thistype.count = thistype.count + 1;
      ;;
    }

    private void OnLevel( ){
      if (GetHeroLevel(target.Unit) >= level){
        this.Progress = QUEST_PROGRESS_COMPLETE;
      }
    }

    private static void OnAnyLevel( ){
      var i = 0;
      thistype loopItem;
      Legend triggerLegend = Legend.ByHandle(GetTriggerUnit());
      while(true){
        if ( i == thistype.count){ break; }
        loopItem = thistype.byIndex[i];
        if (loopItem.target == triggerLegend){
          loopItem.OnLevel();
        }
        i = i + 1;
      }
    }

    private static void onInit( ){
      PlayerUnitEventAddAction(EVENT_PLAYER_HERO_LEVEL,  thistype.OnAnyLevel) ;//TODO: use filtered events
    }


  }
}
