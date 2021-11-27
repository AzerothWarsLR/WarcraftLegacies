library QuestBlueDragons requires QuestItemControlLegend, LegendDalaran, Display

  globals
    private constant integer RESEARCH_ID = 'R00U'
    private constant integer DRAGON_ID = 'n0AC'
    private constant integer MANADAM_ID = 'R00N'
  endglobals

  struct QuestBlueDragons extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "The Nexus has been captured. The Blue Dragonflight fights for " + this.Holder.Name + "."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Learn to train Blue Dragons"
    endmethod

    private method OnComplete takes nothing returns nothing
      call SetPlayerTechResearched(Holder.Player, RESEARCH_ID, 1)
      call DisplayUnitTypeAcquired(Holder.Player, DRAGON_ID, "You can now train Blue Dragons from Military Quarters and the Nexus.")
    endmethod

    private method OnAdd takes nothing returns nothing
      call this.Holder.ModObjectLimit(DRAGON_ID, 6)
      call this.Holder.ModObjectLimit(MANADAM_ID, UNLIMITED)
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("The Blue Dragonflight", "The Blue Dragons of Northrend are the wardens of magic on Azeroth. They might be convinced to willingly join the mages of Dalaran.", "ReplaceableTextures\\CommandButtons\\BTNAzureDragon.blp")
      call this.AddQuestItem(QuestItemControlLegend.create(LEGEND_NEXUS, false))
      return this
    endmethod
  endstruct

endlibrary