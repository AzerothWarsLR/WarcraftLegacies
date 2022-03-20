using AzerothWarsCSharp.Source.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.Libraries.QuestSystem.UtilityStructs
{
  public class QuestItemLegendInRect : QuestItemData{

    private static region RectToRegion(rect whichRect ){
      region rectRegion = CreateRegion();
      RegionAddRect(rectRegion, whichRect);
      return rectRegion;
    }


    private Legend legend;
    private region target;
    private rect targetRect;

    private static trigger entersRectTrig = CreateTrigger();
    private static trigger exitsRectTrig = CreateTrigger();
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

    private void OnRegionExit( ){
      if (UnitAlive(legend.Unit) && IsUnitInRegion(target, legend.Unit)){
        this.Progress = QUEST_PROGRESS_COMPLETE;
      }else {
        this.Progress = QUEST_PROGRESS_INCOMPLETE;
      }
    }

    private void OnRegionEnter(unit whichUnit ){
      if (UnitAlive(legend.Unit) && GetTriggerUnit() == legend.Unit){
        this.Progress = QUEST_PROGRESS_COMPLETE;
      }
    }

    private static void OnAnyRegionExit( ){
      var i = 0;
      while(true){
        if ( i == thistype.count){ break; }
        if (GetTriggeringRegion() == thistype.byIndex[i].target){
          thistype.byIndex[i].OnRegionExit();
        }
        i = i + 1;
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

    public QuestItemLegendInRect(Legend legend, rect targetRect, string rectName ){

      target = RectToRegion(targetRect);
      this.targetRect = targetRect;
      this.legend = legend;
      this.Description = legend.Name + " is at " + rectName;
      TriggerRegisterEnterRegion(thistype.entersRectTrig, target, null);
      TriggerRegisterLeaveRegion(thistype.exitsRectTrig, target, null);
      thistype.byIndex[thistype.count] = this;
      thistype.count = thistype.count + 1;
      ;;
    }

    private static void onInit( ){
      TriggerAddAction(thistype.entersRectTrig,  OnAnyRegionEnter);
      TriggerAddAction(thistype.exitsRectTrig,  OnAnyRegionExit);
    }


  }
}
