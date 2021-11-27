library QuestItemBuild requires QuestItemData

  struct QuestItemBuild extends QuestItemData
    private static integer count = 0
    private static thistype array byIndex
    private integer objectId
    private integer currentBuildCount
    private integer targetBuildCount

    private method operator CurrentBuildCount= takes integer value returns nothing
      set this.currentBuildCount = value
      set this.Description = "Build " + GetObjectName(objectId) + "s (" + I2S(currentBuildCount) + "/" + I2S(targetBuildCount) + ")"
    endmethod

    static method create takes integer objectId, integer targetBuildCount returns thistype
      local thistype this = thistype.allocate()
      set this.objectId = objectId
      set thistype.byIndex[thistype.count] = this
      set thistype.count = thistype.count + 1
      set this.targetBuildCount = targetBuildCount
      set this.CurrentBuildCount = 0
      return this
    endmethod

    private static method OnAnyBuild takes nothing returns nothing
      local integer i = 0
      local thistype loopQuestItem
      local unit triggerUnit = GetConstructedStructure()
      loop
        exitwhen i == thistype.count
        set loopQuestItem = thistype.byIndex[i]
        if not loopQuestItem.ProgressLocked and loopQuestItem.objectId == GetUnitTypeId(triggerUnit) and loopQuestItem.Holder.Player == GetOwningPlayer(GetConstructedStructure()) then
          set loopQuestItem.CurrentBuildCount = loopQuestItem.currentBuildCount + 1
          if loopQuestItem.currentBuildCount == loopQuestItem.targetBuildCount then
            set loopQuestItem.Progress = QUEST_PROGRESS_COMPLETE
          endif
        endif
        set i = i + 1
      endloop
    endmethod

    private static method onInit takes nothing returns nothing
      call PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_CONSTRUCT_FINISH, function thistype.OnAnyBuild) //TODO: use filtered events
    endmethod
  endstruct

endlibrary