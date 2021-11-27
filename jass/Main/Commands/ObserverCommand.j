library ObserverCommand initializer OnInit

  //**CONFIG
  globals
      private constant string COMMAND     = "-obs"
  endglobals
  //*ENDCONFIG
  
  private function Actions takes nothing returns nothing
    local Person triggerPerson = Person.ByHandle(GetTriggerPlayer())
    local group tempGroup = CreateGroup()

    if triggerPerson != 0 then
      set triggerPerson.Faction.ScoreStatus = SCORESTATUS_DEFEATED
    endif
  endfunction

  private function OnInit takes nothing returns nothing
    local trigger trig = CreateTrigger(  )
    local integer i = 0
    
    loop
    exitwhen i > MAX_PLAYERS
      call TriggerRegisterPlayerChatEvent( trig, Player(i), COMMAND, true )
      set i = i + 1
    endloop   
    
    call TriggerAddCondition( trig, Condition(function Actions) )
  endfunction

endlibrary