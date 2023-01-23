using WarcraftLegacies.Source.Quests.Fel_Horde;
using static WarcraftLegacies.Source.Setup.FactionSetup.FelHordeSetup;

namespace WarcraftLegacies.Source.Setup.QuestSetup
{
  public static class FelHordeQuestSetup
  {
    public static void Setup(AllLegendSetup allLegendSetup)
    {
      var questHellfireCitadel = FelHorde.AddQuest(new QuestHellfireCitadel(Regions.HellfireUnlock));
      FelHorde.AddQuest(new QuestRebuildBlackTemple(Regions.BlackTempleBase));
      FelHorde.AddQuest(new QuestBlackrock(Regions.BlackrockUnlock, new[] { questHellfireCitadel }));
      FelHorde.AddQuest(new QuestFelHordeKillIronforge(allLegendSetup.Ironforge.GreatForge));
      FelHorde.AddQuest(new QuestFelHordeKillStormwind(allLegendSetup.Stormwind.Stormwindkeep));
      FelHorde.AddQuest(new QuestGuldansLegacy());
    }
  }
}