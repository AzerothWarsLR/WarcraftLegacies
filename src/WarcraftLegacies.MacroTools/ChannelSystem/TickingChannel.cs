using WCSharp.Events;
using static War3Api.Common;

namespace WarcraftLegacies.MacroTools.ChannelSystem
{
  public abstract class TickingChannel : Channel
  {
    /// <summary>
    ///   The time, in seconds, remaining until the next tick.
    /// </summary>
    public float IntervalLeft { get; set; }

    /// <summary>
    ///   The time, in seconds, between each tick.
    /// </summary>
    public float Interval { get; set; }

    /// <inheritdoc />
    public sealed override void Action()
    {
      if (IntervalLeft <= PeriodicEvents.SYSTEM_INTERVAL)
      {
        IntervalLeft += Interval;
        OnTick();
      }

      IntervalLeft -= PeriodicEvents.SYSTEM_INTERVAL;
    }

    /// <summary>
    ///   Executes every <see cref="Interval" />.
    /// </summary>
    public abstract void OnTick();

    protected TickingChannel(unit caster, int spellId) : base(caster, spellId)
    {
    }
  }
}