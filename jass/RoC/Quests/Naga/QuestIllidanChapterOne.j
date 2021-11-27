//Illidan Goes to Aetheneum, Finds Immoltar and kills him
library QuestIllidanChapterOne requires QuestData, QuestItemLegendReachRect, QuestItemLegendDead, LegendNaga

  struct QuestIllidanChapterOne extends QuestData

    private QuestData questToDiscover

    private method operator CompletionPopup takes nothing returns string
      return "Illidan has learned of the existence of the Skull of Gul'dan, hidden in Dalaran"
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Chapter Two - The Skull of Gul'dan"
    endmethod

    private method OnComplete takes nothing returns nothing
    set questToDiscover.Progress = QUEST_PROGRESS_INCOMPLETE
    endmethod

    public static method create takes QuestData questToDiscover returns thistype
      local thistype this = thistype.allocate("Chapter One: The Aetheneum Secrets", "The hidden Aetheneum library holds many secrets, Illidan most uncover in order to gain the power he craves", "ReplaceableTextures\\CommandButtons\\BTNDoomlord.blp")
      call this.AddQuestItem(QuestItemLegendReachRect.create(LEGEND_ILLIDAN, gg_rct_Dire_Maul_Entrance, "Feralas"))
      call this.AddQuestItem(QuestItemLegendReachRect.create(LEGEND_ILLIDAN, gg_rct_AethneumLibraryEntrance, "the Aetheneum Library"))
      call this.AddQuestItem(QuestItemLegendReachRect.create(LEGEND_ILLIDAN, gg_rct_ImmolFight, "Immol'thar's Lair"))
      call this.AddQuestItem(QuestItemLegendDead.create(LEGEND_IMMOLTHAR))
      set this.questToDiscover = questToDiscover
      return this
    endmethod
  endstruct

endlibrary