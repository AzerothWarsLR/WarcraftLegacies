//When a Team gets a certain number of Control Points they win. 
//This ends the game.

library ControlPointVictory initializer OnInit requires Team, ControlPoint

  globals
    private constant integer CPS_VICTORY = 90 //This many Control Points gives an instant win
    private constant integer CPS_WARNING = 75 //How many Control Points to start the warning at
    private constant string VICTORY_COLOR = "|cff911499"
    
    private Team VictoriousTeam = 0
    private trigger ControlPointTrig
  endglobals

  function GetVictoriousTeam takes nothing returns Team
    return VictoriousTeam
  endfunction

  function GetControlPointsRequiredVictory takes nothing returns integer
    return CPS_VICTORY
  endfunction

  function GetControlPointsRequiredWarning takes nothing returns integer
    return CPS_WARNING
  endfunction

  private function GetTeamControlPoints takes Team whichTeam returns integer
    local integer total = 0
    local integer i = 0
    loop
      exitwhen i == whichTeam.FactionCount
      if whichTeam.GetFactionByIndex(i).Person != 0 then
        set total = total + whichTeam.GetFactionByIndex(i).Person.ControlPointCount
      endif
      set i = i + 1
    endloop
    return total
  endfunction

  private function TeamWarning takes Team whichTeam, integer controlPoints returns nothing
    call DisplayTextToPlayer(GetLocalPlayer(), 0, 0, "\n" + VICTORY_COLOR + "TEAM VICTORY IMMINENT|r\n" + whichTeam.Name + " has captured " + I2S(controlPoints) + " out of " + I2S(CPS_VICTORY) + " Control Points required to win the game!")
  endfunction

  private function ControlPointOwnerChanges takes nothing returns nothing
    local Team team
    local integer teamControlPoints

    if not GameWon then
      set team = Person.ByHandle(GetOwningPlayer(GetTriggerControlPoint().u)).Faction.Team
      set teamControlPoints = GetTeamControlPoints(team)
      if teamControlPoints >= CPS_VICTORY then
        call TeamVictory(team)
      elseif teamControlPoints > CPS_WARNING then
        call TeamWarning(team, teamControlPoints)
      endif
    endif
  endfunction

  private function OnInit takes nothing returns nothing
    set ControlPointTrig = CreateTrigger()
    call OnControlPointOwnerChange.register(ControlPointTrig)
    call TriggerAddAction(ControlPointTrig, function ControlPointOwnerChanges)
  endfunction

endlibrary