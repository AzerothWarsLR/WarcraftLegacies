using MacroTools.Extensions;
using MacroTools.Factions;
using WCSharp.Events;

namespace WarcraftLegacies.Source.Factions.Stormwind.Researches;

public static class TierExpeditionSurvivors
{
  private static void Research()
  {
    var faction = @event.Player.GetPlayerData().Faction;
    if (faction == null)
    {
      return;
    }

    faction.ModObjectLimit(StromgardeFaction.EquivalentFor(faction, UNIT_H00A_SPEARMAN_STORMWIND), -Faction.Unlimited);
    faction.ModObjectLimit(StromgardeFaction.EquivalentFor(faction, UNIT_H05N_MARKSMAN_STORMWIND), Faction.Unlimited);
  }

  public static void Setup()
  {
    PlayerUnitEvents.Register(ResearchEvent.IsFinished, Research, UPGRADE_R031_EXPEDITION_SURVIVORS_ARATHOR_T3);
    PlayerUnitEvents.Register(ResearchEvent.IsFinished, Research, UPGRADE_R11R_EXPEDITION_SURVIVORS_STROMGARDE);
  }
}
