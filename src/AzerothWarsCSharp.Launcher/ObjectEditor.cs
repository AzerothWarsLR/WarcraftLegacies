using AzerothWarsCSharp.ObjectFactory.Abilities;
using War3Api.Object;
using War3Net.Build;

namespace AzerothWarsCSharp.Launcher
{
  /// <summary>
  ///   Helper class for adding object data to the map at compile time.
  /// </summary>
  public static class ObjectEditor
  {
    /// <summary>
    ///   Adds additional object data to a map.
    /// </summary>
    public static void SupplmentMapWithObjectData(Map map)
    {
      var objectDatabase = GetObjectDatabaseFromMap(map);
      var slowAura = new EffectlessAuraFactory
      {
        AttachmentPoint = "origin",
        Icon = "RunedBracers",
        TextName = "Spell Resistance Aura",
        IsPositive = true,
        TextTooltipExtended = "This unit takes reduced damage from magic attacks and spells."
      };
      var buff = slowAura.GenerateBuff("BBBB", objectDatabase);
      slowAura.Generate("AAAA", buff, objectDatabase);
      WriteObjectData(map, objectDatabase);
    }

    private static ObjectDatabase GetObjectDatabaseFromMap(Map map)
    {
      var objectDatabase = new ObjectDatabase();
      if (map.AbilityObjectData != null) objectDatabase.AddObjects(map.AbilityObjectData);
      if (map.BuffObjectData != null) objectDatabase.AddObjects(map.BuffObjectData);
      if (map.DestructableObjectData != null) objectDatabase.AddObjects(map.DestructableObjectData);
      if (map.DoodadObjectData != null) objectDatabase.AddObjects(map.DoodadObjectData);
      if (map.ItemObjectData != null) objectDatabase.AddObjects(map.ItemObjectData);
      if (map.UnitObjectData != null) objectDatabase.AddObjects(map.UnitObjectData);
      if (map.UpgradeObjectData != null) objectDatabase.AddObjects(map.UpgradeObjectData);
      return objectDatabase;
    }

    private static void WriteObjectData(Map map, ObjectDatabase objectDatabase)
    {
      var objectData = objectDatabase.GetAllData();
      if (objectData.UnitData != null) map.UnitObjectData = objectData.UnitData;
      if (objectData.ItemData != null) map.ItemObjectData = objectData.ItemData;
      if (objectData.DestructableData != null) map.DestructableObjectData = objectData.DestructableData;
      if (objectData.DoodadData != null) map.DoodadObjectData = objectData.DoodadData;
      if (objectData.AbilityData != null) map.AbilityObjectData = objectData.AbilityData;
      if (objectData.BuffData != null) map.BuffObjectData = objectData.BuffData;
      if (objectData.UpgradeData != null) map.UpgradeObjectData = objectData.UpgradeData;
    }
  }
}