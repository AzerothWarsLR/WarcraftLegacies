using System;

namespace MacroTools.GameTime;

/// <summary>Counts the elapsed game time, displayed in number of turns passed.</summary>
public static class GameTimeManager
{
  public const int TurnDuration = 60;

  /// <summary>
  /// How long after game start to actually show the timer.
  /// </summary>
  private const float TimerDelay = 2;

  //This must be after the Multiboard is shown or the Multiboard will break
  private static timerdialog? _turnTimerDialog;
  private static int _turnCount;
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

  /// <summary>What turn it is right now.</summary>
  public static int GetTurn() => _turnCount;

  /// <summary>Skips the game forward a number of turns.</summary>
  public static void SkipTurns(int turnSkip)
  {
    for (var i = 0; i < turnSkip; i++)
    {
      EndTurn();
    }
  }

  private static void EndTurn()
  {
    _turnCount += 1;

    if (!_gameStarted)
    {
      _gameStarted = true;
      GameStarted?.Invoke(null, EventArgs.Empty);
    }

    if (_turnTimerDialog != null)
    {
      _turnTimerDialog.SetTitle($"Turn {_turnCount}");
    }

    TurnEnded?.Invoke(null, EventArgs.Empty);
  }
}
