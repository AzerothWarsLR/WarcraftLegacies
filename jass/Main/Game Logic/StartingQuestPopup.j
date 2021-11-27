//Displays each Faction's starting quest after the cinematic phase ends
library StartingQuestPopup initializer OnInit requires Faction

  private function Actions takes nothing returns nothing
    local integer i = 0
    local Person loopPerson
    loop
    exitwhen i > MAX_PLAYERS
      set loopPerson = Person.ById(i)
      if loopPerson.Faction.StartingQuest != 0 then
        if GetLocalPlayer() == loopPerson.Player then
          call loopPerson.Faction.StartingQuest.DisplayDiscovered()
        endif
      endif
      set i = i + 1
    endloop
  endfunction

  private function OnInit takes nothing returns nothing
    local trigger trig = CreateTrigger()
    call TriggerRegisterTimerEvent(trig, 63., false)
    call TriggerAddCondition(trig, Condition(function Actions))
  endfunction

endlibrary