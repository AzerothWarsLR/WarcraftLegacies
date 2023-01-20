using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Quests.Druids;

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
        allLegendSetup.Druids.Nordrassil.Unit, artifactSetup.HornOfCenarius,
        allLegendSetup.Druids.Malfurion));
      druids.StartingQuest = newQuest;
      druids.AddQuest(new QuestAshenvale(Regions.AshenvaleUnlock, allLegendSetup.Druids.Malfurion));
      druids.AddQuest(new QuestDruidsKillFrostwolf(allLegendSetup.Frostwolf.ThunderBluff));
      druids.AddQuest(new QuestDruidsKillWarsong());
      druids.AddQuest(new QuestAndrassil(allLegendSetup.Scourge.TheFrozenThrone));
      druids.AddQuest(new QuestShaladrassil(allLegendSetup.Neutral.Shaladrassil));
      druids.AddQuest(new QuestTortolla(allLegendSetup.Druids.Tortolla));
    }
  }
}