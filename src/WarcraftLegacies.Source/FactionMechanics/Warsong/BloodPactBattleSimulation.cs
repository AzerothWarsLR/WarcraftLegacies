
using WCSharp.Shared.Data;
using WCSharp.Shared.Extensions;


namespace WarcraftLegacies.Source.FactionMechanics.Warsong;

public static class BloodPactBattleSimulation
{
  private const int NeutralHostile = 24;
  private const int Player = 0;
  private const float MinHealthPercentage = 70f;
  private const float HealthRestorePercentage = 100f;

  public static readonly group SentinelsGroup = CreateGroup();
  public static readonly group WarsongGroup = CreateGroup();
  public static readonly group BattleSimulationGroup = CreateGroup();

  private static readonly int[] _sentinelsUnits =
  {
          UNIT_BPH1_HUNTRESS_SENTINELS,
          UNIT_BPH1_HUNTRESS_SENTINELS,
          UNIT_BPH1_HUNTRESS_SENTINELS,
          UNIT_BPH1_HUNTRESS_SENTINELS,
          UNIT_BPA1_ARCHER_SENTINELS,
          UNIT_BPA1_ARCHER_SENTINELS,
          UNIT_BPA1_ARCHER_SENTINELS
  };

  private static readonly int[] _warsongUnits =
  {
    UNIT_OPGH_CORRUPTOR_OF_THE_WARSONG_CLAN_WARSONG_BLOODPACT,
    UNIT_O00P_CHAOS_WARSONG_GRUNT_WARSONG,
    UNIT_O00P_CHAOS_WARSONG_GRUNT_WARSONG,
    UNIT_O00P_CHAOS_WARSONG_GRUNT_WARSONG,
    UNIT_O00P_CHAOS_WARSONG_GRUNT_WARSONG,
    UNIT_O00P_CHAOS_WARSONG_GRUNT_WARSONG,
    UNIT_O00P_CHAOS_WARSONG_GRUNT_WARSONG
  };

  private static readonly int[] _playerunits =
    { UNIT_OEYE_SENTRY_WARD_FROSTWOLF_WITCH_DOCTOR };


  public static void StartSimulation()
  {
    var regionRect = Regions.BloodPactBattle;


    foreach (var unitTypeId in _sentinelsUnits)
    {
      try
      {
        var randomPoint = regionRect.GetRandomPoint();
        var spawnedUnit = SpawnSimulationUnit(NeutralHostile, unitTypeId, randomPoint);
        GroupAddUnit(SentinelsGroup, spawnedUnit);
        GroupAddUnit(BattleSimulationGroup, spawnedUnit);
      }
      catch (System.Exception ex)
      {
        System.Console.WriteLine($"Sentinel spawn error: {ex.Message}");
      }
    }
    foreach (var unitTypeId in _warsongUnits)
    {
      try
      {
        var randomPoint = regionRect.GetRandomPoint();
        var spawnedUnit = SpawnSimulationUnit(NeutralHostile, unitTypeId, randomPoint);
        GroupAddUnit(WarsongGroup, spawnedUnit);
        GroupAddUnit(BattleSimulationGroup, spawnedUnit);
      }
      catch (System.Exception ex)
      {
        System.Console.WriteLine($"Warsong spawn error: {ex.Message}");
      }
    }

    foreach (var unitTypeId in _playerunits)
    {
      try
      {
        var randomPoint = regionRect.GetRandomPoint();
        var spawnedUnit = SpawnSimulationUnit(Player, unitTypeId, randomPoint);
        GroupAddUnit(BattleSimulationGroup, spawnedUnit);
      }
      catch (System.Exception ex)
      {
        System.Console.WriteLine($"Player unit spawn error: {ex.Message}");
      }
    }

    foreach (var sentinelUnit in SentinelsGroup.ToList())
    {
      var targetUnit = GetRandomUnitFromGroup(WarsongGroup);
      if (targetUnit != null)
      {
        IssueTargetOrder(sentinelUnit, "attack", targetUnit);
      }
    }

    foreach (var warsongUnit in WarsongGroup.ToList())
    {
      var targetUnit = GetRandomUnitFromGroup(SentinelsGroup);
      if (targetUnit != null)
      {
        IssueTargetOrder(warsongUnit, "attack", targetUnit);
      }
    }

    var healthCheckTimer = CreateTimer();
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
    {
      return null;
    }

    var randomIndex = GetRandomInt(0, units.Count - 1);
    return units[randomIndex];
  }

  private static void CheckAndRestoreUnitHealth()
  {
    foreach (var unit in BattleSimulationGroup.ToList())
    {
      if (GetWidgetLife(unit) <= 0.405f)
      {
        continue;
      }

      var currentHpPercent = (GetWidgetLife(unit) / GetUnitState(unit, UNIT_STATE_MAX_LIFE)) * 100f;

      if (currentHpPercent <= MinHealthPercentage)
      {
        var restoreAmount = (HealthRestorePercentage / 100f) * GetUnitState(unit, UNIT_STATE_MAX_LIFE);
        SetWidgetLife(unit, restoreAmount);
      }
    }
  }
}
