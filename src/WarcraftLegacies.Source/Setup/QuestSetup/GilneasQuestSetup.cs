using WarcraftLegacies.Source.Quests.Gilneas;
using WarcraftLegacies.Source.Setup.FactionSetup;

namespace WarcraftLegacies.Source.Setup.QuestSetup
{
  public static class GilneasQuestSetup
  {
    public static void Setup(ArtifactSetup artifactSetup)
    {
      var gilneas = GilneasSetup.Gilneas;

      gilneas.AddQuest(new QuestDuskhaven());
      gilneas.AddQuest(new QuestStormglen());
      gilneas.AddQuest(new QuestKeelHarbor());
      gilneas.AddQuest(new QuestTempestReach());
      gilneas.AddQuest(new QuestGilneasCity());
      gilneas.AddQuest(new QuestGoldrinnHumanPath(artifactSetup.HornOfCenarius));
    }
  }
}
