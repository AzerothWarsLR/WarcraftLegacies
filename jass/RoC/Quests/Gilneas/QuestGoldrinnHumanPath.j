library QuestGoldrinnHumanPath requires QuestData, GilneasSetup

  globals
    private constant integer QUEST_RESEARCH_ID = 'R07U'   //This research is given when the quest is completed
  endglobals

  struct QuestGoldrinnHumanPath extends QuestData

    method operator Global takes nothing returns boolean
      return true
    endmethod
    
    private method operator CompletionPopup takes nothing returns string
      return "Goldrinn as joined Gilneas and they remain in the Alliance"
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Goldrinn will be trainable at the altar"
    endmethod

    private method OnComplete takes nothing returns nothing
      set GOLDRINNELVE_PATH.Progress = QUEST_PROGRESS_FAILED
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("The Twilight Grove", "To understand the plight of her people, Tess will go to the Shrine of Goldrinn in Duskwood to understand what it is to be a Worgen.", "ReplaceableTextures\\CommandButtons\\BTNWorgenHunger.blp")
      call this.AddQuestItem(QuestItemLegendReachRect.create(LEGEND_TESS, gg_rct_GoldrinnDuskwood, "Shrine of Goldrinn in Duskwood"))
      call this.AddQuestItem(QuestItemLegendHasArtifact.create(LEGEND_TESS, ARTIFACT_SCYTHEOFELUNE))
      set this.ResearchId = QUEST_RESEARCH_ID
      return this
    endmethod
  endstruct

endlibrary