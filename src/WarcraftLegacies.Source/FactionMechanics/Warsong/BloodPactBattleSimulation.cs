
using WCSharp.Shared.Data;
using WCSharp.Shared.Extensions;


namespace WarcraftLegacies.Source.FactionMechanics.Warsong;

public static class BloodPactBattleSimulation
{
  private const int NeutralHostile = 24;
  private const int Player = 0;
  private const float MinHealthPercentage = 70f;
  private const float HealthRestorePercentage = 100f;

  public static readonly group SentinelsGroup = group.Create();
  public static readonly group WarsongGroup = group.Create();
  public static readonly group BattleSimulationGroup = group.Create();

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
        SentinelsGroup.Add(spawnedUnit);
        BattleSimulationGroup.Add(spawnedUnit);
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
        WarsongGroup.Add(spawnedUnit);
        BattleSimulationGroup.Add(spawnedUnit);
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
        BattleSimulationGroup.Add(spawnedUnit);
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
        sentinelUnit.IssueOrder("attack", targetUnit);
      }
    }

    foreach (var warsongUnit in WarsongGroup.ToList())
    {
      var targetUnit = GetRandomUnitFromGroup(SentinelsGroup);
      if (targetUnit != null)
      {
        warsongUnit.IssueOrder("attack", targetUnit);
      }
    }

    var healthCheckTimer = timer.Create();
    healthCheckTimer.Start(8f, true, CheckAndRestoreUnitHealth);
  }

  private static unit SpawnSimulationUnit(int ownerId, int unitTypeId, Point position)
  {
    var newUnit = unit.Create(player.Create(ownerId), unitTypeId, position.X, position.Y, 0);
    newUnit.IsInvulnerable = false;
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
      if (unit.Life <= 0.405f)
      {
        continue;
      }

      var currentHpPercent = (unit.Life / unit.MaxLife) * 100f;

      if (currentHpPercent <= MinHealthPercentage)
      {
        var restoreAmount = (HealthRestorePercentage / 100f) * unit.MaxLife;
        unit.Life = restoreAmount;
      }
    }
  }
}
