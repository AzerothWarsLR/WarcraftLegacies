library QuestGoldenFleet requires QuestData

  globals
    private constant integer QUEST_RESEARCH_ID = 'R06W'   //This research is given when the quest is completed
  endglobals

  struct QuestGoldenFleet extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "Rastakhan is now trainable and Direhorn are available"
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Rastakhan is trainable at the altar and Direhorns are trainable"
    endmethod

    private method OnComplete takes nothing returns nothing
    endmethod

    private method OnAdd takes nothing returns nothing
      call this.Holder.ModObjectLimit(QUEST_RESEARCH_ID, 1)
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("The Golden Fleet", "The King has ordered for the greatest armada in the world, the construction for the Golden Fleet has begun", "ReplaceableTextures\\CommandButtons\\BTNTrollConjurer.blp")
      call this.AddQuestItem(QuestItemTrain.create('o04W','o049', 5))
      set this.ResearchId = QUEST_RESEARCH_ID
      return this
    endmethod
  endstruct

endlibrary