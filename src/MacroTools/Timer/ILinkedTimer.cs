using System;

namespace WarcraftLegacies.Source.GameLogic
{
  /// <summary>
  /// 
  /// </summary>
  public interface ILinkedTimer
  {
    /// <summary>
    /// 
    /// </summary>
    public void StartTimer();

    /// <summary>
    /// 
    /// </summary>
    public EventHandler? OnTimerEnds { get; set; }

  }
}