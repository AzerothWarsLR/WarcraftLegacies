library QuestFallenGuardian requires LegendDalaran, LegendNeutral, ControlPoint

  globals
    private constant integer RESEARCH_ID = 'R04K'
    private constant integer MEDIVH_ID = 'Haah'
  endglobals

  struct QuestFallenGuardian extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "Medivh's spirit has been cleansed of Sargeras' influence, allowing him to return to Azeroth for a time."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "You can summon Medivh from the Altar of Knowledge"
    endmethod

    private method OnAdd takes nothing returns nothing
      call Holder.ModObjectLimit(RESEARCH_ID, UNLIMITED)
      call Holder.ModObjectLimit(MEDIVH_ID, 1)
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("The Fallen Guardian", "Medivh's body was corrupted by Sargeras at conception. Now that he is dead, the secrets of the Tomb of Sargeras and Sargeras combined might allow the mages of Dalaran to cleanse his spirit.", "ReplaceableTextures\\CommandButtons\\BTNMedivh.blp")
      call this.AddQuestItem(QuestItemControlLegend.create(LEGEND_KARAZHAN, false))
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n00J')))
      set this.ResearchId = 'R04K'
      return this
    endmethod
  endstruct

endlibrary