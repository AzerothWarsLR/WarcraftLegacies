library QuestSafeSea requires QuestData, KultirasSetup

  globals 
    private constant integer QUEST_RESEARCH_ID = 'R06T'   //This research is given when the quest is completed
  endglobals

  struct QuestSafeSea extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "With the Sea's now secure, the Ember Order can be reformed and Lucille Waycrest is trainable"
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "The Order of Embers is reborn and Lucille Waycrest is trainable"
    endmethod

    private method OnComplete takes nothing returns nothing

    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Safe Sea Decree", "The sea's must be secured and the Kul'tiras navy must be returned to it's once former glory!", "ReplaceableTextures\\CommandButtons\\BTNKulTirasDreadnought.blp")
      call this.AddQuestItem(QuestItemTrain.create('hdes','hshy', 2))
      call this.AddQuestItem(QuestItemTrain.create('h04J','hshy', 1))
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n01W')))
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n07L')))
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n08Q')))
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n09K')))
      set this.ResearchId = QUEST_RESEARCH_ID
      return this
    endmethod
  endstruct

endlibrary