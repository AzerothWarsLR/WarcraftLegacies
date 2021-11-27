library CheatSkipCinematic initializer OnInit requires TestSafety

    private function Actions takes nothing returns nothing
      call CinematicModeBJ(false, GetPlayersAll())
      call DestroyTrigger(GetTriggeringTrigger())
    endfunction

    private function OnInit takes nothing returns nothing
      local trigger trig = CreateTrigger(  )
      local integer i = 0
      loop
      exitwhen i > MAX_PLAYERS
        call TriggerRegisterPlayerEventEndCinematic(trig, Player(i))
        set i = i + 1
      endloop   
      call TriggerAddCondition(trig, Condition(function CheatCondition))
      call TriggerAddAction( trig, function Actions )
    endfunction

endlibrary