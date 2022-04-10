using AzerothWarsCSharp.Source.Quests.Sentinels;
using AzerothWarsCSharp.Source.Setup.FactionSetup;

namespace AzerothWarsCSharp.Source.Setup.QuestSetup
{
  public static class SentinelsQuestSetup{
    public static void Setup( )
    {
      var sentinels = SentinelsSetup.Sentinels;
      
      sentinels.StartingQuest = sentinels.AddQuest(new QuestAstranaar());
      sentinels.AddQuest(new QuestFeathermoon());
      sentinels.AddQuest(new QuestSentinelsKillWarsong());
      sentinels.AddQuest(new QuestSentinelsKillFrostwolf());
      sentinels.AddQuest(new QuestMaievOutland(Regions.MaievStartUnlock));
      //sentinels.AddQuest(new QuestScepterOfTheQueenSentinels());
      sentinels.AddQuest(new QuestVaultoftheWardens());
    }

  }
}
