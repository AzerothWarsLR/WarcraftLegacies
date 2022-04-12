using AzerothWarsCSharp.MacroTools.FactionSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Game_Logic.GameEnd
{
  /// <summary>
  ///   When a Team gets a certain number of <see cref="ControlPoint" />s they win.
  /// </summary>
  public static class ControlPointVictory
  {
    private const int CPS_WARNING = 75; //How many Control Points to start the warning at
    private const string VICTORY_COLOR = "|cff911499";
    private static int _cpsVictory = 90; //This many Control Points gives an instant win

    private static Team _victoriousTeam;
    private static trigger _controlPointTrig;

    public static Team GetVictoriousTeam()
    {
      return _victoriousTeam;
    }

    public static void SetCpsVictory(int victoryCpCount)
    {
      _cpsVictory = victoryCpCount;
    }

    public static int GetControlPointsRequiredVictory()
    {
      return _cpsVictory;
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
        " out of " + I2S(_cpsVictory) + " Control Points required to win the game!");
    }

    private static void ControlPointOwnerChanges(object? sender,
      ControlPointOwnerChangeEventArgs controlPointOwnerChangeEventArgs)
    {
      if (!VictoryDefeat.GameWon)
      {
        var team = Person.ByHandle(GetOwningPlayer(controlPointOwnerChangeEventArgs.ControlPoint.Unit)).Faction.Team;
        var teamControlPoints = GetTeamControlPoints(team);
        if (teamControlPoints >= _cpsVictory)
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