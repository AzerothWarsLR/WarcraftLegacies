using System.Collections.Generic;
using MacroTools;
using MacroTools.ArtifactSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Quests;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.QuestSetup
{
  /// <summary>
  /// Responsible for setting up all shared <see cref="QuestData"/>s.
  /// </summary>
  public static class SharedQuestSetup
  {
    /// <summary>
    /// Sets up all shared <see cref="QuestData"/>s.
    /// </summary>
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem, ArtifactSetup artifactSetup, AllLegendSetup allLegendSetup)
    {
      var tombOfSargerasQuest = CreateTombOfSargerasQuest(preplacedUnitSystem);
      var ragnarosQuest = CreateRagnarosQuest(preplacedUnitSystem, allLegendSetup);
      var dragonsOfNightmareOne = CreateDragonsOfNightmareQuestOne(preplacedUnitSystem);
      var dragonsOfNightmareTwo = CreateDragonsOfNightmareQuestTwo(preplacedUnitSystem);
      var navigation = new QuestNavigation();
      foreach (var faction in FactionManager.GetAllFactions())
      {
        faction.AddQuest(navigation);
        faction.AddQuest(tombOfSargerasQuest);
        faction.AddQuest(new QuestZinrokhAssembly(new List<Artifact>
        {
          artifactSetup.AzureFragment,
          artifactSetup.BronzeFragment,
          artifactSetup.EmeraldFragment,
          artifactSetup.ObsidianFragment,
          artifactSetup.RubyFragment
        }));
        faction.AddQuest(new QuestBookOfMedivh(allLegendSetup.Dalaran.Dalaran, preplacedUnitSystem.GetUnit(Constants.UNIT_NBSM_BOOK_OF_MEDIVH),
          artifactSetup.BookOfMedivh, faction == LegionSetup.Legion, faction == DalaranSetup.Dalaran));
        faction.AddQuest(new QuestSkullOfGuldan(allLegendSetup.Dalaran.Dalaran,
          preplacedUnitSystem.GetUnit(Constants.UNIT_N0DK_SKULL_OF_GUL_DAN_PEDESTAL),
          faction == IllidanSetup.Illidan, artifactSetup.SkullOfGuldan));
        faction.AddQuest(ragnarosQuest);
      }
      AddDragonsOfNightmareQuests(dragonsOfNightmareOne, dragonsOfNightmareTwo);
    }
    private static void AddDragonsOfNightmareQuests(QuestDragonsOfNightmare dragonsOfNightmareOne, QuestDragonsOfNightmare dragonsOfNightmareTwo)
    {
      // These quests should only show up once they become relevant
      TimerStart(CreateTimer(), 1500, false, () =>
      {
        foreach (var faction in FactionManager.GetAllFactions())
        {
          faction.AddQuest(dragonsOfNightmareTwo);
          faction.AddQuest(dragonsOfNightmareOne);
        }
      });
    }
    private static QuestDragonsOfNightmare CreateDragonsOfNightmareQuestOne(PreplacedUnitSystem preplacedUnitSystem)
    {
      var waygateOne = preplacedUnitSystem.GetUnit(Constants.UNIT_N07F_EMERALD_PORTAL_DRAGON_PORTALS, Regions.FeralasEmeraldPortal.Center).Show(false);
      var waygateTwo = preplacedUnitSystem.GetUnit(Constants.UNIT_N07F_EMERALD_PORTAL_DRAGON_PORTALS, Regions.HinterEmeraldPortal.Center).Show(false);
      var dragonEk = preplacedUnitSystem.GetUnit(Constants.UNIT_N054_EMERISS);
      var dragonKalimdor = preplacedUnitSystem.GetUnit(Constants.UNIT_N04S_TAERAR);
      return new QuestDragonsOfNightmare(dragonKalimdor, dragonEk, "Feralas", "Hinterlands", waygateOne, waygateTwo, Regions.HinterEmeraldPortal, Regions.FeralasEmeraldPortal, "BTNWarpPortalGreen");
    }

    private static QuestDragonsOfNightmare CreateDragonsOfNightmareQuestTwo(PreplacedUnitSystem preplacedUnitSystem)
    {
      var waygateOne = preplacedUnitSystem.GetUnit(Constants.UNIT_N07F_EMERALD_PORTAL_DRAGON_PORTALS, Regions.AshenvaleEmeraldPortal.Center).Show(false);
      var waygateTwo = preplacedUnitSystem.GetUnit(Constants.UNIT_N07F_EMERALD_PORTAL_DRAGON_PORTALS, Regions.DuskwoodEmeraldPortal.Center).Show(false);
      var dragonEk = preplacedUnitSystem.GetUnit(Constants.UNIT_N04X_YSONDRE);
      var dragonKalimdor = preplacedUnitSystem.GetUnit(Constants.UNIT_N05O_LETHON);
      return new QuestDragonsOfNightmare(dragonKalimdor, dragonEk, "Ashenvale", "Duskwood", waygateOne, waygateTwo, Regions.DuskwoodEmeraldPortal, Regions.AshenvaleEmeraldPortal, "BTNWarpPortalRed");
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