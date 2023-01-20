using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Quests.Druids;
using WarcraftLegacies.Source.Setup.Legends;

namespace WarcraftLegacies.Source.Setup.QuestSetup
{
  /// <summary>
  /// Responsible for setting up all Druid <see cref="QuestData"/>s.
  /// </summary>
  public static class DruidsQuestSetup
  {
    /// <summary>
    /// Sets up <see cref="DruidsQuestSetup"/>.
    /// </summary>
    public static void Setup(ArtifactSetup artifactSetup, AllLegendSetup allLegendSetup)
    {
      var druids = FactionSetup.DruidsSetup.Druids;
      var newQuest = druids.AddQuest(new QuestMalfurionAwakens(Regions.MoongladeVillage,
        allLegendSetup.Druids.LegendNordrassil.Unit, artifactSetup.HornOfCenarius,
        allLegendSetup.Druids.LegendMalfurion));
      druids.StartingQuest = newQuest;
      druids.AddQuest(new QuestAshenvale(Regions.AshenvaleUnlock, allLegendSetup.Druids.LegendMalfurion));
      druids.AddQuest(new QuestDruidsKillFrostwolf(allLegendSetup.Frostwolf.LegendThunderbluff));
      druids.AddQuest(new QuestDruidsKillWarsong());
      druids.AddQuest(new QuestAndrassil(allLegendSetup.Scourge.LegendLichking));
      druids.AddQuest(new QuestShaladrassil(allLegendSetup.Neutral.Shaladrassil));
      druids.AddQuest(new QuestTortolla(allLegendSetup.Druids.LegendTortolla));
    }
  }
}