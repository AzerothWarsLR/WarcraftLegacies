library QuestAstranaar requires QuestData, SentinelsSetup, GeneralHelpers

  struct QuestAstranaar extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "Astranaar has been relieved and has joined the Sentinels in their war effort"
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Control of all units in Astranaar Outpost and Darnassus"
    endmethod

    private method OnFail takes nothing returns nothing
      call RescueNeutralUnitsInRect(gg_rct_AstranaarUnlock, Player(PLAYER_NEUTRAL_AGGRESSIVE))
      call RescueNeutralUnitsInRect(gg_rct_TeldrassilUnlock1, Player(PLAYER_NEUTRAL_AGGRESSIVE))
      call RescueNeutralUnitsInRect(gg_rct_TeldrassilUnlock2, Player(PLAYER_NEUTRAL_AGGRESSIVE))
    endmethod

    private method OnComplete takes nothing returns nothing
      call RescueNeutralUnitsInRect(gg_rct_AstranaarUnlock, this.Holder.Player)
      call RescueNeutralUnitsInRect(gg_rct_TeldrassilUnlock1, this.Holder.Player)
      call RescueNeutralUnitsInRect(gg_rct_TeldrassilUnlock2, this.Holder.Player)
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Astranaar Stronghold", "Darkshore is under attack by some Murloc. We should deal with them swiftly and then make for the Astranaar Outpost. Clearing the Murlocs will also reestablish communication with Darnassus.", "ReplaceableTextures\\CommandButtons\\BTNMurloc.blp")
      call this.AddQuestItem(QuestItemLegendReachRect.create(LEGEND_TYRANDE, gg_rct_AstranaarUnlock, "Astranaar Outpost"))
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n02U')))
      call this.AddQuestItem(QuestItemUpgrade.create('n06P', 'n06J'))
      call this.AddQuestItem(QuestItemExpire.create(1430))
      call this.AddQuestItem(QuestItemSelfExists.create())
      return this
    endmethod
  endstruct

endlibrary