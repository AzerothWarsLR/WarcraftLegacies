library QuestFeathermoon requires QuestData, ScarletSetup

  globals
    private constant integer RESEARCH_ID = 'R06M'   //This research is given when the quest is completed
  endglobals

  struct QuestFeathermoon extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "Feathermoon Stronghold has been relieved and has joined the Sentinels in their war effort"
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Control of all units in Feathermoon Stronghold and make Shandris trainable at the Altar"
    endmethod

    private method GrantFeathermoon takes player whichPlayer returns nothing
      local group tempGroup = CreateGroup()
      local unit u

      //Transfer all Neutral Passive units in Feathermoon
      call GroupEnumUnitsInRect(tempGroup, gg_rct_FeathermoonUnlock, null)
      set u = FirstOfGroup(tempGroup)
      loop
      exitwhen u == null
        if GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE) then
          call UnitRescue(u, whichPlayer)
        endif
        call GroupRemoveUnit(tempGroup, u)
        set u = FirstOfGroup(tempGroup)
      endloop
      call DestroyGroup(tempGroup)
      set tempGroup = null      
    endmethod

    private method OnFail takes nothing returns nothing
      call this.GrantFeathermoon(Player(PLAYER_NEUTRAL_AGGRESSIVE))
    endmethod

    private method OnComplete takes nothing returns nothing
      call this.GrantFeathermoon(this.Holder.Player)
      if GetLocalPlayer() == this.Holder.Player then
        call PlayThematicMusicBJ( "war3mapImported\\SentinelTheme.mp3" )
      endif
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Feathermoon Stronghold", "Feathermoon Stronghold stood guard for ten thousand years, it is time to relieve the guards from their duty.", "ReplaceableTextures\\CommandButtons\\BTNBearDen.blp")
      call this.AddQuestItem(QuestItemLegendReachRect.create(LEGEND_TYRANDE, gg_rct_FeathermoonUnlock, "Feathermoon Stronghold"))
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n027')))
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n01R')))
      call this.AddQuestItem(QuestItemExpire.create(1485))
      call this.AddQuestItem(QuestItemSelfExists.create())
      set this.ResearchId = RESEARCH_ID
      return this
    endmethod
  endstruct

endlibrary