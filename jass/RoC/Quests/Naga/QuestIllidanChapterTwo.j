//Escapes Kalimdor, Find the Skull of Guldan
library QuestIllidanChapterTwo requires QuestData, QuestItemLegendReachRect, QuestItemLegendDead, LegendNaga, Artifact

  struct QuestIllidanChapterTwo extends QuestData

    private QuestData questToDiscover

    private method operator CompletionPopup takes nothing returns string
      return "Illidan has learned of the existence of the Skull of Gul'dan, hidden in Dalaran"
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Chapter Three: Dwellers from the Deep"
    endmethod

    private method OnComplete takes nothing returns nothing
      set LEGEND_ILLIDAN.UnitType = 'Eevi'
      set questToDiscover.Progress = QUEST_PROGRESS_INCOMPLETE
    endmethod

    public static method create takes QuestData questToDiscover returns thistype
      local thistype this = thistype.allocate("Chapter Two: The Skull of Gul'dan", "The mages of Dalaran are hiding a powerful artifact that will grant Illidan unlimited power, the Skull of Gul'dan.", "ReplaceableTextures\\CommandButtons\\BTNGuldanSkull.blp")
      call this.AddQuestItem(QuestItemLegendReachRect.create(LEGEND_ILLIDAN, gg_rct_IllidanBoat1, "the escape boat"))
      call this.AddQuestItem(QuestItemLegendReachRect.create(LEGEND_ILLIDAN, gg_rct_SkullOfGuldan, "the dungeons of Dalaran"))
      call this.AddQuestItem(QuestItemLegendHasArtifact.create(LEGEND_ILLIDAN, ARTIFACT_SKULLOFGULDAN))
      set this.questToDiscover = questToDiscover

      return this
    endmethod
  endstruct

endlibrary