using MacroTools.FactionSystem;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WCSharp.Events;


namespace WarcraftLegacies.Source.Researches.Stormwind
{
  public static class TierVeteranGuard
  {
    private static void Research()
    {
      StormwindSetup.Stormwind.ModObjectLimit(Constants.UNIT_H03K_MARSHAL_STORMWIND, -Faction.UNLIMITED);
      StormwindSetup.Stormwind.ModObjectLimit(Constants.UNIT_H03U_REAR_MARSHAL_ARATHOR_DEFENSIVE, 12);
      StormwindSetup.Stormwind.ModObjectLimit(Constants.UPGRADE_R03B_EXPLOIT_WEAKNESS_ARATHOR_T2, Faction.UNLIMITED);
      StormwindSetup.Stormwind.ModObjectLimit(Constants.UPGRADE_R02Z_REFLECTIVE_PLATING_ARATHOR_T2, Faction.UNLIMITED);
    }

    public static void Setup()
    {
      PlayerUnitEvents.Register(PlayerUnitEvent.ResearchIsFinished, Research,
        Constants.UPGRADE_R03D_VETERAN_GUARD_ARATHOR_T1);
    }
  }
}