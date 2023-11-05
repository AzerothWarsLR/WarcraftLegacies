using System.Collections.Generic;
using MacroTools;
using MacroTools.ArtifactSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Quests;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Setup.QuestSetup
{
  /// <summary>
  /// Responsible for setting up all shared <see cref="QuestData"/>s.
  /// </summary>
  public static class SharedQuestSetup
  {
    private static QuestData _tombOfSargerasQuest;
    private static QuestData _ragnarosQuest;
    private static QuestData _dragonsOfNightmareOne;
    
    /// <summary>
    /// Adds to the <see cref="Faction"/> any <see cref="QuestData"/>s that should be globally available.
    /// </summary>
    public static void AddSharedQuests(Faction faction, ArtifactSetup artifactSetup)
    {
      faction.AddQuest(new QuestZinrokhAssembly(new List<Artifact>
      {
        artifactSetup.AzureFragment,
        artifactSetup.BronzeFragment,
        artifactSetup.EmeraldFragment,
        artifactSetup.ObsidianFragment,
        artifactSetup.RubyFragment
      }));
      faction.AddQuest(_tombOfSargerasQuest);
      faction.AddQuest(_ragnarosQuest);
      faction.AddQuest(_dragonsOfNightmareOne);
    }
    
    /// <summary>
    /// Sets up all shared <see cref="QuestData"/>s.
    /// </summary>
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem, ArtifactSetup artifactSetup, AllLegendSetup allLegendSetup)
    {
      //Todo: this function should eventually be removed in favour of just using AddSharedQuests for each Faction in
      //their OnRegister methods, as exemplied by Dalaran and Gilneas currently.
      _tombOfSargerasQuest = CreateTombOfSargerasQuest(preplacedUnitSystem);
      _ragnarosQuest = CreateRagnarosQuest(preplacedUnitSystem, allLegendSetup);
      _dragonsOfNightmareOne = CreateDragonsOfNightmareQuest(preplacedUnitSystem);
      foreach (var faction in FactionManager.GetAllFactions()) 
        AddSharedQuests(faction, artifactSetup);
    }
    
    private static QuestDragonsOfNightmare CreateDragonsOfNightmareQuest(PreplacedUnitSystem preplacedUnitSystem)
    {
      var waygateOne = preplacedUnitSystem.GetUnit(Constants.UNIT_N07F_EMERALD_PORTAL_DRAGON_PORTALS, Regions.FeralasEmeraldPortal.Center).Show(false);
      var waygateTwo = preplacedUnitSystem.GetUnit(Constants.UNIT_N07F_EMERALD_PORTAL_DRAGON_PORTALS, Regions.AshenvaleEmeraldPortal.Center).Show(false);
      var dragonEk = preplacedUnitSystem.GetUnit(Constants.UNIT_N04X_YSONDRE);
      var dragonKalimdor = preplacedUnitSystem.GetUnit(Constants.UNIT_N04S_TAERAR);
      return new QuestDragonsOfNightmare(dragonKalimdor, dragonEk, "Feralas", "Ashenvale", waygateOne, waygateTwo, Regions.AshenvaleEmeraldPortal, Regions.FeralasEmeraldPortal, "BTNWarpPortalGreen");
    }

    private static QuestRagnaros CreateRagnarosQuest(PreplacedUnitSystem preplacedUnitSystem, AllLegendSetup allLegendSetup)
    {
      return new QuestRagnaros(allLegendSetup.Neutral.Ragnaros,
        preplacedUnitSystem.GetUnit(Constants.UNIT_N02B_RAGNAROS_SUMMONING_PEDESTAL_PEDESTAL));
    }

    private static QuestTombOfSargeras CreateTombOfSargerasQuest(PreplacedUnitSystem preplacedUnitSystem)
    {
      return new QuestTombOfSargeras(
          new List<Rectangle>
          {
            Regions.TombOfSargerasInteriorA,
            Regions.TombOfSargerasInteriorB,
            Regions.TombOfSargerasInteriorC,
            Regions.TombOfSargerasInteriorD,
            Regions.TombOfSargerasInteriorE,
            Regions.TombOfSargerasInteriorF,
            Regions.TombOfSargerasInteriorG,
            Regions.TombOfSargerasInteriorH
          }, Regions.Sargeras_Entrance, preplacedUnitSystem.GetUnit(Constants.UNIT_H00K_HORIZONTAL_WOODEN_GATE_CLOSED, Regions.Sargeras_Entrance.Center)
          , preplacedUnitSystem.GetUnit(Constants.UNIT_O01U_GUL_DAN_S_REMAINS));
    }
  }
}