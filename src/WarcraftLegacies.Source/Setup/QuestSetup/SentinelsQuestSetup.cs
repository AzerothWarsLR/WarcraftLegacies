using System.Collections.Generic;
using WarcraftLegacies.Source.Quests.Sentinels;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Setup.QuestSetup
{
  public static class SentinelsQuestSetup
  {
    public static void Setup(ArtifactSetup artifactSetup, AllLegendSetup allLegendSetup)
    {
      var sentinels = SentinelsSetup.Sentinels;
      if (sentinels != null)
      {
        sentinels.StartingQuest = sentinels.AddQuest(new QuestFeathermoon(Regions.FeathermoonUnlock));
        sentinels.AddQuest(new QuestAstranaar(new List<Rectangle> { Regions.AstranaarUnlock, Regions.AuberdineUnlock }));
        sentinels.AddQuest(new QuestSentinelsKillWarsong(allLegendSetup.Warsong.Orgrimmar));
        sentinels.AddQuest(new QuestSentinelsKillFrostwolf(allLegendSetup.Frostwolf.ThunderBluff));
        sentinels.AddQuest(new QuestScepterOfTheQueenSentinels(Regions.TheAthenaeum, artifactSetup.ScepterOfTheQueen, allLegendSetup.Warsong.StonemaulKeep));
        sentinels.AddQuest(new QuestVaultoftheWardens(allLegendSetup.Sentinels.Maiev, allLegendSetup.Sentinels.VaultOfTheWardens));
        sentinels.AddQuest(new QuestMaievOutland(Regions.MaievStartUnlock, allLegendSetup.Sentinels.Maiev, allLegendSetup.Sentinels.VaultOfTheWardens));
      }
    }
  }
}