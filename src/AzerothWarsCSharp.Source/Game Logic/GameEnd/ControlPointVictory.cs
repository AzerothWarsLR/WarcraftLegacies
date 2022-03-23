using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.Source.Game_Logic.GameEnd
{
  /// <summary>
  ///   When a Team gets a certain number of <see cref="ControlPoint" />s they win.
  /// </summary>
  public static class ControlPointVictory
  {
    private const int CPS_WARNING = 75; //How many Control Points to start the warning at
    private const string VICTORY_COLOR = "|cff911499";
    private static int CPS_VICTORY = 90; //This many Control Points gives an instant win

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

    private static int GetTeamControlPoints(Team? whichTeam)
    {
      var total = 0;
      foreach (var faction in whichTeam.GetAllFactions())
        if (faction.Person != null)
          total += faction.Person.ControlPointCount;
      return total;
    }

    private static void TeamWarning(Team? whichTeam, int controlPoints)
    {
      DisplayTextToPlayer(GetLocalPlayer(), 0, 0,
        "\n" + VICTORY_COLOR + "TEAM VICTORY IMMINENT|r\n" + whichTeam.Name + " has captured " + I2S(controlPoints) +
        " out of " + I2S(CPS_VICTORY) + " Control Points required to win the game!");
    }

    private static void ControlPointOwnerChanges(object? sender,
      ControlPointOwnerChangeEventArgs controlPointOwnerChangeEventArgs)
    {
      if (!VictoryDefeat.GameWon)
      {
        var team = Person.ByHandle(GetOwningPlayer(controlPointOwnerChangeEventArgs.ControlPoint.Unit)).Faction.Team;
        var teamControlPoints = GetTeamControlPoints(team);
        if (teamControlPoints >= CPS_VICTORY)
          VictoryDefeat.TeamVictory(team);
        else if (teamControlPoints > CPS_WARNING) TeamWarning(team, teamControlPoints);
      }
    }

    public static void Setup()
    {
      ControlPoint.OnControlPointOwnerChange += ControlPointOwnerChanges;
    }
  }
}