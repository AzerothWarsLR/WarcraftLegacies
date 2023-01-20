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
    public static void Setup(ArtifactSetup artifactSetup, LegendDruids legendDruids)
    {
      var druids = FactionSetup.DruidsSetup.Druids;
      var newQuest = druids.AddQuest(new QuestMalfurionAwakens(Regions.MoongladeVillage, legendDruids.LegendNordrassil.Unit, artifactSetup.HornOfCenarius));
      druids.StartingQuest = newQuest;
      druids.AddQuest(new QuestAshenvale(Regions.AshenvaleUnlock));
      druids.AddQuest(new QuestDruidsKillFrostwolf());
      druids.AddQuest(new QuestDruidsKillWarsong());
      druids.AddQuest(new QuestAndrassil());
      druids.AddQuest(new QuestShaladrassil());
      druids.AddQuest(new QuestTortolla());
    }
  }
}