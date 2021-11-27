library UnitsSpawnIfZulIsAlive initializer OnInit

    globals
        private timer SpawnPeriodicTimer
        private trigger ZulDiesTrigger
        private timer SpawnDelayTimer

        private real SPAWN_INTERVAL = 85
        private real SPAWN_DELAY = 180 
    endglobals

    private function SpawnAndAttack takes integer unitTypeToSpawn returns nothing
        local unit spawnedUnit = CreateUnit(Player(21), unitTypeToSpawn, GetRectCenterX(gg_rct_TrollAttackSpawn), GetRectCenterY(gg_rct_TrollAttackSpawn), 0)
        call IssuePointOrder(spawnedUnit, "attack", GetRectCenterX(gg_rct_TrollTarget), GetRectCenterY(gg_rct_TrollTarget))
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
        if GetPlayerSlotState(Player(2)) == PLAYER_SLOT_STATE_PLAYING then
          call SpawnAndAttackMultipleUnits('nftr', 2)
          call SpawnAndAttackMultipleUnits('nfsp', 1)
          else 
          call DestroyTimer(SpawnPeriodicTimer)
          call DestroyTrigger(ZulDiesTrigger)
          call DestroyTimer(SpawnDelayTimer)
        endif
    endfunction

    private function OnZulDies takes nothing returns nothing
        call DestroyTimer(SpawnPeriodicTimer)
        call DestroyTrigger(ZulDiesTrigger)
        call DestroyTimer(SpawnDelayTimer)
    endfunction

    private function OnTimeElapsed takes nothing returns nothing
        set SpawnPeriodicTimer = CreateTimer()
        call TimerStart(SpawnPeriodicTimer, SPAWN_INTERVAL, true, function OnPeriodic)
        call DestroyTimer(GetExpiredTimer())
    endfunction

    private function OnInit takes nothing returns nothing
        set ZulDiesTrigger = CreateTrigger()
        call TriggerRegisterUnitEvent(ZulDiesTrigger, gg_unit_O00O_1933, EVENT_UNIT_DEATH)
        call TriggerAddAction(ZulDiesTrigger, function OnZulDies)
        
        set SpawnDelayTimer = CreateTimer()
        call TimerStart(SpawnDelayTimer, SPAWN_DELAY, false, function OnTimeElapsed)
    endfunction

endlibrary