using AzerothWarsCSharp.Source.Libraries.MacroTools;
using WCSharp.Events;

namespace AzerothWarsCSharp.Source.Game_Logic
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