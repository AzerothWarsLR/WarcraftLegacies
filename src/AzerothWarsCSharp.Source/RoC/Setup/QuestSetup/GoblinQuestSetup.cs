using AzerothWarsCSharp.Source.RoC.Quests.Goblin;

namespace AzerothWarsCSharp.Source.RoC.Setup.QuestSetup
{
  public static class GoblinQuestSetup
  {
    public static void Setup()
    {
      var goblin = FactionSetup.GoblinSetup.FACTION_GOBLIN;
      goblin.StartingQuest = goblin.AddQuest(new QuestBusinessExpansion());
      goblin.AddQuest(new QuestGadgetzan());
      goblin.AddQuest(new QuestExplosiveEngineering());
      goblin.AddQuest(new QuestWesternExpansion());
      goblin.AddQuest(new QuestLumberMarket());
      goblin.AddQuest(new QuestGoblinEmpire());
    }
  }
}