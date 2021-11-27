

library CheatMana initializer OnInit requires Persons, TestSafety

    //**CONFIG
    globals
      private constant string COMMAND     = "-mana "
      private boolean array Toggle
    endglobals
    //*ENDCONFIG

    private function Spell takes nothing returns nothing
      if Toggle[GetPlayerId(GetTriggerPlayer())] then
        call SetUnitManaPercentBJ(GetTriggerUnit(), 100)
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
        call DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Infinite mana activated.")
      elseif parameter == "off" then
        set Toggle[pId] = false
        call DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Infinite mana deactivated.")
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
      call TriggerAddAction( trig, function Actions) 

      call PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_SPELL_ENDCAST, function Spell)
    endfunction
    
endlibrary