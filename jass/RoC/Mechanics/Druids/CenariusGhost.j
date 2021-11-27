library CenariusGhost initializer OnInit requires LegendDruids

  private function Dies takes nothing returns nothing
    if LEGEND_CENARIUS == GetTriggerLegend() and GetUnitTypeId(GetTriggerLegend().Unit) == UNITTYPE_CENARIUS_ALIVE then
      set LEGEND_CENARIUS.UnitType = UNITTYPE_CENARIUS_GHOST
      set LEGEND_CENARIUS.PermaDies = false
      call LEGEND_CENARIUS.ClearUnitDependencies()
      call ReviveHero(LEGEND_CENARIUS.Unit, GetRectCenterX(gg_rct_Cenarius), GetRectCenterY(gg_rct_Cenarius), false)
      call DestroyTrigger(GetTriggeringTrigger())         
    endif
  endfunction

  private function OnInit takes nothing returns nothing
    local trigger trig = CreateTrigger()
    call OnLegendPermaDeath.register(trig)
    call TriggerAddCondition(trig, Condition(function Dies))        
    set LEGEND_CENARIUS.DeathMessage = "Cenarius, Demigod of the Night Elves, has fallen. His spirit lives on, a mere echo of his former self."
  endfunction  

endlibrary