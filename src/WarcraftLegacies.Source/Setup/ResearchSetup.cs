using MacroTools;
using WarcraftLegacies.Source.Researches.Lordaeron;
using WarcraftLegacies.Source.Researches.Ironforge;
using WarcraftLegacies.Source.Researches.Stormwind;

namespace WarcraftLegacies.Source.Setup
{
  public static class ResearchSetup
  {
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem)
    {
      VeteranFootmen.Setup();
      TitanForgeArtifact.Setup();
      DeeprunTram.Setup(preplacedUnitSystem);

      TierBattleTactics.Setup();
      TierCodeOfChivalry.Setup();
      TierElectricStrikeRitual.Setup();
      TierExpeditionSurvivors.Setup();
      TierExploitWeakness.Setup();
      TierHighSorcererAndromath.Setup();
      TierKatranaPrestor.Setup();
      TierKnowledgeOfHonorHold.Setup(preplacedUnitSystem);
      TierMagesOfStromgarde.Setup(preplacedUnitSystem);
      TierReflectivePlating.Setup();
      TierSolarFlareRitual.Setup();
      TierVeteranGuard.Setup();
    }
  }
} 