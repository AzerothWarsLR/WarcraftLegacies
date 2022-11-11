using WarcraftLegacies.Source.Quests.Goblin;
using WarcraftLegacies.Source.Setup.FactionSetup;

namespace WarcraftLegacies.Source.Setup.QuestSetup
{
  public static class GoblinQuestSetup
  {
    public static void Setup()
    {
      var goblin = GoblinSetup.Goblin;
      goblin.StartingQuest = goblin.AddQuest(new QuestBusinessExpansion());
      goblin.AddQuest(new QuestGadgetzan(Regions.GadgetUnlock));
      goblin.AddQuest(new QuestExplosiveEngineering());
      goblin.AddQuest(new QuestWesternExpansion());
      goblin.AddQuest(new QuestLumberMarket());
      goblin.AddQuest(new QuestGoblinEmpire());
    }
  }
}