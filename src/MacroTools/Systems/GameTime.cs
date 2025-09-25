using System;
using MacroTools.Extensions;

namespace MacroTools.Systems;

/// <summary>Counts the elapsed game time, displayed in number of turns passed.</summary>
public static class GameTime
{
  public const float TurnDuration = 60;

  /// <summary>
  /// How long after game start to actually show the timer.
  /// </summary>
  private const float TimerDelay = 2;

  //This must be after the Multiboard is shown or the Multiboard will break
  private static timerdialog? _turnTimerDialog;
  private static int _turnCount;
  private static float _currentTime;
  private static bool _gameStarted;

  /// <summary>Fired when a turn ends.</summary>
  public static event EventHandler? TurnEnded;

  /// <summary>Fired when the game starts.</summary>
  public static event EventHandler? GameStarted;

  /// <summary>Starts the timers that keeps trac of the game's ticks and turns.</summary>
  public static void Start()
  {
    timer.Create().Start(0, false, () =>
    {
      timer.Create().Start(1, true, GameTick);
      var turnTimer = timer.Create();
      turnTimer.Start(TurnDuration, true, EndTurn);
      _turnTimerDialog = timerdialog.Create(turnTimer);
      @event.ExpiredTimer.Dispose();
    });

    timer.Create().Start(TimerDelay, false, () =>
    {
      _turnTimerDialog.IsDisplayed = true;
      _turnTimerDialog.SetTitle("Game starts in:");
      @event.ExpiredTimer.Dispose();
    });
  }

  public static int ConvertGameTimeToTurn(float gameTime) => (int)Math.Floor(gameTime / TurnDuration);

  /// <summary>What turn it is right now.</summary>
  public static int GetTurn() => ConvertGameTimeToTurn(_currentTime);

  /// <returns>The number of seconds that have elapsed since the start of the game</returns>
  public static float GetGameTime() => _currentTime;

  /// <summary>Skips the game forward a number of turns.</summary>
  public static void SkipTurns(int turnSkip)
  {
    _currentTime += TurnDuration * turnSkip;
    for (var i = 0; i < turnSkip; i++)
    {
      EndTurn();
    }
  }

  private static void EndTurn()
  {
    _turnCount += 1;

    if (_gameStarted == false)
    {
      _gameStarted = true;
      GameStarted?.Invoke(null, EventArgs.Empty);
    }

    _turnTimerDialog.SetTitle($"Turn {_turnCount}");
    if (_turnCount >= 20)
    {
      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers(playerslotstate.Playing, mapcontrol.User))
      {
        var faction = player.GetFaction();
        var meetEliminationThreshold = player.GetControlPoints().Count <= 5 && player.GetFoodUsed() <= 105 &&
                                       !player.GetTeam()!.DoesTeamHaveEssentialLegend();
        if (meetEliminationThreshold)
        {
          if (PlayerData.ByHandle(player).EliminationTurns >= 3)
          {
            faction?.Defeat();
          }
          else
          {
            player.DisplayTextTo(PlayerData.ByHandle(player).EliminationTurns == 2
                ? $"You have met the threshold for being eliminated from the game. Unless you raise your Control Point count above 5, raise food used above 105 or your team retakes/gains an essential Legend you will be defeated in {3 - PlayerData.ByHandle(player).EliminationTurns} turn."
                : $"You have met the threshold for being eliminated from the game. Unless you raise your cp count above 5, raise food used above 105 or your team retakes/gains an essential Legend you will be defeated in {3 - PlayerData.ByHandle(player).EliminationTurns} turns.");
          }

          PlayerData.ByHandle(player).EliminationTurns++;
        }
        else
        {
          PlayerData.ByHandle(player).EliminationTurns = 0;
        }
      }
    }

    TurnEnded?.Invoke(null, EventArgs.Empty);
  }

  private static void GameTick() => _currentTime += 1;
}
