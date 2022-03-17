public class BlackEmpireQuestSetup{

  public static void OnInit( ){
    FACTION_BLACKEMPIRE.StartingQuest = FACTION_BLACKEMPIRE.AddQuest(QuestFirstObelisk.create());
    FACTION_BLACKEMPIRE.AddQuest(QuestSecondObelisk.create());
    FACTION_BLACKEMPIRE.AddQuest(QuestThirdObelisk.create());
    FACTION_BLACKEMPIRE.AddQuest(QuestYoggSaron.create());
    FACTION_BLACKEMPIRE.AddQuest(QuestBladeOfTheBlackEmpire.create());

    TOMB_OF_TYR = QuestIntoTheVoid.create();
  }

}
