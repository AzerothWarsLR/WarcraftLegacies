library DalaranQuestSetup requires DalaranSetup, QuestBlueDragons, QuestCrystalGolem, QuestJainaSoulGem, QuestKarazhan, QuestNewGuardian, QuestTheramore, QuestFallenGuardian

  public function OnInit takes nothing returns nothing
    local QuestNewGuardian newGuardian = QuestNewGuardian.create()
    local QuestTheNexus theNexus = QuestTheNexus.create()
    local QuestCrystalGolem crystalGolem = QuestCrystalGolem.create()
    local QuestFallenGuardian fallenGuardian = QuestFallenGuardian.create()
    local QuestSouthshore questSouthshore = QuestSouthshore.create()

    call newGuardian.AddQuestItem(QuestItemDontCompleteQuest.create(theNexus))
    call crystalGolem.AddQuestItem(QuestItemDontCompleteQuest.create(theNexus))
    call fallenGuardian.AddQuestItem(QuestItemDontCompleteQuest.create(theNexus))
    call theNexus.AddQuestItem(QuestItemDontCompleteQuest.create(newGuardian))

    //Early duel
    call FACTION_DALARAN.AddQuest(questSouthshore)
    set FACTION_DALARAN.StartingQuest = questSouthshore
    call FACTION_DALARAN.AddQuest(QuestShadowfang.create())
    call FACTION_DALARAN.AddQuest(QuestDalaran.create())
    call FACTION_DALARAN.AddQuest(QuestJainaSoulGem.create())
    call FACTION_DALARAN.AddQuest(QuestBlueDragons.create())
    //Misc
    call FACTION_DALARAN.AddQuest(QuestKarazhan.create())
    call FACTION_DALARAN.AddQuest(QuestTheramore.create())

    call FACTION_DALARAN.AddQuest(crystalGolem)
    call FACTION_DALARAN.AddQuest(fallenGuardian)
    call FACTION_DALARAN.AddQuest(newGuardian)
    call FACTION_DALARAN.AddQuest(theNexus)
  endfunction

endlibrary