library QuestItemLegendAlive requires QuestItemData, Environment, Legend

  struct QuestItemLegendAlive extends QuestItemData
    private Legend target = 0
    private static integer count = 0
    private static thistype array byIndex

    private method OnDeath takes nothing returns nothing
      set this.Progress = QUEST_PROGRESS_FAILED
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

    private static method OnAnyUnitTrain takes nothing returns nothing  //this will fuck up if a legend is already alive or another one is trained
      local integer i = 0
      local thistype loopQuestItem
      local unit triggerUnit = GetTrainedUnit()
      loop
        exitwhen i == thistype.count
        set loopQuestItem = thistype.byIndex[i]
        if not loopQuestItem.ProgressLocked and loopQuestItem.target.UnitType == GetUnitTypeId(triggerUnit) and loopQuestItem.Holder.Player == GetOwningPlayer(GetTrainedUnit()) then
          set loopQuestItem.Progress = QUEST_PROGRESS_COMPLETE
        endif
        set i = i + 1
      endloop
    endmethod

    method OnAdd takes nothing returns nothing
      if UnitAlive(this.target.Unit) then
        set this.Progress = QUEST_PROGRESS_COMPLETE
      endif
    endmethod

    static method create takes Legend target returns thistype
      local thistype this = thistype.allocate()
      set this.target = target
      if IsUnitType(target.Unit, UNIT_TYPE_STRUCTURE) then
        set this.Description = target.Name + " is intact"
      else
        set this.Description = target.Name + " is alive"
      endif
      set thistype.byIndex[thistype.count] = this
      set thistype.count = thistype.count + 1
      return this
    endmethod

    private static method onInit takes nothing returns nothing
      local trigger trig = CreateTrigger()
      call OnLegendPermaDeath.register(trig)
      call PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_TRAIN_FINISH, function thistype.OnAnyUnitTrain)
      call TriggerAddAction(trig, function thistype.OnAnyUnitDeath)
    endmethod
  endstruct

endlibrary