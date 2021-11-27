library LegionQuestSetup requires LegionSetup, QuestDemonGateMonastery, QuestLegionCaptureSunwell, QuestLegionKillLordaeron, QuestSummonLegion

  public function OnInit takes nothing returns nothing
    //Early duel
    local QuestData newQuest = FACTION_LEGION.AddQuest(QuestEmbassy.create())
    set FACTION_LEGION.StartingQuest = newQuest
    call FACTION_LEGION.AddQuest(QuestLegionCaptureSunwell.create())
    call FACTION_LEGION.AddQuest(QuestLegionKillLordaeron.create())
    //Misc
    call FACTION_LEGION.AddQuest(QuestSummonLegion.create())
  endfunction

endlibrary