using AzerothWarsCSharp.MacroTools.FactionSystem;
using WCSharp.Events;
using static War3Api.Common;

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
            : GetTriggerPlayer().GetFaction()?.PlayerColor);
      });
    }
  }
}