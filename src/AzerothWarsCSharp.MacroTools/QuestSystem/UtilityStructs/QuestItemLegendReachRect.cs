using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs
{
  public class QuestItemLegendReachRect{

    private static region RectToRegion(rect whichRect ){
      region rectRegion = CreateRegion();
      RegionAddRect(rectRegion, whichRect);
      return rectRegion;
    }


    private Legend legend;
    private region target;
    private rect targetRect;

    private static trigger entersRectTrig = CreateTrigger();
    private static int count = 0;
    private static thistype[] byIndex;

    float operator X( ){
      return GetRectCenterX(targetRect);
    }

    float operator Y( ){
      return GetRectCenterY(targetRect);
    }

    string operator PingPath( ){
      return "MinimapQuestTurnIn";
    }

    private void OnRegionEnter(unit whichUnit ){
      if (UnitAlive(legend.Unit) && GetTriggerUnit() == legend.Unit){
        this.Progress = QUEST_PROGRESS_COMPLETE;
      }
    }

    private static void OnAnyRegionEnter( ){
      var i = 0;
      while(true){
        if ( i == thistype.count){ break; }
        if (GetTriggeringRegion() == thistype.byIndex[i].target){
          thistype.byIndex[i].OnRegionEnter(GetEnteringUnit());
        }
        i = i + 1;
      }
    }

    thistype (Legend legend, rect targetRect, string rectName ){

      target = RectToRegion(targetRect);
      this.targetRect = targetRect;
      this.legend = legend;
      this.Description = legend.Name + " reaches " + rectName;
      TriggerRegisterEnterRegion(thistype.entersRectTrig, target, null);
      thistype.byIndex[thistype.count] = this;
      thistype.count = thistype.count + 1;
      ;;
    }

    private static void onInit( ){
      TriggerAddAction(thistype.entersRectTrig,  OnAnyRegionEnter);
    }


  }
}
