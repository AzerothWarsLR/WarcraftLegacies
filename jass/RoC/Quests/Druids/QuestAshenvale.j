library QuestAshenvale requires QuestData, DruidsSetup

  globals
    private constant integer RESEARCH_ID = 'R06R'   //This research is given when the quest is completed
  endglobals

  struct QuestAshenvale extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "Ashenvale is under control and Cenarius can now be awaken"
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Control of all units in Ashenvale and make Cenarius trainable at the Altar"
    endmethod

    private method GrantAshenvale takes player whichPlayer returns nothing
      local group tempGroup = CreateGroup()
      local unit u

      //Transfer all Neutral Passive units in Ashenvale
      call GroupEnumUnitsInRect(tempGroup, gg_rct_AshenvaleUnlock, null)
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
      call this.GrantAshenvale(Player(PLAYER_NEUTRAL_AGGRESSIVE))
    endmethod

    private method OnComplete takes nothing returns nothing
      call this.GrantAshenvale(this.Holder.Player)
      if GetLocalPlayer() == this.Holder.Player then
        call PlayThematicMusicBJ( "war3mapImported\\DruidTheme.mp3" )
      endif
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("The Spirits of Ashenvale", "The forest needs healing. Regain control of it to summon it's Guardian, the Demigod Cenarius", "ReplaceableTextures\\CommandButtons\\BTNKeeperC.blp")
      call this.AddQuestItem(QuestItemLegendReachRect.create(LEGEND_MALFURION, gg_rct_AshenvaleUnlock, "Ashenvale"))
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n07C')))
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n01Q')))
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n08U')))
      call this.AddQuestItem(QuestItemUpgrade.create('etoa', 'etol'))
      call this.AddQuestItem(QuestItemExpire.create(1440))
      call this.AddQuestItem(QuestItemSelfExists.create())
      set this.ResearchId = RESEARCH_ID
      return this
    endmethod
  endstruct

endlibrary