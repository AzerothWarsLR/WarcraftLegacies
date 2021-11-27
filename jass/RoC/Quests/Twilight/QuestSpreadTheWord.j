library QuestSpreadTheWord requires QuestData

  globals
    private constant integer QUEST_RESEARCH_ID = 'R05F'   //This research is given when the quest is completed
  endglobals

  struct QuestSpreadTheWord extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "The high priestess Azil is now trainable"
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "The high priestess Azil is trainable at the altar"
    endmethod

    private method OnComplete takes nothing returns nothing
    endmethod

    private method OnAdd takes nothing returns nothing
      call this.Holder.ModObjectLimit(QUEST_RESEARCH_ID, 1)
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Spread the Whispers of the Old God", "The world shall hear the whispers of the Old God. Spread the visions of the end", "ReplaceableTextures\\CommandButtons\\BTNOldGodWhispers.blp")
      call this.AddQuestItem(QuestItemBuild.create('o03C', 1))
      call this.AddQuestItem(QuestItemTrain.create('obot','o03I', 3))
      set this.ResearchId = QUEST_RESEARCH_ID
      return this
    endmethod
  endstruct

endlibrary