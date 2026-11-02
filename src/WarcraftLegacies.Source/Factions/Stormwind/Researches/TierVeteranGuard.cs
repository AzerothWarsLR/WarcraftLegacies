using MacroTools.Extensions;
using MacroTools.Factions;
using WCSharp.Events;

namespace WarcraftLegacies.Source.Factions.Stormwind.Researches;

public static class TierVeteranGuard
{
  private static void Research()
  {
    var faction = @event.Player.GetPlayerData().Faction;
    if (faction == null)
    {
      return;
    }

    faction.ModObjectLimit(StromgardeFaction.EquivalentFor(faction, UNIT_H03K_MARSHAL_STORMWIND), -Faction.Unlimited);
    faction.ModObjectLimit(StromgardeFaction.EquivalentFor(faction, UNIT_H03U_REAR_MARSHAL_STORMWIND_DEFENSIVE), 12);
  }

  public static void Setup()
  {
    PlayerUnitEvents.Register(ResearchEvent.IsFinished, Research,
      UPGRADE_R03D_VETERAN_GUARD_ARATHOR_T1);
  }
}
