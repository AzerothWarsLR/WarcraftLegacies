using WCSharp.Events;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.ChannelSystem
{
  public abstract class SimpleChannel : Channel
  {
    protected SimpleChannel(unit caster, int spellId) : base(caster, spellId)
    {
    }

    public sealed override void Apply()
    {
      OnApply();
    }

    public sealed override void Action()
    {
      if (Duration <= PeriodicEvents.SYSTEM_INTERVAL)
      {
        OnExpire();
        Active = false;
      }
      else
      {
        Duration -= PeriodicEvents.SYSTEM_INTERVAL;
      }
    }

    public override void Dispose()
    {
      OnDispose();
      ChannelManager.Remove(this);
    }
  }
}