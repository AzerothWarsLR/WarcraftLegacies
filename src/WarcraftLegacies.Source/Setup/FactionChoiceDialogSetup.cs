using System.Collections.Generic;
using MacroTools;
using MacroTools.FactionChoices;
using WarcraftLegacies.Source.Factions;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Setup
{
  public static class FactionChoiceDialogSetup
  {
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem, ArtifactSetup artifactSetup, AllLegendSetup allLegendSetup, SharedGoldMineManager sharedGoldMineManager)
    {
      var sharedStartLocationManager = new SharedStartLocationManager();
      var factionsWithSharedStartLocations = new Dictionary<string, Faction>
      {
        { "Sentinels", new Sentinels(preplacedUnitSystem, allLegendSetup, artifactSetup, sharedGoldMineManager, sharedStartLocationManager) },
        { "Draenei", new Draenei(preplacedUnitSystem, allLegendSetup, artifactSetup, sharedGoldMineManager, sharedStartLocationManager) },
        // Add other factions with shared start locations here...
      };

      // Register the worker unit types for each faction
      RegisterFactionWorkerUnitTypes(sharedStartLocationManager, preplacedUnitSystem, allLegendSetup, artifactSetup, sharedGoldMineManager);

      // Setup factions which need to transfer ownership of shared starting units
      var sentinelsStartLocation = sharedStartLocationManager.GetStartLocation("Sentinels");
      var draeneiStartLocation = sharedStartLocationManager.GetStartLocation("Draenei");

      // Setup faction choice dialogs
      new FactionChoiceDialogPresenter(new Illidari(allLegendSetup, artifactSetup),
        new Sunfury(preplacedUnitSystem, allLegendSetup, artifactSetup)).Run(Player(15));

      new FactionChoiceDialogPresenter(new Dalaran(preplacedUnitSystem, artifactSetup, allLegendSetup),
        new Gilneas(preplacedUnitSystem, artifactSetup, allLegendSetup)).Run(Player(7));

      new FactionChoiceDialogPresenter(new Sentinels(preplacedUnitSystem, allLegendSetup, artifactSetup, sharedGoldMineManager, sharedStartLocationManager),
        new Draenei(preplacedUnitSystem, allLegendSetup, artifactSetup, sharedGoldMineManager, sharedStartLocationManager)).Run(Player(18));
    }

    private static void RegisterFactionWorkerUnitTypes(SharedStartLocationManager sharedStartLocationManager, PreplacedUnitSystem preplacedUnitSystem, AllLegendSetup allLegendSetup, ArtifactSetup artifactSetup, SharedGoldMineManager sharedGoldMineManager)
    {
      // Create instances of the factions with all required parameters
      var sentinelsFaction = new Sentinels(preplacedUnitSystem, allLegendSetup, artifactSetup, sharedGoldMineManager, sharedStartLocationManager);
      var sentinelsWorkerUnitTypeId = UNIT_EWSP_WISP_DRUIDS_SENTINELS_WORKER;

      var draeneiFaction = new Draenei(preplacedUnitSystem, allLegendSetup, artifactSetup, sharedGoldMineManager, sharedStartLocationManager);
      var draeneiFactionWorkerUnitTypeId = UNIT_O05A_GEMCRAFTER_DRAENEI_WORKER;

      // Register the worker unit types for each faction
      sharedStartLocationManager.RegisterFactionWorkerUnitType(sentinelsFaction, sentinelsWorkerUnitTypeId);
      sharedStartLocationManager.RegisterFactionWorkerUnitType(draeneiFaction, draeneiFactionWorkerUnitTypeId);
    }
  }
}