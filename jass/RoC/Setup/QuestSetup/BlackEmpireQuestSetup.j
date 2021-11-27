library BlackEmpireQuestSetup requires BlackEmpireSetup

  public function OnInit takes nothing returns nothing    
    set FACTION_BLACKEMPIRE.StartingQuest = FACTION_BLACKEMPIRE.AddQuest(QuestFirstObelisk.create())
    call FACTION_BLACKEMPIRE.AddQuest(QuestSecondObelisk.create())
    call FACTION_BLACKEMPIRE.AddQuest(QuestThirdObelisk.create())
    call FACTION_BLACKEMPIRE.AddQuest(QuestDragonSoul.create())
    call FACTION_BLACKEMPIRE.AddQuest(QuestYoggSaron.create())
  endfunction

endlibrary