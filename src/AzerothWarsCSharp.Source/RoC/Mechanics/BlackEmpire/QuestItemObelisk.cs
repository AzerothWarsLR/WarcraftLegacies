using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.RoC.Mechanics.BlackEmpire
{
  public class QuestItemObelisk{

    //An objective in which the player has to summon a Black Empire Obelisk on a specific Control Point.

    private static int count = 0;
    private static thistype[] byIndex;
    private ControlPoint target;

    float operator X( ){
      return GetUnitX(target.Unit);
    }

    float operator Y( ){
      return GetUnitY(target.Unit);
    }

    thistype (ControlPoint target ){

      this.Description = "Summon a NyaFourCC(lothan Obelisk on " + GetUnitName(target.u);
      this.target = target;
      thistype.byIndex[thistype.count] = this;
      thistype.count = thistype.count + 1;
      ;;
    }

    static void OnAnyBlackEmpireObeliskSummoned( ){
      int i = 0;
      thistype loopItem;
      while(true){
        if ( i == thistype.count){ break; }
        loopItem = thistype.byIndex[i];
        if (loopItem.target == GetTriggerBlackEmpireObelisk().ControlPoint){
          loopItem.Progress = QUEST_PROGRESS_COMPLETE;
        }
        i = i + 1;
      }
    }


    private static void OnInit( ){
      trigger trig = CreateTrigger();
      BlackEmpireObeliskSummoned.register(trig);
      TriggerAddAction(trig,  QuestItemObelisk.OnAnyBlackEmpireObeliskSummoned);
    }

  }
}
