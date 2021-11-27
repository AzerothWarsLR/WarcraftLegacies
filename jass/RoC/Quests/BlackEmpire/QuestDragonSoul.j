library QuestDragonSoul requires QuestData, GeneralHelpers

  globals
    private constant integer RESEARCH_ID = 'R07S'
  endglobals

  struct QuestDragonSoul extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "Yor'sahj can now be trained at the altar"
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "The hero Yor'sahj will join the Black Empire"
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Siege of Wyrmrest Temple", "Yor'sahj the Unsleeping's mission is to destroy the Wyrmrest temple, assist him and he will join the Black Empire", "ReplaceableTextures\\CommandButtons\\BTNHeroMastermind.blp")
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n02Q')))
      call this.AddQuestItem(QuestItemLegendDead.create(LEGEND_SARAGOSA))
      call this.AddQuestItem(QuestItemLegendDead.create(LEGEND_VAELASTRASZ))
      call this.AddQuestItem(QuestItemLegendDead.create(LEGEND_OCCULUS))
      set this.ResearchId = RESEARCH_ID
      return this
    endmethod
  endstruct

endlibrary