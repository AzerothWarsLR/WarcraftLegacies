library QuestZulfarrak requires LegendNeutral

  globals
    private constant integer GAHZRILLA_RESEARCH = 'R02F'
    private constant integer GAHZRILLA_ID = 'H06Q'
  endglobals

  struct QuestZulfarrak extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "Zul'farrak has fallen. The Sandfury trolls lend their might to the " + this.Holder.Team.Name + ", you can train Storm Wyrms and Gahz'rilla awakens from its slumber."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Control of Zul'farrak, enable to train Storm Wyrm and you can summon the hero Gahz'rilla from the Altar of Conquerors"
    endmethod

    private method OnComplete takes nothing returns nothing
      local unit u
      local group tempGroup
      set tempGroup = CreateGroup()
      call GroupEnumUnitsInRect(tempGroup, gg_rct_Zulfarrak, null)
      set u = FirstOfGroup(tempGroup)
      loop
      exitwhen u == null
        if GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE) or GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_AGGRESSIVE) then
          if IsUnitType(u, UNIT_TYPE_HERO) == true then
            call KillUnit(u)
          else
            call UnitRescue(u, this.Holder.Player)
          endif
        endif
        call GroupRemoveUnit(tempGroup, u)
        set u = FirstOfGroup(tempGroup)
      endloop   
      call DestroyGroup(tempGroup)
      call SetPlayerTechResearched(Holder.Player, GAHZRILLA_RESEARCH, 1)
    endmethod

    private method OnAdd takes nothing returns nothing
      call this.Holder.ModObjectLimit(GAHZRILLA_RESEARCH, UNLIMITED)
      call this.Holder.ModObjectLimit(GAHZRILLA_ID, 1)
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Fury of the Sands", "The Sandfury Trolls of Zul'farrak are openly hostile to visitors, but they share a common heritage with the Zandalari Trolls. An adequate display of force could bring them around.", "ReplaceableTextures\\CommandButtons\\BTNDarkTroll.blp")
      call this.AddQuestItem(QuestItemControlLegend.create(LEGEND_ZULFARRAK, false))
      return this
    endmethod
  endstruct

endlibrary