library QuestItemArtifactInRect requires QuestItemData, Artifact

  private function RectToRegion takes rect whichRect returns region
    local region rectRegion = CreateRegion()
    call RegionAddRect(rectRegion, whichRect)
    return rectRegion
  endfunction

  struct QuestItemArtifactInRect extends QuestItemData
    private Artifact targetArtifact
    private rect targetRect
    private region targetRegion

    private static trigger entersRectTrig = CreateTrigger()
    private static trigger exitsRectTrig = CreateTrigger()
    private static integer count = 0
    private static thistype array byIndex
    private static group tempGroup = CreateGroup()    

    method operator X takes nothing returns real
      return GetRectCenterX(this.targetRect)
    endmethod

    method operator Y takes nothing returns real
      return GetRectCenterY(this.targetRect)
    endmethod

    private method IsArtifactInRect takes nothing returns boolean
      if targetArtifact.OwningUnit != null and RectContainsCoords(this.targetRect, GetUnitX(this.targetArtifact.OwningUnit), GetUnitY(this.targetArtifact.OwningUnit)) then
        return true
      endif
      if targetArtifact.OwningUnit == null and RectContainsCoords(this.targetRect, GetItemX(this.targetArtifact.item), GetItemY(this.targetArtifact.item)) then
        return true
      endif
      return false
    endmethod

    private method OnRegionEnter takes unit whichUnit returns nothing
      if targetArtifact.OwningUnit == GetEnteringUnit() then
        set this.Progress = QUEST_PROGRESS_COMPLETE
      else
        set this.Progress = QUEST_PROGRESS_INCOMPLETE
      endif
    endmethod

    private method OnRegionExit takes nothing returns nothing
      if IsArtifactInRect() then
        set this.Progress = QUEST_PROGRESS_COMPLETE
      else
        set this.Progress = QUEST_PROGRESS_INCOMPLETE      
      endif
    endmethod

    private static method OnAnyRegionExit takes nothing returns nothing
      local integer i = 0
      loop
        exitwhen i == thistype.count
        if GetTriggeringRegion() == thistype.byIndex[i].targetRegion then
          call thistype.byIndex[i].OnRegionExit()
        endif
        set i = i + 1
      endloop
    endmethod

    private static method OnAnyRegionEnter takes nothing returns nothing
      local integer i = 0
      loop
        exitwhen i == thistype.count
        if GetTriggeringRegion() == thistype.byIndex[i].targetRegion then
          call thistype.byIndex[i].OnRegionEnter(GetEnteringUnit())
        endif
        set i = i + 1
      endloop    
    endmethod

    static method create takes Artifact targetArtifact, rect targetRect, string rectName returns thistype
      local thistype this = thistype.allocate()
      set this.targetArtifact = targetArtifact
      set this.targetRect = targetRect
      set this.targetRegion = RectToRegion(targetRect)
      set this.Description = "Bring " + GetItemName(targetArtifact.item) + " to " + rectName
      call TriggerRegisterEnterRegion(thistype.entersRectTrig, this.targetRegion, null)
      call TriggerRegisterLeaveRegion(thistype.exitsRectTrig, this.targetRegion, null)      
      set thistype.byIndex[thistype.count] = this
      set thistype.count = thistype.count + 1         
      return this
    endmethod

    private static method onInit takes nothing returns nothing
      call TriggerAddAction(thistype.entersRectTrig, function thistype.OnAnyRegionEnter)
      call TriggerAddAction(thistype.exitsRectTrig, function thistype.OnAnyRegionEnter)
    endmethod

  endstruct

endlibrary