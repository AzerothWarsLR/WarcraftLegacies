using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs
{
  public class QuestItemArtifactInRect{

    private static region RectToRegion(rect whichRect ){
      region rectRegion = CreateRegion();
      RegionAddRect(rectRegion, whichRect);
      return rectRegion;
    }


    private Artifact targetArtifact;
    private rect targetRect;
    private region targetRegion;

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

    private boolean IsArtifactInRect( ){
      if (targetArtifact.OwningUnit != null && RectContainsCoords(this.targetRect, GetUnitX(this.targetArtifact.OwningUnit), GetUnitY(this.targetArtifact.OwningUnit))){
        return true;
      }
      if (targetArtifact.OwningUnit == null && RectContainsCoords(this.targetRect, GetItemX(this.targetArtifact.item), GetItemY(this.targetArtifact.item))){
        return true;
      }
      return false;
    }

    private void OnRegionEnter(unit whichUnit ){
      if (targetArtifact.OwningUnit == GetEnteringUnit()){
        //call BJDebugMsg("On Region Enter" + GetUnitName(GetEnteringUnit()))
        this.Progress = QUEST_PROGRESS_COMPLETE;
      }else {
        this.Progress = QUEST_PROGRESS_INCOMPLETE;
      }
    }

    private void OnRegionExit( ){
      if (IsArtifactInRect()){
        //call BJDebugMsg("On Region Exit")
        this.Progress = QUEST_PROGRESS_COMPLETE;
      }else {
        this.Progress = QUEST_PROGRESS_INCOMPLETE;
      }
    }

    private static void OnAnyRegionExit( ){
      int i = 0;
      while(true){
        if ( i == thistype.count){ break; }
        if (GetTriggeringRegion() == thistype.byIndex[i].targetRegion){
          thistype.byIndex[i].OnRegionExit();
        }
        i = i + 1;
      }
    }

    private static void OnAnyRegionEnter( ){
      int i = 0;
      while(true){
        if ( i == thistype.count){ break; }
        if (GetTriggeringRegion() == thistype.byIndex[i].targetRegion){
          thistype.byIndex[i].OnRegionEnter(GetEnteringUnit());
        }
        i = i + 1;
      }
    }

    thistype (Artifact targetArtifact, rect targetRect, string rectName ){

      this.targetArtifact = targetArtifact;
      this.targetRect = targetRect;
      this.targetRegion = RectToRegion(targetRect);
      this.Description = "Bring " + GetItemName(targetArtifact.item) + " to " + rectName;
      TriggerRegisterEnterRegion(thistype.entersRectTrig, this.targetRegion, null);
      TriggerRegisterLeaveRegion(thistype.exitsRectTrig, this.targetRegion, null);
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
