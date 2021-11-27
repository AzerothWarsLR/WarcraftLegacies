library TrollQuestSetup requires TrollSetup

  public function OnInit takes nothing returns nothing

    set FACTION_TROLL.StartingQuest = FACTION_TROLL.AddQuest(QuestZandalar.create())
    call FACTION_TROLL.AddQuest(QuestGoldenFleet.create())
    call FACTION_TROLL.AddQuest(QuestZulfarrak.create())
    call FACTION_TROLL.AddQuest(QuestZulgurub.create())
    call FACTION_TROLL.AddQuest(QuestGundrak.create())  
    call FACTION_TROLL.AddQuest(QuestJinthaAlor.create())
    call FACTION_TROLL.AddQuest(QuestHakkar.create())

  endfunction

endlibrary