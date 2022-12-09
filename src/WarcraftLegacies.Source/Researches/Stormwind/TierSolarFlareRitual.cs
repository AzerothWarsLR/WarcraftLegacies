using MacroTools.FactionSystem;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WCSharp.Events;

namespace WarcraftLegacies.Source.Researches.Stormwind
{
  public static class TierSolarFlareRitual
  {
    private static void Research()
    {
      StormwindSetup.Stormwind.ModObjectLimit(Constants.UPGRADE_R03V_MAGES_OF_STROMGARDE_ARATHOR_T2, Faction.UNLIMITED);
      StormwindSetup.Stormwind.ModObjectLimit(Constants.UPGRADE_R03W_KNOWLEDGE_OF_HONOR_HOLD_ARATHOR_T2,
        Faction.UNLIMITED);
    }

    public static void Setup() => PlayerUnitEvents.Register(ResearchEvent.IsFinished, Research,
      Constants.UPGRADE_R03U_SOLAR_FLARE_RITUAL_ARATHOR_T1);
  }
}