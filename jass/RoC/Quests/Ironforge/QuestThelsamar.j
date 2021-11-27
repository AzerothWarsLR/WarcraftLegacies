library QuestThelsamar requires QuestData, ScarletSetup

  struct QuestThelsamar extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "The Murlocs have been defeated, Thelsamar will join your cause."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Control of all units in Thelsamar"
    endmethod

    private method GrantThelsamar takes player whichPlayer returns nothing
      local group tempGroup = CreateGroup()
      local unit u

      //Transfer all Neutral Passive units in Thelsamar
      call GroupEnumUnitsInRect(tempGroup, gg_rct_ThelUnlock, null)
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
      call this.GrantThelsamar(Player(PLAYER_NEUTRAL_AGGRESSIVE))
    endmethod

    private method OnComplete takes nothing returns nothing
      call this.GrantThelsamar(this.Holder.Player)
    endmethod


    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Murloc Menace", "A vile group of Murloc is terrorizing Thelsamar, destroy them", "ReplaceableTextures\\CommandButtons\\BTNMurlocNightCrawler.blp")
      call this.AddQuestItem(QuestItemKillUnit.create(gg_unit_N089_1494)) //Murloc
      call this.AddQuestItem(QuestItemExpire.create(1435))
      call this.AddQuestItem(QuestItemSelfExists.create())
      return this
    endmethod
  endstruct

endlibrary