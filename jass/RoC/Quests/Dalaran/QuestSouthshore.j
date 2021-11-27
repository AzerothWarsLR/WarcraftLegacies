library QuestSouthshore requires QuestData, DalaranSetup

  struct QuestSouthshore extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "The Murlocs have been defeated, Southshore is safe."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Control of all units in Southshore"
    endmethod

    private method GrantSouthshore takes player whichPlayer returns nothing
      local group tempGroup = CreateGroup()
      local unit u

      //Transfer all Neutral Passive units in Southshore
      call GroupEnumUnitsInRect(tempGroup, gg_rct_SouthshoreUnlock, null)
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
      call this.GrantSouthshore(Player(PLAYER_NEUTRAL_AGGRESSIVE))
    endmethod

    private method OnComplete takes nothing returns nothing
      call this.GrantSouthshore(this.Holder.Player)
    endmethod


    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Murloc Troubles", "A small murloc skirmish is attacking Southshore, push them back", "ReplaceableTextures\\CommandButtons\\BTNMurloc.blp")
      call this.AddQuestItem(QuestItemKillUnit.create(gg_unit_nmrm_0204)) //Murloc
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n08M')))
      call this.AddQuestItem(QuestItemExpire.create(1135))
      call this.AddQuestItem(QuestItemSelfExists.create())
      return this
    endmethod
  endstruct

endlibrary