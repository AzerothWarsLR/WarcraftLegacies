using System.Collections.Generic;
using System.IO;
using System.Text;
using Launcher.Services;
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

namespace Launcher.Extensions;

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
    if (map.AbilityObjectData != null)
    {
      objectDatabase.AddObjects(map.AbilityObjectData, new AbilityObjectData(ObjectDataFormatVersion.v3));
    }

    if (map.BuffObjectData != null)
    {
      objectDatabase.AddObjects(map.BuffObjectData, new BuffObjectData(ObjectDataFormatVersion.v3));
    }
    //if (map.DestructableObjectData != null) objectDatabase.AddObjects(map.DestructableObjectData);
    if (map.DoodadObjectData != null)
    {
      objectDatabase.AddObjects(map.DoodadObjectData, new DoodadObjectData(ObjectDataFormatVersion.v3));
    }

    if (map.ItemObjectData != null)
    {
      objectDatabase.AddObjects(map.ItemObjectData, new ItemObjectData(ObjectDataFormatVersion.v3));
    }

    if (map.UnitObjectData != null)
    {
      objectDatabase.AddObjects(map.UnitObjectData, new UnitObjectData(ObjectDataFormatVersion.v3));
    }

    if (map.UpgradeObjectData != null)
    {
      objectDatabase.AddObjects(map.UpgradeObjectData, new UpgradeObjectData(ObjectDataFormatVersion.v3));
    }

    return objectDatabase;
  }

  /// <summary>
  /// Builds a folder containing a complete Warcraft 3 map, which can be opened by the editor.
  /// </summary>
  /// <param name="map">The map to build a directory from.</param>
  /// <param name="destinationRootDirectory">The location of the output.</param>
  /// <param name="additionalFiles">Any additional files to add into the output directory, such as texture imports.</param>
  public static void BuildDirectory(this Map map, string destinationRootDirectory, IEnumerable<PathData> additionalFiles)
  {
    Directory.CreateDirectory(destinationRootDirectory);
    if (map.Sounds != null)
    {
      Write(destinationRootDirectory, MapSounds.FileName, map.Sounds);
    }

    if (map.Environment != null)
    {
      Write(destinationRootDirectory, MapEnvironment.FileName, map.Environment);
    }

    if (map.PathingMap != null)
    {
      Write(destinationRootDirectory, MapPathingMap.FileName, map.PathingMap);
    }

    if (map.PreviewIcons != null)
    {
      Write(destinationRootDirectory, MapPreviewIcons.FileName, map.PreviewIcons);
    }

    if (map.Regions != null)
    {
      Write(destinationRootDirectory, MapRegions.FileName, map.Regions);
    }

    if (map.ShadowMap != null)
    {
      Write(destinationRootDirectory, MapShadowMap.FileName, map.ShadowMap);
    }

    if (map.ImportedFiles != null)
    {
      Write(destinationRootDirectory, ImportedFiles.MapFileName, map.ImportedFiles);
    }

    if (map.Info != null)
    {
      Write(destinationRootDirectory, MapInfo.FileName, map.Info);
    }

    if (map.AbilityObjectData != null)
    {
      Write(destinationRootDirectory, AbilityObjectData.MapFileName, map.AbilityObjectData);
    }

    if (map.BuffObjectData != null)
    {
      Write(destinationRootDirectory, BuffObjectData.MapFileName, map.BuffObjectData);
    }

    if (map.DestructableObjectData != null)
    {
      Write(destinationRootDirectory, DestructableObjectData.MapFileName, map.DestructableObjectData);
    }

    if (map.DoodadObjectData != null)
    {
      Write(destinationRootDirectory, DoodadObjectData.MapFileName, map.DoodadObjectData);
    }

    if (map.ItemObjectData != null)
    {
      Write(destinationRootDirectory, ItemObjectData.MapFileName, map.ItemObjectData);
    }

    if (map.UnitObjectData != null)
    {
      Write(destinationRootDirectory, UnitObjectData.MapFileName, map.UnitObjectData);
    }

    if (map.UpgradeObjectData != null)
    {
      Write(destinationRootDirectory, UpgradeObjectData.MapFileName, map.UpgradeObjectData);
    }

    if (map.CustomTextTriggers != null)
    {
      Write(destinationRootDirectory, MapCustomTextTriggers.FileName, map.CustomTextTriggers);
    }

    if (map.Doodads != null)
    {
      Write(destinationRootDirectory, MapDoodads.FileName, map.Doodads);
    }

    if (map.Units != null)
    {
      Write(destinationRootDirectory, MapUnits.FileName, map.Units);
    }

    if (map.Triggers != null)
    {
      Write(destinationRootDirectory, MapTriggers.FileName, map.Triggers);
    }

    if (map.AbilitySkinObjectData != null)
    {
      Write(destinationRootDirectory, AbilityObjectData.MapSkinFileName, map.AbilitySkinObjectData);
    }

    if (map.BuffSkinObjectData != null)
    {
      Write(destinationRootDirectory, BuffObjectData.MapSkinFileName, map.BuffSkinObjectData);
    }

    if (map.DestructableSkinObjectData != null)
    {
      Write(destinationRootDirectory, DestructableObjectData.MapSkinFileName, map.DestructableSkinObjectData);
    }

    if (map.DoodadSkinObjectData != null)
    {
      Write(destinationRootDirectory, DoodadObjectData.MapSkinFileName, map.DoodadSkinObjectData);
    }

    if (map.ItemSkinObjectData != null)
    {
      Write(destinationRootDirectory, ItemObjectData.MapSkinFileName, map.ItemSkinObjectData);
    }

    if (map.UnitSkinObjectData != null)
    {
      Write(destinationRootDirectory, UnitObjectData.MapSkinFileName, map.UnitSkinObjectData);
    }

    if (map.UpgradeSkinObjectData != null)
    {
      Write(destinationRootDirectory, UpgradeObjectData.MapSkinFileName, map.UpgradeSkinObjectData);
    }

    if (map.Script != null)
    {
      Write(destinationRootDirectory, "war3map.lua", map.Script);
    }

    foreach (var file in additionalFiles)
    {
      if (!File.Exists(file.AbsolutePath))
      {
        continue;
      }

      var destinationPath = Path.Combine(destinationRootDirectory, file.RelativePath);
      Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));
      File.Copy(file.AbsolutePath, destinationPath, true);
    }
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
