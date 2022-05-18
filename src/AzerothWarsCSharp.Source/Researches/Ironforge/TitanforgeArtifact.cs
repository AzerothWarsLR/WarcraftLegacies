// using AzerothWarsCSharp.MacroTools.FactionSystem;
//
// using static War3Api.Common; using static War3Api.Blizzard; using static AzerothWarsCSharp.MacroTools.GeneralHelpers;
// {
//   public static class TitanForgeArtifact
//   {
//     private static readonly int RESEARCH_ID = FourCC("R08K");
//
//     private static void Research()
//     {
//       var heldItem = UnitItemInSlot(GetTriggerUnit(), 0);
//       Artifact heldArtifact = Artifact.GetFromTypeId(GetItemTypeId(heldItem));
//       if (heldItem != null && heldArtifact != null && heldArtifact.Titanforged == false)
//       {
//         heldArtifact.Titanforge();
//       }
//       else
//       {
//         AdjustPlayerStateBJ(1000, GetTriggerPlayer(), PLAYER_STATE_RESOURCE_GOLD);
//         AdjustPlayerStateBJ(750, GetTriggerPlayer(), PLAYER_STATE_RESOURCE_LUMBER);
//       }
//
//       SetPlayerTechResearched(GetTriggerPlayer(), RESEARCH_ID, 1);
//     }
//
//     public static void Setup()
//     {
//       RegisterResearchFinishedAction(RESEARCH_ID, Research);
//     }
//   }
// }