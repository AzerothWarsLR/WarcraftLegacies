library QuestSentinelsKillFrostwolf requires SentinelsSetup, LegendFrostwolf, Display

  globals
    private constant integer RESEARCH_ID = 'R052'
    private constant integer AMARA_ID = 'h03I'
  endglobals

  struct QuestSentinelsKillFrostwolf extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "The Frostwolves have been ousted from Kalimdor, along with their Tauren allies. They will not be missed."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "The demihero Amara and the hero Jarod"
    endmethod

    private method OnComplete takes nothing returns nothing
      call SetPlayerTechResearched(this.Holder.Player, RESEARCH_ID, 1)
      call DisplayUnitTypeAcquired(this.Holder.Player, AMARA_ID, "You can now revive Amara from the Altar of Elders.")
    endmethod

    private method OnAdd takes nothing returns nothing
      call this.Holder.ModObjectLimit(AMARA_ID, 1)
      call this.Holder.ModObjectLimit(RESEARCH_ID, UNLIMITED)
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Drive Them Back", "The Frostwolf Clan is beginning to seize a firm foothold within the Barrens and on the plains of Mulgore. They must be driven back.", "ReplaceableTextures\\CommandButtons\\BTNThrall.blp")
      call this.AddQuestItem(QuestItemLegendDead.create(LEGEND_THUNDERBLUFF))
      return this
    endmethod
  endstruct

endlibrary