library BootCommand initializer OnInit requires Faction

  globals
    private constant string COMMAND     = "-boot "
    private string parameter = null
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

      if senderPerson.Faction != FACTION_NAGA then
        call DisplayTextToPlayer(senderPerson.Player, 0, 0, "This command can only be used by liege factions.")
        return
      endif

      if AreAllianceActive == true then
        call DisplayTextToPlayer(senderPerson.Player, 0, 0, "Alliances are open")
        return
      endif

      if targetFaction == 0 then
        call DisplayTextToPlayer(senderPerson.Player, 0, 0, "There is no Faction with the name " + content + ".")
        return
      endif

      if senderPerson.Faction == targetFaction then
        call DisplayTextToPlayer(senderPerson.Player, 0, 0, "You cannot boot yourself from the game.")
        return
      endif

      if targetFaction.Person == 0 then
        call DisplayTextToPlayer(senderPerson.Player, 0, 0, "There is no player with the Faction " + targetFaction.ColoredName + ".")
        return
      endif

      if FACTION_FEL_HORDE.Team != TEAM_NAGA then
        call DisplayTextToPlayer(senderPerson.Player, 0, 0, " " + targetFaction.ColoredName + " is not your vassal.")
        return
      endif

      if targetFaction.Person != 0 then
        call targetFaction.obliterate()
        set targetFaction.Person.Faction = 0
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
    call TriggerAddAction( trig, function Actions )
  endfunction

endlibrary