library QuestItemControlUnit requires QuestItemData

  struct QuestItemControlUnit extends QuestItemData
    private static thistype array byHandleId
    private unit target = null

    method operator X takes nothing returns real
      return GetUnitX(target)
    endmethod

    method operator Y takes nothing returns real
      return GetUnitY(target)
    endmethod

    private method OnUnitChangeOwner takes nothing returns nothing
      if this.Holder.Team.ContainsFaction(Person.ByHandle(GetOwningPlayer(this.target))) then
        set this.Progress = QUEST_PROGRESS_COMPLETE
      endif
    endmethod

    private static method OnAnyUnitChangeOwner takes nothing returns nothing
      call thistype.byHandleId[GetHandleId(GetTriggerUnit())].OnUnitChangeOwner()
    endmethod

    static method create takes unit target returns thistype
      local thistype this = thistype.allocate()
      local trigger trig = CreateTrigger()
      call TriggerRegisterUnitEvent(trig, target, EVENT_UNIT_CHANGE_OWNER)    
      call TriggerAddAction(trig, function thistype.OnAnyUnitChangeOwner)
      set this.Description = "Your team controls " + GetUnitName(target)
      set this.target = target
      set thistype.byHandleId[GetHandleId(target)] = this
      return this
    endmethod

  endstruct

endlibrary