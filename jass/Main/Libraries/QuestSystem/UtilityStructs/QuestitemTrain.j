library QuestItemTrain requires QuestItemData

  struct QuestItemTrain extends QuestItemData
    private static integer count = 0
    private static thistype array byIndex
    private integer objectId
    private integer trainFromId
    private integer currentTrainCount
    private integer targetTrainCount

    private method operator CurrentTrainCount= takes integer value returns nothing
      set this.currentTrainCount = value
      set this.Description = "Train " + GetObjectName(objectId) + "s from the " + GetObjectName(trainFromId) + " (" + I2S(currentTrainCount) + "/" + I2S(targetTrainCount) + ")"
    endmethod

    static method create takes integer objectId, integer trainFromId, integer targetTrainCount returns thistype
      local thistype this = thistype.allocate()
      set this.objectId = objectId
      set this.trainFromId = trainFromId
      set thistype.byIndex[thistype.count] = this
      set thistype.count = thistype.count + 1
      set this.targetTrainCount = targetTrainCount
      set this.CurrentTrainCount = 0
      return this
    endmethod

    private static method OnAnyTrain takes nothing returns nothing
      local integer i = 0
      local thistype loopQuestItem
      local unit triggerUnit = GetTrainedUnit()
      loop
        exitwhen i == thistype.count
        set loopQuestItem = thistype.byIndex[i]
        if not loopQuestItem.ProgressLocked and loopQuestItem.objectId == GetUnitTypeId(triggerUnit) and loopQuestItem.Holder.Player == GetOwningPlayer(GetTrainedUnit()) then
          set loopQuestItem.CurrentTrainCount = loopQuestItem.currentTrainCount + 1
          if loopQuestItem.currentTrainCount == loopQuestItem.targetTrainCount then
            set loopQuestItem.Progress = QUEST_PROGRESS_COMPLETE
          endif
        endif
        set i = i + 1
      endloop
    endmethod

    private static method onInit takes nothing returns nothing
      call PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_TRAIN_FINISH, function thistype.OnAnyTrain) //TODO: use filtered events
    endmethod
  endstruct

endlibrary