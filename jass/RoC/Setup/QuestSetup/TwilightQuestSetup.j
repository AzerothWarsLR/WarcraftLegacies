library TwilightQuestSetup requires TwilightSetup

  public function OnInit takes nothing returns nothing

    set FACTION_TWILIGHT.StartingQuest = FACTION_TWILIGHT.AddQuest(QuestDragonmawPort.create())
    call FACTION_TWILIGHT.AddQuest(QuestGrimBatol.create())
    call FACTION_TWILIGHT.AddQuest(QuestSpreadTheWord.create())
    call FACTION_TWILIGHT.AddQuest(QuestThunderfury.create())
    call FACTION_TWILIGHT.AddQuest(QuestFeludius.create())
    call FACTION_TWILIGHT.AddQuest(QuestIgnacious.create())
    call FACTION_TWILIGHT.AddQuest(QuestCataclysm.create())

  endfunction

endlibrary