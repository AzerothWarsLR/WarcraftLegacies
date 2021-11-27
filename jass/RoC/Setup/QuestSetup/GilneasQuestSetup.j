library GilneasQuestSetup requires GilneasSetup, QuestIllidanChapterOne, QuestIllidanChapterTwo, QuestIllidanChapterThree

  public function OnInit takes nothing returns nothing
    //Early duel
    local QuestData ChapterOne = FACTION_GILNEAS.AddQuest(QuestGilneasChapterOne.create())
    local QuestData ChapterTwo = FACTION_GILNEAS.AddQuest(QuestGilneasChapterTwo.create())
    local QuestData ChapterThree = FACTION_GILNEAS.AddQuest(QuestGilneasChapterThree.create())
  
    set FACTION_GILNEAS.StartingQuest = ChapterOne

    set ChapterTwo.Progress = QUEST_PROGRESS_UNDISCOVERED
    set ChapterThree.Progress = QUEST_PROGRESS_UNDISCOVERED

    set GOLDRINNELVE_PATH = QuestGoldrinnElvePath.create()
    set GOLDRINNHUMAN_PATH = QuestGoldrinnHumanPath.create()

  endfunction

endlibrary