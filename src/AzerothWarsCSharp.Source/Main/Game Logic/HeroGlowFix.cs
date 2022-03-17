using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.Main.Game_Logic
{
  public class HeroGlowFix{

    private static void Revived( ){
      Legend revivedLegend = Legend.ByHandle(GetTriggerUnit());
      if (revivedLegend.HasCustomColor){
        SetUnitColor(GetTriggerUnit(), revivedLegend.PlayerColor);
      }else {
        SetUnitColor(GetTriggerUnit(), Person.ByHandle(GetTriggerPlayer()).Faction.playCol);
      }
    }

    private static void OnInit( ){
      PlayerUnitEventAddAction(EVENT_PLAYER_HERO_REVIVE_FINISH,  Revived);
    }

  }
}
