using System;
using System.Collections.Generic;

namespace WarcraftLegacies.Source.GameLogic
{
  /// <summary>
  /// 
  /// </summary>
  public partial class TimerQueue
  {
    private Queue<ILinkedTimer> Queue = new();

    private ILinkedTimer _currentTimer;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="linkedTimer"></param>
    public void Add(ILinkedTimer linkedTimer)
    {
      Queue.Enqueue(linkedTimer);
    }

    /// <summary>
    /// 
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