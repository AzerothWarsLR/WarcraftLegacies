namespace AzerothWarsCSharp.Source.RoC.Mechanics.Quelthalas
{
    public class UnitsSpawnIfZulIsAlive{

    
        private timer SpawnPeriodicTimer;
        private trigger ZulDiesTrigger;
        private timer SpawnDelayTimer;

        private float SPAWN_INTERVAL = 85;
        private float SPAWN_DELAY = 180;
    

        private static void SpawnAndAttack(int unitTypeToSpawn ){
            unit spawnedUnit = CreateUnit(Player(21), unitTypeToSpawn, GetRectCenterX(gg_rct_TrollAttackSpawn), GetRectCenterY(gg_rct_TrollAttackSpawn), 0);
            IssuePointOrder(spawnedUnit, "attack", GetRectCenterX(gg_rct_TrollTarget), GetRectCenterY(gg_rct_TrollTarget));
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
            if (GetPlayerSlotState(Player(2)) == PLAYER_SLOT_STATE_PLAYING){
                SpawnAndAttackMultipleUnits(FourCC(nftr), 2);
                SpawnAndAttackMultipleUnits(FourCC(nfsp), 1);
            }else {
                DestroyTimer(SpawnPeriodicTimer);
                DestroyTrigger(ZulDiesTrigger);
                DestroyTimer(SpawnDelayTimer);
            }
        }

        private static void OnZulDies( ){
            DestroyTimer(SpawnPeriodicTimer);
            DestroyTrigger(ZulDiesTrigger);
            DestroyTimer(SpawnDelayTimer);
        }

        private static void OnTimeElapsed( ){
            SpawnPeriodicTimer = CreateTimer();
            TimerStart(SpawnPeriodicTimer, SPAWN_INTERVAL, true,  OnPeriodic);
            DestroyTimer(GetExpiredTimer());
        }

        private static void OnInit( ){
            ZulDiesTrigger = CreateTrigger();
            TriggerRegisterUnitEvent(ZulDiesTrigger, gg_unit_O00O_1933, EVENT_UNIT_DEATH);
            TriggerAddAction(ZulDiesTrigger,  OnZulDies);

            SpawnDelayTimer = CreateTimer();
            TimerStart(SpawnDelayTimer, SPAWN_DELAY, false,  OnTimeElapsed);
        }

    }
}
