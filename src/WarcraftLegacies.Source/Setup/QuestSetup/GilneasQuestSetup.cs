using WarcraftLegacies.Source.Quests.Gilneas;
using WarcraftLegacies.Source.Setup.FactionSetup;

namespace WarcraftLegacies.Source.Setup.QuestSetup
{
  public static class GilneasQuestSetup
  {
    public static void Setup(ArtifactSetup artifactSetup)
    {
      var gilneas = GilneasSetup.Gilneas;
      if (gilneas != null)
      {
        gilneas.AddQuest(new QuestTempestReach());
        gilneas.AddQuest(new QuestStormglen());
        gilneas.AddQuest(new QuestKeelHarbor());
        gilneas.AddQuest(new QuestDuskhaven());
        gilneas.AddQuest(new QuestGilneasCity());

        var questGoldrinnElvePath = new QuestGoldrinnElvePath(artifactSetup.ScytheOfElune);
        gilneas.AddQuest(questGoldrinnElvePath);
        gilneas.AddQuest(new QuestGoldrinnHumanPath(questGoldrinnElvePath, artifactSetup.ScytheOfElune));
      }
    }
  }
}
