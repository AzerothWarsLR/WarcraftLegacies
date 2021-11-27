
library CheatGod initializer OnInit requires Persons, TestSafety

  globals
    private constant string COMMAND     = "-god "
    private boolean array Toggle
  endglobals

  private function Damage takes nothing returns nothing
    if Toggle[GetPlayerId(GetTriggerPlayer())] then
      call BlzSetEventDamage(0)
    elseif Toggle[GetPlayerId(GetOwningPlayer(GetEventDamageSource()))] then
      call BlzSetEventDamage(GetEventDamage() * 100)
    endif
  endfunction
  
  private function Actions takes nothing returns nothing
    local integer i = 0
    local string enteredString = GetEventPlayerChatString()
    local player p = GetTriggerPlayer()
    local integer pId = GetPlayerId(p)
    local string parameter = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString))  
    
    if parameter == "on" then
        set Toggle[pId] = true
      call DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r God mod activated. Your units will deal 100x damage and take no damage.")
    elseif parameter == "off" then
      set Toggle[pId] = false
      call DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r God mode deactivated.")
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
    call TriggerAddAction(trig, function Actions)

    call PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_DAMAGED, function Damage)
  endfunction
    
endlibrary