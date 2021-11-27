library EventKelthuzadDeath initializer OnInit requires LegendScourge

  //When Kel'thuzad (Necromancer) is permanently killed
  //Record his experience, and create Kel'thuzad (Ghost) as a replacement
  //This experience is given to Kel'thuzad (Lich) in QuestKelthuzadLich

  globals
    integer KelthuzadExp = 0
    private constant integer GHOST_ID = 'uktg'
  endglobals

  private function Dies takes nothing returns nothing
    if LEGEND_KELTHUZAD == GetTriggerLegend() and GetUnitTypeId(GetTriggerLegend().Unit) == UNITTYPE_KELTHUZAD_NECROMANCER then
      set KelthuzadExp = GetHeroXP(LEGEND_KELTHUZAD.Unit)
      set LEGEND_KELTHUZAD.UnitType = UNITTYPE_KELTHUZAD_GHOST
      set LEGEND_KELTHUZAD.PermaDies = false
      call ReviveHero(LEGEND_KELTHUZAD.Unit, GetRectCenterX(gg_rct_FTSummon), GetRectCenterY(gg_rct_FTSummon), false)
      call DestroyTrigger(GetTriggeringTrigger())         
    endif
  endfunction

  private function OnInit takes nothing returns nothing
    local trigger trig = CreateTrigger()
    call OnLegendPermaDeath.register(trig)
    call TriggerAddCondition(trig, Condition(function Dies))            
  endfunction

endlibrary