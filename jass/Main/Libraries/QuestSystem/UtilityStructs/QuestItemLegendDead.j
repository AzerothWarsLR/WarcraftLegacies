library QuestItemLegendDead requires QuestItemData, Legend

  struct QuestItemLegendDead extends QuestItemData
    private Legend target = 0
    private static integer count = 0
    private static thistype array byIndex

    method operator X takes nothing returns real
      if IsUnitType(target.Unit, UNIT_TYPE_STRUCTURE) or GetOwningPlayer(target.Unit) == Player(PLAYER_NEUTRAL_AGGRESSIVE) then
        return GetUnitX(target.Unit)
      endif
      return 0.
    endmethod

    method operator Y takes nothing returns real
      if IsUnitType(target.Unit, UNIT_TYPE_STRUCTURE) or GetOwningPlayer(target.Unit) == Player(PLAYER_NEUTRAL_AGGRESSIVE) then
        return GetUnitY(target.Unit)
      endif
      return 0.
    endmethod

    private method OnDeath takes nothing returns nothing
      set this.Progress = QUEST_PROGRESS_COMPLETE
    endmethod

    private static method OnAnyUnitDeath takes nothing returns nothing
      local integer i = 0
      local thistype loopItem
      local Legend triggerLegend = GetTriggerLegend()
      loop
        exitwhen i == thistype.count
        set loopItem = thistype.byIndex[i]
        if loopItem.target == triggerLegend then
          call loopItem.OnDeath()
        endif
        set i = i + 1
      endloop
    endmethod

    static method create takes Legend target returns thistype
      local thistype this = thistype.allocate()
      set this.target = target
      if IsUnitType(target.Unit, UNIT_TYPE_STRUCTURE) then
        set this.Description = target.Name + " is destroyed"
      else
        set this.Description = target.Name + " is dead"
      endif
      set thistype.byIndex[thistype.count] = this
      set thistype.count = thistype.count + 1
      return this
    endmethod

    private static method onInit takes nothing returns nothing
      local trigger trig = CreateTrigger()
      call OnLegendPermaDeath.register(trig)
      call TriggerAddAction(trig, function thistype.OnAnyUnitDeath)
    endmethod

  endstruct

endlibrary