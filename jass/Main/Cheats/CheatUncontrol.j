
library CheatUncontrol initializer OnInit requires Persons, Persons, TestSafety

  //**CONFIG
  globals
    private constant string COMMAND = "-uncontrol "
  endglobals
  //*ENDCONFIG

  private function Actions takes nothing returns nothing
    local integer i = 0
    local string enteredString = GetEventPlayerChatString()
    local player p = GetTriggerPlayer()
    local integer pId = GetPlayerId(p)
    local string parameter = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString))  

    if parameter == "all" then
      set i = 0
      loop
      exitwhen i > MAX_PLAYERS
        call SetPlayerAlliance(Player(i), GetTriggerPlayer(), ALLIANCE_SHARED_CONTROL, false)
        call SetPlayerAlliance(Player(i), GetTriggerPlayer(), ALLIANCE_SHARED_ADVANCED_CONTROL, false)
        set i = i + 1
      endloop
      call DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Revoked control of all players.")
    else      
      call SetPlayerAlliance(Player(S2I(parameter)), GetTriggerPlayer(), ALLIANCE_SHARED_CONTROL, false)  
      call SetPlayerAlliance(Player(S2I(parameter)), GetTriggerPlayer(), ALLIANCE_SHARED_ADVANCED_CONTROL, false)
      call DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Revoked control of player " + GetPlayerName(Player(S2I(parameter))) + ".")
    endif
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