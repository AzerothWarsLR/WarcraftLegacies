library QuestTheNine requires QuestData, ForsakenSetup

  struct QuestTheNine extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "Enable up to 9 Val'kyr join their ranks."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Enable 9 Val'kyr to be raised"
    endmethod

    private method OnComplete takes nothing returns nothing
    call FACTION_FORSAKEN.ModObjectLimit('u01V', 9)           //Valyr
    endmethod


    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("The Nine", "Most of the Val'kyr are still in Northrend, under the influence of the Lich King, they need to join the Forsaken cause", "ReplaceableTextures\\CommandButtons\\BTNPaleValkyr.blp")
      call this.AddQuestItem(QuestItemControlLegend.create(LEGEND_SYLVANASV, false))
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n02J')))
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n03U')))
      call this.AddQuestItem(QuestItemLegendDead.create(LEGEND_LICHKING))
      call this.AddQuestItem(QuestItemSelfExists.create())
      return this
    endmethod
  endstruct

endlibrary