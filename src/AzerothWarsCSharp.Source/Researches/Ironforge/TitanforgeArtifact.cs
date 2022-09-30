 using AzerothWarsCSharp.MacroTools.FactionSystem;
 using static War3Api.Common;  
 using WCSharp.Events;
 using AzerothWarsCSharp.MacroTools.ArtifactSystem;
 namespace AzerothWarsCSharp.Source.Researches.Ironforge
 {
   public static class TitanForgeArtifact
   {
     private static readonly int RESEARCH_ID = Constants.UPGRADE_R08K_TITANFORGE_ARTIFACT_IRONFORGE;

     private static void Research()
     {
       var heldItem = UnitItemInSlot(GetTriggerUnit(), 0);
       Artifact heldArtifact = ArtifactManager.GetFromTypeId(GetItemTypeId(heldItem));
       if (heldItem != null && heldArtifact != null && heldArtifact.Titanforged == false)
       {
         heldArtifact.Titanforge();
       }
       else
       {
         GetTriggerPlayer().AdjustPlayerState(PLAYER_STATE_RESOURCE_GOLD, 1000);
         GetTriggerPlayer().AdjustPlayerState(PLAYER_STATE_RESOURCE_LUMBER, 750);
       }

       SetPlayerTechResearched(GetTriggerPlayer(), RESEARCH_ID, 1);
     }

     public static void Setup()
     {
       PlayerUnitEvents.Register(PlayerUnitEvent.ResearchIsFinished, Research, Constants.UPGRADE_R08K_TITANFORGE_ARTIFACT_IRONFORGE);
     }
   }
 }