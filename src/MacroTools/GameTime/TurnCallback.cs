using System;

namespace MacroTools.GameTime;

/// <summary>
/// Represents a callback that executes on scheduled turns and tracks its own lifecycle.
/// </summary>
internal sealed class TurnCallback
{
  /// <summary>
  /// Represents an infinite number of turns.
  /// </summary>
  public const int Infinite = -1;

  private readonly int _interval;
  private readonly int _endTurn;
  private readonly Action _action;
  private readonly Func<bool>? _condition;
  private int _nextExecutionTurn;

  public TurnCallback(int startTurn, int endTurn, int interval, Action action, Func<bool>? condition = null)
  {
    if (interval <= 0)
    {
      throw new ArgumentException("Interval must be > 0", nameof(interval));
    }

    if (endTurn != Infinite && endTurn < startTurn)
    {
      throw new ArgumentException("End turn must be >= start turn", nameof(endTurn));
    }

    var currentTurn = GameTimeManager.Turn;

    if (startTurn <= currentTurn)
    {
      throw new ArgumentException($"Cannot register callback for turn {startTurn} when current turn is {currentTurn}", nameof(startTurn));
    }

    if (endTurn != Infinite && endTurn <= currentTurn)
    {
      throw new ArgumentException($"Cannot register callback for end turn {endTurn} when current turn is {currentTurn}", nameof(endTurn));
    }

    _nextExecutionTurn = startTurn;
    _endTurn = endTurn;
    _interval = interval;
    _action = action;
    _condition = condition;
  }

  /// <summary>Executes the callback if it is due for the specified turn and updates its schedule.</summary>
  /// <param name="currentTurn">The current turn.</param>
  /// <returns><c>true</c> if the callback has completed and should be removed; otherwise, <c>false</c>.</returns>
  public bool Advance(int currentTurn)
  {
    if (currentTurn >= _nextExecutionTurn && (_condition?.Invoke() ?? true))
    {
      _action();

      if (_endTurn == Infinite || _nextExecutionTurn + _interval <= _endTurn)
      {
        _nextExecutionTurn += _interval;
      }
      else
      {
        _nextExecutionTurn = int.MaxValue;
      }
    }

    return _endTurn != Infinite && _nextExecutionTurn > _endTurn;
  }
}
