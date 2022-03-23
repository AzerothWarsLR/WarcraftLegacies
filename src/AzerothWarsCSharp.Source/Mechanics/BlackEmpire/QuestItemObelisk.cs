using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;

namespace AzerothWarsCSharp.Source.Mechanics.BlackEmpire
{
  public class QuestItemObelisk : QuestItemData{

    //An objective in which the player has to summon a Black Empire Obelisk on a specific Control Point.

    private static int _count = 0;
    private static thistype[] _byIndex;
    private ControlPoint _target;

    float operator X( ){
      return GetUnitX(_target.Unit);
    }

    float operator Y( ){
      return GetUnitY(_target.Unit);
    }

    public QuestItemObelisk(ControlPoint target ){

      Description = "Summon a NyaFourCC(lothan Obelisk on " + GetUnitName(target.u);
      this._target = target;
      thistype.byIndex[thistype.count] = this;
      thistype.count = thistype.count + 1;
      
    }

    static void OnAnyBlackEmpireObeliskSummoned( ){
      var i = 0;
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


    public static void Setup( ){
      trigger trig = CreateTrigger();
      BlackEmpireObeliskSummoned.register(trig);
      TriggerAddAction(trig,  OnAnyBlackEmpireObeliskSummoned);
    }

  }
}
