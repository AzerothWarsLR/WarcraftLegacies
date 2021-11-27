library IronforgeQuestSetup requires IronforgeSetup, QuestDarkIron, QuestGnomeregan, QuestWildhammer

  public function OnInit takes nothing returns nothing
    //Setup
    local QuestData newQuest = FACTION_IRONFORGE.AddQuest(QuestThelsamar.create())
    set FACTION_IRONFORGE.StartingQuest = newQuest
    //Early duel
    call FACTION_IRONFORGE.AddQuest(QuestDunMorogh.create())
    call FACTION_IRONFORGE.AddQuest(QuestDominion.create())
    call FACTION_IRONFORGE.AddQuest(QuestGnomeregan.create())
    call FACTION_IRONFORGE.AddQuest(QuestDarkIron.create())
    call FACTION_IRONFORGE.AddQuest(QuestWildhammer.create())
    //Misc
  endfunction

endlibrary