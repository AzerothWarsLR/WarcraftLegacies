using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;
using WCSharp.Events;

namespace AzerothWarsCSharp.Source.Main.Game_Logic
{
  public static class HeroGlowFix
  {
    public static void Setup()
    {
      PlayerUnitEvents.Register(PlayerUnitEvent.HeroTypeFinishesRevive, () =>
      {
        var revivedLegend = Legend.GetFromUnit(GetTriggerUnit());
        SetUnitColor(GetTriggerUnit(),
          revivedLegend is {HasCustomColor: true}
            ? revivedLegend.PlayerColor
            : Person.ByHandle(GetTriggerPlayer())?.Faction.PlayerColor);
      });
    }
  }
}