using AzerothWarsCSharp.Source.Legends;

namespace AzerothWarsCSharp.Source.Mechanics.Quelthalas
{
  public static class SilvermoonDies
  {
    private static void Dies()
    {
      SetUnitInvulnerable(LegendQuelthalas.legendSunwell.Unit, false);
    }

    public static void Setup()
    {
      trigger trig = CreateTrigger();
      TriggerRegisterUnitEvent(trig, LegendQuelthalas.legendSunwell.Unit, EVENT_UNIT_DEATH);
      TriggerAddAction(trig, Dies);
    }
  }
}