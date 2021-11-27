library QuestWesternExpansion requires LegendSentinels, Display, QuestItemLegendDead

  globals
    private constant integer QUEST_RESEARCH_ID = 'R07Y' 
  endglobals

  struct QuestWesternExpansion extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "The western shores are now clear of pesky elves, our business expansion can continue and our Zeppelins can fly safe."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Learn to train " + GetObjectName('h091') + "s"
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Western Expansion", "Feathermoon Stronghold and Auberdine give the Elves a grip on the western shore of Kalimdor. We need to destroy them to clear a way for our business expansion west!", "ReplaceableTextures\\CommandButtons\\BTNNightElfShipyard.blp")
      call this.AddQuestItem(QuestItemLegendDead.create(LEGEND_FEATHERMOON))
      call this.AddQuestItem(QuestItemLegendDead.create(LEGEND_AUBERDINE))
      return this
    endmethod
  endstruct

endlibrary