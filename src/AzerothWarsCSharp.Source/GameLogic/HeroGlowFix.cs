//using AzerothWarsCSharp.Source.Libraries;
//using static War3Api.Common;
//using static War3Api.Blizzard;

//namespace AzerothWarsCSharp.Source.GameLogic
//{
//  /// <summary>
//  /// Manually resets a hero's color when trained.
//  /// Avoids a bug with hero glows.
//  /// </summary>
//  public static class HeroGlowFix
//  {
//    private static void OnAnyHeroRevived()
//    {
//      var revivedLegend = Legend.ByUnitHandle(GetTriggerUnit());
//      if (revivedLegend.PlayerColor != null)
//      {
//        SetUnitColor(revivedLegend.Unit, revivedLegend.PlayerColor);
//      }
//      else
//      {
//        SetUnitColor(GetTriggerUnit(), Faction.ByPlayerHandle(GetTriggerPlayer()).PlayerColor);
//      }
//    }

//    public static void Initialize()
//    {
//      trigger trig = CreateTrigger();
//      TriggerRegisterAnyUnitEventBJ(trig, EVENT_PLAYER_HERO_REVIVE_FINISH);
//      TriggerAddAction(trig, OnAnyHeroRevived);
//    }
//  }
//}
