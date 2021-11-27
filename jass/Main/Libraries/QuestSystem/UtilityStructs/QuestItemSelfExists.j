library QuestItemSelfExists initializer OnInit requires QuestItemData, Faction

  struct QuestItemSelfExists extends QuestItemData
    private static integer count = 0
    private static thistype array byIndex

    method operator ShowsInQuestLog takes nothing returns boolean
      return false
    endmethod

    method OnAdd takes nothing returns nothing
      set this.Progress = QUEST_PROGRESS_COMPLETE
    endmethod

    static method OnAnyFactionScoreStatusChanged takes nothing returns nothing
      local integer i = 0
      local Faction triggerFaction = GetTriggerFaction()
      if triggerFaction != 0 and triggerFaction.ScoreStatus == SCORESTATUS_DEFEATED then
        loop
          exitwhen i == thistype.count
          if thistype.byIndex[i].Holder == triggerFaction then
            set thistype.byIndex[i].Progress = QUEST_PROGRESS_FAILED
          endif
          set i = i + 1
        endloop
      endif
    endmethod

    static method create takes nothing returns thistype
      local thistype this = thistype.allocate()
      set thistype.byIndex[thistype.count] = this
      set thistype.count = thistype.count + 1
      set this.Progress = QUEST_PROGRESS_COMPLETE
      return this
    endmethod
  endstruct

  private function OnInit takes nothing returns nothing
    local trigger trig = CreateTrigger()
    call FactionScoreStatusChanged.register(trig) 
    call TriggerAddAction(trig, function QuestItemSelfExists.OnAnyFactionScoreStatusChanged)
  endfunction

endlibrary