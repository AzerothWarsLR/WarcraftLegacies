library ScourgeQuestSetup requires ScourgeSetup, QuestSapphiron QuestCorruptArthas, QuestKelthuzad, QuestLichKingArthas, QuestPlague, QuestReanimateSylvanas

  public function OnInit takes nothing returns nothing
    //Setup
    set FACTION_SCOURGE.StartingQuest = FACTION_SCOURGE.AddQuest(QuestSpiderWar.create())
    call FACTION_SCOURGE.AddQuest(QuestPlague.create())
    call FACTION_SCOURGE.AddQuest(QuestSapphiron.create())
    //Early duel
    call FACTION_SCOURGE.AddQuest(QuestCorruptArthas.create())
    call FACTION_SCOURGE.AddQuest(QuestKelthuzad.create())
    call FACTION_SCOURGE.AddQuest(QuestNaxxramas.create())
    //Misc
    call FACTION_SCOURGE.AddQuest(QuestLichKingArthas.create())
  endfunction

endlibrary