library QuestItemEitherOf initializer OnInit requires QuestItemData

  struct QuestItemEitherOf extends QuestItemData
    private static integer count = 0
    private static thistype array byIndex

    private QuestItemData questItemA
    private QuestItemData questItemB

    method operator X takes nothing returns real
      return questItemA.X
    endmethod

    method operator Y takes nothing returns real
      return questItemA.Y
    endmethod

    static method create takes QuestItemData questItemA, QuestItemData questItemB returns thistype
      local thistype this = thistype.allocate()
      set this.questItemA = questItemA
      set this.questItemB = questItemB
      set questItemA.ParentQuestItem = this
      set questItemB.ParentQuestItem = this
      set this.Description = questItemA.Description + " or " + questItemB.Description
      set thistype.byIndex[thistype.count] = this
      set thistype.count = thistype.count + 1
      return this
    endmethod

    private method OnQuestItemProgressChanged takes nothing returns nothing
      if this.questItemA.Progress == QUEST_PROGRESS_COMPLETE or this.questItemB.Progress == QUEST_PROGRESS_COMPLETE then
        set this.Progress = QUEST_PROGRESS_COMPLETE
        return
      endif
      if this.questItemA.Progress == QUEST_PROGRESS_FAILED and this.questItemB.Progress == QUEST_PROGRESS_FAILED then
        set this.Progress = QUEST_PROGRESS_FAILED
        return
      endif
    endmethod

    public static method OnAnyQuestItemProgressChanged takes nothing returns nothing
      local QuestItemData triggerQuestItemData = QuestItemData.TriggerQuestItemData
      local integer i = 0
      loop
        exitwhen i == thistype.count
        if triggerQuestItemData == thistype.byIndex[i].questItemA or triggerQuestItemData == thistype.byIndex[i].questItemB then
          call thistype.byIndex[i].OnQuestItemProgressChanged()
        endif
        set i = i + 1
      endloop
    endmethod
  endstruct

  private function OnInit takes nothing returns nothing
    local trigger trig = CreateTrigger()
    call QuestItemData.ProgressChanged.register(trig)
    call TriggerAddAction(trig, function QuestItemEitherOf.OnAnyQuestItemProgressChanged)
  endfunction

endlibrary