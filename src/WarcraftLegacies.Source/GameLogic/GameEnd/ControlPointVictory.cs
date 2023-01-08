using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.GameLogic.GameEnd
{
  /// <summary>
  ///   When a Team gets a certain number of <see cref="ControlPoint" />s they win.
  /// </summary>
  public static class ControlPointVictory
  {
    private const int CpsWarning = 75; //How many Control Points to start the warning at
    private const string VictoryColor = "|cff911499";
    private static int _cpsVictory = 90; //This many Control Points gives an instant win

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
      return CpsWarning;
    }

    private static int GetTeamControlPoints(Team whichTeam)
    {
      var total = 0;
      foreach (var faction in whichTeam.GetAllFactions())
        if (faction.Player != null)
          total += faction.Player.GetControlPointCount();
      return total;
    }

    private static void TeamWarning(Team whichTeam, int controlPoints)
    {
      DisplayTextToPlayer(GetLocalPlayer(), 0, 0,
        $"\n{VictoryColor}TEAM VICTORY IMMINENT|r\n{whichTeam.Name} has captured {I2S(controlPoints)} out of {I2S(_cpsVictory)} Control Points required to win the game!");
    }

    private static void ControlPointOwnerChanges(object? sender,
      ControlPointOwnerChangeEventArgs controlPointOwnerChangeEventArgs)
    {
      if (VictoryDefeat.GameWon) return;
      var newOwnerTeam = controlPointOwnerChangeEventArgs.ControlPoint.Owner.GetTeam();
      var formerOwnerTeam = controlPointOwnerChangeEventArgs.FormerOwner.GetTeam();
      if (newOwnerTeam == null || newOwnerTeam == formerOwnerTeam) return;
      var teamControlPoints = GetTeamControlPoints(newOwnerTeam);
      if (teamControlPoints >= _cpsVictory)
        VictoryDefeat.TeamVictory(newOwnerTeam);
      else if (teamControlPoints > CpsWarning) TeamWarning(newOwnerTeam, teamControlPoints);
    }

    public static void Setup()
    {
      foreach (var controlPoint in ControlPointManager.Instance.GetAllControlPoints())
        controlPoint.ChangedOwner += ControlPointOwnerChanges;
    }
  }
}
