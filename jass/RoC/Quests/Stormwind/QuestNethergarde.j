library QuestNethergarde requires QuestItemKillUnit, IronforgeSetup, LegendNeutral

  struct QuestNethergarde extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "Varian has come to relieve the Nethergarde garrison."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "You gain control of the Nethergarde base"
    endmethod

    private method GrantNethergarde takes player whichPlayer returns nothing
      local group tempGroup = CreateGroup()
      local unit u

      //Transfer all Neutral Passive units in Nethergarde
      call GroupEnumUnitsInRect(tempGroup, gg_rct_NethergardeUnlock, null)
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
      call this.GrantNethergarde(Player(PLAYER_NEUTRAL_AGGRESSIVE))
    endmethod

    private method OnComplete takes nothing returns nothing
      call this.GrantNethergarde(this.Holder.Player)
      call FACTION_STORMWIND.ModObjectLimit('h03F',1)               //Reginald windsor
    endmethod

    private method OnAdd takes nothing returns nothing
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Nethergarde relief", "The nethergarde fort is holding down the Dark Portal, they will need to be reinforced soon!", "ReplaceableTextures\\CommandButtons\\BTNNobbyMansionBarracks.blp")
      call this.AddQuestItem(QuestItemLegendInRect.create(LEGEND_VARIAN, gg_rct_NethergardeUnlock, "Nethergarde"))
      call this.AddQuestItem(QuestItemExpire.create(1440))
      call this.AddQuestItem(QuestItemSelfExists.create())
      return this
    endmethod
  endstruct

endlibrary