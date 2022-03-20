//When a Team gets a certain number of Control Points they win.
//This ends the game.

using AzerothWarsCSharp.Source.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.Game_Logic.GameEnd
{
  public static class ControlPointVictory
  {
    private static int CPS_VICTORY = 90; //This many Control Points gives an instant win
    private const int CPS_WARNING = 75; //How many Control Points to start the warning at
    private const string VICTORY_COLOR = "|cff911499";

    private static Team VictoriousTeam;
    private static trigger ControlPointTrig;
    
    public static Team GetVictoriousTeam()
    {
      return VictoriousTeam;
    }

    public static void SetCpsVictory(int victoryCpCount)
    {
      CPS_VICTORY = victoryCpCount;
    }

    public static int GetControlPointsRequiredVictory()
    {
      return CPS_VICTORY;
    }

    public static int GetControlPointsRequiredWarning()
    {
      return CPS_WARNING;
    }

    public static int GetTeamControlPoints(Team? whichTeam)
    {
      var total = 0;
      var i = 0;
      while (true)
      {
        if (i == whichTeam.FactionCount)
        {
          break;
        }

        if (whichTeam.GetFactionByIndex(i).Person != 0)
        {
          total = total + whichTeam.GetFactionByIndex(i).Person.ControlPointCount;
        }

        i = i + 1;
      }

      return total;
    }

    private static void TeamWarning(Team? whichTeam, int controlPoints)
    {
      DisplayTextToPlayer(GetLocalPlayer(), 0, 0,
        "\n" + VICTORY_COLOR + "TEAM VICTORY IMMINENT|r\n" + whichTeam.Name + " has captured " + I2S(controlPoints) +
        " out of " + I2S(CPS_VICTORY) + " Control Points required to win the game!");
    }

    private static void ControlPointOwnerChanges()
    {
      Team? team;
      int teamControlPoints;

      if (!GameWon)
      {
        team = Person.ByHandle(GetOwningPlayer(GetTriggerControlPoint().u)).Faction.Team;
        teamControlPoints = GetTeamControlPoints(team);
        if (teamControlPoints >= CPS_VICTORY)
        {
          TeamVictory(team);
        }
        else if (teamControlPoints > CPS_WARNING)
        {
          TeamWarning(team, teamControlPoints);
        }
      }
    }

    public static void Setup()
    {
      ControlPointTrig = CreateTrigger();
      OnControlPointOwnerChange.register(ControlPointTrig);
      TriggerAddAction(ControlPointTrig, ControlPointOwnerChanges);
    }
  }
}