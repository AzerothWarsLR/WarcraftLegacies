library QuestSentinelsKillWarsong requires SentinelsSetup, LegendWarsong, Display

  globals
    private constant integer RESEARCH_ID = 'R007'
  endglobals

  struct QuestSentinelsKillWarsong extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "The Warsong presence on Kalimdor has been eliminated. The land has been protected from their misbegotten race."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Enable the Watcher Bastion to be built"
    endmethod

    private method OnComplete takes nothing returns nothing
      call SetPlayerTechResearched(Holder.Player, RESEARCH_ID, 1)
    endmethod

    private method OnAdd takes nothing returns nothing
      call Holder.ModObjectLimit(RESEARCH_ID, UNLIMITED)
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Green-skinned Brutes", "The Warsong Clan has arrived near Ashenvale and begun threatening the wilds. These invaders must be repelled.", "ReplaceableTextures\\CommandButtons\\BTNRaider.blp")
      call this.AddQuestItem(QuestItemLegendDead.create(LEGEND_STONEMAUL))
      return this
    endmethod
  endstruct

endlibrary