using System.Collections.Generic;
using MacroTools;
using MacroTools.ArtifactSystem;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Quests;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WCSharp.Shared.Data;

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
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem, ArtifactSetup artifactSetup)
    {
      var tombOfSargerasQuest =
        new QuestTombOfSargeras(
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
          ,preplacedUnitSystem.GetUnit(Constants.UNIT_O01U_GUL_DAN_S_REMAINS));

      var ragnarosQuest = new QuestRagnaros(preplacedUnitSystem.GetUnit(Constants.UNIT_N02B_ALTAR_OF_FLAMES_PEDESTAL));

      foreach (var faction in FactionManager.GetAllFactions())
      {
        faction.AddQuest(tombOfSargerasQuest);
        faction.AddQuest(new QuestZinrokhAssembly(new List<Artifact>()
        {
          artifactSetup.AzureFragment,
          artifactSetup.BronzeFragment,
          artifactSetup.EmeraldFragment,
          artifactSetup.ObsidianFragment,
          artifactSetup.RubyFragment
        }));
        faction.AddQuest(new QuestBookOfMedivh(preplacedUnitSystem.GetUnit(Constants.UNIT_NBSM_BOOK_OF_MEDIVH),
          faction == LegionSetup.Legion, artifactSetup.BookOfMedivh));
        faction.AddQuest(new QuestSkullOfGuldan(
          preplacedUnitSystem.GetUnit(Constants.UNIT_N0DK_SKULL_OF_GUL_DAN_PEDESTAL),
          faction == LegionSetup.Legion || faction == IllidanSetup.Illidan, artifactSetup.SkullOfGuldan));
        faction.AddQuest(ragnarosQuest);
      }
    }
  }
}