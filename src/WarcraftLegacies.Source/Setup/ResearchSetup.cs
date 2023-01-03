using MacroTools;
using MacroTools.Extensions;
using MacroTools.Powers;
using MacroTools.ResearchSystems;
using WarcraftLegacies.Source.Researches;
using WarcraftLegacies.Source.Researches.Ironforge;
using WarcraftLegacies.Source.Researches.Stormwind;
using WCSharp.Events;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup
{
  /// <summary>
  /// Responsible for setting up all coded researches.
  /// </summary>
  public static class ResearchSetup
  {
    /// <summary>
    /// Sets up all coded researches.
    /// </summary>
    /// <param name="preplacedUnitSystem">A system that can find preplaced units.</param>
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem)
    {
      TitanForgeArtifact.Setup();
      DeeprunTram.Setup(preplacedUnitSystem);
      TierBattleTactics.Setup();
      TierCodeOfChivalry.Setup();
      TierElectricStrikeRitual.Setup();
      TierExpeditionSurvivors.Setup();
      TierExploitWeakness.Setup();
      TierKnowledgeOfHonorHold.Setup(preplacedUnitSystem);
      TierMagesOfStromgarde.Setup(preplacedUnitSystem);
      TierReflectivePlating.Setup();
      TierSolarFlareRitual.Setup();
      TierVeteranGuard.Setup();

      ResearchManager.Register(new VeteranFootmen(Constants.UPGRADE_R00B_VETERAN_FOOTMEN_LORDAERON, 220, 120));

      var revenants = new Revenants(Constants.UPGRADE_R08T_REVENANTS_SCOURGE, 250, 200);
      ResearchManager.Register(revenants);
      IncompatibleResearchSystem.Register(new BasicResearch(Constants.UPGRADE_R01X_EPIDEMIC_SCOURGE, 250, 200),
        revenants);
      
      PlayerUnitEvents.Register(ResearchEvent.IsFinished, () =>
      {
        GetTriggerPlayer()
          .GetFaction()?
          .AddPower(new Rematerialization(0.15f, new Point(20454.9f, -28873.6f), "Argus", Regions.MonolithNoBuild)
          {
            IconName = "achievement_raid_argusraid",
            Name = "Rematerialization",
            EligibilityCondition = dyingUnit => dyingUnit.OwningPlayer().GetObjectLimit(dyingUnit.GetTypeId()) != 0
          });
      }, Constants.UPGRADE_R096_REMATERIALIZATION_LEGION);
    }
  }
} 