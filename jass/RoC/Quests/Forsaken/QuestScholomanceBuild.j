library QuestScholomanceBuild requires QuestData

  globals
    private constant integer QUEST_RESEARCH_ID = 'R04Z'   //This research is given when the quest is completed
  endglobals

  struct QuestScholomanceBuild extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "Putress is now trainable."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Putress is trainable at the altar"
    endmethod

    private method OnComplete takes nothing returns nothing
    endmethod

    private method OnAdd takes nothing returns nothing
      call this.Holder.ModObjectLimit(QUEST_RESEARCH_ID, 1)
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Secret Buildup", "The Scholomance is the secret staging ground for the invasion of Lordaeron, build your infrastructure and be ready for war.", "ReplaceableTextures\\CommandButtons\\BTNAffinityII.blp")
      call this.AddQuestItem(QuestItemBuild.create('u011', 2))
      call this.AddQuestItem(QuestItemBuild.create('h08C', 20))
      call this.AddQuestItem(QuestItemBuild.create('u014', 1))
      call this.AddQuestItem(QuestItemBuild.create('u01J', 2))
      call this.AddQuestItem(QuestItemUpgrade.create('h08B', 'h089'))
      set this.ResearchId = QUEST_RESEARCH_ID
      return this
    endmethod
  endstruct

endlibrary