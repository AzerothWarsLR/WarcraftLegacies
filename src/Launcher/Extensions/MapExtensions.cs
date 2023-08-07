using War3Api.Object;
using War3Net.Build;

namespace Launcher.Extensions
{
  /// <summary>
  /// A useful set of extension methods for the <see cref="Map"/> class.
  /// </summary>
  public static class MapExtensions
  {
    /// <summary>
    /// Creates an <see cref="ObjectDatabase"/> populated with data from the provided <see cref="Map"/>.
    /// </summary>
    public static ObjectDatabase GetObjectDatabaseFromMap(this Map map)
    {
      var objectDatabase = new ObjectDatabase();
      if (map.AbilityObjectData != null) objectDatabase.AddObjects(map.AbilityObjectData);
      if (map.BuffObjectData != null) objectDatabase.AddObjects(map.BuffObjectData);
      //if (map.DestructableObjectData != null) objectDatabase.AddObjects(map.DestructableObjectData);
      if (map.DoodadObjectData != null) objectDatabase.AddObjects(map.DoodadObjectData);
      if (map.ItemObjectData != null) objectDatabase.AddObjects(map.ItemObjectData);
      if (map.UnitObjectData != null) objectDatabase.AddObjects(map.UnitObjectData);
      if (map.UpgradeObjectData != null) objectDatabase.AddObjects(map.UpgradeObjectData);
      return objectDatabase;
    }
  }
}