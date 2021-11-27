library QuestFelHordeKillIronforge requires QuestData, FelHordeSetup, QuestItemLegendDead, LegendIronforge

  globals
    private constant integer RESEARCH_ID = 'R011'
    private constant integer UNITTYPE_ID = 'nina'
    private constant integer BUILDING_ID = 'o030'
    private constant integer UNIT_LIMIT = 4
  endglobals

  struct QuestFelHordeKillIronforge extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "The Great Forge has been annihilated. The Fel Horde's peons immediately salvage its intact refineries and put them to purpose in the creation of Felsteel."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Learn to train " + I2S(UNIT_LIMIT) + " " + GetObjectName(UNITTYPE_ID) + "s from the " + GetObjectName(BUILDING_ID) + " and acquire Felsteel Plating"
    endmethod

    private method OnComplete takes nothing returns nothing
      call SetPlayerTechResearched(Holder.Player, RESEARCH_ID, 1)
    endmethod

    private method OnAdd takes nothing returns nothing
      call Holder.ModObjectLimit(RESEARCH_ID, UNLIMITED)
      call Holder.ModObjectLimit(UNITTYPE_ID, UNIT_LIMIT)
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Felsteel Refining", "The smiths of Ironforge have long been put to use crafting goods and war machinery. In the hands of the Fel Horde, they could be used to smelt and refine the ultimate metal: Felsteel.", "ReplaceableTextures\\CommandButtons\\BTNInfernalFlameCannon.blp")
      call this.AddQuestItem(QuestItemLegendDead.create(LEGEND_GREATFORGE))
      return this
    endmethod
  endstruct

endlibrary