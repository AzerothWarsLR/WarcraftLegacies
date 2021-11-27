library QuestItemFactionDefeated initializer OnInit requires QuestItemData, Faction

  struct QuestItemFactionDefeated extends QuestItemData
    private static integer count = 0
    private static thistype array byIndex
    private Faction target = 0

    static method OnAnyFactionScoreStatusChanged takes nothing returns nothing
      local integer i = 0
      local Faction triggerFaction = GetTriggerFaction()
      if triggerFaction.ScoreStatus == SCORESTATUS_DEFEATED then
        loop
          exitwhen i == thistype.count
          if thistype.byIndex[i].target == triggerFaction then
            set thistype.byIndex[i].Progress = QUEST_PROGRESS_COMPLETE
          endif
          set i = i + 1
        endloop
      endif
    endmethod

    static method create takes Faction whichFaction returns thistype
      local thistype this = thistype.allocate()
      set thistype.byIndex[thistype.count] = this
      set thistype.count = thistype.count + 1
      set this.target = whichFaction
      set this.Description = whichFaction.Name + " has been defeated"
      return this
    endmethod
  endstruct

  private function OnInit takes nothing returns nothing
    local trigger trig = CreateTrigger()
    call FactionScoreStatusChanged.register(trig) 
    call TriggerAddAction(trig, function QuestItemFactionDefeated.OnAnyFactionScoreStatusChanged)
  endfunction

endlibrary