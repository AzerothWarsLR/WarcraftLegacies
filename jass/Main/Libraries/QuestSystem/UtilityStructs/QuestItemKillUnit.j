library QuestItemKillUnit requires QuestItemData, Event, Environment

  struct QuestItemKillUnit extends QuestItemData
    private static group targets = CreateGroup()
    private unit target = null
    private static integer count = 0
    private static thistype array byIndex

    method operator X takes nothing returns real
      if IsUnitType(target, UNIT_TYPE_STRUCTURE) or IsPlayerNeutralHostile(GetOwningPlayer(target)) then
        return GetUnitX(target)
      endif
      return 0.
    endmethod

    method operator Y takes nothing returns real
      if IsUnitType(target, UNIT_TYPE_STRUCTURE) or IsPlayerNeutralHostile(GetOwningPlayer(target)) then
        return GetUnitY(target)
      endif
      return 0.
    endmethod

    method operator Target takes nothing returns unit
      return this.target
    endmethod

    private method OnUnitDeath takes nothing returns nothing
      if this.Holder.Team.ContainsPlayer(GetOwningPlayer(GetKillingUnit())) then
        set this.Progress = QUEST_PROGRESS_COMPLETE
      else
        set this.Progress = QUEST_PROGRESS_FAILED
      endif
    endmethod

    private method InitializeDescription takes nothing returns nothing
      if IsUnitType(this.target, UNIT_TYPE_STRUCTURE) or IsUnitType(this.target, UNIT_TYPE_ANCIENT) then
        set this.Description = "Destroy " + GetUnitName(this.target)
        return
      endif
      set this.Description = "Kill " + GetUnitName(this.target)
    endmethod

    private static method OnAnyUnitDeath takes nothing returns nothing
      local integer i = 0
      local thistype loopItem
      loop
        exitwhen i == thistype.count
        set loopItem = thistype.byIndex[i]
        if loopItem.target == GetTriggerUnit() then
          call loopItem.OnUnitDeath()
        endif
        set i = i + 1
      endloop
    endmethod

    static method create takes unit unitToKill returns thistype
      local thistype this = thistype.allocate()
      local trigger trig = CreateTrigger()
      call TriggerRegisterUnitEvent(trig, unitToKill, EVENT_UNIT_DEATH)    
      call TriggerAddAction(trig, function thistype.OnAnyUnitDeath)
      set this.target = unitToKill
      call InitializeDescription()
      call GroupAddUnit(thistype.targets, unitToKill)
      set thistype.byIndex[thistype.count] = this
      set thistype.count = thistype.count + 1
      return this
    endmethod

  endstruct

endlibrary