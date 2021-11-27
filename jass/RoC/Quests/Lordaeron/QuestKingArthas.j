//Prince Arthas goes to the Frozen Throne after it's destroyed. He becomes King Arthas, gets the Crown of Lordaeron, and Terenas dies.
library QuestKingArthas requires QuestData, LordaeronSetup, LegendLordaeron, GeneralHelpers

  struct QuestKingArthas extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "With the Lich King eliminated, the Kingdom of Lordaeron is free of its greatest threat. King Terenas Menethil proudly abdicates in favor of his son."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Arthas gains 2000 experience and the Crown of Lordaeron, and he can no longer permanently die"
    endmethod

    private method OnComplete takes nothing returns nothing
      call BlzSetUnitName(LEGEND_ARTHAS.Unit, "King of Lordaeron")
      call BlzSetUnitName(gg_unit_nemi_0019, "King Emeritus Terenas Menethil")
      call RemoveUnit(gg_unit_nemi_0019)
      call AddHeroXP(LEGEND_ARTHAS.Unit, 2000, true)
      call UnitAddItemSafe(LEGEND_ARTHAS.Unit, ARTIFACT_CROWNLORDAERON.item)
      call LEGEND_ARTHAS.ClearUnitDependencies()
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Line of Succession", "Arthas Menethil is the one true heir of the Kingdom of Lordaeron. The only thing standing in the way of his coronation is the world-ending threat of the Scourge.", "ReplaceableTextures\\CommandButtons\\BTNArthas.blp")
      call this.AddQuestItem(QuestItemLegendAlive.create(LEGEND_CAPITALPALACE))
      call this.AddQuestItem(QuestItemControlLegend.create(LEGEND_ARTHAS, true))
      call this.AddQuestItem(QuestItemLegendDead.create(LEGEND_LICHKING))
      call this.AddQuestItem(QuestItemLegendInRect.create(LEGEND_ARTHAS, gg_rct_King_Arthas_crown, "King Terenas"))
      return this
    endmethod
  endstruct

endlibrary