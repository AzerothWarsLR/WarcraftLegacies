using WarcraftLegacies.Source.Quests;
using WarcraftLegacies.Source.Quests.Naga;
using WarcraftLegacies.Source.Setup.FactionSetup;

namespace WarcraftLegacies.Source.Setup.QuestSetup
{
  public static class NagaQuestSetup
  {
    public static void Setup(ArtifactSetup artifactSetup, AllLegendSetup allLegendSetup)
    {
      var illidari = IllidariSetup.Illidari;
      illidari.StartingQuest = illidari.AddQuest(new QuestLostOnes(Regions.AkamaUnlock));
      illidari.AddQuest(new QuestBlackTemple(Regions.IllidanBlackTempleUnlock, allLegendSetup.Naga.LegendIllidan));
      illidari.AddQuest(new QuestEyeofSargeras(artifactSetup.EyeOfSargeras, allLegendSetup.Naga.LegendIllidan));
      illidari.AddQuest(new QuestZangarmarsh(Regions.TelredorUnlock, allLegendSetup.Naga.LegendVashj));
      illidari.AddQuest(new QuestStranglethornOutpost(Regions.IllidariUnlockSA, allLegendSetup.Naga.LegendVashj));
      illidari.AddQuest(new QuestNajentus(new[]
      {
        allLegendSetup.Stormwind.Stormwindkeep,
        allLegendSetup.Ironforge.LegendGreatforge
      }));
      illidari.AddQuest(new QuestRegroupCastaway());
      illidari.AddQuest(new QuestBlackrookHold(allLegendSetup.Sentinels.BlackrookHold));
    }
  }
}