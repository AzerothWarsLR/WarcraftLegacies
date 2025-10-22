using WCSharp.Events;

namespace MacroTools.Spells;

public static class HazardSystem
{
  private static readonly PeriodicDisposableTrigger<Hazard> _periodicTrigger = new(PeriodicEvents.SYSTEM_INTERVAL);

  public static void Add(Hazard hazard)
  {
    _periodicTrigger.Add(hazard);
    hazard.OnCreate();
  }
}
