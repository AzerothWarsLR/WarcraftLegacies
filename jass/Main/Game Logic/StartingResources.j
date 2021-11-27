//Give each player their starting gold and lumber as the opening cinematic ends.
library StartingResources initializer OnInit requires Faction

  private function Actions takes nothing returns nothing
    local integer i = 0
    local Person loopPerson
    local Faction loopFaction
    loop
    exitwhen i > MAX_PLAYERS
      set loopPerson = Person.ById(i)
      if loopPerson != 0 then
        set loopFaction = loopPerson.Faction
        if loopFaction != 0 then
          if loopFaction.StartingGold != 0 then
            call SetPlayerState(loopPerson.Player, PLAYER_STATE_RESOURCE_GOLD, loopPerson.Faction.StartingGold)
          endif
          if loopFaction.StartingLumber != 0 then
            call SetPlayerState(loopPerson.Player, PLAYER_STATE_RESOURCE_LUMBER, loopPerson.Faction.StartingLumber)
          endif
        endif
      endif
      set i = i + 1
    endloop
  endfunction

  private function OnInit takes nothing returns nothing
    local trigger trig = CreateTrigger()
    call TriggerRegisterTimerEvent(trig, 60., false)
    call TriggerAddCondition(trig, Condition(function Actions))
  endfunction

endlibrary