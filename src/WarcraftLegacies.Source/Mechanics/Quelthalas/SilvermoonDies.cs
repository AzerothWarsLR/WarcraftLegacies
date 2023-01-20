using MacroTools.Extensions;
using WarcraftLegacies.Source.Setup.Legends;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Mechanics.Quelthalas
{
  public static class SilvermoonDies
  {
    public static void Setup(LegendQuelthalas legendQuelthalas)
    {
      var trig = CreateTrigger();
      TriggerRegisterUnitEvent(trig, legendQuelthalas.LegendSunwell.Unit, EVENT_UNIT_DEATH);
      TriggerAddAction(trig, () =>
      {
        legendQuelthalas.LegendSunwell.Unit?.SetInvulnerable(false);
      });
    }
  }
}