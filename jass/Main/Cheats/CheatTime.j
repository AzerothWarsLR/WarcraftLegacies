
library CheatTime initializer OnInit requires Persons, Persons, TestSafety

  //**CONFIG
  globals
      private constant string COMMAND     = "-time "
  endglobals
  //*ENDCONFIG

  private function Actions takes nothing returns nothing
    local integer i = 0
    local string enteredString = GetEventPlayerChatString()
    local player p = GetTriggerPlayer()
    local integer pId = GetPlayerId(p)
    local string parameter = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString))  
    
    call SetFloatGameState(GAME_STATE_TIME_OF_DAY, S2R(parameter))
    call DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Time of day set to " + parameter + ".")
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