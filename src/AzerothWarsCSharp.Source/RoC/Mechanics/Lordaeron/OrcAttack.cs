public class UnitsSpawnIfJubeiIsAlive{

    
        private timer SpawnPeriodicTimer;
        private trigger JubeiDiesTrigger;
        private timer SpawnDelayTimer;

        private float SPAWN_INTERVAL = 85;
        private float SPAWN_DELAY = 180;
    

    private static void SpawnAndAttack(int unitTypeToSpawn ){
        unit spawnedUnit = CreateUnit(Player(21), unitTypeToSpawn, GetRectCenterX(gg_rct_Lord2), GetRectCenterY(gg_rct_Lord2), 0);
        IssuePointOrder(spawnedUnit, "attack", GetRectCenterX(gg_rct_AndhoralTaxe), GetRectCenterY(gg_rct_AndhoralTaxe));
        spawnedUnit = null;
    }

    private static void SpawnAndAttackMultipleUnits(int unitTypeToSpawn, int unitCount ){
        int i = 0;
        while(true){
            if ( i == unitCount){ break; }
            SpawnAndAttack(unitTypeToSpawn);
            i = i + 1;
        }
    }

    private static void OnPeriodic( ){
        if (GetPlayerSlotState(Player(1)) == PLAYER_SLOT_STATE_PLAYING){
            SpawnAndAttackMultipleUnits(FourCC(o01F), 3);
            }else {
            DestroyTimer(SpawnPeriodicTimer);
            DestroyTrigger(JubeiDiesTrigger);
            DestroyTimer(SpawnDelayTimer);
        }
    }

    private static void OnJubeiDies( ){
        DestroyTimer(SpawnPeriodicTimer);
        DestroyTrigger(JubeiDiesTrigger);
        DestroyTimer(SpawnDelayTimer);
    }

    private static void OnTimeElapsed( ){
        SpawnPeriodicTimer = CreateTimer();
        TimerStart(SpawnPeriodicTimer, SPAWN_INTERVAL, true,  OnPeriodic);
        DestroyTimer(GetExpiredTimer());
    }

    private static void OnInit( ){
        JubeiDiesTrigger = CreateTrigger();
        TriggerRegisterUnitEvent(JubeiDiesTrigger, gg_unit_o00B_1316, EVENT_UNIT_DEATH);
        TriggerAddAction(JubeiDiesTrigger,  OnJubeiDies);

        SpawnDelayTimer = CreateTimer();
        TimerStart(SpawnDelayTimer, SPAWN_DELAY, false,  OnTimeElapsed);
    }

}
