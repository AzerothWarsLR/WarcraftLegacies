library QuestLakeshire requires QuestData, StormwindSetup, QuestItemKillUnit

  struct QuestLakeshire extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "Lakeshire has been liberated, and its military is now free to assist the " + this.Holder.Team.Name + "."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Control of all units in Lakeshire"
    endmethod

    private method GrantLakeshire takes player whichPlayer returns nothing
      local group tempGroup = CreateGroup()
      local unit u

      //Transfer all Neutral Passive units in Lakeshire
      call GroupEnumUnitsInRect(tempGroup, gg_rct_LakeshireUnlock, null)
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
      call this.GrantLakeshire(Player(PLAYER_NEUTRAL_AGGRESSIVE))
    endmethod

    private method OnComplete takes nothing returns nothing
      call this.GrantLakeshire(this.Holder.Player)
    endmethod

    private method OnAdd takes nothing returns nothing
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Marauding Ogres", "The town of Lakeshire is invaded by Ogres, wipe them out!", "ReplaceableTextures\\CommandButtons\\BTNOgreLord.blp")
      call this.AddQuestItem(QuestItemKillUnit.create(gg_unit_nogl_0621)) //Ogre Lord
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n011')))
      call this.AddQuestItem(QuestItemExpire.create(1427))
      call this.AddQuestItem(QuestItemSelfExists.create())
      return this
    endmethod
  endstruct

endlibrary