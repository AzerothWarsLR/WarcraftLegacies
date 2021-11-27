library GoblinQuestSetup requires GoblinSetup

  public function OnInit takes nothing returns nothing

    set FACTION_GOBLIN.StartingQuest = FACTION_GOBLIN.AddQuest(QuestBusinessExpansion.create())
    call FACTION_GOBLIN.AddQuest(QuestExplosiveEngineering.create())
    call FACTION_GOBLIN.AddQuest(QuestGadgetzan.create())
    call FACTION_GOBLIN.AddQuest(QuestWesternExpansion.create())
    call FACTION_GOBLIN.AddQuest(QuestLumberMarket.create())
    call FACTION_GOBLIN.AddQuest(QuestGoblinEmpire.create())

  endfunction

endlibrary