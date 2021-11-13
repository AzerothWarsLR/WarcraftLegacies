//using AzerothWarsCSharp.Source.Libraries;
//using static War3Api.Common;

//namespace AzerothWarsCSharp.Source.GameLogic
//{
//  /// <summary>
//  /// When a Team gets a certain number of Control Points, they get a popup indicating they won the game.
//  /// There is also a popup warning whenever a Team gets a different Control Point threshold.
//  /// </summary>
//  public static class Victory
//  {
//    public static int CPS_VICTORY { get; } = 80;
//    public static int CPS_WARNING { get; } = 70;
//    private static readonly string VICTORY_COLOR = "|cff911499";
//    private static bool _gameWon = false;

//    private static void TeamVictory(Team team)
//    {
//      _gameWon = true;
//      DisplayTextToPlayer(GetLocalPlayer(), 0, 0, VICTORY_COLOR + "TEAM VICTORY!|r\n" + team.Name +
//        " has won the game! You may continue playing, but no further winners will be determined.");
//      //Play victory music from first player in winning team
//      foreach (var faction in team.Factions)
//        if (faction.Player != null && faction.VictoryMusic != null)
//        {
//          StopMusic(true);
//          PlayThematicMusic(faction.VictoryMusic);
//          break;
//        }
//    }

//    private static void TeamWarning(Team team, int controlPointCount)
//    {
//      DisplayTextToPlayer(GetLocalPlayer(), 0, 0, "\n" + VICTORY_COLOR + "TEAM VICTORY IMMINENT|r\n" +
//        team.Name + " has captured " + controlPointCount.ToString() + " out of " + I2S(CPS_VICTORY) +
//        " Control Points required to win the game!");
//    }

//    private static int GetTeamTotalControlPoints(Team team)
//    {
//      var total = 0;
//      foreach (var faction in team.Factions)
//      {
//        total += faction.ControlPoints;
//      }
//      return total;
//    }

//    private static void OnControlPointOwnerChanged(object sender, ControlPointEventArgs e)
//    {
//      if (!_gameWon)
//      {
//        var triggerTeam = e.ControlPoint.OwningFaction.Team;
//        var teamTotalCPs = GetTeamTotalControlPoints(triggerTeam);
//        if (teamTotalCPs >= CPS_VICTORY)
//        {
//          TeamVictory(triggerTeam);
//        }
//        else if (teamTotalCPs > CPS_WARNING)
//        {
//          TeamWarning(triggerTeam, teamTotalCPs);
//        }
//      }
//    }

//    public static void Initialize()
//    {
//      foreach (var controlPoint in ControlPoint.All)
//      {
//        controlPoint.OwnerChanged += OnControlPointOwnerChanged;
//      }
//    }
//  }
//}
