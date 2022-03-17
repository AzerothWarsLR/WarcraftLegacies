//When a Team gets a certain number of Control Points they win.
//This ends the game.

public class ControlPointVictory{

  
    private int CPS_VICTORY = 90 ;//This many Control Points gives an instant win
    private const int CPS_WARNING = 75 ;//How many Control Points to start the warning at
    private const string VICTORY_COLOR = "|cff911499";

    private Team VictoriousTeam = 0;
    private trigger ControlPointTrig;
  

  static Team GetVictoriousTeam( ){
    return VictoriousTeam;
  }

  static void SetCpsVictory(int victoryCpCount ){
    CPS_VICTORY = victoryCpCount;
  }

  static integer GetControlPointsRequiredVictory( ){
    return CPS_VICTORY;
  }

  static integer GetControlPointsRequiredWarning( ){
    return CPS_WARNING;
  }

  private static integer GetTeamControlPoints(Team whichTeam ){
    int total = 0;
    int i = 0;
    while(true){
      if ( i == whichTeam.FactionCount){ break; }
      if (whichTeam.GetFactionByIndex(i).Person != 0){
        total = total + whichTeam.GetFactionByIndex(i).Person.ControlPointCount;
      }
      i = i + 1;
    }
    return total;
  }

  private static void TeamWarning(Team whichTeam, int controlPoints ){
    DisplayTextToPlayer(GetLocalPlayer(), 0, 0, "\n" + VICTORY_COLOR + "TEAM VICTORY IMMINENT|r\n" + whichTeam.Name + " has captured " + I2S(controlPoints) + " out of " + I2S(CPS_VICTORY) + " Control Points required to win the game!");
  }

  private static void ControlPointOwnerChanges( ){
    Team team;
    int teamControlPoints;

    if (!GameWon){
      team = Person.ByHandle(GetOwningPlayer(GetTriggerControlPoint().u)).Faction.Team;
      teamControlPoints = GetTeamControlPoints(team);
      if (teamControlPoints >= CPS_VICTORY){
        TeamVictory(team);
      }else if (teamControlPoints > CPS_WARNING){
        TeamWarning(team, teamControlPoints);
      }
    }
  }

  private static void OnInit( ){
    ControlPointTrig = CreateTrigger();
    OnControlPointOwnerChange.register(ControlPointTrig);
    TriggerAddAction(ControlPointTrig,  ControlPointOwnerChanges);
  }

}
