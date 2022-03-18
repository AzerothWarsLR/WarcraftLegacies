namespace AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs
{
  public class QuestItemAnyUnitInRect{

    private static region RectToRegion(rect whichRect ){
      region rectRegion = CreateRegion();
      RegionAddRect(rectRegion, whichRect);
      return rectRegion;
    }


    private region target;
    private rect targetRect;
    private boolean heroOnly = false;
    private unit triggerUnit;

    private static trigger entersRectTrig = CreateTrigger();
    private static trigger exitsRectTrig = CreateTrigger();
    private static int count = 0;
    private static thistype[] byIndex;
    private static group tempGroup = CreateGroup();

    float operator X( ){
      return GetRectCenterX(targetRect);
    }

    float operator Y( ){
      return GetRectCenterY(targetRect);
    }

    string operator PingPath( ){
      return "MinimapQuestTurnIn";
    }

    unit operator TriggerUnit( ){
      ;.triggerUnit;
    }

    private boolean IsValidUnitInRect( ){
      unit u;
      player holderPlayer = this.Holder.Player;
      GroupClear(thistype.tempGroup);
      GroupEnumUnitsInRect(thistype.tempGroup, targetRect, null);
      while(true){
        u = FirstOfGroup(thistype.tempGroup);
        if ( u == null){ break; }
        if (GetOwningPlayer(u) == this.Holder.Player && UnitAlive(u) && (IsUnitType(u, UNIT_TYPE_HERO) || !heroOnly)){
          return true;
        }
        GroupRemoveUnit(thistype.tempGroup, u);
      }
      return false;
    }

    private void OnRegionEnter(unit whichUnit ){
      if ((GetOwningPlayer(whichUnit) == this.Holder.Player && UnitAlive(whichUnit) && (IsUnitType(whichUnit, UNIT_TYPE_HERO) || !heroOnly)) || IsValidUnitInRect()){
        triggerUnit = whichUnit;
        this.Progress = QUEST_PROGRESS_COMPLETE;
      }else {
        this.Progress = QUEST_PROGRESS_INCOMPLETE;
      }
    }

    private void OnRegionExit( ){
      if (IsValidUnitInRect()){
        this.Progress = QUEST_PROGRESS_COMPLETE;
      }else {
        this.Progress = QUEST_PROGRESS_INCOMPLETE;
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

    thistype (rect targetRect, string rectName, boolean heroOnly ){

      trigger trig = CreateTrigger();
      if (heroOnly){
        this.Description = "You have a hero at " + rectName;
      }else {
        this.Description = "You have a unit at " + rectName;
      }
      target = RectToRegion(targetRect);
      this.targetRect = targetRect;
      this.heroOnly = heroOnly;
      TriggerRegisterEnterRegion(thistype.entersRectTrig, target, null);
      TriggerRegisterLeaveRegion(thistype.exitsRectTrig, target, null);
      thistype.byIndex[thistype.count] = this;
      thistype.count = thistype.count + 1;
      ;;
    }

    private static void onInit( ){
      TriggerAddAction(thistype.entersRectTrig,  thistype.OnAnyRegionEnter);
      TriggerAddAction(thistype.exitsRectTrig,  thistype.OnAnyRegionExit);
    }



  }
}
