using AzerothWarsCSharp.Source.Legends;
using AzerothWarsCSharp.Source.Setup;
using AzerothWarsCSharp.Source.Setup.FactionSetup;

namespace AzerothWarsCSharp.Source.Mechanics.Scourge
{
  public class HelmOfDominationDropsWhenScourgeLeaves{

    private static void Actions( ){
      if (GetTriggerFaction() == ScourgeSetup.FactionScourge && ArtifactSetup.ArtifactHelmofdomination.OwningUnit == LegendScourge.LegendLichking.Unit){
        SetItemPosition(ArtifactSetup.ArtifactHelmofdomination.Item, GetRectCenterX(gg_rct_LichKing), GetRectCenterY(gg_rct_LichKing));
      }
    }

    public static void Setup( ){
      trigger trig = CreateTrigger();
      OnFactionGameLeave.register(trig);
      TriggerAddAction(trig,  Actions);
    }

  }
}
