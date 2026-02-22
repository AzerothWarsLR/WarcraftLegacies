using MacroTools.Extensions;
using MacroTools.GameTime;
using WCSharp.Shared;

namespace WarcraftLegacies.Source.GameLogic.GameEnd;

/// <summary>
/// Evaluates and applies turn-based elimination rules for players.
/// </summary>
/// <remarks>
/// Once the <see cref="EliminationStartTurn"/> is reached, players who remain below the control point and food thresholds may be defeated.
/// The thresholds are <see cref="EliminationControlPointThreshold"/> control points and <see cref="EliminationFoodThreshold"/> food used.
/// A player is defeated after <see cref="EliminationGraceTurns"/> consecutive turns below these thresholds if their team does not control an essential legend.
/// </remarks>
public static class PlayerElimination
{
  private const int EliminationStartTurn = 20;
  private const int EliminationGraceTurns = 3;

  private const int EliminationControlPointThreshold = 5;
  private const int EliminationFoodThreshold = 105;

  /// <summary>
  /// Registers the player elimination rule with the turn manager.
  /// </summary>
  /// <remarks>
  /// Elimination checks begin once the <see cref="EliminationStartTurn"/> turn is reached.
  /// </remarks>
  public static void Setup()
  {
    GameTimeManager.OnTurnRepeating(EliminationStartTurn, static () =>
    {
      foreach (var player in Util.EnumeratePlayers(playerslotstate.Playing, mapcontrol.User))
      {
        ProcessPlayerElimination(player);
      }
    });
  }

  private static void ProcessPlayerElimination(player player)
  {
    var playerData = player.GetPlayerData();

    if (!ShouldEliminate(player, playerData))
    {
      playerData.EliminationTurns = 0;
      return;
    }

    if (playerData.EliminationTurns >= EliminationGraceTurns)
    {
      playerData.Faction?.Defeat();
      return;
    }

    ShowEliminationWarning(player, playerData);

    playerData.EliminationTurns++;
  }

  private static bool ShouldEliminate(player player, PlayerData playerData)
  {
    return playerData.ControlPoints.Count <= EliminationControlPointThreshold
           && player.FoodUsed <= EliminationFoodThreshold
           && playerData.Team?.DoesTeamHaveEssentialLegend() != true;
  }

  private static void ShowEliminationWarning(player player, PlayerData playerData)
  {
    var turnsRemaining = EliminationGraceTurns - playerData.EliminationTurns;
    var turnText = turnsRemaining == 1 ? "turn" : "turns";

    player.DisplayTextTo($"You have met the threshold for being eliminated from the game. Unless you raise your Control Point count above {EliminationControlPointThreshold}, raise food used above {EliminationFoodThreshold} or your team retakes/gains an essential Legend, you will be defeated in {turnsRemaining} {turnText}.");
  }
}
