using WCSharp.Events;

namespace MacroTools.SpellSystem
{
  public static class HazardSystem
  {
    private static readonly PeriodicDisposableTrigger<Hazard> PeriodicTrigger = new(PeriodicEvents.SYSTEM_INTERVAL);

    public static void Add(Hazard hazard)
    {
      PeriodicTrigger.Add(hazard);
      hazard.OnCreate();
    }
  }
}