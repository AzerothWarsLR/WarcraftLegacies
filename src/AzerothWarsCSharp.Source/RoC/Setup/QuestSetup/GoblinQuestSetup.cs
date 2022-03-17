public class GoblinQuestSetup{

  public static void OnInit( ){

    FACTION_GOBLIN.StartingQuest = FACTION_GOBLIN.AddQuest(QuestBusinessExpansion.create());
    FACTION_GOBLIN.AddQuest(QuestGadgetzan.create());
    FACTION_GOBLIN.AddQuest(QuestExplosiveEngineering.create());
    FACTION_GOBLIN.AddQuest(QuestWesternExpansion.create());
    FACTION_GOBLIN.AddQuest(QuestLumberMarket.create());
    FACTION_GOBLIN.AddQuest(QuestGoblinEmpire.create());

  }

}
