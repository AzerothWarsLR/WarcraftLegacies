using MacroTools.Extensions;
using MacroTools.FactionSystem;
using WCSharp.Events;

namespace WarcraftLegacies.Source.Researches.Stormwind
{
  public static class TierReflectivePlating
  {
    private static void Research()
    {
      GetTriggerPlayer().GetFaction()?.ModObjectLimit(UNIT_H04C_PIKEMAN_STORMWIND, Faction.UNLIMITED);
      GetTriggerPlayer().GetFaction()?.ModObjectLimit(UNIT_H02O_BLADESMAN_STORMWIND, -Faction.UNLIMITED);
    }

    public static void Setup()
    {
      PlayerUnitEvents.Register(ResearchEvent.IsFinished, Research, FourCC("R02Z"));
    }
  }
}