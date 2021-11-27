library CthunQuestSetup requires CthunSetup

  public function OnInit takes nothing returns nothing

    set FACTION_CTHUN.StartingQuest = FACTION_CTHUN.AddQuest(QuestTitanJailors.create())
    call FACTION_CTHUN.AddQuest(QuestAwakenCthun.create())
    call FACTION_CTHUN.AddQuest(QuestEndlessRanks.create())
    call FACTION_CTHUN.AddQuest(QuestGatesofAhnqiraj.create())
  endfunction

endlibrary