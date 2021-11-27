//A command that causes a player to leave their Team and be given a solo Team with their Faction as the name. 

library Unally initializer OnInit requires Team, Persons, Faction

	globals
    private constant string COMMAND = "-unally"
  endglobals

	private function Actions takes nothing returns nothing
   local Person triggerPerson = Person.ByHandle(GetTriggerPlayer())
     call triggerPerson.Faction.Unally()

   // if AreAllianceActive == true then
   //   call triggerPerson.Faction.Unally()
   // else 
   //   call DisplayTextToPlayer(triggerPerson.Player, 0, 0, "You cannot unally yet")
   // endif
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