using WarcraftLegacies.Source.Researches.Lordaeron;
using WarcraftLegacies.Source.Researches.Ironforge;
using WarcraftLegacies.Source.Researches.Stormwind;

namespace WarcraftLegacies.Source.Setup
{
  public static class ResearchSetup
  {
    public static void Setup()
    {
      VeteranFootmen.Setup();
      TitanForgeArtifact.Setup();
      DeeprunTram.Setup();

      TierBattleTactics.Setup();
      TierCodeOfChivalry.Setup();
      TierElectricStrikeRitual.Setup();
      TierExpeditionSurvivors.Setup();
      TierExploitWeakness.Setup();
      TierHighSorcererAndromath.Setup();
      TierKatranaPrestor.Setup();
      TierKnowledgeOfHonorHold.Setup();
      TierMagesOfStromgarde.Setup();
      TierReflectivePlating.Setup();
      TierSolarFlareRitual.Setup();
      TierVeteranGuard.Setup();
    }
  }
} 