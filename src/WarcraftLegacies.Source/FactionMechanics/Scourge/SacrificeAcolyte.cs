using MacroTools.Extensions;
using WCSharp.Events;

namespace WarcraftLegacies.Source.FactionMechanics.Scourge;

public static class SacrificeAcolyte
{
  private static readonly int _acolyteId = FourCC("uaco");

  private static void OnSell()
  {
    var triggerUnit = @event.Unit;
    triggerUnit.Kill();
    var soldUnit = @event.SoldUnit;
    var facing = triggerUnit.Facing;
    soldUnit.Facing = facing;
    soldUnit.Owner.Select(soldUnit);
  }

  public static void Setup() => PlayerUnitEvents.Register(UnitTypeEvent.SellsUnit, OnSell, _acolyteId);
}
