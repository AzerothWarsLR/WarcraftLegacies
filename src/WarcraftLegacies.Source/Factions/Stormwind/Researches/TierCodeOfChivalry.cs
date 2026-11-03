using MacroTools.Extensions;
using MacroTools.Factions;
using WCSharp.Events;

namespace WarcraftLegacies.Source.Factions.Stormwind.Researches;

public static class TierCodeOfChivalry
{
  private static void Research()
  {
    var faction = @event.Player.GetPlayerData().Faction;
    if (faction == null)
    {
      return;
    }

    faction.ModObjectLimit(StromgardeFaction.EquivalentFor(faction, UNIT_H01B_OUTRIDER_STORMWIND), -Faction.Unlimited);
    faction.ModObjectLimit(StromgardeFaction.EquivalentFor(faction, UNIT_H054_STORMWIND_KNIGHT_STORMWIND), Faction.Unlimited);
  }

  public static void Setup()
  {
    PlayerUnitEvents.Register(ResearchEvent.IsFinished, Research, UPGRADE_R030_CODE_OF_CHIVALRY_ARATHOR_T3);
    PlayerUnitEvents.Register(ResearchEvent.IsFinished, Research, UPGRADE_R11Q_CODE_OF_CHIVALRY_STROMGARDE);
  }
}
