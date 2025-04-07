using WCSharp.Shared.Data;
using WCSharp.Shared.Extensions;


namespace WarcraftLegacies.Source.FactionMechanics.Warsong
{
    public static class BloodPactBattleSimulation
    {
        private const int PlayerSentinels = 19;
        private const int PlayerWarsong = 20;
        private const int Player = 0;
        private const float MinHealthPercentage = 70f;
        private const float HealthRestorePercentage = 100f; 

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
            UNIT_O00P_CHAOS_WARSONG_GRUNT_WARSONG,
        };

        private static readonly int[] Playerunits =
          { UNIT_OEYE_SENTRY_WARD_FROSTWOLF_WITCH_DOCTOR };
        

        public static void StartSimulation()
        {
            SetPlayersHostile(PlayerWarsong, PlayerSentinels, true);

            Rectangle regionRect = Regions.BloodPactBattle;
            Point midpoint = regionRect.Center;

            foreach (var unitTypeId in SentinelsUnits)
            {
                try
                {
                    Point randomPoint = regionRect.GetRandomPoint();
                    unit spawnedUnit = SpawnSimulationUnit(PlayerSentinels, unitTypeId, randomPoint);
                    GroupAddUnit(battleSimulationGroup, spawnedUnit);
                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine($"Sentinel spawn error: {ex.Message}");
                }
            }

            foreach (var unitTypeId in WarsongUnits)
            {
                try
                {
                    Point randomPoint = regionRect.GetRandomPoint();
                    unit spawnedUnit = SpawnSimulationUnit(PlayerWarsong, unitTypeId, randomPoint);
                    GroupAddUnit(battleSimulationGroup, spawnedUnit);
                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine($"Warsong spawn error: {ex.Message}");
                }
            }
            
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
                System.Console.WriteLine($"Warsong spawn error: {ex.Message}");
              }
            }

            IssueGroupAttack(battleSimulationGroup, midpoint);

            // Start the native periodic timer explicitly
            timer healthCheckTimer = CreateTimer();
            TimerStart(healthCheckTimer, 8f, true, CheckAndRestoreUnitHealth);
        }

        private static unit SpawnSimulationUnit(int ownerId, int unitTypeId, Point position)
        {
            var newUnit = CreateUnit(Player(ownerId), unitTypeId, position.X, position.Y, 0);
            SetUnitInvulnerable(newUnit, false);
            return newUnit;
        }

        private static void IssueGroupAttack(group unitGroup, Point targetLocation)
        {
            foreach (var unit in unitGroup.ToList())
                IssuePointOrder(unit, "attack", targetLocation.X, targetLocation.Y);
        }

        private static void SetPlayersHostile(int playerA, int playerB, bool hostile)
        {
            SetPlayerAlliance(Player(playerA), Player(playerB), ALLIANCE_PASSIVE, !hostile);
            SetPlayerAlliance(Player(playerA), Player(playerB), ALLIANCE_HELP_REQUEST, !hostile);
            SetPlayerAlliance(Player(playerA), Player(playerB), ALLIANCE_HELP_RESPONSE, !hostile);
            SetPlayerAlliance(Player(playerA), Player(playerB), ALLIANCE_SHARED_XP, !hostile);
            SetPlayerAlliance(Player(playerA), Player(playerB), ALLIANCE_SHARED_SPELLS, !hostile);
            SetPlayerAlliance(Player(playerA), Player(playerB), ALLIANCE_SHARED_VISION, !hostile);
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