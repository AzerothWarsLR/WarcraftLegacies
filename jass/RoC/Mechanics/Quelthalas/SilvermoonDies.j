library SilvermoonDies initializer OnInit requires LegendQuelthalas

  private function Dies takes nothing returns nothing
    call SetUnitInvulnerable(LEGEND_SUNWELL.Unit, false)
  endfunction

  private function OnInit takes nothing returns nothing
    local trigger trig = CreateTrigger()
    call TriggerRegisterUnitEvent(trig, LEGEND_SILVERMOON.Unit, EVENT_UNIT_DEATH)
    call TriggerAddCondition(trig, Condition(function Dies))       
  endfunction    

endlibrary