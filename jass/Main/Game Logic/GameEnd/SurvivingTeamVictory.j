//When there is only one team left in the game that hasn't been defeated, that team wins.
library SurvivingTeamVictory initializer OnInit requires VictoryDefeat, Team, Faction

  private function OnTeamScoreStatusChanged takes nothing returns nothing
    local Team loopTeam
    local integer i = 0
    local Team victoriousTeam = 0
    local integer total = 0
    if not GameWon and GetTriggerTeam().ScoreStatus == SCORESTATUS_DEFEATED then
      loop
        exitwhen i == Team.Count or total > 1
        set loopTeam = Team.ByIndex(i)
        if loopTeam.ScoreStatus == SCORESTATUS_NORMAL then
          set total = total + 1
          set victoriousTeam = loopTeam
        endif
        set i = i + 1
      endloop
    endif
    if total == 1 then
      call TeamVictory(victoriousTeam)
    endif
  endfunction

  private function OnInit takes nothing returns nothing
    local trigger trig = CreateTrigger()
    call TeamScoreStatusChanged.register(trig)
    call TriggerAddAction(trig, function OnTeamScoreStatusChanged)
  endfunction

endlibrary