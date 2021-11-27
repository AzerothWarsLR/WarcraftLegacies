library StormwindDies initializer OnInit requires StormwindSetup

  private function Dies takes nothing returns nothing
    call KillUnit( gg_unit_h055_0035 )
    call KillUnit( gg_unit_h053_1121 )
    call KillUnit( udg_HeadquartersORHall )
    call KillUnit( udg_SanctumORCathedral )
    call DestroyTrigger(GetTriggeringTrigger())
  endfunction

  private function OnInit takes nothing returns nothing
    local trigger trig = CreateTrigger()
    call TriggerRegisterUnitEvent(trig, gg_unit_h00X_0007, EVENT_UNIT_DEATH)
    call TriggerAddCondition(trig, Condition(function Dies))       
  endfunction    

endlibrary