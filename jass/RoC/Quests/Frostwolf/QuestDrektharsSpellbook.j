library QuestDrektharsSpellbook requires QuestData, Artifact, FrostwolfSetup, LegendFrostwolf, LegendDruids, QuestItemControlLegend, QuestItemAnyUnitInRect, GeneralHelpers

  struct QuestDrektharsSpellbook extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "The World Tree, Nordrassil, has been captured by the forces of the Horde. Drek'thar has gifted Warchief Thrall his magical spellbook for this achievement."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Drek'thar's Spellbook"
    endmethod   

    private method OnComplete takes nothing returns nothing
      call ARTIFACT_DREKTHARSSPELLBOOK.setStatus(ARTIFACT_STATUS_GROUND)
      call UnitAddItemSafe(LEGEND_THRALL.Unit, ARTIFACT_DREKTHARSSPELLBOOK.item)
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Drekthar's Spellbook", "The savage Night Elves threaten the safety of the entire Horde. Capture their World Tree and bring Thrall to its roots.", "ReplaceableTextures\\CommandButtons\\BTNSorceressMaster.blp")
      call this.AddQuestItem(QuestItemControlLegend.create(LEGEND_NORDRASSIL, false))
      call this.AddQuestItem(QuestItemLegendInRect.create(LEGEND_THRALL, gg_rct_Drekthars_Spellbook, "Nordrassil"))
      return this
    endmethod
  endstruct
  
endlibrary