public class CthunQuestSetup{

  public static void OnInit( ){

    FACTION_CTHUN.StartingQuest = FACTION_CTHUN.AddQuest(QuestTitanJailors.create());
    FACTION_CTHUN.AddQuest(QuestAwakenCthun.create());
    FACTION_CTHUN.AddQuest(QuestEndlessRanks.create());
    FACTION_CTHUN.AddQuest(QuestGatesofAhnqiraj.create());
    FACTION_CTHUN.AddQuest(QuestDragonSoul.create());
    FACTION_CTHUN.AddQuest(QuestWyrmrestTemple.create());
  }

}
