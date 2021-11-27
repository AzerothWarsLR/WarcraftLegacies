library QuestAndrassil requires QuestData, ControlPoint, DruidsSetup

  globals
    private constant integer RESEARCH_ID = 'R002'
    private constant integer URSOC_ID = 'E00A'
  endglobals

  struct QuestAndrassil extends QuestData

    private method operator CompletionPopup takes nothing returns string
      return "With Northrend finally free of the Lich King's influence, the time is ripe to regrow Andrassil in the hope that it can help reclaim this barren land."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "A new capital at Grizzly Hills that can research a powerful upgrade for your Druids of the Claw, and you can train the hero Ursoc from the Altar of Elders"
    endmethod

    private method OnComplete takes nothing returns nothing
      call SetPlayerTechResearched(Holder.Player, RESEARCH_ID, 1)
      call CreateUnit(Holder.Player, 'n04F', GetRectCenterX(gg_rct_Andrassil), GetRectCenterY(gg_rct_Andrassil), 0)
    endmethod

    private method OnAdd takes nothing returns nothing
      call Holder.ModObjectLimit('R05X', UNLIMITED)
      call Holder.ModObjectLimit(URSOC_ID, 1)
      call Holder.ModObjectLimit(RESEARCH_ID, UNLIMITED)
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Crown of the Snow", "Long ago, Fandral Staghelm cut a sapling from Nordrassil and used it to grow Andrassil in Northrend. Without the blessing of the Aspects, it fell to the Old Gods' corruption. If Northrend were to be reclaimed, Andrassil's growth could begin anew.", "ReplaceableTextures\\CommandButtons\\BTNTreant.blp")
      call this.AddQuestItem(QuestItemLegendDead.create(LEGEND_LICHKING))
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n03U')))
      call this.AddQuestItem(QuestItemAnyUnitInRect.create(gg_rct_GrizzlyHills, "Grizzly Hills", true))
      return this
    endmethod
  endstruct

endlibrary