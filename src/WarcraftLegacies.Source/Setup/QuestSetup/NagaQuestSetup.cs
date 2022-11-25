using WarcraftLegacies.Source.Quests.Naga;
using WarcraftLegacies.Source.Setup.FactionSetup;

namespace WarcraftLegacies.Source.Setup.QuestSetup
{
  public static class NagaQuestSetup
  {
    public static void Setup()
    {
      var naga = IllidanSetup.Illidan;
      {
        // //Early duel
        //
        naga.AddQuest(new QuestAetheneumTomb(Regions.AethneumCatacombs));
        naga.AddQuest(new QuestRegroupCastaway());
        naga.AddQuest(new QuestEyeofSargeras());
        naga.AddQuest(new QuestIllidanKillGoblin());
        naga.AddQuest(new QuestADestinyofFlameandSorrow());

      }

    }
  }
}