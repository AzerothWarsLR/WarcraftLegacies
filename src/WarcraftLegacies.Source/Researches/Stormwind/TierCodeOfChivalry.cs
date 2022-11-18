using MacroTools.FactionSystem;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WCSharp.Events;

namespace WarcraftLegacies.Source.Researches.Stormwind
{
  public static class TierCodeOfChivalry
  {
    private static void Research()
    {
      StormwindSetup.Stormwind.ModObjectLimit(Constants.UNIT_H01B_OUTRIDER_STORMWIND, -Faction.UNLIMITED);
      StormwindSetup.Stormwind.ModObjectLimit(Constants.UNIT_H054_STORMWIND_KNIGHT_ARATHOR, Faction.UNLIMITED);
    }

    public static void Setup()
    {
      PlayerUnitEvents.Register(PlayerUnitEvent.ResearchIsFinished, Research, Constants.UPGRADE_R030_CODE_OF_CHIVALRY_ARATHOR_T3);
    }
  }
}