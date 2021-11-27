
library CheatUnlock initializer OnInit requires Persons, TestSafety

  globals
    private constant string COMMAND     = "-unlock"
    private constant integer UPGRADE_A = 'R04I'
    private constant integer UPGRADE_B = 'R04J'
    private constant integer UPGRADE_C = 'R04N'
    private constant integer UPGRADE_D = 'R009'
  endglobals

  private function UnlockUpgrade takes player p, integer i returns nothing
    call DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Granted research " + GetObjectName(i) + ".")
    call SetPlayerTechResearched(p, i, 1)
  endfunction

  private function Actions takes nothing returns nothing
    local integer i = 0
    local string enteredString = GetEventPlayerChatString()
    local player p = GetTriggerPlayer()
    local integer pId = GetPlayerId(p)
    local string parameter = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString))  
    
    call UnlockUpgrade(p, UPGRADE_A)
    call UnlockUpgrade(p, UPGRADE_B)
    call UnlockUpgrade(p, UPGRADE_C)
    call UnlockUpgrade(p, UPGRADE_D)
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