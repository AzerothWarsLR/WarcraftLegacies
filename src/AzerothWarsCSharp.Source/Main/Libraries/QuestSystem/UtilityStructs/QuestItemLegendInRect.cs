using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs
{
  public class QuestItemLegendInRect{

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
      return GetRectCenterX(this.targetRect);
    }

    float operator Y( ){
      return GetRectCenterY(this.targetRect);
    }

    string operator PingPath( ){
      return "MinimapQuestTurnIn";
    }

    private void OnRegionExit( ){
      if (UnitAlive(this.legend.Unit) == true && IsUnitInRegion(this.target, this.legend.Unit)){
        this.Progress = QUEST_PROGRESS_COMPLETE;
      }else {
        this.Progress = QUEST_PROGRESS_INCOMPLETE;
      }
    }

    private void OnRegionEnter(unit whichUnit ){
      if (UnitAlive(this.legend.Unit) == true && GetTriggerUnit() == this.legend.Unit){
        this.Progress = QUEST_PROGRESS_COMPLETE;
      }
    }

    private static void OnAnyRegionExit( ){
      int i = 0;
      while(true){
        if ( i == thistype.count){ break; }
        if (GetTriggeringRegion() == thistype.byIndex[i].target){
          thistype.byIndex[i].OnRegionExit();
        }
        i = i + 1;
      }
    }

    private static void OnAnyRegionEnter( ){
      int i = 0;
      while(true){
        if ( i == thistype.count){ break; }
        if (GetTriggeringRegion() == thistype.byIndex[i].target){
          thistype.byIndex[i].OnRegionEnter(GetEnteringUnit());
        }
        i = i + 1;
      }
    }

    thistype (Legend legend, rect targetRect, string rectName ){

      this.target = RectToRegion(targetRect);
      this.targetRect = targetRect;
      this.legend = legend;
      this.Description = legend.Name + " is at " + rectName;
      TriggerRegisterEnterRegion(thistype.entersRectTrig, this.target, null);
      TriggerRegisterLeaveRegion(thistype.exitsRectTrig, this.target, null);
      thistype.byIndex[thistype.count] = this;
      thistype.count = thistype.count + 1;
      ;;
    }

    private static void onInit( ){
      TriggerAddAction(thistype.entersRectTrig,  QuestItemLegendInRect.OnAnyRegionEnter);
      TriggerAddAction(thistype.exitsRectTrig,  QuestItemLegendInRect.OnAnyRegionExit);
    }


  }
}
