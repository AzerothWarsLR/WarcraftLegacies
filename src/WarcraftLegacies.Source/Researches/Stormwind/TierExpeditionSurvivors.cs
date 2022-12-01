using MacroTools.FactionSystem;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WCSharp.Events;

namespace WarcraftLegacies.Source.Researches.Stormwind
{
  public static class TierExpeditionSurvivors
  {
    private static void Research()
    {
      StormwindSetup.Stormwind.ModObjectLimit(Constants.UNIT_H00A_SPEARMAN_STORMWIND, -Faction.UNLIMITED);
      StormwindSetup.Stormwind.ModObjectLimit(Constants.UNIT_H05N_MARKSMAN_ARATHOR, Faction.UNLIMITED);
    }

    public static void Setup()
    {
      PlayerUnitEvents.Register(ResearchEvent.IsFinished, Research, Constants.UPGRADE_R031_EXPEDITION_SURVIVORS_ARATHOR_T3);
    }
  }
}