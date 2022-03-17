public class TitanForgeArtifact{

  
    private const int RESEARCH_ID = FourCC(R08K);
  

  private static void Research( ){
    item heldItem = UnitItemInSlot(GetTriggerUnit(), 0);
    Artifact heldArtifact = Artifact.artifactsByType[GetItemTypeId(heldItem)];
    if ((heldItem != null && heldArtifact != 0 && heldArtifact.Titanforged == false)){
      heldArtifact.Titanforge();
    }else {
      AdjustPlayerStateBJ(1000, GetTriggerPlayer(), PLAYER_STATE_RESOURCE_GOLD);
      AdjustPlayerStateBJ(750, GetTriggerPlayer(), PLAYER_STATE_RESOURCE_LUMBER);
    }
    SetPlayerTechResearched(GetTriggerPlayer(), RESEARCH_ID, 1);
  }

  private static void OnInit( ){
    RegisterResearchFinishedAction(RESEARCH_ID,  Research);
  }

}
