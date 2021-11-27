library QuestZeppelins requires LegendSentinels, Display

  globals
    private constant integer RESEARCH_ID = 'R058'
    private constant integer UNITTYPE_ID = 'nzep'
    private constant integer LIMIT_CHANGE = 2
  endglobals

  struct QuestZeppelins extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "The Sentinels have been slain. With their Hippogryphs no longer terrorizing the skies, the Horde can field its refurbished Zeppelins."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Learn to train " + GetObjectName(UNITTYPE_ID) + "s"
    endmethod

    private method OnAdd takes nothing returns nothing
      call this.Holder.ModObjectLimit(UNITTYPE_ID, LIMIT_CHANGE)
      call this.Holder.ModObjectLimit(RESEARCH_ID, UNLIMITED)
    endmethod

    private method OnComplete takes nothing returns nothing
      call SetPlayerTechResearched(this.Holder.Player, RESEARCH_ID, 1)
      call DisplayUnitTypeAcquired(this.Holder.Player, UNITTYPE_ID, "You can now train Zeppelins from the Goblin Laboratory.")
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("The Spirits of Ashenvale", "The Sentinels have laid claim over Kalimdor. As long as they survive, the Orcs will never be safe.", "ReplaceableTextures\\CommandButtons\\BTNGoblinZeppelin.blp")
      call this.AddQuestItem(QuestItemLegendDead.create(LEGEND_AUBERDINE))
      call this.AddQuestItem(QuestItemLegendDead.create(LEGEND_FEATHERMOON))
      return this
    endmethod
  endstruct

endlibrary