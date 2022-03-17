public class NagaQuestSetup{

  public static void OnInit( ){
    //Early duel

    QuestData chapterThree = QuestIllidanChapterThree.create();
    QuestData chapterTwo = QuestIllidanChapterTwo.create(chapterThree);
    QuestData chapterOne = QuestIllidanChapterOne.create(chapterTwo);
    FACTION_NAGA.AddQuest(chapterOne);
    FACTION_NAGA.AddQuest(chapterTwo);
    FACTION_NAGA.AddQuest(chapterThree);

    EXILE_PATH = QuestExilePath.create();
    MADNESS_PATH = QuestMadnessPath.create();
    REDEMPTION_PATH = QuestRedemptionPath.create();
    //set ALLIANCE_NAGA = QuestJoinAllianceNaga.create()
    CONQUER_BLACK_TEMPLE = QuestBlackTemple.create();
    KILL_FROZEN_THRONE = QuestFrozenThrone.create();

    chapterTwo.Progress = QUEST_PROGRESS_UNDISCOVERED;
    chapterThree.Progress = QUEST_PROGRESS_UNDISCOVERED;

    FACTION_NAGA.StartingQuest = chapterOne;
  }

}
