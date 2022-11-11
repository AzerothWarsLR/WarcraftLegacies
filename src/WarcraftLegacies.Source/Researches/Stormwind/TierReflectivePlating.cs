using MacroTools.FactionSystem;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WCSharp.Events;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Researches.Stormwind
{
  public static class TierReflectivePlating
  {
    private static void Research()
    {
      StormwindSetup.Stormwind.ModObjectLimit(Constants.UNIT_H04C_PIKEMAN_STORMWIND, Faction.UNLIMITED);
      StormwindSetup.Stormwind.ModObjectLimit(Constants.UNIT_H02O_BLADESMAN_STORMWIND, -Faction.UNLIMITED);
      StormwindSetup.Stormwind.ModObjectLimit(Constants.UPGRADE_R030_CODE_OF_CHIVALRY_ARATHOR_T3, Faction.UNLIMITED);
      StormwindSetup.Stormwind.ModObjectLimit(Constants.UPGRADE_R031_EXPEDITION_SURVIVORS_ARATHOR_T3, Faction.UNLIMITED);
    }

    public static void Setup()
    {
      PlayerUnitEvents.Register(PlayerUnitEvent.ResearchIsFinished, Research, FourCC("R02Z"));
    }
  }
}