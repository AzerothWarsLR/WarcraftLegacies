using WarcraftLegacies.Source.Quests.Druids;
using WarcraftLegacies.Source.Setup.Legends;

namespace WarcraftLegacies.Source.Setup.QuestSetup
{
  public static class DruidsQuestSetup{

    public static void Setup( )
    {
      var druids = FactionSetup.DruidsSetup.Druids;
      var newQuest = druids.AddQuest(new QuestMalfurionAwakens(Regions.Moonglade, LegendDruids.LegendNordrassil.Unit));
      druids.StartingQuest = newQuest;
      druids.AddQuest(new QuestAshenvale(Regions.AshenvaleUnlock));
      druids.AddQuest(new QuestDruidsKillFrostwolf());
      druids.AddQuest(new QuestDruidsKillWarsong());
      druids.AddQuest(new QuestAndrassil());
      druids.AddQuest(new QuestTortolla());
    }

  }
}
