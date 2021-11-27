library QuestItemObelisk initializer OnInit requires QuestItemData, BlackEmpireObelisk, ControlPoint

  //An objective in which the player has to summon a Black Empire Obelisk on a specific Control Point.
  struct QuestItemObelisk extends QuestItemData
    private static integer count = 0
    private static thistype array byIndex
    private ControlPoint target

    method operator X takes nothing returns real
      return GetUnitX(target.Unit)
    endmethod

    method operator Y takes nothing returns real
      return GetUnitY(target.Unit)
    endmethod

    static method create takes ControlPoint target returns thistype
      local thistype this = thistype.allocate()
      set this.Description = "Summon a Nya'lothan Obelisk on " + GetUnitName(target.u)
      set this.target = target
      set thistype.byIndex[thistype.count] = this
      set thistype.count = thistype.count + 1
      return this
    endmethod

    static method OnAnyBlackEmpireObeliskSummoned takes nothing returns nothing
      local integer i = 0
      local thistype loopItem
      loop
        exitwhen i == thistype.count
        set loopItem = thistype.byIndex[i]
        if loopItem.target == GetTriggerBlackEmpireObelisk().ControlPoint then
          set loopItem.Progress = QUEST_PROGRESS_COMPLETE
        endif
        set i = i + 1
      endloop
    endmethod
  endstruct

  private function OnInit takes nothing returns nothing
    local trigger trig = CreateTrigger()
    call BlackEmpireObeliskSummoned.register(trig)
    call TriggerAddAction(trig, function QuestItemObelisk.OnAnyBlackEmpireObeliskSummoned)
  endfunction

endlibrary