library UnitsSpawnIfBlademasterIsAlive initializer OnInit

    globals
        private timer SpawnPeriodicTimer
        private trigger BlademasterDiesTrigger
        private timer SpawnDelayTimer

        private real SPAWN_INTERVAL = 85
        private real SPAWN_DELAY = 180 
    endglobals

    private function SpawnAndAttack takes integer unitTypeToSpawn returns nothing
        local unit spawnedUnit = CreateUnit(Player(21), unitTypeToSpawn, GetRectCenterX(gg_rct_KulAttack), GetRectCenterY(gg_rct_KulAttack), 0)
        call IssuePointOrder(spawnedUnit, "attack", GetRectCenterX(gg_rct_KulTarget), GetRectCenterY(gg_rct_KulTarget))
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
        if GetPlayerSlotState(Player(22)) == PLAYER_SLOT_STATE_PLAYING then
            call SpawnAndAttackMultipleUnits('ogru', 3)
            call SpawnAndAttackMultipleUnits('nftr', 1)
            call SpawnAndAttackMultipleUnits('u00V', 1)
            else 
            call DestroyTimer(SpawnPeriodicTimer)
            call DestroyTrigger(BlademasterDiesTrigger)
            call DestroyTimer(SpawnDelayTimer)
        endif
    endfunction

    private function OnBlademasterDies takes nothing returns nothing
        call DestroyTimer(SpawnPeriodicTimer)
        call DestroyTrigger(BlademasterDiesTrigger)
        call DestroyTimer(SpawnDelayTimer)
    endfunction

    private function OnTimeElapsed takes nothing returns nothing
        set SpawnPeriodicTimer = CreateTimer()
        call TimerStart(SpawnPeriodicTimer, SPAWN_INTERVAL, true, function OnPeriodic)
        call DestroyTimer(GetExpiredTimer())
    endfunction

    private function OnInit takes nothing returns nothing
        set BlademasterDiesTrigger = CreateTrigger()
        call TriggerRegisterUnitEvent(BlademasterDiesTrigger, gg_unit_o00G_1521, EVENT_UNIT_DEATH)
        call TriggerAddAction(BlademasterDiesTrigger, function OnBlademasterDies)
        
        set SpawnDelayTimer = CreateTimer()
        call TimerStart(SpawnDelayTimer, SPAWN_DELAY, false, function OnTimeElapsed)
    endfunction

endlibrary