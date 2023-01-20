using WarcraftLegacies.Source.Quests.Goblin;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WarcraftLegacies.Source.Setup.Legends;

namespace WarcraftLegacies.Source.Setup.QuestSetup
{
  public static class GoblinQuestSetup
  {
    public static void Setup(AllLegendSetup allLegendSetup)
    {
      var goblin = GoblinSetup.Goblin;
      goblin.StartingQuest = goblin.AddQuest(new QuestBusinessExpansion());
      goblin.AddQuest(new QuestExplosiveEngineering());
      goblin.AddQuest(new QuestWesternExpansion(new [] { allLegendSetup.Sentinels.Auberdine, allLegendSetup.Sentinels.Feathermoon }));
      goblin.AddQuest(new QuestLumberMarket(allLegendSetup.Druids.LegendNordrassil));
      goblin.AddQuest(new QuestGoblinEmpire());
    }
  }
}