library QuestWildhammer requires QuestItemKillUnit, IronforgeSetup, LegendNeutral

  globals
    private constant integer HERO_ID = 'H028'
    private constant integer RESEARCH_ID = 'R01C'
  endglobals

  struct QuestWildhammer extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "Magni has spoken with Falstad Wildhammer and secured an alliance with the Wildhammer Clan."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "You gain control of Aerie Peak and you can train the hero Falstad Wildhammer from the Altar of Fortitude"
    endmethod

    private method OnComplete takes nothing returns nothing
      local group tempGroup = CreateGroup()
      local unit u

      //Remove pathing blockers obstructing Aerie Peak
      call RemoveDestructable( gg_dest_YTpc_7559 )
      call RemoveDestructable( gg_dest_YTpc_2065 )
      call RemoveDestructable( gg_dest_YTpc_2067 )
      call RemoveDestructable( gg_dest_YTpc_12037 )

      //Transfer all Neutral Passive units in region to Ironforge
      call GroupEnumUnitsInRect(tempGroup, gg_rct_Aerie_Peak, null)
      
      loop
        set u = FirstOfGroup(tempGroup)
        exitwhen u == null
        if GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE) then
          call UnitRescue(u, this.Holder.Player)
        endif
        call GroupRemoveUnit(tempGroup, u)
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
      local thistype this = thistype.allocate("Wildhammer Alliance", "The Wildhammer dwarves roam freely over the peaks of the Hinterlands. An audience with Magni himself might earn their cooperation.", "ReplaceableTextures\\CommandButtons\\BTNHeroGriffonWarrior.blp")
      call this.AddQuestItem(QuestItemLegendInRect.create(LEGEND_MAGNI, gg_rct_Aerie_Peak, "Aerie Peak"))
      return this
    endmethod
  endstruct

endlibrary