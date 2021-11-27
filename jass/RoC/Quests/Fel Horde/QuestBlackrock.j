library QuestBlackrock requires QuestData, QuestItemKillUnit

  globals
    private constant integer QUEST_RESEARCH_ID = 'R03C'
  endglobals

  struct QuestBlackrock extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "Blackrock Citadel has been subjugated, and its military is now free to assist the " + this.Holder.Team.Name + "."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Control of all units in Blackrock Citadel and enable Dal'rend Blackhand to be trained at the altar"
    endmethod

    private method GrantBlackrock takes player whichPlayer returns nothing
      local group tempGroup = CreateGroup()
      local unit u

      //Transfer all Neutral Passive units in Blackrock
      call GroupEnumUnitsInRect(tempGroup, gg_rct_BlackrockUnlock, null)
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
      call this.GrantBlackrock(Player(PLAYER_NEUTRAL_AGGRESSIVE))
    endmethod

    private method OnComplete takes nothing returns nothing
      call SetPlayerTechResearched(Holder.Player, 'R03C', 1) 
      call this.GrantBlackrock(this.Holder.Player)
    endmethod

    private method OnAdd takes nothing returns nothing
      call this.Holder.ModObjectLimit(QUEST_RESEARCH_ID, 1)
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Blackrock Unification", "Make contact with the Blackrock clan and convince them to join Magtheridon", "ReplaceableTextures\\CommandButtons\\BTNBlackhand.blp")
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n00S')))
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n09Y')))
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n0A9')))
      call this.AddQuestItem(QuestItemExpire.create(1451))
      call this.AddQuestItem(QuestItemSelfExists.create())
      return this
    endmethod
  endstruct

endlibrary