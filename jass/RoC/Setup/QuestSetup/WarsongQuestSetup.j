library WarsongQuestSetup requires WarsongSetup, FrostwolfSetup, QuestChenStormstout, QuestCrossroads, QuestFountainOfBlood, QuestWarMachine, QuestWarsongHold, QuestWarsongKillDruids, QuestZulfarrak, QuestMoreWyverns

  public function OnInit takes nothing returns nothing
    //Setup
    set FACTION_WARSONG.StartingQuest = FACTION_WARSONG.AddQuest(QuestLumberQuota.create())
    call FACTION_WARSONG.AddQuest(QuestCrossroads.create())
    call FACTION_WARSONG.AddQuest(QuestChenStormstout.create())
    call FACTION_WARSONG.AddQuest(QuestFountainOfBlood.create())
    //Early duel
    call FACTION_WARSONG.AddQuest(QuestWarsongKillDruids.create())
    call FACTION_WARSONG.AddQuest(QuestMoreWyverns.create())
    //Misc
    call FACTION_WARSONG.AddQuest(QuestWarsongHold.create())

  endfunction

endlibrary