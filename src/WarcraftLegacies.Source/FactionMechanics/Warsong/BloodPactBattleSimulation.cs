
using WCSharp.Shared.Data;
using WCSharp.Shared.Extensions;


namespace WarcraftLegacies.Source.FactionMechanics.Warsong
{
    public static class BloodPactBattleSimulation
    {
        private const int NeutralHostile = 24;
        private const int Player = 0;
        private const float MinHealthPercentage = 70f;
        private const float HealthRestorePercentage = 100f; 

        public static readonly group sentinelsGroup = CreateGroup();
        public static readonly group warsongGroup = CreateGroup();
        public static readonly group battleSimulationGroup = CreateGroup();

        private static readonly int[] SentinelsUnits =
        {
            UNIT_ESEN_HUNTRESS_SENTINELS,
            UNIT_ESEN_HUNTRESS_SENTINELS,
            UNIT_ESEN_HUNTRESS_SENTINELS,
            UNIT_ESEN_HUNTRESS_SENTINELS,
            UNIT_EARC_ARCHER_SENTINELS,
            UNIT_EARC_ARCHER_SENTINELS,
            UNIT_EARC_ARCHER_SENTINELS
        };

        private static readonly int[] WarsongUnits =
        {
            UNIT_OPGH_CORRUPTOR_OF_THE_WARSONG_CLAN_WARSONG_BLOODPACT,
            UNIT_O00P_CHAOS_WARSONG_GRUNT_WARSONG,
            UNIT_O00P_CHAOS_WARSONG_GRUNT_WARSONG,
            UNIT_O00P_CHAOS_WARSONG_GRUNT_WARSONG,
            UNIT_O00P_CHAOS_WARSONG_GRUNT_WARSONG,
            UNIT_O00P_CHAOS_WARSONG_GRUNT_WARSONG,
            UNIT_O00P_CHAOS_WARSONG_GRUNT_WARSONG
        };

        private static readonly int[] Playerunits =
          { UNIT_OEYE_SENTRY_WARD_FROSTWOLF_WITCH_DOCTOR };
        

        public static void StartSimulation()
        {
            Rectangle regionRect = Regions.BloodPactBattle;

            // Spawn Sentinels units
            foreach (var unitTypeId in SentinelsUnits)
            {
                try
                {
                    Point randomPoint = regionRect.GetRandomPoint();
                    unit spawnedUnit = SpawnSimulationUnit(NeutralHostile, unitTypeId, randomPoint);
                    GroupAddUnit(sentinelsGroup, spawnedUnit);
                    GroupAddUnit(battleSimulationGroup, spawnedUnit);
                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine($"Sentinel spawn error: {ex.Message}");
                }
            }

            // Spawn Warsong units
            foreach (var unitTypeId in WarsongUnits)
            {
                try
                {
                    Point randomPoint = regionRect.GetRandomPoint();
                    unit spawnedUnit = SpawnSimulationUnit(NeutralHostile, unitTypeId, randomPoint);
                    GroupAddUnit(warsongGroup, spawnedUnit);
                    GroupAddUnit(battleSimulationGroup, spawnedUnit);
                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine($"Warsong spawn error: {ex.Message}");
                }
            }
            
            // Spawn player units
            foreach (var unitTypeId in Playerunits)
            {
                try
                {
                    Point randomPoint = regionRect.GetRandomPoint();
                    unit spawnedUnit = SpawnSimulationUnit(Player, unitTypeId, randomPoint);
                    GroupAddUnit(battleSimulationGroup, spawnedUnit);
                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine($"Player unit spawn error: {ex.Message}");
                }
            }
            
            foreach (var sentinelUnit in sentinelsGroup.ToList())
            {
                var targetUnit = GetRandomUnitFromGroup(warsongGroup);
                if (targetUnit != null)
                {
                    IssueTargetOrder(sentinelUnit, "attack", targetUnit);
                }
            }
            
            foreach (var warsongUnit in warsongGroup.ToList())
            {
                var targetUnit = GetRandomUnitFromGroup(sentinelsGroup);
                if (targetUnit != null)
                {
                    IssueTargetOrder(warsongUnit, "attack", targetUnit);
                }
            }
          
            timer healthCheckTimer = CreateTimer();
            TimerStart(healthCheckTimer, 8f, true, CheckAndRestoreUnitHealth);
        }

        private static unit SpawnSimulationUnit(int ownerId, int unitTypeId, Point position)
        {
            var newUnit = CreateUnit(Player(ownerId), unitTypeId, position.X, position.Y, 0);
            SetUnitInvulnerable(newUnit, false);
            return newUnit;
        }

        private static unit GetRandomUnitFromGroup(group unitGroup)
        {
            var units = unitGroup.ToList();
            if (units.Count == 0)
                return null;
                
            int randomIndex = GetRandomInt(0, units.Count - 1);
            return units[randomIndex];
        }
        
        private static void CheckAndRestoreUnitHealth()
        {
            foreach (var unit in battleSimulationGroup.ToList())
            {
                if (GetWidgetLife(unit) <= 0.405f)
                    continue;

                float currentHpPercent = (GetWidgetLife(unit) / GetUnitState(unit, UNIT_STATE_MAX_LIFE)) * 100f;

                if (currentHpPercent <= MinHealthPercentage)
                {
                    float restoreAmount = (HealthRestorePercentage / 100f) * GetUnitState(unit, UNIT_STATE_MAX_LIFE);
                    SetWidgetLife(unit, restoreAmount);
                }
            }
        }
    }
}