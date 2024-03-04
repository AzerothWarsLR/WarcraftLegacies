using MacroTools.Extensions;
using WCSharp.Events;


namespace WarcraftLegacies.Source.FactionMechanics.Scourge
{
  public static class SacrificeAcolyte
  {
    private static readonly int AcolyteId = FourCC("uaco");
    
    private static void OnSell()
    {
      GetTriggerUnit().Kill();
      GetSoldUnit().Facing = GetTriggerUnit().Facing;
      GetSoldUnit().Owner.Select(GetSoldUnit());
    }

    public static void Setup()
    {
      PlayerUnitEvents.Register(UnitTypeEvent.SellsUnit, OnSell, AcolyteId);
    }
  }
}