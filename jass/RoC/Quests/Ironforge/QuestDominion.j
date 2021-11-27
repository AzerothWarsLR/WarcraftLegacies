library QuestDominion requires QuestData, IronforgeSetup

  globals
    private constant integer RESEARCH_ID = 'R043'   //This research is given when the quest is completed
  endglobals

  struct QuestDominion extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "The Dwarven Empire is re-united again, Ironforge is ready for war again."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Control of all units in Ironforge"
    endmethod

    private method GrantDominion takes player whichPlayer returns nothing
      local group tempGroup = CreateGroup()
      local unit u

      //Transfer all Neutral Passive units in Dominion
      call GroupEnumUnitsInRect(tempGroup, gg_rct_IronforgeAmbient, null)
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
      call this.GrantDominion(Player(PLAYER_NEUTRAL_AGGRESSIVE))
    endmethod

    private method OnComplete takes nothing returns nothing
      call this.GrantDominion(this.Holder.Player)
      if GetLocalPlayer() == this.Holder.Player then
        call PlayThematicMusicBJ( "war3mapImported\\DwarfTheme.mp3" )
      endif
    endmethod

    private method OnAdd takes nothing returns nothing
      call this.Holder.ModObjectLimit(RESEARCH_ID, 1)
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Dwarven Dominion", "The Dwarven Dominion must be established before Ironforge can join the war", "ReplaceableTextures\\CommandButtons\\BTNNorthrendCastle.blp")
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n017')))
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n014')))
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n013')))
      call this.AddQuestItem(QuestItemUpgrade.create('h07G', 'h07E'))
      call this.AddQuestItem(QuestItemExpire.create(1462))
      call this.AddQuestItem(QuestItemSelfExists.create())
      set this.ResearchId = RESEARCH_ID
      return this
    endmethod
  endstruct

endlibrary