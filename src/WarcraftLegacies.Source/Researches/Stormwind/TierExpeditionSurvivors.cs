using MacroTools.Extensions;
using MacroTools.FactionSystem;
using WCSharp.Events;

namespace WarcraftLegacies.Source.Researches.Stormwind;

public static class TierExpeditionSurvivors
{
  private static void Research()
  {
    @event.Player.GetFaction()?.ModObjectLimit(UNIT_H00A_SPEARMAN_STORMWIND, -Faction.Unlimited);
    @event.Player.GetFaction()?.ModObjectLimit(UNIT_H05N_MARKSMAN_STORMWIND, Faction.Unlimited);
  }

  public static void Setup()
  {
    PlayerUnitEvents.Register(ResearchEvent.IsFinished, Research, UPGRADE_R031_EXPEDITION_SURVIVORS_ARATHOR_T3);
  }
}
