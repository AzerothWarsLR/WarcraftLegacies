library QuestItemResearch requires QuestItemData

  struct QuestItemResearch extends QuestItemData
    private static integer count = 0
    private static thistype array byIndex
    private integer researchId

    static method create takes integer researchId, integer structureId returns thistype
      local thistype this = thistype.allocate()
      set this.Description = "Research " + GetObjectName(researchId) + " from the " + GetObjectName(structureId)
      set this.researchId = researchId
      set thistype.byIndex[thistype.count] = this
      set thistype.count = thistype.count + 1
      return this
    endmethod

    private static method OnAnyResearch takes nothing returns nothing
      local integer i = 0
      local thistype loopQuestItem
      local integer researched = GetResearched()
      loop
        exitwhen i == thistype.count
        set loopQuestItem = thistype.byIndex[i]
        if loopQuestItem.researchId == researched and loopQuestItem.Holder.Player == GetOwningPlayer(GetTriggerUnit()) then
          set loopQuestItem.Progress = QUEST_PROGRESS_COMPLETE
        endif
        set i = i + 1
      endloop
    endmethod

    private static method onInit takes nothing returns nothing
      call PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_RESEARCH_FINISH, function thistype.OnAnyResearch) //TODO: use filtered events
    endmethod
  endstruct

endlibrary