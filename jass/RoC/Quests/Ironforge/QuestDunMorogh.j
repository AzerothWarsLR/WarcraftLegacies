library QuestDunMorogh requires QuestData, ScarletSetup

  struct QuestDunMorogh extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "The Trolls have been defeated, Dun Morogh will join your cause."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Control of all units in Dun Morogh"
    endmethod

    private method GrantDunMorogh takes player whichPlayer returns nothing
      local group tempGroup = CreateGroup()
      local unit u

      //Transfer all Neutral Passive units in DunMorogh
      call GroupEnumUnitsInRect(tempGroup, gg_rct_DunmoroghAmbient2, null)
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
      call this.GrantDunMorogh(Player(PLAYER_NEUTRAL_AGGRESSIVE))
    endmethod

    private method OnComplete takes nothing returns nothing
      call this.GrantDunMorogh(this.Holder.Player)
    endmethod


    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Mountain Village", "A small troll skirmish is attacking Dun Morogh, push them back", "ReplaceableTextures\\CommandButtons\\BTNIceTrollShadowPriest.blp")
      call this.AddQuestItem(QuestItemKillUnit.create(gg_unit_nith_1625)) //Troll
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n014')))
      call this.AddQuestItem(QuestItemExpire.create(1435))
      call this.AddQuestItem(QuestItemSelfExists.create())
      return this
    endmethod
  endstruct

endlibrary