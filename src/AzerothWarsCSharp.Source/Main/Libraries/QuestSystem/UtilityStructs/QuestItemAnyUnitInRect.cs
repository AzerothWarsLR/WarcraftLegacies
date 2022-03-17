public class QuestItemAnyUnitInRect{

  private static region RectToRegion(rect whichRect ){
    region rectRegion = CreateRegion();
    RegionAddRect(rectRegion, whichRect);
    return rectRegion;
  }


    private region target;
    private rect targetRect;
    private boolean heroOnly = false;
    private unit triggerUnit = null;

    private static trigger entersRectTrig = CreateTrigger();
    private static trigger exitsRectTrig = CreateTrigger();
    private static int count = 0;
    private static thistype[] byIndex;
    private static group tempGroup = CreateGroup();

    float operator X( ){
      return GetRectCenterX(this.targetRect);
    }

    float operator Y( ){
      return GetRectCenterY(this.targetRect);
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
      GroupEnumUnitsInRect(thistype.tempGroup, this.targetRect, null);
      while(true){
        u = FirstOfGroup(thistype.tempGroup);
        if ( u == null){ break; }
        if (GetOwningPlayer(u) == this.Holder.Player && UnitAlive(u) && (IsUnitType(u, UNIT_TYPE_HERO) || !this.heroOnly)){
          return true;
        }
        GroupRemoveUnit(thistype.tempGroup, u);
      }
      return false;
    }

    private void OnRegionEnter(unit whichUnit ){
      if ((GetOwningPlayer(whichUnit) == this.Holder.Player && UnitAlive(whichUnit) && (IsUnitType(whichUnit, UNIT_TYPE_HERO) || !this.heroOnly)) || IsValidUnitInRect()){
        this.triggerUnit = whichUnit;
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

     thistype (rect targetRect, string rectName, boolean heroOnly ){

      trigger trig = CreateTrigger();
      if (heroOnly){
        this.Description = "You have a hero at " + rectName;
      }else {
        this.Description = "You have a unit at " + rectName;
      }
      this.target = RectToRegion(targetRect);
      this.targetRect = targetRect;
      this.heroOnly = heroOnly;
      TriggerRegisterEnterRegion(thistype.entersRectTrig, this.target, null);
      TriggerRegisterLeaveRegion(thistype.exitsRectTrig, this.target, null);
      thistype.byIndex[thistype.count] = this;
      thistype.count = thistype.count + 1;
      ;;
    }

    private static void onInit( ){
      TriggerAddAction(thistype.entersRectTrig,  thistype.OnAnyRegionEnter);
      TriggerAddAction(thistype.exitsRectTrig,  thistype.OnAnyRegionExit);
    }



}
