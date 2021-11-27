library QuestDruidsKillFrostwolf requires DruidsSetup, LegendFrostwolf, Display

  globals
    private constant integer RESEARCH_ID = 'R044'
    private constant integer ELEMENTAL_GUARDIAN_ID = 'e00X'
  endglobals

  struct QuestDruidsKillFrostwolf extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "The Frostwolves have been driven from Kalimdor. Their departure reveals the existence of a powerful nature spirit that now heeds the call of the Druids."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "The demihero " + GetObjectName(ELEMENTAL_GUARDIAN_ID)
    endmethod

    private method OnComplete takes nothing returns nothing
      call SetPlayerTechResearched(this.Holder.Player, RESEARCH_ID, 1)
      call DisplayUnitTypeAcquired(this.Holder.Player, ELEMENTAL_GUARDIAN_ID, "You can now train the Elemental Guardian from the Altar of Elders.")
    endmethod

    private method OnAdd takes nothing returns nothing
      call this.Holder.ModObjectLimit(ELEMENTAL_GUARDIAN_ID, 1)
      call this.Holder.ModObjectLimit(RESEARCH_ID, UNLIMITED)
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Natural Contest", "The Frostwolf Clan has arrived on the shores of Kalimdor. Though their respect of the wild spirits is to be admired, their presence cannot be tolerated.", "ReplaceableTextures\\CommandButtons\\BTNHeroTaurenChieftain.blp")
      call this.AddQuestItem(QuestItemLegendDead.create(LEGEND_THUNDERBLUFF))
      return this
    endmethod
  endstruct

endlibrary