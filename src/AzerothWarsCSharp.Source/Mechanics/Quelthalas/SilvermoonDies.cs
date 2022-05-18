using AzerothWarsCSharp.Source.Setup.Legends;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Mechanics.Quelthalas
{
  public static class SilvermoonDies
  {
    private static void Dies()
    {
      SetUnitInvulnerable(LegendQuelthalas.LegendSunwell.Unit, false);
    }

    public static void Setup()
    {
      trigger trig = CreateTrigger();
      TriggerRegisterUnitEvent(trig, LegendQuelthalas.LegendSunwell.Unit, EVENT_UNIT_DEATH);
      TriggerAddAction(trig, Dies);
    }
  }
}