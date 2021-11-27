library QuestDarkIron requires QuestItemKillUnit, IronforgeSetup, LegendNeutral

  globals
    private constant integer HERO_ID = 'H03G'
    private constant integer RESEARCH_ID = 'R01A'
  endglobals

  struct QuestDarkIron extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "The peace talk were succesful, The Dark Iron will join the Dwarven Empire."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "You gain control of Shadowforge City and can train the hero Dagran Thaurassian from the Altar of Fortitude"
    endmethod

    private method OnComplete takes nothing returns nothing
      local group tempGroup = CreateGroup()
      local unit u          
      //Transfer all Neutral Passive units in region to Ironforge
      call GroupEnumUnitsInRect(tempGroup, gg_rct_Shadowforge_City, null)
      set u = FirstOfGroup(tempGroup)
      loop
      exitwhen u == null
        if GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE) then
          call UnitRescue(u, this.Holder.Player)
        endif
        call GroupRemoveUnit(tempGroup, u)
        set u = FirstOfGroup(tempGroup)
      endloop
      call DestroyGroup(tempGroup)
      set tempGroup = null
      call SetPlayerTechResearched(this.Holder.Player, RESEARCH_ID, 1)
    endmethod

    private method OnAdd takes nothing returns nothing
      call Holder.ModObjectLimit(RESEARCH_ID, UNLIMITED)
      call Holder.ModObjectLimit(HERO_ID, 1)
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Dark Iron Alliance", "The Dark Iron dwarves are renegades. Bring Magni to their capital to open negotiations for an alliance", "ReplaceableTextures\\CommandButtons\\BTNRPGDarkIron.blp")
      call this.AddQuestItem(QuestItemLegendInRect.create(LEGEND_MAGNI, gg_rct_Shadowforge_gate, "Shadowforge"))
      return this
    endmethod
  endstruct

endlibrary