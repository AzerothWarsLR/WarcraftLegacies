using WarcraftLegacies.Source.Quests;
using WarcraftLegacies.Source.Setup.FactionSetup;

namespace WarcraftLegacies.Source.Setup.QuestSetup
{
  public static class NagaQuestSetup
  {
    public static void Setup(ArtifactSetup artifactSetup)
    {
      var illidari = IllidariSetup.Illidari;
      illidari.AddQuest(new QuestBlackrookHold());
    }
  }
}