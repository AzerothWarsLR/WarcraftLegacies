using System.Collections.Generic;
using MacroTools;
using MacroTools.ArtifactSystem;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Quests;
using WarcraftLegacies.Source.Setup.FactionSetup;

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
      // var tombOfSargerasQuest =
      //   new QuestTombOfSargeras(
      //     preplacedUnitSystem.GetUnit(Constants.UNIT_N032_TOMB_OF_SARGERAS, Regions.Broken_Isles.Center),
      //     Regions.Sargeras_Exit, preplacedUnitSystem.GetUnit(Constants.UNIT_O01U_GUL_DAN_S_REMAINS));
      
      foreach (var faction in FactionManager.GetAllFactions())
      {
        //faction.AddQuest(tombOfSargerasQuest);
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
        faction.AddQuest(new QuestSkullOfGuldan(preplacedUnitSystem.GetUnit(Constants.UNIT_N0DK_SKULL_OF_GUL_DAN_PEDESTAL),
          faction == LegionSetup.Legion || faction == IllidanSetup.Illidan, artifactSetup.SkullOfGuldan));
      }
    }
  }
}