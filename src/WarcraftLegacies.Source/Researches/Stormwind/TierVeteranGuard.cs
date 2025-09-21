using MacroTools.Extensions;
using MacroTools.FactionSystem;
using WCSharp.Events;

namespace WarcraftLegacies.Source.Researches.Stormwind;

public static class TierVeteranGuard
{
  private static void Research()
  {
    @event.Player.GetFaction()?.ModObjectLimit(UNIT_H03K_MARSHAL_STORMWIND, -Faction.Unlimited);
    @event.Player.GetFaction()?.ModObjectLimit(UNIT_H03U_REAR_MARSHAL_STORMWIND_DEFENSIVE, 12);
  }

  public static void Setup()
  {
    PlayerUnitEvents.Register(ResearchEvent.IsFinished, Research,
      UPGRADE_R03D_VETERAN_GUARD_ARATHOR_T1);
  }
}
