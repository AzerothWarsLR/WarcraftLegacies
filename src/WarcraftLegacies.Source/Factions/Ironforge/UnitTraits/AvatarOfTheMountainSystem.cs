using System.Collections.Generic;
using WCSharp.Events;

namespace WarcraftLegacies.Source.Factions.Ironforge.UnitTraits;

public static class AvatarOfTheMountainSystem
{
  public static readonly List<AvatarOfTheMountain> Traits = new();

  static AvatarOfTheMountainSystem()
  {
    PeriodicEvents.AddPeriodicEvent(OnTick, 0.25);
  }

  private static bool OnTick()
  {
    foreach (var trait in Traits)
    {
      trait.Tick(0.25f);
    }

    return true;
  }
}
