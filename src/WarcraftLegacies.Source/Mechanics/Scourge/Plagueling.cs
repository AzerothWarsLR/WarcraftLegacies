using WCSharp.Events;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Mechanics.Scourge
{
  public static class Plagueling
  {
    private static readonly int PlaguelingId = FourCC("n08G");
    private const float Duration = 15;
    
    private static void OnSell()
    {
      UnitApplyTimedLife(GetSoldUnit(), 0, Duration);
      SetUnitExploded(GetSoldUnit(), true);
    }

    public static void Setup()
    {
      PlayerUnitEvents.Register(UnitTypeEvent.SellsUnit, OnSell, PlaguelingId);
    }
  }
}