library QuestAwakenCthun requires QuestData, QuestItemChannelRect

  globals
    private constant integer QUEST_RESEARCH_ID = 'R06A'   //This research is given when the quest is completed
  endglobals

  struct QuestAwakenCthun extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "The Old God C'thun has awaken and you can train Wasps"
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Gain control of C'thun and enable you to train Wasps"
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("The Awakening of C'thun", "The Old God C'thun is still slumbering, Skeram will need to awaken him with an unholy ritual.", "ReplaceableTextures\\CommandButtons\\BTNCthunIcon.blp")
      call this.AddQuestItem(QuestItemChannelRect.create(gg_rct_CthunSummon, "C'thun", LEGEND_SKERAM, 15, 270))
      set this.ResearchId = QUEST_RESEARCH_ID
      return this
    endmethod
  endstruct

endlibrary