//Revokes an invitation sent to a player from the sending player's Team.

library UninviteCommand initializer OnInit requires Team

	globals
    private constant string COMMAND = "-uninvite "
  endglobals

	private function Actions takes nothing returns nothing
  	local string enteredString = GetEventPlayerChatString()
    local string content = null
    local Faction targetFaction = 0
    local Person senderPerson = Person.ByHandle(GetTriggerPlayer())

  	if SubString( enteredString, 0, StringLength(COMMAND) ) == COMMAND then
    	set content = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString))
      set content = StringCase(content, false)
      set targetFaction = Faction.factionsByName[content]
      if targetFaction != 0 then
        if targetFaction.Person != 0 then
        	call senderPerson.Faction.Team.Uninvite(targetFaction)
        else
          call DisplayTextToPlayer(senderPerson.Player, 0, 0, "There is no player with the Faction " + targetFaction.prefixCol + targetFaction.Name + "|r.")
      	endif
      else
        call DisplayTextToPlayer(senderPerson.Player, 0, 0, "There is no Faction with the name " + content + ".")
      endif
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

    call TriggerAddAction(trig, function Actions)
 	endfunction

endlibrary 