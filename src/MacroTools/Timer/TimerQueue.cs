using System;
using System.Collections.Generic;

namespace MacroTools.Timer
{
  /// <summary>
  /// Allows chaining timers together so they run one after the other seamlessly
  /// </summary>
  public partial class TimerQueue
  {
    private Queue<ITimer> Queue = new();

    private ITimer _currentTimer;

    /// <summary>
    /// Adds a timer to the queue.
    /// </summary>
    /// <param name="linkedTimer"></param>
    public void Add(ITimer linkedTimer)
    {
      Queue.Enqueue(linkedTimer);
    }

    /// <summary>
    /// Starts the queue.
    /// <para/>
    /// Dequeues the first timer and chains it to the next one.
    /// <para/>
    /// Then starts the first timer.
    /// </summary>
    public void Start()
    {
      if (Queue.Count > 0)
      {
        _currentTimer = Queue.Dequeue();
        _currentTimer.OnTimerEnds += OnTimerEnds;
        _currentTimer.StartTimer();
      }
    }

    private void OnTimerEnds(object? sender, EventArgs e)
    {
      if (Queue.Count > 0)
      {
        _currentTimer.OnTimerEnds -= OnTimerEnds;
        _currentTimer = Queue.Dequeue();
        _currentTimer.OnTimerEnds += OnTimerEnds;
        _currentTimer.StartTimer();
      }
    }
  }
}