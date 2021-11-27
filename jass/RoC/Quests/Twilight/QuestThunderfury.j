library QuestThunderfury requires QuestData, Artifact, LegendTwilight, GeneralHelpers

  struct QuestThunderfury extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "Cho'gall has found the legendary sword, Thunderfury"
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "The legendary sword Thunderfury"
    endmethod

    private method OnComplete takes nothing returns nothing
      call UnitAddItemSafe(LEGEND_CHOGALL.Unit, ARTIFACT_THUNDERFURY.item) 
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Blessed Blade of the Windseeker", "The legendary sword, Thunderfury, has been lost somewhere in the Broken Isles, Cho'gall has seen it in a vision. It will be a great asset to the Old Gods", "ReplaceableTextures\\CommandButtons\\BTNThunderfury2.blp")
      call this.AddQuestItem(QuestItemLegendInRect.create(LEGEND_CHOGALL, gg_rct_Broken_Isles, "The Broken Isles"))
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n05Y')))
      return this
    endmethod
  endstruct

endlibrary