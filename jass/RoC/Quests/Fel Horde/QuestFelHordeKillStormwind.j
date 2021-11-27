library QuestFelHordeKillStormwind requires QuestData, FelHordeSetup, QuestItemLegendDead, LegendStormwind

  globals
    private constant integer RESEARCH_ID = 'R05Z'
    private constant integer UNITTYPE_ID = 'n086'
    private constant integer BUILDING_ID = 'o030'
    private constant integer UNIT_LIMIT = 6
  endglobals

  struct QuestFelHordeKillStormwind extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "Stormwind's annihilation has left behind the corpses of thousands of elite knights. As occurred during the Second War, these corpses have been filled with the souls of slain Shadow Council members, recreating the indominatable order of Death Knights."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Teron Gorefiend can be trained at the altar and learn to train " + I2S(UNIT_LIMIT) + " " + GetObjectName(UNITTYPE_ID) + "s from the " + GetObjectName(BUILDING_ID)
    endmethod

    private method OnComplete takes nothing returns nothing
      call SetPlayerTechResearched(Holder.Player, RESEARCH_ID, 1)
    endmethod

    private method OnAdd takes nothing returns nothing
      call Holder.ModObjectLimit(RESEARCH_ID, UNLIMITED)
      call Holder.ModObjectLimit(UNITTYPE_ID, UNIT_LIMIT)
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Those Who Came Before", "During the Second War, the souls of slain Shadow Council members were infused into the corpses of Stormwind knights to create the Death Knights. If Stormwind were to fall again, the unholy order could return.", "ReplaceableTextures\\CommandButtons\\BTNAcolyte.blp")
      call this.AddQuestItem(QuestItemLegendDead.create(LEGEND_STORMWINDKEEP))
      return this
    endmethod
  endstruct

endlibrary