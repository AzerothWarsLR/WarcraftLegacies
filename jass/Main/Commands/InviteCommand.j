//Invites the specified faction's player to the sender's Team. 

library InviteCommand initializer OnInit requires Team

	globals
    private constant string COMMAND = "-invite "
  endglobals

	private function Actions takes nothing returns nothing
  	local string enteredString = GetEventPlayerChatString()
    local string content = null
    local Faction targetFaction = 0
    local Person senderPerson = Person.ByHandle(GetTriggerPlayer())
   
    if AreAllianceActive == true then
  	  if SubString( enteredString, 0, StringLength(COMMAND) ) == COMMAND then
    	  set content = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString))
        set content = StringCase(content, false)
        set targetFaction = Faction.factionsByName[content]

        if targetFaction == 0 then
          call DisplayTextToPlayer(senderPerson.Player, 0, 0, "There is no Faction with the name " + content + ".")
          return
        endif

        if targetFaction.CanBeInvited == false then
          call DisplayTextToPlayer(senderPerson.Player, 0, 0, targetFaction.prefixCol + targetFaction.Name + " can't voluntarily change teams.")
        endif

        if senderPerson.Faction == targetFaction then
          call DisplayTextToPlayer(senderPerson.Player, 0, 0, "You cannot invite yourself to your own team.")
          return
        endif

        if targetFaction.Person == 0 then
          call DisplayTextToPlayer(senderPerson.Player, 0, 0, "There is no player with the Faction " + targetFaction.prefixCol + targetFaction.Name + "|r.")
          return
        endif

        if targetFaction.Person != 0 then
          call senderPerson.Faction.Team.Invite(targetFaction)
        endif

      endif
    else 
      call DisplayTextToPlayer(senderPerson.Player, 0, 0, "You cannot ally yet")
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