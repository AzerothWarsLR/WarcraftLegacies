library UnitsSpawnIfJubeiIsAlive initializer OnInit

    globals
        private timer SpawnPeriodicTimer
        private trigger JubeiDiesTrigger
        private timer SpawnDelayTimer

        private real SPAWN_INTERVAL = 85
        private real SPAWN_DELAY = 180 
    endglobals

    private function SpawnAndAttack takes integer unitTypeToSpawn returns nothing
        local unit spawnedUnit = CreateUnit(Player(21), unitTypeToSpawn, GetRectCenterX(gg_rct_Lord2), GetRectCenterY(gg_rct_Lord2), 0)
        call IssuePointOrder(spawnedUnit, "attack", GetRectCenterX(gg_rct_Lord3), GetRectCenterY(gg_rct_Lord3))
        set spawnedUnit = null
    endfunction

    private function SpawnAndAttackMultipleUnits takes integer unitTypeToSpawn, integer unitCount returns nothing
        local integer i = 0
        loop
            exitwhen i == unitCount
            call SpawnAndAttack(unitTypeToSpawn)
            set i = i + 1
        endloop
    endfunction

    private function OnPeriodic takes nothing returns nothing
        if GetPlayerSlotState(Player(1)) == PLAYER_SLOT_STATE_PLAYING then
            call SpawnAndAttackMultipleUnits('o01F', 3)
            else
            call DestroyTimer(SpawnPeriodicTimer)
            call DestroyTrigger(JubeiDiesTrigger)
            call DestroyTimer(SpawnDelayTimer)
        endif
    endfunction

    private function OnJubeiDies takes nothing returns nothing
        call DestroyTimer(SpawnPeriodicTimer)
        call DestroyTrigger(JubeiDiesTrigger)
        call DestroyTimer(SpawnDelayTimer)
    endfunction

    private function OnTimeElapsed takes nothing returns nothing
        set SpawnPeriodicTimer = CreateTimer()
        call TimerStart(SpawnPeriodicTimer, SPAWN_INTERVAL, true, function OnPeriodic)
        call DestroyTimer(GetExpiredTimer())
    endfunction

    private function OnInit takes nothing returns nothing
        set JubeiDiesTrigger = CreateTrigger()
        call TriggerRegisterUnitEvent(JubeiDiesTrigger, gg_unit_o00B_1316, EVENT_UNIT_DEATH)
        call TriggerAddAction(JubeiDiesTrigger, function OnJubeiDies)
        
        set SpawnDelayTimer = CreateTimer()
        call TimerStart(SpawnDelayTimer, SPAWN_DELAY, false, function OnTimeElapsed)
    endfunction

endlibrary