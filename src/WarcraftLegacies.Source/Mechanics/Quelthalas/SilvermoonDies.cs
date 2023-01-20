using MacroTools.Extensions;
using MacroTools.LegendSystem;
using WarcraftLegacies.Source.Setup.Legends;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Mechanics.Quelthalas
{
  public static class SilvermoonDies
  {
    public static void Setup(Capital sunwell)
    {
      var trig = CreateTrigger();
      TriggerRegisterUnitEvent(trig, sunwell.Unit, EVENT_UNIT_DEATH);
      TriggerAddAction(trig, () =>
      {
        sunwell.Unit?.SetInvulnerable(false);
      });
    }
  }
}