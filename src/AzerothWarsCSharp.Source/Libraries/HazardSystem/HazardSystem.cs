using WCSharp.Events;

namespace AzerothWarsCSharp.Source.Libraries.HazardSystem
{
  public static class HazardSystem
  {
    private static readonly PeriodicDisposableTrigger<Hazard> PeriodicTrigger = new(PeriodicEvents.SYSTEM_INTERVAL);

    public static void Add(Hazard hazard)
    {
      PeriodicTrigger.Add(hazard);
    }
  }
}