library QuestRetakeSunwell requires QuestData, ForsakenSetup, LegendForsaken, LegendQuelthalas

  struct QuestRetakeSunwell extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "Sylvanas and all the Banshee Hall units gain 500 bonus hit points"
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Sylvanas and her Banshees will be empowered with 500 additional hitpoints each"
    endmethod

    private method OnComplete takes nothing returns nothing
      call SetPlayerTechResearched(Holder.Player, 'R07V', 1)
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Retaking the Sunwell", "Even in undeath, the Sunwell's energy call to the Forsaken banshees. Reclaim it to bolster their vitality", "ReplaceableTextures\\CommandButtons\\BTNGhost.blp")
      call this.AddQuestItem(QuestItemControlLegend.create(LEGEND_SUNWELL, false))
      call this.AddQuestItem(QuestItemControlLegend.create(LEGEND_NATHANOS, false))
      return this
    endmethod
  endstruct

endlibrary