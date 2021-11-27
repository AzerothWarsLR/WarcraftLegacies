
library CheatTele initializer OnInit requires Persons, TestSafety

  //**CONFIG
  globals
    private constant string COMMAND     = "-tele "
    private boolean array TeleToggle 
  endglobals
  //*ENDCONFIG

  private function Patrol takes nothing returns nothing
    if GetIssuedOrderId() == 851990 and TeleToggle[GetPlayerId(GetTriggerPlayer())] then
      call SetUnitX(GetTriggerUnit(), GetOrderPointX())
      call SetUnitY(GetTriggerUnit(), GetOrderPointY())
    endif
  endfunction
  
  private function Actions takes nothing returns nothing
    local integer i = 0
    local string enteredString = GetEventPlayerChatString()
    local player p = GetTriggerPlayer()
    local integer pId = GetPlayerId(p)
    local string parameter = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString))  
    
    if parameter == "on" then
      set TeleToggle[pId] = true
      call DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Teleport activated. Use patrol to move instantly.")
    elseif parameter == "off" then
      set TeleToggle[pId] = false
      call DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Teleport deactivated. Patrol works normally.")
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
  
    call PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_ISSUED_POINT_ORDER, function Patrol)
  endfunction
  
endlibrary