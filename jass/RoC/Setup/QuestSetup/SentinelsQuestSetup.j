library SentinelsQuestSetup requires SentinelsSetup, QuestSentinelsKillFrostwolf, QuestSentinelsKillWarsong, QuestVaultoftheWardens, QuestScepterOfTheQueen, QuestFeathermoon, QuestAstranaar

  public function OnInit takes nothing returns nothing
    //Early duel
    set FACTION_SENTINELS.StartingQuest = FACTION_SENTINELS.AddQuest(QuestAstranaar.create())
    call FACTION_SENTINELS.AddQuest(QuestFeathermoon.create())
    call FACTION_SENTINELS.AddQuest(QuestSentinelsKillWarsong.create())
    call FACTION_SENTINELS.AddQuest(QuestSentinelsKillFrostwolf.create())
    call FACTION_SENTINELS.AddQuest(QuestMaievOutland.create())
    call FACTION_SENTINELS.AddQuest(QuestScepterOfTheQueenSentinels.create())
    //Misc
    call FACTION_SENTINELS.AddQuest(QuestVaultoftheWardens.create())
    //call FACTION_SENTINELS.AddQuest(QuestJoinAllianceSentinel.create())
  endfunction

endlibrary