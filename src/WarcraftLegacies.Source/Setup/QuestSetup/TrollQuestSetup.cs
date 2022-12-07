using WarcraftLegacies.Source.Quests.Zandalar;
using WarcraftLegacies.Source.Setup.FactionSetup;

namespace WarcraftLegacies.Source.Setup.QuestSetup
{
  public static class TrollQuestSetup
  {
    public static void Setup()
    {
      var zandalar = ZandalarSetup.Zandalar;

      zandalar.StartingQuest = zandalar.AddQuest(new QuestZandalar(Regions.ZandalarUnlock));
      zandalar.AddQuest(new QuestConquerKul());
      zandalar.AddQuest(new QuestZulfarrak(Regions.Zulfarrak));
      zandalar.AddQuest(new QuestZulgurub());
      zandalar.AddQuest(new QuestGundrak());
      zandalar.AddQuest(new QuestJinthaAlor());
      zandalar.AddQuest(new QuestHakkar());
    }
  }
}