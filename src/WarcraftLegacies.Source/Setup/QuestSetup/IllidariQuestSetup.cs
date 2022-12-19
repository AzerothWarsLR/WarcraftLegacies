using WarcraftLegacies.Source.Quests;
using WarcraftLegacies.Source.Quests.Naga;
using WarcraftLegacies.Source.Setup.FactionSetup;

namespace WarcraftLegacies.Source.Setup.QuestSetup
{
  public static class NagaQuestSetup
  {
    public static void Setup(ArtifactSetup artifactSetup)
    {
      var illidari = IllidariSetup.Illidari;
      illidari.AddQuest(new QuestFrozenThrone());
      illidari.AddQuest(new QuestEyeofSargeras(artifactSetup.EyeOfSargeras));
      illidari.AddQuest(new QuestIllidanKillGoblin());
      illidari.AddQuest(new QuestRegroupCastaway());
      illidari.AddQuest(new QuestBlackrookHold());
    }
  }
}