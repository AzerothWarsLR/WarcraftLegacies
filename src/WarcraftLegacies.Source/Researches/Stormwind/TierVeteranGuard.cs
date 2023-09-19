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
      StormwindSetup.Stormwind.ModObjectLimit(Constants.UNIT_H03U_REAR_MARSHAL_STORMWIND_DEFENSIVE, 12);
    }

    public static void Setup()
    {
      PlayerUnitEvents.Register(ResearchEvent.IsFinished, Research,
        Constants.UPGRADE_R03D_VETERAN_GUARD_ARATHOR_T1);
    }
  }
}