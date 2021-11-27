library QuestExplosiveEngineering requires QuestData

  globals
    private constant integer QUEST_RESEARCH_ID = 'R01F'   //This research is given when the quest is completed
  endglobals

  struct QuestExplosiveEngineering extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "Gazlowee is now trainable"
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Gazlowee is trainable at the altar"
    endmethod

    private method OnComplete takes nothing returns nothing
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Explosive Engineering", "The world shall hear the whispers of the Old God. Spread the visions of the end", "ReplaceableTextures\\CommandButtons\\BTNHeroTinker.blp")
      call this.AddQuestItem(QuestItemTrain.create('n0AQ','h04Z', 4))
      set this.ResearchId = QUEST_RESEARCH_ID
      return this
    endmethod
  endstruct

endlibrary