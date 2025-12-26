#nullable enable

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Launcher.DataTransferObjects;
using Launcher.Extensions;
using Launcher.Infrastructure;
using War3Net.Build;
using War3Net.Build.Audio;
using War3Net.Build.Environment;
using War3Net.Build.Extensions;
using War3Net.Build.Object;
using War3Net.Build.Script;
using War3Net.Build.Widget;
using War3Net.Common.Extensions;
using static Launcher.Paths.PathConventions;

namespace Launcher.Services;

/// <summary>
/// Converts a Warcraft 3 map into a collection of loose files so that they can be stored in version control.
/// </summary>
public sealed class W3XToMapDataConverter(W3XToMapDataConverterOptions options)
{
  /// <summary>
  /// Converts the provided Warcraft 3 map to JSON and saves it in the specified folder.
  /// </summary>
  public void Convert(string baseMapPath)
  {
    var map = Map.Open(baseMapPath);
    map.MergeObjectData();
    SerializeAndWriteMapData(map);

    CopyImportedFiles(baseMapPath);
    CopyUnserializableFiles(baseMapPath);
    CopyGameInterface(baseMapPath, map.TriggerStrings);
  }

  private void SerializeAndWriteMapData(Map map)
  {
    if (map.Doodads != null)
    {
      SerializeAndWriteDoodads(map.Doodads, options.MapDataPaths.DoodadsPath);
    }

    if (map.Environment != null)
    {
      FileHelper.SerializeAndWrite<MapEnvironment, MapEnvironmentDto>(options.MapDataPaths.EnvironmentPath, map.Environment);
    }

    if (map.Info != null)
    {
      map.LocalizeInfo();
      map.Info.MapVersion = 100;
      FileHelper.SerializeAndWrite(options.MapDataPaths.InfoPath, map.Info);
    }

    if (map.Regions != null)
    {
      SerializeAndWriteRegions(map.Regions);
    }

    if (map.Units != null)
    {
      SerializeAndWriteUnits(map.Units, options.MapDataPaths.UnitsPath);
    }

    if (map.PathingMap != null)
    {
      FileHelper.SerializeAndWrite<MapPathingMap, MapPathingMapDto>(options.MapDataPaths.PathingMapPath, map.PathingMap);
    }

    if (map.PreviewIcons != null)
    {
      SerializeAndWritePreviewIcons(map.PreviewIcons, options.MapDataPaths.PreviewIconsPath);
    }

    if (map.ShadowMap != null)
    {
      FileHelper.SerializeAndWrite<MapShadowMap, MapShadowMapDto>(options.MapDataPaths.ShadowMapPath, map.ShadowMap);
    }

    if (map.Sounds != null)
    {
      SerializeAndWriteSounds(map.Sounds);
    }

    if (map.UnitObjectData != null)
    {
      SerializeAndWriteUnitData(map.UnitObjectData);
    }

    if (map.AbilityObjectData != null)
    {
      SerializeAndWriteAbilityData(map.AbilityObjectData);
    }

    if (map.ItemObjectData != null)
    {
      SerializeAndWriteItemData(map.ItemObjectData);
    }

    if (map.DestructableObjectData != null)
    {
      SerializeAndWriteDestructableData(map.DestructableObjectData);
    }

    if (map.DoodadObjectData != null)
    {
      SerializeAndWriteDoodadData(map.DoodadObjectData);
    }

    if (map.BuffObjectData != null)
    {
      SerializeAndWriteBuffData(map.BuffObjectData);
    }

    if (map.UpgradeObjectData != null)
    {
      SerializeAndWriteUpgradeData(map.UpgradeObjectData);
    }
  }

  private void CopyImportedFiles(string baseMapPath)
  {
    var importFileExtensions = new[] { ".blp", ".mdx", ".mdl", ".toc", ".fdf", ".mp3", ".webp", ".slk" };
    var files = Directory
      .EnumerateFiles(baseMapPath, "*", SearchOption.AllDirectories)
      .Where(file => importFileExtensions.Any(file.ToLower().EndsWith))
      .ToList();

    var unserializableFilePaths = GetUnserializableFilePaths().ToList();
    foreach (var file in files)
    {
      var relativePath = Path.GetRelativePath(baseMapPath, file);
      if (unserializableFilePaths.Contains(relativePath))
      {
        continue;
      }

      var destinationFileName = Path.Combine(options.MapDataPaths.ImportsPath, relativePath);
      Directory.CreateDirectory(Path.GetDirectoryName(destinationFileName)!);
      File.Copy(file, destinationFileName, true);
    }
  }

  private void CopyUnserializableFiles(string baseMapPath)
  {
    foreach (var filePath in GetUnserializableFilePaths())
    {
      var fullSourceFilePath = Path.Combine(baseMapPath, filePath);
      if (!File.Exists(fullSourceFilePath))
      {
        continue;
      }

      var fullOutputFilePath = Path.Combine(options.MapDataPaths.RootPath, filePath);
      File.Copy(fullSourceFilePath, fullOutputFilePath, true);
    }
  }

