library DruidsQuestSetup requires DruidsSetup, QuestAndrassil, QuestDruidsKillFrostwolf, QuestDruidsKillWarsong, QuestMalfurionAwakens

  public function OnInit takes nothing returns nothing
    //Setup
    local QuestData newQuest = FACTION_DRUIDS.AddQuest(QuestMalfurionAwakens.create())
    set FACTION_DRUIDS.StartingQuest = newQuest
    //Early duel
    call FACTION_DRUIDS.AddQuest(QuestAshenvale.create())
    call FACTION_DRUIDS.AddQuest(QuestDruidsKillFrostwolf.create())
    call FACTION_DRUIDS.AddQuest(QuestDruidsKillWarsong.create())
    //Misc
    call FACTION_DRUIDS.AddQuest(QuestAndrassil.create())
    call FACTION_DRUIDS.AddQuest(QuestTortolla.create())
    //call FACTION_DRUIDS.AddQuest(QuestJoinAllianceDruid.create())
  endfunction

endlibrary