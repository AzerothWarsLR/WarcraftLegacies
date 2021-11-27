
library CheatVision initializer OnInit requires Persons, Persons, TestSafety

  //**CONFIG
  globals
    private constant string COMMAND     = "-vision "
    private fogmodifier array fogs 
  endglobals
  //*ENDCONFIG

  private function Actions takes nothing returns nothing
    local integer i = 0
    local string enteredString = GetEventPlayerChatString()
    local player p = GetTriggerPlayer()
    local integer pId = GetPlayerId(p)
    local string parameter = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString))  
    
    if parameter == "on" then
      set fogs[pId] = CreateFogModifierRectBJ( true, p, FOG_OF_WAR_VISIBLE, GetPlayableMapRect() )
      call DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Whole map revealed.")
    elseif parameter == "off" then
      call DestroyFogModifier(fogs[pId])
      call DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Whole map unrevealed.")
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