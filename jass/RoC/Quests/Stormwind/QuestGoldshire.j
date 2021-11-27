library QuestGoldshire requires QuestData, StormwindSetup

  struct QuestGoldshire extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "The Gnolls have been defeated, Goldshire is safe."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Control of all units in Goldshire"
    endmethod

    private method GrantGoldshire takes player whichPlayer returns nothing
      local group tempGroup = CreateGroup()
      local unit u

      //Transfer all Neutral Passive units in Goldshire
      call GroupEnumUnitsInRect(tempGroup, gg_rct_ElwinForestAmbient, null)
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
      call this.GrantGoldshire(Player(PLAYER_NEUTRAL_AGGRESSIVE))
    endmethod

    private method OnComplete takes nothing returns nothing
      call this.GrantGoldshire(this.Holder.Player)
    endmethod


    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("The Scourge of Elwynn", "Hogger and his pack have taken over Goldshire, clear them out!", "ReplaceableTextures\\CommandButtons\\BTNGnoll.blp")
      call this.AddQuestItem(QuestItemKillUnit.create(gg_unit_n021_2624)) //Hogger
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n00Z')))
      call this.AddQuestItem(QuestItemExpire.create(1335))
      call this.AddQuestItem(QuestItemSelfExists.create())
      return this
    endmethod
  endstruct

endlibrary