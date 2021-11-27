library CheatMP initializer OnInit requires TestSafety

  globals
      private constant string COMMAND     = "-mp "
      private string parameter = null
  endglobals

  private function SetMana takes nothing returns nothing
      call SetUnitManaBJ( GetEnumUnit(), S2R(parameter))
  endfunction

  private function Actions takes nothing returns nothing
    local integer i = 0
    local string enteredString = GetEventPlayerChatString()
    local player p = GetTriggerPlayer()
    local integer pId = GetPlayerId(p)
    set parameter = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString))  
    
    if S2I(parameter) >= 0 then
      call ForGroupBJ( GetUnitsSelectedAll(p), function SetMana )
      call DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Setting mana of selected units to " + parameter + ".")
    endif    
  endfunction

  //===========================================================================
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