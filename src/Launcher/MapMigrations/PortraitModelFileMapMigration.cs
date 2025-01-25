using War3Api.Object;
using War3Net.Build;

namespace Launcher.MapMigrations
{
  public sealed class PortraitModelFileMapMigration : IMapMigration
  {
    public void Migrate(Map map, ObjectDatabase objectDatabase)
    {
      foreach (var unit in objectDatabase.GetUnits())
      {
        
          unit.ArtPortraitModelFile = "None";
      }

      map.UnitObjectData = objectDatabase.GetAllData().UnitData;
    }
  }
}
