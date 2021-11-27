library CheatSpawn initializer OnInit requires TestSafety

  globals
    private constant string COMMAND     = "-spawn "
    private string parameter = null
    private string parameter2 = null
  endglobals

  private function Char2Id takes string c returns integer
    local integer i = 0
    local string abc = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
    local string t

    loop
      set t = SubString(abc,i,i + 1)
      exitwhen t == null or t == c
      set i = i + 1
    endloop
    if i < 10 then
      return i + 48
    elseif i < 36 then
      return i + 65 - 10
    endif
    return i + 97 - 36
  endfunction

  private function S2Raw takes string s returns integer
    return ((Char2Id(SubString(s,0,1)) * 256 + Char2Id(SubString(s,1,2))) * 256 + Char2Id(SubString(s,2,3))) * 256 + Char2Id(SubString(s,3,4))
  endfunction

  private function Spawn takes nothing returns nothing
    local integer i = 0
    loop
    exitwhen i == S2I(parameter2)
      call CreateUnit( GetTriggerPlayer(), S2Raw(parameter), GetUnitX(GetEnumUnit()), GetUnitY(GetEnumUnit()), 0 )
      call CreateItem( S2Raw(parameter), GetUnitX(GetEnumUnit()), GetUnitY(GetEnumUnit()) )
      set i = i + 1
    endloop
  endfunction

  private function Actions takes nothing returns nothing
    local integer i = 0
    local string enteredString = GetEventPlayerChatString()
    local player p = GetTriggerPlayer()
    local integer pId = GetPlayerId(p)
    set parameter = SubString(enteredString, StringLength(COMMAND), StringLength(COMMAND)+4)  
    set parameter2 = SubString(enteredString, StringLength(COMMAND) + StringLength(parameter)+1, StringLength(enteredString))
    
    if S2I(parameter2) < 1 then
      set parameter2 = "1"
    endif
    
    if S2Raw(parameter) >= 0 then
      call ForGroupBJ( GetUnitsSelectedAll(p), function Spawn )
      call DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Attempted to spawn " + parameter2 + " of object " + GetObjectName(S2Raw(parameter)) + ".")
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