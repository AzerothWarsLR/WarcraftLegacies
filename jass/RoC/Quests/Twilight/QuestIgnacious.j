library QuestIgnacious requires QuestData, TwilightSetup, QuestItemLegendDead, LegendIronforge

  globals
    private constant integer RESEARCH_ID = 'R07Q'
  endglobals

  struct QuestIgnacious extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "The great Ragnaros has ascended one of our shamans."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "You can summon Ignacious from the Altar"
    endmethod


    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Gift of the Firelord", "Destroying the Dwarf great forge will please the Great Elemental Lord, Ragnaros.", "ReplaceableTextures\\CommandButtons\\BTNHeroAvatarOfFlame.blp")
      call this.AddQuestItem(QuestItemLegendDead.create(LEGEND_GREATFORGE))
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n0AA')))
      set this.ResearchId = RESEARCH_ID
      return this
    endmethod
  endstruct

endlibrary