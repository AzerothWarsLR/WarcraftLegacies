library CleanPersons initializer OnInit requires Persons, TestSafety

  //Removes players from the game if their slot is unoccupied

  private function Actions takes nothing returns nothing
    local integer i = 0
    local Person loopPerson = 0

    if not AreCheatsActive then
      loop
      exitwhen i > MAX_PLAYERS
        set loopPerson = Person.ById(i)
        if loopPerson != 0 and GetPlayerSlotState(Player(i)) != PLAYER_SLOT_STATE_PLAYING and loopPerson.Faction.ScoreStatus == SCORESTATUS_NORMAL then
          set loopPerson.Faction.ScoreStatus = SCORESTATUS_DEFEATED
        endif
        set i = i + 1
      endloop
    endif
  endfunction

  private function OnInit takes nothing returns nothing
    local trigger trig = CreateTrigger()
    call TriggerRegisterTimerEvent(trig, 2., false)
    call TriggerAddCondition(trig, Condition(function Actions))
  endfunction

endlibrary