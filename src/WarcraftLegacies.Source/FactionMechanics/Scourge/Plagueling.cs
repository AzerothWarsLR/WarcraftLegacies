using WCSharp.Events;

namespace WarcraftLegacies.Source.FactionMechanics.Scourge;

public static class Plagueling
{
  private static readonly int _plaguelingId = FourCC("n08G");
  private const float Duration = 15;

  private static void OnSell()
  {
    @event.SoldUnit.ApplyTimedLife(0, Duration);
    @event.SoldUnit.SetExploded(true);
  }

  public static void Setup()
  {
    PlayerUnitEvents.Register(UnitTypeEvent.SellsUnit, OnSell, _plaguelingId);
  }
}
