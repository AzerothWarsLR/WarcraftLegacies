library QuestCataclysm requires QuestData, TwilightSetup

  globals
    private constant integer CATACLYSM_RESEARCH = 'R05E'
  endglobals

  struct QuestCataclysm extends QuestData

    method operator Global takes nothing returns boolean
      return true
    endmethod
    
    private method operator CompletionPopup takes nothing returns string
      return "Deathwing is here, Doomsday is at hand, the Cataclysm as begun!"
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Cultists all over the world join your cause actively, Deathwing as a super demihero and the 2 elemental ascendant heroes."
    endmethod

    private method OnComplete takes nothing returns nothing
      call SetPlayerTechResearched(this.Holder.Player, CATACLYSM_RESEARCH, 1)
      call PlayThematicMusicBJ( "war3mapImported\\TwilightTheme.mp3" )
      call SetPlayerTechResearched(FACTION_CTHUN.Player, 'R07D', 1)
      call IssueImmediateOrderBJ( gg_unit_h02U_2413, "unrobogoblin" )
    endmethod

    private method OnAdd takes nothing returns nothing
      call this.Holder.ModObjectLimit(CATACLYSM_RESEARCH, UNLIMITED)
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("The Cataclysm", "The Old God's will is finnicky, you are not privy to when their plan will be set in motion, but when it is, your cult will be ready to welcome it.", "ReplaceableTextures\\CommandButtons\\BTNDeathwing.blp")
      call this.AddQuestItem(QuestItemControlLegend.create(LEGEND_DEATHWING, false))
      return this
    endmethod
  endstruct

endlibrary