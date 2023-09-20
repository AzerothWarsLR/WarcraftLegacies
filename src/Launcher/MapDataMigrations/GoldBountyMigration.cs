using System.Linq;
using Launcher.Extensions;
using War3Net.Build;

namespace Launcher.MapDataMigrations
{
  public sealed class GoldBountyMigration
  {
    public void Migrate(Map map)
    {
      var units = map.UnitObjectData?.BaseUnits.Concat(map.UnitObjectData.NewUnits);
      const int levelId = 1986358389;
      foreach (var unit in units)
      {
        if (unit.TryGetDataModification(levelId, out var level))
        {
          
        }
      }
    }
  }
}