using MacroTools;
using MacroTools.Extensions;
using MacroTools.Powers;
using MacroTools.ResearchSystems;
using WarcraftLegacies.Source.Researches;
using WarcraftLegacies.Source.Researches.Ironforge;
using WarcraftLegacies.Source.Researches.Stormwind;
using WCSharp.Shared.Data;

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
      TierCodeOfChivalry.Setup();
      TierExpeditionSurvivors.Setup();
      TierReflectivePlating.Setup();
      TierVeteranGuard.Setup();

      ResearchManager.Register(new DeeprunTram(Constants.UPGRADE_R014_DEEPRUN_TRAM_IRONFORGE, 70, 75,
        preplacedUnitSystem));

      ResearchManager.Register(new FlightPath(Constants.UPGRADE_R09N_FLIGHT_PATH_WARSONG, 70, 75,
        preplacedUnitSystem));

      ResearchManager.Register(new VeteranFootmen(Constants.UPGRADE_R00B_VETERAN_FOOTMEN_LORDAERON, 220, 120));

      ResearchManager.Register(new SunfuryWarrior(Constants.UPGRADE_R004_SUNFURY_TRAINING_QUEL_THALAS, 300, 300));

      ResearchManager.Register(new PowerResearch(Constants.UPGRADE_R096_REMATERIALIZATION_LEGION, 150, 250,
        new Rematerialization(0.15f, new Point(20454.9f, -28873.6f), "Argus", Regions.MonolithNoBuild)
        {
          Name = "Rematerialization",
          EligibilityCondition = dyingUnit => dyingUnit.OwningPlayer().GetObjectLimit(dyingUnit.GetTypeId()) != 0
        }));
    }
  }
}