using System;

namespace MacroTools.Timer
{
  /// <summary>
  /// 
  /// </summary>
  public interface ITimer
  {
    /// <summary>
    /// Starts the timer
    /// </summary>
    public void StartTimer();

    /// <summary>
    /// Fires when the timer expires
    /// </summary>
    public EventHandler? OnTimerEnds { get; set; }

  }
}