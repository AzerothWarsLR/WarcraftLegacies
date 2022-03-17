namespace AzerothWarsCSharp.Source.RoC.Mechanics.Scourge
{
  public class HelmOfDominationDropsWhenScourgeLeaves{

    private static void Actions( ){
      if (GetTriggerFaction() == FACTION_SCOURGE && ARTIFACT_HELMOFDOMINATION.OwningUnit == LEGEND_LICHKING.Unit){
        SetItemPosition(ARTIFACT_HELMOFDOMINATION.item, GetRectCenterX(gg_rct_LichKing), GetRectCenterY(gg_rct_LichKing));
      }
    }

    private static void OnInit( ){
      trigger trig = CreateTrigger();
      OnFactionGameLeave.register(trig);
      TriggerAddAction(trig,  Actions);
    }

  }
}
