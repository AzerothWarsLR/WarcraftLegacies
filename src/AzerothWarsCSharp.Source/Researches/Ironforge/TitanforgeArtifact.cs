using AzerothWarsCSharp.Source.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.Researches.Ironforge
{
  public class TitanForgeArtifact{
    private const int RESEARCH_ID = FourCC("R08K");
    
    private static void Research( ){
      var heldItem = UnitItemInSlot(GetTriggerUnit(), 0);
      Artifact heldArtifact = Artifact.artifactsByType[GetItemTypeId(heldItem)];
      if (heldItem != null && heldArtifact != null && heldArtifact.Titanforged == false){
        heldArtifact.Titanforge();
      }else {
        AdjustPlayerStateBJ(1000, GetTriggerPlayer(), PLAYER_STATE_RESOURCE_GOLD);
        AdjustPlayerStateBJ(750, GetTriggerPlayer(), PLAYER_STATE_RESOURCE_LUMBER);
      }
      SetPlayerTechResearched(GetTriggerPlayer(), RESEARCH_ID, 1);
    }

    public static void Setup( ){
      RegisterResearchFinishedAction(RESEARCH_ID,  Research);
    }
  }
}
