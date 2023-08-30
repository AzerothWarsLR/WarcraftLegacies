using System.IO;
using System.Text;
using War3Api.Object;
using War3Net.Build;
using War3Net.Build.Audio;
using War3Net.Build.Environment;
using War3Net.Build.Extensions;
using War3Net.Build.Import;
using War3Net.Build.Info;
using War3Net.Build.Object;
using War3Net.Build.Script;
using War3Net.Build.Widget;

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

    /// <summary>
    /// Builds a folder containing a complete Warcraft 3 map, which can be opened by the editor.
    /// </summary>
    public static void BuildFolder(this Map map, string rootFolderPath)
    {
      Directory.CreateDirectory(rootFolderPath);
      if (map.Sounds != null) Write(rootFolderPath, MapSounds.FileName, map.Sounds);
      if (map.Environment != null) Write(rootFolderPath, MapEnvironment.FileName, map.Environment);
      if (map.PathingMap != null) Write(rootFolderPath, MapPathingMap.FileName, map.PathingMap);
      if (map.PreviewIcons != null) Write(rootFolderPath, MapPreviewIcons.FileName, map.PreviewIcons);
      if (map.Regions != null) Write(rootFolderPath, MapRegions.FileName, map.Regions);
      if (map.ShadowMap != null) Write(rootFolderPath, MapShadowMap.FileName, map.ShadowMap);
      if (map.ImportedFiles != null) Write(rootFolderPath, ImportedFiles.MapFileName, map.ImportedFiles);
      if (map.Info != null) Write(rootFolderPath, MapInfo.FileName, map.Info);
      if (map.AbilityObjectData != null) Write(rootFolderPath, AbilityObjectData.MapFileName, map.AbilityObjectData);
      if (map.BuffObjectData != null) Write(rootFolderPath, BuffObjectData.MapFileName, map.BuffObjectData);
      if (map.DestructableObjectData != null)
        Write(rootFolderPath, DestructableObjectData.MapFileName, map.DestructableObjectData);
      if (map.DoodadObjectData != null) Write(rootFolderPath, DoodadObjectData.MapFileName, map.DoodadObjectData);
      if (map.ItemObjectData != null) Write(rootFolderPath, ItemObjectData.MapFileName, map.ItemObjectData);
      if (map.UnitObjectData != null) Write(rootFolderPath, UnitObjectData.MapFileName, map.UnitObjectData);
      if (map.UpgradeObjectData != null) Write(rootFolderPath, UpgradeObjectData.MapFileName, map.UpgradeObjectData);
      if (map.CustomTextTriggers != null) Write(rootFolderPath, MapCustomTextTriggers.FileName, map.CustomTextTriggers);
      if (map.TriggerStrings != null) Write(rootFolderPath, TriggerStrings.MapFileName, map.TriggerStrings.ToString());
      if (map.Doodads != null) Write(rootFolderPath, MapDoodads.FileName, map.Doodads);
      if (map.Units != null) Write(rootFolderPath, MapUnits.FileName, map.Units);
      if (map.Triggers != null) Write(rootFolderPath, MapTriggers.FileName, map.Triggers);
      if (map.AbilitySkinObjectData != null)
        Write(rootFolderPath, AbilityObjectData.MapSkinFileName, map.AbilitySkinObjectData);
      if (map.BuffSkinObjectData != null) Write(rootFolderPath, BuffObjectData.MapSkinFileName, map.BuffSkinObjectData);
      if (map.DestructableSkinObjectData != null)
        Write(rootFolderPath, DestructableObjectData.MapSkinFileName, map.DestructableSkinObjectData);
      if (map.DoodadSkinObjectData != null)
        Write(rootFolderPath, DoodadObjectData.MapSkinFileName, map.DoodadSkinObjectData);
      if (map.ItemSkinObjectData != null) Write(rootFolderPath, ItemObjectData.MapSkinFileName, map.ItemSkinObjectData);
      if (map.UnitSkinObjectData != null) Write(rootFolderPath, UnitObjectData.MapSkinFileName, map.UnitSkinObjectData);
      if (map.UpgradeSkinObjectData != null)
        Write(rootFolderPath, UpgradeObjectData.MapSkinFileName, map.UpgradeSkinObjectData);
      if (map.Script != null) Write(rootFolderPath, "war3map.lua", map.Script);
    }

    private static void Write(string rootFolderPath, string subFolderPath, string rawText)
    {
      var path = Path.Combine(rootFolderPath, subFolderPath);
      File.WriteAllText(path, rawText);
    }

    private static void Write(string rootFolderPath, string subFolderPath, MapTriggers mapTriggers)
    {
      var path = Path.Combine(rootFolderPath, subFolderPath);
      using var stream = File.Open(path, FileMode.Create);
      using var writer = new BinaryWriter(stream, Encoding.UTF8, false);
      writer.Write(mapTriggers);
    }

    private static void Write(string rootFolderPath, string subFolderPath, MapUnits mapUnits)
    {
      var path = Path.Combine(rootFolderPath, subFolderPath);
      using var stream = File.Open(path, FileMode.Create);
      using var writer = new BinaryWriter(stream, Encoding.UTF8, false);
      writer.Write(mapUnits);
    }

    private static void Write(string rootFolderPath, string subFolderPath, MapCustomTextTriggers mapCustomTextTriggers)
    {
      var path = Path.Combine(rootFolderPath, subFolderPath);
      using var stream = File.Open(path, FileMode.Create);
      using var writer = new BinaryWriter(stream, Encoding.UTF8, false);
      writer.Write(mapCustomTextTriggers);
    }

    private static void Write(string rootFolderPath, string subFolderPath, UpgradeObjectData upgradeObjectData)
    {
      var path = Path.Combine(rootFolderPath, subFolderPath);
      using var stream = File.Open(path, FileMode.Create);
      using var writer = new BinaryWriter(stream, Encoding.UTF8, false);
      writer.Write(upgradeObjectData);
    }

    private static void Write(string rootFolderPath, string subFolderPath, UnitObjectData unitObjectData)
    {
      var path = Path.Combine(rootFolderPath, subFolderPath);
      using var stream = File.Open(path, FileMode.Create);
      using var writer = new BinaryWriter(stream, Encoding.UTF8, false);
      writer.Write(unitObjectData);
    }

    private static void Write(string rootFolderPath, string subFolderPath, ItemObjectData itemObjectData)
    {
      var path = Path.Combine(rootFolderPath, subFolderPath);
      using var stream = File.Open(path, FileMode.Create);
      using var writer = new BinaryWriter(stream, Encoding.UTF8, false);
      writer.Write(itemObjectData);
    }

    private static void Write(string rootFolderPath, string subFolderPath, DoodadObjectData doodadObjectData)
    {
      var path = Path.Combine(rootFolderPath, subFolderPath);
      using var stream = File.Open(path, FileMode.Create);
      using var writer = new BinaryWriter(stream, Encoding.UTF8, false);
      writer.Write(doodadObjectData);
    }

    private static void Write(string rootFolderPath, string subFolderPath,
      DestructableObjectData destructableObjectData)
    {
      var path = Path.Combine(rootFolderPath, subFolderPath);
      using var stream = File.Open(path, FileMode.Create);
      using var writer = new BinaryWriter(stream, Encoding.UTF8, false);
      writer.Write(destructableObjectData);
    }

    private static void Write(string rootFolderPath, string subFolderPath, BuffObjectData buffObjectData)
    {
      var path = Path.Combine(rootFolderPath, subFolderPath);
      using var stream = File.Open(path, FileMode.Create);
      using var writer = new BinaryWriter(stream, Encoding.UTF8, false);
      writer.Write(buffObjectData);
    }

    private static void Write(string rootFolderPath, string subFolderPath, AbilityObjectData abilityObjectData)
    {
      var path = Path.Combine(rootFolderPath, subFolderPath);
      using var stream = File.Open(path, FileMode.Create);
      using var writer = new BinaryWriter(stream, Encoding.UTF8, false);
      writer.Write(abilityObjectData);
    }

    private static void Write(string rootFolderPath, string subFolderPath, MapInfo mapInfo)
    {
      var path = Path.Combine(rootFolderPath, subFolderPath);
      using var stream = File.Open(path, FileMode.Create);
      using var writer = new BinaryWriter(stream, Encoding.UTF8, false);
      writer.Write(mapInfo);
    }

    private static void Write(string rootFolderPath, string subFolderPath, ImportedFiles importedFiles)
    {
      var path = Path.Combine(rootFolderPath, subFolderPath);
      using var stream = File.Open(path, FileMode.Create);
      using var writer = new BinaryWriter(stream, Encoding.UTF8, false);
      writer.Write(importedFiles);
    }

    private static void Write(string rootFolderPath, string subFolderPath, MapShadowMap mapShadowMap)
    {
      var path = Path.Combine(rootFolderPath, subFolderPath);
      using var stream = File.Open(path, FileMode.Create);
      using var writer = new BinaryWriter(stream, Encoding.UTF8, false);
      writer.Write(mapShadowMap);
    }

    private static void Write(string rootFolderPath, string subFolderPath, MapRegions mapRegions)
    {
      var path = Path.Combine(rootFolderPath, subFolderPath);
      using var stream = File.Open(path, FileMode.Create);
      using var writer = new BinaryWriter(stream, Encoding.UTF8, false);
      writer.Write(mapRegions);
    }

    private static void Write(string rootFolderPath, string subFolderPath, MapPreviewIcons mapPreviewIcons)
    {
      var path = Path.Combine(rootFolderPath, subFolderPath);
      using var stream = File.Open(path, FileMode.Create);
      using var writer = new BinaryWriter(stream, Encoding.UTF8, false);
      writer.Write(mapPreviewIcons);
    }

    private static void Write(string rootFolderPath, string subFolderPath, MapPathingMap mapPathingMap)
    {
      var path = Path.Combine(rootFolderPath, subFolderPath);
      using var stream = File.Open(path, FileMode.Create);
      using var writer = new BinaryWriter(stream, Encoding.UTF8, false);
      writer.Write(mapPathingMap);
    }

    private static void Write(string rootFolderPath, string subFolderPath, MapEnvironment mapEnvironment
    )
    {
      var path = Path.Combine(rootFolderPath, subFolderPath);
      using var stream = File.Open(path, FileMode.Create);
      using var writer = new BinaryWriter(stream, Encoding.UTF8, false);
      writer.Write(mapEnvironment);
    }

    private static void Write(string rootFolderPath, string subFolderPath, MapSounds mapSounds)
    {
      var path = Path.Combine(rootFolderPath, subFolderPath);
      using var stream = File.Open(path, FileMode.Create);
      using var writer = new BinaryWriter(stream, Encoding.UTF8, false);
      writer.Write(mapSounds);
    }

    private static void Write(string rootFolderPath, string subFolderPath, MapDoodads mapDoodads)
    {
      var path = Path.Combine(rootFolderPath, subFolderPath);
      using var stream = File.Open(path, FileMode.Create);
      using var writer = new BinaryWriter(stream, Encoding.UTF8, false);
      writer.Write(mapDoodads);
    }
  }
}