  private void CopyGameInterface(string baseMapPath, TriggerStrings? triggerStrings)
  {
    var gameInterfacePath = Path.Combine(baseMapPath, MapData.GameInterface);
    if (!File.Exists(gameInterfacePath))
    {
      return;
    }

    var localizedContent = Regex.Replace(
      File.ReadAllText(gameInterfacePath),
      @"TRIGSTR_\d+",
      match => $"\"{match.Value.Localize(triggerStrings)}\"");

    File.WriteAllText(options.MapDataPaths.GameInterfacePath, localizedContent);
  }

  private static void SerializeAndWritePreviewIcons(MapPreviewIcons mapPreviewIcons, string path)
  {
    FileHelper.SerializeAndWrite<MapPreviewIcons, MapPreviewIconsDto>(path, new MapPreviewIcons(mapPreviewIcons.FormatVersion)
    {
      Icons = mapPreviewIcons.Icons
        .OrderByDescending(x => x.IconType)
        .ThenByDescending(x => x.X)
        .ThenByDescending(x => x.Y)
        .ToList()
    });
  }

  private static void SerializeAndWriteUnits(MapUnits units, string path)
  {
    FileHelper.SerializeAndWriteInChunks<UnitData, UnitDataDto>(units.Units, path);
  }

  private static void SerializeAndWriteDoodads(MapDoodads doodads, string path)
  {
    FileHelper.SerializeAndWriteInChunks<DoodadData, DoodadDataDto>(doodads.Doodads, path);
  }

  private void SerializeAndWriteSounds(MapSounds sounds)
  {
    foreach (var sound in sounds.Sounds)
    {
      FileHelper.SerializeAndWrite<Sound, SoundDto>(Path.Combine(options.MapDataPaths.SoundsPath, $"{sound.Name.Remove(0, 7)}.json"), sound);
    }
  }

  private void SerializeAndWriteRegions(MapRegions regions)
  {
    foreach (var region in regions.Regions)
    {
      FileHelper.SerializeAndWrite<Region, RegionDto>(Path.Combine(options.MapDataPaths.RegionsPath, $"{region.Name}.json"), region);
    }
  }

  private void SerializeAndWriteUnitData(UnitObjectData objectData)
  {
    SerializeAndWriteModifications(options.MapDataPaths.UnitDataPath, objectData.BaseUnits);
    SerializeAndWriteModifications(options.MapDataPaths.UnitDataPath, objectData.NewUnits);
  }

  private void SerializeAndWriteBuffData(BuffObjectData objectData)
  {
    SerializeAndWriteModifications(options.MapDataPaths.BuffDataPath, objectData.BaseBuffs);
    SerializeAndWriteModifications(options.MapDataPaths.BuffDataPath, objectData.NewBuffs);
  }

  private void SerializeAndWriteDoodadData(DoodadObjectData objectData)
  {
    SerializeAndWriteModifications(options.MapDataPaths.DoodadDataPath, objectData.BaseDoodads);
    SerializeAndWriteModifications(options.MapDataPaths.DoodadDataPath, objectData.NewDoodads);
  }

  private void SerializeAndWriteDestructableData(DestructableObjectData objectData)
  {
    SerializeAndWriteModifications(options.MapDataPaths.DestructableDataPath, objectData.BaseDestructables);
    SerializeAndWriteModifications(options.MapDataPaths.DestructableDataPath, objectData.NewDestructables);
  }

  private void SerializeAndWriteItemData(ItemObjectData objectData)
  {
    SerializeAndWriteModifications(options.MapDataPaths.ItemDataPath, objectData.BaseItems);
    SerializeAndWriteModifications(options.MapDataPaths.ItemDataPath, objectData.NewItems);
  }

  private void SerializeAndWriteAbilityData(AbilityObjectData objectData)
  {
    SerializeAndWriteModifications(options.MapDataPaths.AbilityDataPath, objectData.BaseAbilities);
    SerializeAndWriteModifications(options.MapDataPaths.AbilityDataPath, objectData.NewAbilities);
  }

  private void SerializeAndWriteUpgradeData(UpgradeObjectData objectData)
  {
    SerializeAndWriteModifications(options.MapDataPaths.UpgradeDataPath, objectData.BaseUpgrades);
    SerializeAndWriteModifications(options.MapDataPaths.UpgradeDataPath, objectData.NewUpgrades);
  }

  private static void SerializeAndWriteModifications(string path, params IEnumerable<VariationObjectModification> modifications)
  {
    foreach (var modification in modifications)
    {
      FileHelper.SerializeAndWrite(Path.Combine(path, $"{modification.GetId().ToRawcode()}.json"), modification);
    }
  }

  private static void SerializeAndWriteModifications(string path, params IEnumerable<LevelObjectModification> modifications)
  {
    foreach (var modification in modifications)
    {
      FileHelper.SerializeAndWrite(Path.Combine(path, $"{modification.GetId().ToRawcode()}.json"), modification);
    }
  }

  private static void SerializeAndWriteModifications(string path, params IEnumerable<SimpleObjectModification> modifications)
  {
    foreach (var modification in modifications)
    {
      FileHelper.SerializeAndWrite(Path.Combine(path, $"{modification.GetId().ToRawcode()}.json"), modification);
    }
  }
}
