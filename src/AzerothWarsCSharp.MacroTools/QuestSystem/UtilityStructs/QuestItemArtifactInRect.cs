using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs
{
  public class QuestItemArtifactInRect : QuestItemData{

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
      return GetRectCenterX(targetRect);
    }

    float operator Y( ){
      return GetRectCenterY(targetRect);
    }

    private bool IsArtifactInRect( ){
      if (targetArtifact.OwningUnit != null && RectContainsCoords(targetRect, GetUnitX(targetArtifact.OwningUnit), GetUnitY(targetArtifact.OwningUnit))){
        return true;
      }
      if (targetArtifact.OwningUnit == null && RectContainsCoords(targetRect, GetItemX(targetArtifact.item), GetItemY(targetArtifact.item))){
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
      var i = 0;
      while(true){
        if ( i == thistype.count){ break; }
        if (GetTriggeringRegion() == thistype.byIndex[i].targetRegion){
          thistype.byIndex[i].OnRegionExit();
        }
        i = i + 1;
      }
    }

    private static void OnAnyRegionEnter( ){
      var i = 0;
      while(true){
        if ( i == thistype.count){ break; }
        if (GetTriggeringRegion() == thistype.byIndex[i].targetRegion){
          thistype.byIndex[i].OnRegionEnter(GetEnteringUnit());
        }
        i = i + 1;
      }
    }

    public QuestItemArtifactInRect (Artifact targetArtifact, rect targetRect, string rectName ){

      this.targetArtifact = targetArtifact;
      this.targetRect = targetRect;
      targetRegion = RectToRegion(targetRect);
      this.Description = "Bring " + GetItemName(targetArtifact.item) + " to " + rectName;
      TriggerRegisterEnterRegion(thistype.entersRectTrig, targetRegion, null);
      TriggerRegisterLeaveRegion(thistype.exitsRectTrig, targetRegion, null);
      thistype.byIndex[thistype.count] = this;
      thistype.count = thistype.count + 1;
      
    }

    private static void onInit( ){
      TriggerAddAction(thistype.entersRectTrig,  thistype.OnAnyRegionEnter);
      TriggerAddAction(thistype.exitsRectTrig,  thistype.OnAnyRegionExit);
    }



  }
}
