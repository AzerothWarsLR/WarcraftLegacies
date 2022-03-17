public class SentinelsQuestSetup{

  public static void OnInit( ){
    //Early duel
    FACTION_SENTINELS.StartingQuest = FACTION_SENTINELS.AddQuest(QuestAstranaar.create());
    FACTION_SENTINELS.AddQuest(QuestFeathermoon.create());
    FACTION_SENTINELS.AddQuest(QuestSentinelsKillWarsong.create());
    FACTION_SENTINELS.AddQuest(QuestSentinelsKillFrostwolf.create());
    FACTION_SENTINELS.AddQuest(QuestMaievOutland.create());
    FACTION_SENTINELS.AddQuest(QuestScepterOfTheQueenSentinels.create());
    //Misc
    FACTION_SENTINELS.AddQuest(QuestVaultoftheWardens.create());
    //call FACTION_SENTINELS.AddQuest(QuestJoinAllianceSentinel.create())
  }

}
