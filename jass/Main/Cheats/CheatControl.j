
library CheatControl initializer OnInit requires Persons, Persons, TestSafety

  //**CONFIG
  globals
    private constant string COMMAND     = "-control "
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
        call SetPlayerAllianceStateBJ( GetTriggerPlayer(), Player(i), bj_ALLIANCE_ALLIED_ADVUNITS )
        call SetPlayerAllianceStateBJ( Player(i), GetTriggerPlayer(), bj_ALLIANCE_ALLIED_ADVUNITS )
        set i = i + 1
      endloop
      call DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Granted control of all players.")
    else        
      call SetPlayerAllianceStateBJ( Player(S2I(parameter)), GetTriggerPlayer(), bj_ALLIANCE_ALLIED_ADVUNITS )
      call SetPlayerAllianceStateBJ( GetTriggerPlayer(), Player(S2I(parameter)), bj_ALLIANCE_ALLIED_ADVUNITS )
      call DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Granted control of player " + GetPlayerName(Player(S2I(parameter))) + ".")
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