using MacroTools;
using WarcraftLegacies.Source.Quests.Zandalar;
using WarcraftLegacies.Source.Setup.FactionSetup;

namespace WarcraftLegacies.Source.Setup.QuestSetup
{
  public static class ZandalarQuestSetup
  {
    public static void Setup(ArtifactSetup artifactSetup, PreplacedUnitSystem preplacedUnitSystem, AllLegendSetup allLegendSetup)
    {
      var zandalar = ZandalarSetup.Zandalar;
      zandalar.AddQuest(new QuestZulfarrak(Regions.Zulfarrak, allLegendSetup.Neutral.Zulfarrak, allLegendSetup.Troll.Zul));
      zandalar.AddQuest(new QuestZandalar(allLegendSetup.Sentinels.Feathermoon, Regions.ZandalarUnlock));
      zandalar.AddQuest(new QuestGundrak(allLegendSetup));
      zandalar.AddQuest(new QuestJinthaAlor(allLegendSetup));
      zandalar.AddQuest(new QuestZulgurub(allLegendSetup));
      zandalar.AddQuest(new QuestHakkar(artifactSetup.ZinRokh));
    }
  }
}
