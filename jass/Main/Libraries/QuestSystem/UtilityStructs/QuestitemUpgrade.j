library QuestItemUpgrade requires QuestItemData

  struct QuestItemUpgrade extends QuestItemData
    private static integer count = 0
    private static thistype array byIndex
    private integer objectId
    private unit triggerUnit

    method operator TriggerUnit takes nothing returns unit
      return this.triggerUnit
    endmethod

    static method create takes integer objectId, integer upgradeFromId returns thistype
      local thistype this = thistype.allocate()
      set this.Description = "Upgrade your " + GetObjectName(upgradeFromId) + " to a " + GetObjectName(objectId)
      set this.objectId = objectId
      set thistype.byIndex[thistype.count] = this
      set thistype.count = thistype.count + 1
      return this
    endmethod

    private static method OnAnyUpgrade takes nothing returns nothing
      local integer i = 0
      local thistype loopQuestItem
      local unit triggerUnit = GetTriggerUnit()
      loop
        exitwhen i == thistype.count
        set loopQuestItem = thistype.byIndex[i]
        if not loopQuestItem.ProgressLocked and loopQuestItem.objectId == GetUnitTypeId(triggerUnit) and loopQuestItem.Holder.Player == GetOwningPlayer(GetTriggerUnit()) then
          set loopQuestItem.triggerUnit = triggerUnit
          set loopQuestItem.Progress = QUEST_PROGRESS_COMPLETE
        endif
        set i = i + 1
      endloop
    endmethod

    private static method onInit takes nothing returns nothing
      call PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_UPGRADE_FINISH, function thistype.OnAnyUpgrade) //TODO: use filtered events
    endmethod
  endstruct

endlibrary