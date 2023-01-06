using WarcraftLegacies.Source.Quests.Fel_Horde;
using static WarcraftLegacies.Source.Setup.FactionSetup.FelHordeSetup;

namespace WarcraftLegacies.Source.Setup.QuestSetup
{
  public static class FelHordeQuestSetup
  {
    public static void Setup()
    {
      var questHellfireCitadel = FelHorde.AddQuest(new QuestHellfireCitadel(Regions.HellfireUnlock));
      FelHorde.AddQuest(new QuestBlackrock(Regions.BlackrockUnlock, new[] { questHellfireCitadel }));
      FelHorde.AddQuest(new QuestFelHordeKillIronforge());
      FelHorde.AddQuest(new QuestFelHordeKillStormwind());
      FelHorde.AddQuest(new QuestGuldansLegacy());
    }
  }
}