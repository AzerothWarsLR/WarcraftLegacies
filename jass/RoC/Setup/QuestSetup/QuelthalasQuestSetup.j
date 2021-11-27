library QuelthalasQuestSetup requires QuelthalasSetup, QuestQueldanil, QuestTheBloodElves

  public function OnInit takes nothing returns nothing
    //Setup
    local QuestData newQuest = FACTION_QUELTHALAS.AddQuest(QuestSilvermoon.create())
    local QuestData tempestKeep = QuestTempestKeep.create()
    
    set FACTION_QUELTHALAS.StartingQuest = newQuest
    //Early duel
    call FACTION_QUELTHALAS.AddQuest(QuestTheBloodElves.create())
    call FACTION_QUELTHALAS.AddQuest(QuestQueldanil.create())

    call FACTION_QUELTHALAS.AddQuest(tempestKeep)
    set tempestKeep.Progress = QUEST_PROGRESS_UNDISCOVERED

    set SUMMON_KIL = QuestSummonKil.create()
    set GREAT_TREACHERY = QuestGreatTreachery.create()
    set STAY_LOYAL = QuestStayLoyal.create()
  endfunction

endlibrary