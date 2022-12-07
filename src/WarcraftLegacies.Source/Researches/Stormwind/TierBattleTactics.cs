using MacroTools.FactionSystem;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WCSharp.Events;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Researches.Stormwind
{
  public static class TierBattleTactics
  {
    private static void Research()
    {
      StormwindSetup.Stormwind.ModObjectLimit(Constants.UNIT_H03K_MARSHAL_STORMWIND, -Faction.UNLIMITED);
      StormwindSetup.Stormwind.ModObjectLimit(Constants.UNIT_H014_FORWARD_MARSHAL_STORMWIND_OFFENSIVE, 12);
      StormwindSetup.Stormwind.ModObjectLimit(Constants.UPGRADE_R03B_EXPLOIT_WEAKNESS_ARATHOR_T2, Faction.UNLIMITED);
      StormwindSetup.Stormwind.ModObjectLimit(Constants.UPGRADE_R02Z_REFLECTIVE_PLATING_ARATHOR_T2, Faction.UNLIMITED);
    }

    public static void Setup()
    {
      PlayerUnitEvents.Register(PlayerUnitEvent.ResearchIsFinished, Research, FourCC("R02Y"));
    }
  }
}