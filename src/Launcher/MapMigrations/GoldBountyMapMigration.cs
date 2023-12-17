using War3Api.Object;
using War3Net.Build;

namespace Launcher.MapMigrations
{
  /// <summary>
  /// Assigns gold bounties based on level to all units in the map.
  /// </summary>
  public sealed class GoldBountyMapMigration : IMapMigration
  {
    public void Migrate(Map map, ObjectDatabase objectDatabase)
    {
      foreach (var unit in objectDatabase.GetUnits())
      {
        var level = unit.StatsLevel;
        var scalingFactor = 4;
        var numberOfDiceConstant = 1;
        var maxValueOnDice = 2;
        var baseConstant = -2;
        var baseGold = (level * scalingFactor) + baseConstant;

        if (level >= 7)
          baseGold += 5;

        if (unit.StatsHitPointsMaximumBase >= 1500)
          baseGold += 7;

        if (unit.StatsHitPointsMaximumBase >= 2000)
          baseGold += 10;

        if (unit.StatsHitPointsMaximumBase >= 2500)
          baseGold += 15;

        if (unit.StatsGoldBountyAwardedBase != baseGold)
          unit.StatsGoldBountyAwardedBase = baseGold;

        if (unit.StatsGoldBountyAwardedNumberOfDice != level + numberOfDiceConstant)
          unit.StatsGoldBountyAwardedNumberOfDice = level + numberOfDiceConstant;

        if (unit.StatsGoldBountyAwardedNumberOfDice != maxValueOnDice)
          unit.StatsGoldBountyAwardedSidesPerDie = maxValueOnDice;

        if (level == 0)
          unit.StatsGoldBountyAwardedBase = 0;
          unit.StatsGoldBountyAwardedNumberOfDice = 0;
          unit.StatsGoldBountyAwardedSidesPerDie = 0;
      }

      map.UnitObjectData = objectDatabase.GetAllData().UnitData;
    }
  }
}