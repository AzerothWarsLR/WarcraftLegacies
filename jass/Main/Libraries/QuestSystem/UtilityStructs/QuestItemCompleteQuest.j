library QuestItemCompleteQuest initializer OnInit requires QuestData, Faction

  struct QuestItemCompleteQuest extends QuestItemData
    private QuestData target = 0
    private static integer count = 0
    private static thistype array byIndex

    public method OnQuestProgressChanged takes nothing returns nothing
      if this.target.Progress == QUEST_PROGRESS_COMPLETE then
        set this.Progress = QUEST_PROGRESS_COMPLETE
      elseif this.target.Progress == QUEST_PROGRESS_FAILED then
        set this.Progress = QUEST_PROGRESS_FAILED
      endif
    endmethod

    public static method OnAnyQuestProgressChanged takes nothing returns nothing
      local integer i = 0
      local thistype loopItem
      loop
        exitwhen i == thistype.count
        set loopItem = thistype.byIndex[i]
        if loopItem.target == GetTriggerQuest() then
          call loopItem.OnQuestProgressChanged()
        endif
        set i = i + 1
      endloop
    endmethod

    static method create takes QuestData target returns thistype
      local thistype this = thistype.allocate()

      if target == 0 then
        call BJDebugMsg("Parameter target of QuestItemCompleteQuest cannot be 0")
      endif

      set this.target = target
      set this.Description = "Complete the quest " + target.Title
      set thistype.byIndex[thistype.count] = this
      set thistype.count = thistype.count + 1
      return this
    endmethod

  endstruct

  private function OnInit takes nothing returns nothing
    local trigger trig = CreateTrigger()
    call QuestProgressChanged.register(trig) 
    call TriggerAddAction(trig, function QuestItemCompleteQuest.OnAnyQuestProgressChanged)
  endfunction  

endlibrary