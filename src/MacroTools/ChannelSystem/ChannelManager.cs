using WCSharp.Events;

namespace MacroTools.ChannelSystem;

/// <summary>
///   Responsible for managing all <see cref="Channel" />s in the game.
/// </summary>
public static class ChannelManager
{
  private static readonly PeriodicDisposableTrigger<Channel> _periodicTrigger = new(PeriodicEvents.SYSTEM_INTERVAL);

  /// <summary>
  ///   Adds the <see cref="Channel" /> to the system, allowing it to take effect.
  /// </summary>
  public static void Add(Channel channel)
  {
    _periodicTrigger.Add(channel);
    channel.RegisterCancellationTrigger();
    channel.OnCreate();
  }
}
