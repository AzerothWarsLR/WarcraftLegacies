using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Quests.Druids;

namespace WarcraftLegacies.Source.Setup.QuestSetup
{
  public static class DruidsQuestSetup{

    public static void Setup( )
    {
      var druids = FactionSetup.DruidsSetup.Druids;
      QuestData newQuest = druids.AddQuest(new QuestMalfurionAwakens(Regions.Moonglade));
      druids.StartingQuest = newQuest;
      druids.AddQuest(new QuestAshenvale(Regions.AshenvaleUnlock));
      druids.AddQuest(new QuestDruidsKillFrostwolf());
      druids.AddQuest(new QuestDruidsKillWarsong());
      druids.AddQuest(new QuestAndrassil());
      druids.AddQuest(new QuestTortolla());
    }

  }
}
