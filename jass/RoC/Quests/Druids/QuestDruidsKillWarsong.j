library QuestDruidsKillWarsong requires DruidsSetup, LegendWarsong, Display

  globals
    private constant integer UNITTYPE_ID = 'e012' //Siege Ancient
    private constant integer RESEARCH_ID = 'R05A' //Research enabling Siege Ancient
  endglobals

  struct QuestDruidsKillWarsong extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "The Warsong presence on Kalimdor has been eliminated. The sacred lands are safe from their hatchets."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Learn to train " + GetObjectName(UNITTYPE_ID) + "s"
    endmethod

    private method OnComplete takes nothing returns nothing
      call SetPlayerTechResearched(this.Holder.Player, RESEARCH_ID, 1)
      call DisplayUnitTypeAcquired(this.Holder.Player, UNITTYPE_ID, "You can now train Siege Ancients at the Ancient of War.")
    endmethod

    private method OnAdd takes nothing returns nothing
      call this.Holder.ModObjectLimit(UNITTYPE_ID, 6) //Siege Ancient
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Enemies at the Gate", "Arriving from another planet and across the seas of Azeroth, the Orcs of the Warsong Clan have arrived to ravage the wilderness and consume its bounty. They must be stopped.", "ReplaceableTextures\\CommandButtons\\BTNHellScream.blp")
      call this.AddQuestItem(QuestItemLegendDead.create(LEGEND_STONEMAUL))
      return this
    endmethod
  endstruct

endlibrary