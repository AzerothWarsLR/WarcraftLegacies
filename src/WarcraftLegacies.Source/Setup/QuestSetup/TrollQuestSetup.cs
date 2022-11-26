using WarcraftLegacies.Source.Quests.Zandalar;
using WarcraftLegacies.Source.Setup.FactionSetup;

namespace WarcraftLegacies.Source.Setup.QuestSetup
{
  public static class TrollQuestSetup
  {
    public static void Setup()
    {
      var zandalar = ZandalarSetup.Zandalar;
      if (zandalar != null)
      {
        var questZulFarrak = new QuestZulfarrak(Regions.Zulfarrak);
        var questZandalar = new QuestZandalar(Regions.ZandalarUnlock);
        zandalar.StartingQuest = zandalar.AddQuest(questZandalar);
      
        zandalar.AddQuest(questZulFarrak);
        zandalar.AddQuest(new QuestConquerKul(Regions.Zulfarrak, questZulFarrak, questZandalar));
        zandalar.AddQuest(new QuestZulgurub());
        zandalar.AddQuest(new QuestGundrak());
        zandalar.AddQuest(new QuestJinthaAlor());
        zandalar.AddQuest(new QuestHakkar());
      }
    }
  }
}