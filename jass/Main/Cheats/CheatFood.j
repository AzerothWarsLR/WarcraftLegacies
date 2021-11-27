
library CheatFood initializer OnInit requires Persons, TestSafety

  globals
    private constant string COMMAND     = "-food "
  endglobals

  private function Actions takes nothing returns nothing
    local integer i = 0
    local string enteredString = GetEventPlayerChatString()
    local string parameter = null
    local player p = GetTriggerPlayer()
    
    set parameter = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString))  
    call AdjustPlayerStateBJ(S2I(parameter), p, PLAYER_STATE_RESOURCE_FOOD_CAP)
    call DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Granted " + parameter + " food.")
  endfunction

  private function OnInit takes nothing returns nothing
    local trigger trig = CreateTrigger(  )
    local integer i = 0
    
    loop
    exitwhen i > MAX_PLAYERS
      call TriggerRegisterPlayerChatEvent( trig, Player(i), COMMAND, false )
      set i = i + 1
    endloop   
    call TriggerAddCondition(trig, Condition(function CheatCondition))
    call TriggerAddAction( trig, function Actions )
  endfunction
    
endlibrary