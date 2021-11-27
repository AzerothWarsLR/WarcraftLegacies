library CheatTeam initializer OnInit requires Team, TestSafety

  globals
    private constant string COMMAND     = "-team "
    private string parameter = null
  endglobals

  private function Actions takes nothing returns nothing
    local integer i = 0
    local string enteredString = GetEventPlayerChatString()
    local player p = GetTriggerPlayer()
    local integer pId = GetPlayerId(p)
    local Team t
    set parameter = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString))  
    set t = Team.teamsByName[parameter]
    set Person.ById(pId).Faction.Team = t
    call DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Attempted to set team to " + t.Name + ".")
  endfunction

  //===========================================================================
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