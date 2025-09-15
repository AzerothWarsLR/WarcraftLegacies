using MacroTools.Extensions;
using WCSharp.Events;

namespace WarcraftLegacies.Source.FactionMechanics.Scourge
{
  public static class SacrificeAcolyte
  {
    private static readonly int AcolyteId = FourCC("uaco");
    
    private static void OnSell()
    {
      var triggerUnit = GetTriggerUnit();
      KillUnit(triggerUnit);
      var soldUnit = GetSoldUnit();
      var facing = GetUnitFacing(triggerUnit);
      BlzSetUnitFacingEx(soldUnit, facing);
      GetOwningPlayer(soldUnit).Select(soldUnit);
    }

    public static void Setup() => PlayerUnitEvents.Register(UnitTypeEvent.SellsUnit, OnSell, AcolyteId);
  }
}