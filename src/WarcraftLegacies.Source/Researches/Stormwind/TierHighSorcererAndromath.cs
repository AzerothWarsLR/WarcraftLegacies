using WarcraftLegacies.Source.Setup.FactionSetup;
using WCSharp.Events;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Researches.Stormwind
{
  public static class TierHighSorcererAndromath
  {
    private const int DEMI_UNITTYPE_ID = Constants.UNIT_H05X_HIGH_SORCERER_ANDROMATH_ARATHOR_DEMI;
  
    private static void Research()
    {
      CreateUnit(StormwindSetup.Stormwind.Player, DEMI_UNITTYPE_ID, GetUnitX(GetTriggerUnit()),
        GetUnitY(GetTriggerUnit()), 0);
    }

    public static void Setup()
    {
      PlayerUnitEvents.Register(PlayerUnitEvent.ResearchIsFinished, Research, FourCC("R03X"));
      StormwindSetup.Stormwind.ModObjectLimit(DEMI_UNITTYPE_ID, 1);
    }
  }
}