// using WarcraftLegacies.Source.Legends;
// using WarcraftLegacies.Source.Setup;
// using WarcraftLegacies.Source.Setup.FactionSetup;
//
// using static War3Api.Common;  using static WarcraftLegacies.MacroTools.GeneralHelpers;
// {
//   public class HelmOfDominationDropsWhenScourgeLeaves{
//
//     private static void Actions( ){
//       if (GetTriggerFaction() == ScourgeSetup.FactionScourge && ArtifactSetup.ArtifactHelmofdomination.OwningUnit == LegendScourge.LegendLichking.Unit){
//         SetItemPosition(ArtifactSetup.ArtifactHelmofdomination.Item, GetRectCenterX(gg_rct_LichKing), GetRectCenterY(gg_rct_LichKing));
//       }
//     }
//
//     public static void Setup( ){
//       trigger trig = CreateTrigger();
//       OnFactionGameLeave.register(trig);
//       TriggerAddAction(trig,  Actions);
//     }
//
//   }
// }
