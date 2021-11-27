library AllianceActive initializer OnInit requires Team

 private function Actions takes nothing returns nothing
    set AreAllianceActive = false
 endfunction

	private function OnInit takes nothing returns nothing
    local trigger trig = CreateTrigger(  )
    call TriggerRegisterTimerEventSingle( trig, 10.00 )
    call TriggerAddAction( trig, function Actions )
 endfunction

endlibrary