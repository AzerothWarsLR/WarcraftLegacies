namespace AzerothWarsCSharp.Source.Mechanics.Scourge
{
  public class HelmOfDominationDropsWhenScourgeLeaves{

    private static void Actions( ){
      if (GetTriggerFaction() == FACTION_SCOURGE && ARTIFACT_HELMOFDOMINATION.OwningUnit == LegendScourge.LegendLichking.Unit){
        SetItemPosition(ARTIFACT_HELMOFDOMINATION.Item, GetRectCenterX(gg_rct_LichKing), GetRectCenterY(gg_rct_LichKing));
      }
    }

    public static void Setup( ){
      trigger trig = CreateTrigger();
      OnFactionGameLeave.register(trig);
      TriggerAddAction(trig,  Actions);
    }

  }
}
