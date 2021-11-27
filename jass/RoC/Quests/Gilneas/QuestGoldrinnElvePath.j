library QuestGoldrinnElvePath requires QuestData, GilneasSetup

  globals
    private constant integer QUEST_RESEARCH_ID = 'R07U'   //This research is given when the quest is completed
  endglobals

  struct QuestGoldrinnElvePath extends QuestData

    method operator Global takes nothing returns boolean
      return true
    endmethod
    
    private method operator CompletionPopup takes nothing returns string
      return "Goldrinn as joined Gilneas and they have joined the Night Elves"
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Goldrinn will be trainable at the altar"
    endmethod

    private method OnComplete takes nothing returns nothing
      set GOLDRINNHUMAN_PATH.Progress = QUEST_PROGRESS_FAILED
      set this.Holder.Team = TEAM_NIGHT_ELVES
      call RescueNeutralUnitsInRect(gg_rct_DarnassusWorgen, this.Holder.Player)
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Shrine of the Wolf God", "To understand the plight of her people, Tess will go to the Night Elves to understand what it is to be a Worgen. She needs to reach the Shrine of Goldrinn in Mount Hyjal", "ReplaceableTextures\\CommandButtons\\BTNWorgenMoon.blp")
      call this.AddQuestItem(QuestItemLegendReachRect.create(LEGEND_TESS, gg_rct_GoldrinnHyjal, "Shrine of Goldrinn in Mount Hyjal"))
      call this.AddQuestItem(QuestItemLegendHasArtifact.create(LEGEND_TESS, ARTIFACT_SCYTHEOFELUNE))
      set this.ResearchId = QUEST_RESEARCH_ID
      return this
    endmethod
  endstruct

endlibrary