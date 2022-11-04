using WarcraftLegacies.Source.Setup.FactionSetup;
using WCSharp.Events;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Researches.Stormwind
{
  public static class TierKatranaPrestor
  {
    private const int DemiUnittypeId = Constants.UNIT_N06F_KATRANA_PRESTOR_ARATHOR_DEMI;
    
    private static void Research()
    {
      CreateUnit(StormwindSetup.Stormwind.Player, DemiUnittypeId, GetUnitX(GetTriggerUnit()),
        GetUnitY(GetTriggerUnit()), 0);
    }

    public static void Setup()
    {
      PlayerUnitEvents.Register(PlayerUnitEvent.ResearchIsFinished, Research, FourCC("R03Y"));
      StormwindSetup.Stormwind.ModObjectLimit(DemiUnittypeId, 1);
    }
  }
}