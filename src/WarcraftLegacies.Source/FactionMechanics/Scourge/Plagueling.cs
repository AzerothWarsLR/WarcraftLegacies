using WCSharp.Events;

namespace WarcraftLegacies.Source.FactionMechanics.Scourge;

public static class Plagueling
{
  private static readonly int _plaguelingId = FourCC("n08G");
  private const float Duration = 15;

  private static void OnSell()
  {
    UnitApplyTimedLife(GetSoldUnit(), 0, Duration);
    SetUnitExploded(GetSoldUnit(), true);
  }

  public static void Setup()
  {
    PlayerUnitEvents.Register(UnitTypeEvent.SellsUnit, OnSell, _plaguelingId);
  }
}
