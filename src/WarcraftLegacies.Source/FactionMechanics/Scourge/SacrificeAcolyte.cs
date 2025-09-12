using MacroTools.Extensions;
using WCSharp.Events;

namespace WarcraftLegacies.Source.FactionMechanics.Scourge
{
  public static class SacrificeAcolyte
  {
    private static readonly int AcolyteId = FourCC("uaco");
    
    private static void OnSell()
    {
      unit tempQualifier1 = GetTriggerUnit();
      KillUnit(tempQualifier1);
      unit tempQualifier = GetSoldUnit();
      float facing = GetTriggerUnit().GetFacing();
      BlzSetUnitFacingEx(tempQualifier, facing);
      GetSoldUnit().OwningPlayer().Select(GetSoldUnit());
    }

    public static void Setup()
    {
      PlayerUnitEvents.Register(UnitTypeEvent.SellsUnit, OnSell, AcolyteId);
    }
  }
}