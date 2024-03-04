using System;


namespace MacroTools.Extensions
{
  /// <summary>
  /// Provides a useful set of extension methods for native Warcraft 3 timers.
  /// </summary>
  public static class TimerExtensions
  {
    /// <summary>
    /// Starts the timer.
    /// </summary>
    /// <param name="timer">The timer to start./</param>
    /// <param name="timeout">How long until the timer fires.</param>
    /// <param name="periodic">If true, the timer immediately restarts after finishing.</param>
    /// <param name="handlerFunc">The function to run when the timer finishes.</param>
    /// <returns></returns>
    public static timer Start(this timer timer, float timeout, bool periodic, Action handlerFunc)
    {
      TimerStart(timer, timeout, periodic, handlerFunc);
      return timer;
    }

    /// <summary>
    /// Destroys the timer.
    /// </summary>
    public static timer Destroy(this timer timer)
    {
      DestroyTimer(timer);
      return timer;
    }
  }
}