library StormwindQuestSetup requires StormwindSetup, QuestHonorHold, QuestStromgarde, QuestKingdomOfManStormwind

  public function OnInit takes nothing returns nothing
    //Setup
    local QuestData newQuest = FACTION_STORMWIND.AddQuest(QuestDarkshire.create())
    set FACTION_STORMWIND.StartingQuest = newQuest
    //Early duel
    call FACTION_STORMWIND.AddQuest(QuestLakeshire.create())
    call FACTION_STORMWIND.AddQuest(QuestGoldshire.create())
    call FACTION_STORMWIND.AddQuest(QuestStormwindCity.create())
    call FACTION_STORMWIND.AddQuest(QuestNethergarde.create())
    //Misc
    call FACTION_STORMWIND.AddQuest(QuestStromgarde.create())
    call FACTION_STORMWIND.AddQuest(QuestKingdomOfManStormwind.create())
    call FACTION_STORMWIND.AddQuest(QuestHonorHold.create())
  endfunction

endlibrary