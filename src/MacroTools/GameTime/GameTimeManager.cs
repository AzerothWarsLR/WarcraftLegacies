using System;

namespace MacroTools.GameTime;

/// <summary>Counts the elapsed game time, displayed in number of turns passed.</summary>
public static class GameTimeManager
{
  public const int TurnDuration = 60;

  private static timer? _turnTimer;
  private static int _turnCount;
  private static bool _gameStarted;

  /// <summary>Fired when a turn ends.</summary>
  public static event EventHandler? TurnEnded;

  /// <summary>Fired when the game starts.</summary>
  public static event EventHandler? GameStarted;

  /// <summary>Starts the timers that keeps trac of the game's ticks and turns.</summary>
  public static void Start()
  {
    if (_turnTimer != null)
    {
      throw new InvalidOperationException($"{nameof(GameTimeManager)} has already been initialized.");
    }

    _turnTimer = timer.Create();
    _turnTimer.Start(TurnDuration, true, EndTurn);
  }

  /// <summary>What turn it is right now.</summary>
  public static int GetTurn() => _turnCount;

  /// <summary>
  /// Creates a <see cref="timerdialog"/> attached to the turn timer.
  /// </summary>
  /// <exception cref="InvalidOperationException">
  /// Thrown if the <see cref="GameTimeManager"/> has not been initialized.
  /// </exception>
  /// <remarks>
  /// <see cref="Start"/> must be called before invoking this method. The returned
  /// dialog reflects the countdown of the current turn, whose duration is defined
  /// by <see cref="TurnDuration"/>.
  /// </remarks>
  public static timerdialog CreateDialog()
  {
    if (_turnTimer == null)
    {
      throw new InvalidOperationException($"{nameof(GameTimeManager)} has not been initialized. Call {nameof(Start)} before creating a timer dialog.");
    }

    return timerdialog.Create(_turnTimer);
  }

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

    TurnEnded?.Invoke(null, EventArgs.Empty);
  }
}
