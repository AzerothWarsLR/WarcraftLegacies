library NagaQuestSetup requires NagaSetup, QuestIllidanChapterOne, QuestIllidanChapterTwo, QuestIllidanChapterThree, GlobalQuest

  public function OnInit takes nothing returns nothing
    //Early duel

    local QuestData chapterThree = QuestIllidanChapterThree.create()
    local QuestData chapterTwo = QuestIllidanChapterTwo.create(chapterThree)
    local QuestData chapterOne = QuestIllidanChapterOne.create(chapterTwo)
    call FACTION_NAGA.AddQuest(chapterOne)
    call FACTION_NAGA.AddQuest(chapterTwo)
    call FACTION_NAGA.AddQuest(chapterThree)

    set EXILE_PATH = QuestExilePath.create()
    set MADNESS_PATH = QuestMadnessPath.create()
    set REDEMPTION_PATH = QuestRedemptionPath.create()
    //set ALLIANCE_NAGA = QuestJoinAllianceNaga.create()
    set CONQUER_BLACK_TEMPLE = QuestBlackTemple.create()
    set KILL_FROZEN_THRONE = QuestFrozenThrone.create()

    set chapterTwo.Progress = QUEST_PROGRESS_UNDISCOVERED
    set chapterThree.Progress = QUEST_PROGRESS_UNDISCOVERED

    set FACTION_NAGA.StartingQuest = chapterOne
  endfunction

endlibrary