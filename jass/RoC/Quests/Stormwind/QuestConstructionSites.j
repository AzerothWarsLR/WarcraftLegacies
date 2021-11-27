//Stormwind's Construction sites are enabled after a delay.
library QuestConstructionSites requires QuestData, StormwindSetup

  globals
    private constant integer RESEARCH_ID = 'R022'
  endglobals

  struct QuestConstructionSites extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "Stormwind's Construction Sites are now ready to be upgraded."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Your Construction Sites can be upgraded"
    endmethod

    private method OnComplete takes nothing returns nothing
      if GetLocalPlayer() == this.Holder.Player then
        call PingMinimap(GetUnitX(gg_unit_h053_1121), GetUnitY(gg_unit_h053_1121), 5)
        call PingMinimap(GetUnitX(gg_unit_h055_0035), GetUnitY(gg_unit_h055_0035), 5)
      endif
      call SetPlayerTechResearched(this.Holder.Player, RESEARCH_ID, 1)
    endmethod

    private method OnAdd takes nothing returns nothing
      call this.Holder.ModObjectLimit(RESEARCH_ID, UNLIMITED)
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Inevitable Progress", "Stormwind has not yet fully recovered from the ravaging it experienced during the Second War. Await reconstruction.", "ReplaceableTextures\\CommandButtons\\BTNGenericHumanBuilding.blp")
      call this.AddQuestItem(QuestItemTime.create(360))
      return this
    endmethod
  endstruct

endlibrary