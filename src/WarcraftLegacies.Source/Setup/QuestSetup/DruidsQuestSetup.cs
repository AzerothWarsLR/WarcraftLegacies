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
    public static void Setup(ArtifactSetup artifactSetup)
    {
      var druids = FactionSetup.DruidsSetup.Druids;
      var newQuest = druids.AddQuest(new QuestMalfurionAwakens(Regions.MoongladeVillage, LegendDruids.LegendNordrassil.Unit, artifactSetup.ArtifactHornofcenarius));
      druids.StartingQuest = newQuest;
      druids.AddQuest(new QuestAshenvale(Regions.AshenvaleUnlock));
      druids.AddQuest(new QuestDruidsKillFrostwolf());
      druids.AddQuest(new QuestDruidsKillWarsong());
      druids.AddQuest(new QuestAndrassil());
      druids.AddQuest(new QuestTortolla());
    }
  }
}