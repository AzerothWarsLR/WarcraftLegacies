using War3Api.Object;
using War3Net.Build;

namespace Launcher.MapMigrations
{
  /// <summary>
  /// Assigns level to all units in the map based on health, attack type and whether it is flying.
  /// </summary>
  public sealed class CreepLevelMapMigration : IMapMigration
  {
    private readonly int healthFactor = 200;

    public void Migrate(Map map, ObjectDatabase objectDatabase)
    {
      foreach (var unit in objectDatabase.GetUnits())
      {
        if (!unit.StatsIsABuilding)
        {
          var level = 0;
          var unitHealth = unit.StatsHitPointsMaximumBase;
          var remainder = unitHealth % healthFactor;

          if (remainder > 0)
            unitHealth -= remainder;

          var healthDividedByFactor = unitHealth / healthFactor;

          if (healthDividedByFactor < 8)
          {
            level += healthDividedByFactor;
          }
          else
          {
            level += 7;
          }

          if (unitHealth >= 1800)
            level += 1;

          if (unitHealth >= 2400)
            level += 1;

          if (unitHealth >= 3000)
            level += 1;

          if (unit.CombatAttack1AttackType.Equals(War3Api.Object.Enums.AttackType.Chaos) || unit.CombatAttack1AttackType.Equals(War3Api.Object.Enums.AttackType.Hero))
            level += 1;

          // is a flying unit
          if (unit.MovementHeight > 100)
            level += 1;

          unit.StatsLevel = level;
        }
      }

      map.UnitObjectData = objectDatabase.GetAllData().UnitData;
    }
  }
}