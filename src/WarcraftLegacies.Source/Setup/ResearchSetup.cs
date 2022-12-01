using MacroTools;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.Powers;
using WarcraftLegacies.Source.Researches.Lordaeron;
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
      VeteranFootmen.Setup();
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

      PlayerUnitEvents.Register(ResearchEvent.IsFinished, () =>
      {
        GetTriggerPlayer()
          .GetFaction()?
          .AddPower(new Rematerialization(0.15f, new Point(-25562.9f, 8536.6f), "Argus", Regions.MonolithNoBuild)
          {
            IconName = "achievement_raid_argusraid",
            Name = "Rematerialization",
            EligibilityCondition = dyingUnit => dyingUnit.OwningPlayer().GetObjectLimit(dyingUnit.GetTypeId()) != 0
          });
      }, Constants.UPGRADE_R096_REMATERIALIZATION_LEGION);
    }
  }
} 