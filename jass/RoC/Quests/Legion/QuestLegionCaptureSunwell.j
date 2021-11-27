library QuestLegionCaptureSunwell requires QuestData, LegionSetup, LegendQuelthalas

  globals
    private constant integer RESEARCH_ID = 'R054'
  endglobals

  struct QuestLegionCaptureSunwell extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "The Sunwell has been captured by the Scourge. It now writhes with necromantic energy."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "A research improving your Dreadlords"
    endmethod

    private method OnComplete takes nothing returns nothing
      call SetPlayerTechResearched(this.Holder.Player, RESEARCH_ID, 1)
      call DisplayResearchAcquired(this.Holder.Player, RESEARCH_ID, 1)
    endmethod

    private method OnAdd takes nothing returns nothing
      call this.Holder.ModObjectLimit(RESEARCH_ID, UNLIMITED)
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Fall of Silvermoon", "The Sunwell is the source of the High Elves' immortality and magical prowess. Under control of the Scourge, it would be the source of immense necromantic power.", "ReplaceableTextures\\CommandButtons\\BTNOrbOfCorruption.blp")
      call this.AddQuestItem(QuestItemControlLegend.create(LEGEND_SUNWELL, false))
      return this
    endmethod
  endstruct

endlibrary