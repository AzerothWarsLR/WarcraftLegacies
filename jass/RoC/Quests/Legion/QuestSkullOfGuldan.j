library QuestSkullOfGuldan requires QuestData, Artifact, LegionSetup, QuestItemAnyUnitInRect, QuestItemEitherOf, QuestItemFactionDefeated, QuestItemLegendDead, GeneralHelpers

  struct QuestSkullOfGuldan extends QuestData
    private QuestItemAnyUnitInRect questItemAnyUnitInRect

    private method operator CompletionPopup takes nothing returns string
      return "The Skull of Gul'dan has been retrieved by " + GetHeroProperName(questItemAnyUnitInRect.TriggerUnit) + ". Its nefarious energies will fuel the Legion's operations on Azeroth."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "The Skull of Gul'dan"
    endmethod   

    private method OnComplete takes nothing returns nothing
      call ARTIFACT_SKULLOFGULDAN.setStatus(ARTIFACT_STATUS_GROUND)
      call UnitAddItemSafe(questItemAnyUnitInRect.TriggerUnit, ARTIFACT_SKULLOFGULDAN.item)
    endmethod

    private method OnFail takes nothing returns nothing
      call SetItemPosition(ARTIFACT_SKULLOFGULDAN.item, -11867, 22216.5)
      call ARTIFACT_SKULLOFGULDAN.setStatus(ARTIFACT_STATUS_GROUND)
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("The Skull of Gul'dan", "The Skull of the master warlock Gul'dan is protected by the Mages of Dalaran. It rightfully belongs to the Legion.", "ReplaceableTextures\\CommandButtons\\BTNGuldanSkull.blp")
      set this.questItemAnyUnitInRect = this.AddQuestItem(QuestItemAnyUnitInRect.create(gg_rct_DalaranDungeon, "Dalaran Dungeons", true))
      call this.AddQuestItem(QuestItemEitherOf.create(QuestItemLegendDead.create(LEGEND_ILLIDAN), QuestItemFactionDefeated.create(FACTION_NAGA)))
      call this.AddQuestItem(QuestItemSelfExists.create())
      return this
    endmethod
  endstruct

endlibrary