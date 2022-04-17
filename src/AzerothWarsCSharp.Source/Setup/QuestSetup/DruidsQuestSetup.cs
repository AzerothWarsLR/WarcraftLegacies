using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.Source.Quests.Druids;

namespace AzerothWarsCSharp.Source.Setup.QuestSetup
{
  public static class DruidsQuestSetup{

    public static void Setup( )
    {
      var druids = FactionSetup.DruidsSetup.factionDruids;
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
