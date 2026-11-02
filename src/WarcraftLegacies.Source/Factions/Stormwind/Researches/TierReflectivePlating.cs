using MacroTools.Extensions;
using MacroTools.Factions;
using WCSharp.Events;

namespace WarcraftLegacies.Source.Factions.Stormwind.Researches;

public static class TierReflectivePlating
{
  private static void Research()
  {
    var faction = @event.Player.GetPlayerData().Faction;
    if (faction == null)
    {
      return;
    }

    faction.ModObjectLimit(StromgardeFaction.EquivalentFor(faction, UNIT_H04C_VANGUARD_STORMWIND), Faction.Unlimited);
    faction.ModObjectLimit(StromgardeFaction.EquivalentFor(faction, UNIT_H02O_BLADESMAN_STORMWIND), -Faction.Unlimited);
  }

  public static void Setup()
  {
    PlayerUnitEvents.Register(ResearchEvent.IsFinished, Research, UPGRADE_R02Z_REFLECTIVE_PLATING_ARATHOR_T2);
    PlayerUnitEvents.Register(ResearchEvent.IsFinished, Research, UPGRADE_R11S_REFLECTIVE_PLATING_STROMGARDE);
  }
}
