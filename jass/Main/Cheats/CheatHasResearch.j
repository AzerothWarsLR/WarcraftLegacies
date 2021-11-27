library CheatHasResearch initializer OnInit requires TestSafety

  globals
    private constant string COMMAND     = "-hasresearch "
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

  private function CheckResearch takes player p, string parameter returns nothing
    local integer object = S2Raw(parameter)
    call DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Level of research " + GetObjectName(object) + ": " + I2S(GetPlayerTechCount(p, object, true)))
  endfunction

  private function Actions takes nothing returns nothing
    local integer i = 0
    local string enteredString = GetEventPlayerChatString()
    local string parameter = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString))  
    call CheckResearch(GetTriggerPlayer(), parameter)
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