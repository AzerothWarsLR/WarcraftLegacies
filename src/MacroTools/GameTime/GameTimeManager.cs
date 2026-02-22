using System;

namespace MacroTools.GameTime;

/// <summary>Counts the elapsed game time, displayed in number of turns passed.</summary>
public static class GameTimeManager
{
  /// <summary>
  /// The duration of a single turn, in seconds.
  /// </summary>
  public const int TurnDuration = 60;

  /// <summary>
  /// Gets the current turn number.
  /// </summary>
  public static int Turn { get; private set; }

  private static timer? _turnTimer;
  private static bool _gameStarted;
  private static readonly TurnScheduler _turnScheduler = new();

  /// <summary>Fired when a turn ends.</summary>
  [Obsolete($"Use {nameof(OnTurn)}, {nameof(OnTurnRange)}, or {nameof(OnTurnRepeating)} instead.")]
  public static event EventHandler? TurnEnded;

  /// <summary>Fired when the game starts.</summary>
  [Obsolete($"Use {nameof(OnTurn)}, {nameof(OnTurnRange)}, or {nameof(OnTurnRepeating)} instead.")]
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

  /// <summary>Execute once on the given turn.</summary>
  public static void OnTurn(int startTurn, Action callback, Func<bool>? condition = null)
  {
    _turnScheduler.Register(startTurn, callback, startTurn, 1, condition);
  }

  /// <summary>Execute repeatedly every N turns starting from startTurn, bounded.</summary>
  public static void OnTurnRange(int startTurn, int endTurn, Action callback, int interval = 1, Func<bool>? condition = null)
  {
    _turnScheduler.Register(startTurn, callback, endTurn, interval, condition);
  }

  /// <summary>Execute repeatedly every N turns starting from startTurn, indefinitely.</summary>
  public static void OnTurnRepeating(int startTurn, Action callback, int interval = 1, Func<bool>? condition = null)
  {
    _turnScheduler.Register(startTurn, callback, TurnCallback.Infinite, interval, condition);
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
    _turnScheduler.Process(++Turn);

    if (!_gameStarted)
    {
      _gameStarted = true;
      GameStarted?.Invoke(null, EventArgs.Empty);
    }

    TurnEnded?.Invoke(null, EventArgs.Empty);
  }
}
