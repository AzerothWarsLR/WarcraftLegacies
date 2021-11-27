//A command that pings all units belonging to the user that have a limit on how many of them can be made.
library LimitedCommand initializer OnInit requires Team, Persons, Faction

	globals
    private constant string COMMAND = "-limited"
  endglobals

	private function Actions takes nothing returns nothing
    local Person triggerPerson = Person.ByHandle(GetTriggerPlayer())
    local Faction triggerFaction = triggerPerson.Faction
    local group tempGroup = CreateGroup()
    local integer i = 0
    local unit u
    call GroupEnumUnitsOfPlayer(tempGroup, triggerPerson.Player, null)

    loop
      set u = FirstOfGroup(tempGroup)
      exitwhen u == null
      set i = 0
      loop
        exitwhen i == triggerFaction.ObjectLimitCount
        if GetUnitTypeId(u) == triggerFaction.objectList[i] and triggerFaction.objectLimits[triggerFaction.objectList[i]] < UNLIMITED then
          call PingMinimapForPlayer(triggerPerson.Player, GetUnitX(u), GetUnitY(u), 5.)
        endif
        set i = i + 1
      endloop
      call GroupRemoveUnit(tempGroup, u)
    endloop

    call DestroyGroup(tempGroup)
    set tempGroup = null
  endfunction

	private function OnInit takes nothing returns nothing
    local trigger trig = CreateTrigger(  )
    local integer i = 0
        
    loop
    exitwhen i > MAX_PLAYERS
    	call TriggerRegisterPlayerChatEvent( trig, Player(i), COMMAND, true )
      set i = i + 1
    endloop
    
    call TriggerAddAction(trig, function Actions)
 	endfunction

endlibrary