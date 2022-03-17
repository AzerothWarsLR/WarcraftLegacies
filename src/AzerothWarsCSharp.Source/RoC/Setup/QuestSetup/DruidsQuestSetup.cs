public class DruidsQuestSetup{

  public static void OnInit( ){
    //Setup
    QuestData newQuest = FACTION_DRUIDS.AddQuest(QuestMalfurionAwakens.create());
    FACTION_DRUIDS.StartingQuest = newQuest;
    //Early duel
    FACTION_DRUIDS.AddQuest(QuestAshenvale.create());
    FACTION_DRUIDS.AddQuest(QuestDruidsKillFrostwolf.create());
    FACTION_DRUIDS.AddQuest(QuestDruidsKillWarsong.create());
    //Misc
    FACTION_DRUIDS.AddQuest(QuestAndrassil.create());
    FACTION_DRUIDS.AddQuest(QuestTortolla.create());
    //call FACTION_DRUIDS.AddQuest(QuestJoinAllianceDruid.create())
  }

}
