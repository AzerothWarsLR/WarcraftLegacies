using System.Linq;
using Launcher.Extensions;
using War3Api.Object;
using War3Api.Object.Enums;
using War3Net.Build;

namespace Launcher.MapDataMigrations
{
  public sealed class GoldBountyMigration
  {
    public void Migrate(Map map, ObjectDatabase objectDatabase)
    {
      foreach (var unit in objectDatabase.GetUnits().Where(IsCreep))
      {
        var level = unit.StatsLevel;
        unit.StatsGoldBountyAwardedBase = level;
        unit.StatsGoldBountyAwardedNumberOfDice = level;
        unit.StatsGoldBountyAwardedSidesPerDie = 4;
      }

      map.UnitObjectData = objectDatabase.GetAllData().UnitData;
    }
    
    private static bool IsCreep(Unit unit) => unit.StatsRace == UnitRace.Creeps && !unit.StatsIsABuilding;
  }
}