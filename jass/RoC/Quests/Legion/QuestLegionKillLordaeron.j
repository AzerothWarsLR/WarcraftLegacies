library QuestLegionKillLordaeron requires LegionSetup, LegendLordaeron, LegendLegion, Display

  struct QuestLegionKillLordaeron extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "The Kingdom of Lordaeron has fallen, eliminating Azeroth's vanguard against the Legion."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Tichondrius gains 15 Strength, Agility and Intelligence"
    endmethod

    private method OnComplete takes nothing returns nothing
      call DisplayHeroReward(LEGEND_TICHONDRIUS.Unit, 15, 15, 15, 0)
      call AddHeroAttributes(LEGEND_TICHONDRIUS.Unit, 15, 15, 15)
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Token Resistance", "The Kingdom of Lordaeron must be eliminated to pave the way for the Legion's arrival.", "ReplaceableTextures\\CommandButtons\\BTNTichondrius.blp")
      call this.AddQuestItem(QuestItemLegendDead.create(LEGEND_CAPITALPALACE))
      call this.AddQuestItem(QuestItemLegendDead.create(LEGEND_STRATHOLME))
      call this.AddQuestItem(QuestItemLegendDead.create(LEGEND_TYRSHAND))
      return this
    endmethod
  endstruct

endlibrary