library QuestItemAnyUnitInRect requires QuestItemData, Environment

  private function RectToRegion takes rect whichRect returns region
    local region rectRegion = CreateRegion()
    call RegionAddRect(rectRegion, whichRect)
    return rectRegion
  endfunction

  struct QuestItemAnyUnitInRect extends QuestItemData
    private region target
    private rect targetRect
    private boolean heroOnly = false
    private unit triggerUnit = null

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

    method operator PingPath takes nothing returns string
      return "MinimapQuestTurnIn"
    endmethod    

    method operator TriggerUnit takes nothing returns unit
      return this.triggerUnit
    endmethod

    private method IsValidUnitInRect takes nothing returns boolean
      local unit u
      local player holderPlayer = this.Holder.Player
      call GroupClear(thistype.tempGroup)
      call GroupEnumUnitsInRect(thistype.tempGroup, this.targetRect, null)
      loop
        set u = FirstOfGroup(thistype.tempGroup)
        exitwhen u == null
        if GetOwningPlayer(u) == this.Holder.Player and UnitAlive(u) and (IsUnitType(u, UNIT_TYPE_HERO) or not this.heroOnly) then
          return true
        endif
        call GroupRemoveUnit(thistype.tempGroup, u)
      endloop
      return false
    endmethod

    private method OnRegionEnter takes unit whichUnit returns nothing
      if (GetOwningPlayer(whichUnit) == this.Holder.Player and UnitAlive(whichUnit) and (IsUnitType(whichUnit, UNIT_TYPE_HERO) or not this.heroOnly)) or IsValidUnitInRect() then
        set this.triggerUnit = whichUnit
        set this.Progress = QUEST_PROGRESS_COMPLETE
      else
        set this.Progress = QUEST_PROGRESS_INCOMPLETE
      endif
    endmethod

    private method OnRegionExit takes nothing returns nothing
      if IsValidUnitInRect() then
        set this.Progress = QUEST_PROGRESS_COMPLETE
      else
        set this.Progress = QUEST_PROGRESS_INCOMPLETE      
      endif
    endmethod

    private static method OnAnyRegionExit takes nothing returns nothing
      local integer i = 0
      loop
        exitwhen i == thistype.count
        if GetTriggeringRegion() == thistype.byIndex[i].target then
          call thistype.byIndex[i].OnRegionExit()
        endif
        set i = i + 1
      endloop
    endmethod

    private static method OnAnyRegionEnter takes nothing returns nothing
      local integer i = 0
      loop
        exitwhen i == thistype.count
        if GetTriggeringRegion() == thistype.byIndex[i].target then
          call thistype.byIndex[i].OnRegionEnter(GetEnteringUnit())
        endif
        set i = i + 1
      endloop    
    endmethod

    static method create takes rect targetRect, string rectName, boolean heroOnly returns thistype
      local thistype this = thistype.allocate()
      local trigger trig = CreateTrigger()
      if heroOnly then
        set this.Description = "You have a hero at " + rectName
      else
        set this.Description = "You have a unit at " + rectName
      endif
      set this.target = RectToRegion(targetRect)
      set this.targetRect = targetRect
      set this.heroOnly = heroOnly
      call TriggerRegisterEnterRegion(thistype.entersRectTrig, this.target, null)
      call TriggerRegisterLeaveRegion(thistype.exitsRectTrig, this.target, null)      
      set thistype.byIndex[thistype.count] = this
      set thistype.count = thistype.count + 1      
      return this
    endmethod

    private static method onInit takes nothing returns nothing
      call TriggerAddAction(thistype.entersRectTrig, function thistype.OnAnyRegionEnter)
      call TriggerAddAction(thistype.exitsRectTrig, function thistype.OnAnyRegionExit)
    endmethod

  endstruct

endlibrary