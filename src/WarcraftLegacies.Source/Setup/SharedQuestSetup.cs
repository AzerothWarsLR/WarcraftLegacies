using System.Collections.Generic;
using MacroTools.Artifacts;
using MacroTools.PreplacedWidgets;
using MacroTools.Quests;
using WarcraftLegacies.Source.GameLogic;
using WarcraftLegacies.Source.Quests;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Setup;

/// <summary>
/// Responsible for setting up all shared <see cref="QuestData"/>s.
/// </summary>
public static class SharedQuestSetup
{
  /// <summary>
  /// Sets up all shared <see cref="QuestData"/>s.
  /// </summary>
  public static void Setup()
  {
    SharedQuestRepository.RegisterQuest(CreateTombOfSargerasQuest());
    SharedQuestRepository.RegisterQuest(CreateRagnarosQuest());
    SharedQuestRepository.RegisterQuest(CreateYoggSaronQuest());
    SharedQuestRepository.RegisterQuest(CreateDragonsOfNightmareQuest());
    SharedQuestRepository.RegisterQuestFactory(_ => new QuestZinrokhAssembly(new List<Artifact>
    {
      Artifacts.AzureFragment,
      Artifacts.BronzeFragment,
      Artifacts.EmeraldFragment,
      Artifacts.ObsidianFragment,
      Artifacts.RubyFragment
    }));
  }

  private static QuestDragonsOfNightmare CreateDragonsOfNightmareQuest()
  {
    var waygateOne = AllPreplacedWidgets.Units.GetClosest(UNIT_N07F_EMERALD_PORTAL_PORTAL, Regions.FeralasEmeraldPortal.Center);
    waygateOne.IsVisible = false;

    var waygateTwo = AllPreplacedWidgets.Units.GetClosest(UNIT_N07F_EMERALD_PORTAL_PORTAL, Regions.AshenvaleEmeraldPortal.Center);
    waygateTwo.IsVisible = false;

    var dragonEk = AllPreplacedWidgets.Units.Get(UNIT_N04X_YSONDRE);
    var dragonKalimdor = AllPreplacedWidgets.Units.Get(UNIT_N04S_TAERAR);
    return new QuestDragonsOfNightmare(dragonKalimdor, dragonEk, "Feralas", "Ashenvale", waygateOne, waygateTwo, Regions.AshenvaleEmeraldPortal, Regions.FeralasEmeraldPortal, "BTNWarpPortalGreen");
  }

  private static QuestRagnaros CreateRagnarosQuest()
  {
    return new QuestRagnaros(AllLegends.Neutral.Ragnaros,
      AllPreplacedWidgets.Units.Get(UNIT_N02B_RAGNAROS_SUMMONING_PEDESTAL_NEUTRAL));
  }

  private static QuestYoggSaron CreateYoggSaronQuest()
  {
    return new QuestYoggSaron(AllLegends.Neutral.YoggSaron,
      AllPreplacedWidgets.Units.Get(UNIT_YLL4_YOGG_SARON_S_PRISON_CREEP));
  }

  private static QuestTombOfSargeras CreateTombOfSargerasQuest()
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
        }, Regions.Sargeras_Entrance, AllPreplacedWidgets.Units.GetClosest(UNIT_H00K_HORIZONTAL_WOODEN_GATE_GATE_CLOSED, Regions.Sargeras_Entrance.Center)
        , AllPreplacedWidgets.Units.Get(UNIT_O01U_GUL_DAN_S_REMAINS));
  }
}
