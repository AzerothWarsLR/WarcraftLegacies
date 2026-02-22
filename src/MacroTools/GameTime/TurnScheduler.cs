using System;
using System.Collections.Generic;

namespace MacroTools.GameTime;

/// <summary>
/// Schedules and executes callbacks based on turn progression.
/// </summary>
internal sealed class TurnScheduler
{
  /// <summary>
  /// Gets the currently registered callbacks.
  /// </summary>
  public List<TurnCallback> Callbacks { get; } = new();

  /// <summary>Registers a turn-based callback.</summary>
  /// <param name="start">The first eligible turn.</param>
  /// <param name="callback">The delegate to invoke.</param>
  /// <param name="end">The last eligible turn, or <see cref="TurnCallback.Infinite"/> for no limit.</param>
  /// <param name="step">The number of turns between executions.</param>
  /// <param name="condition">An optional predicate that must return <see langword="true"/> for execution.</param>
  public void Register(int start, Action callback, int end = TurnCallback.Infinite, int step = 1, Func<bool>? condition = null)
  {
    Register(new TurnCallback(start, end, step, callback, condition));
  }

  private void Register(TurnCallback callback)
  {
    Callbacks.Add(callback);
  }

  /// <summary>Evaluates all registered callbacks for the specified turn and executes those that are due.</summary>
  /// <param name="turn">The current turn.</param>
  /// <remarks>
  /// <para>Callbacks that complete during execution are removed.</para>
  /// <para>Callbacks registered during execution are not evaluated during the same invocation.</para>
  /// </remarks>
  public void Process(int turn)
  {
    for (int i = 0, count = Callbacks.Count; i < count;)
    {
      if (Callbacks[i].Advance(turn))
      {
        Callbacks[i] = Callbacks[--count];
        Callbacks.RemoveAt(count);
      }
      else
      {
        i++;
      }
    }
  }
}
