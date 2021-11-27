library QuestLumberMarket requires GoblinSetup, LegendDruids

  globals
    private constant integer QUEST_RESEARCH_ID = 'R07Z'   //This research is given when the quest is completed
  endglobals

  struct QuestLumberMarket extends QuestData

    private method operator CompletionPopup takes nothing returns string
      return "The World Tree is ours, our lumber supplies will never run out!"
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Shredders will gain cleaving attack and 500 hit points. You will gain 30000 lumber."
    endmethod

    private method OnComplete takes nothing returns nothing
      call AdjustPlayerStateBJ( 30000, this.Holder.Player, PLAYER_STATE_RESOURCE_LUMBER )
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Lumber Market Krash", "The World Tree would provide enough lumber to completly crash the lumber market, forcing our Shredders to specialise more on war.","ReplaceableTextures\\CommandButtons\\BTNJunkGolem.blp")
      call this.AddQuestItem(QuestItemControlLegend.create(LEGEND_NORDRASSIL, false))
      set this.ResearchId = QUEST_RESEARCH_ID
      return this
    endmethod
  endstruct

endlibrary