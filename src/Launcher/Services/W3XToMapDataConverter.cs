#nullable enable
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using AutoMapper;
using Launcher.DataTransferObjects;
using Launcher.DTOMappers;
using Launcher.JsonConverters;
using War3Net.Build;
using War3Net.Build.Audio;
using War3Net.Build.Environment;
using War3Net.Build.Extensions;
using War3Net.Build.Info;
using War3Net.Build.Object;
using War3Net.Build.Script;
using War3Net.Build.Widget;
using War3Net.Common.Extensions;
using static Launcher.MapDataPaths;

namespace Launcher.Services;

/// <summary>
/// Converts a Warcraft 3 map into a collection of loose files so that they can be stored in version control.
/// </summary>
public sealed class W3XToMapDataConverter(IMapper mapper)
{
  private readonly JsonSerializerOptions _jsonSerializerOptions = new()
  {
    IgnoreReadOnlyProperties = true,
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
    WriteIndented = true,
    Converters = { new ColorJsonConverter() }
  };

  /// <summary>
  /// Converts the provided Warcraft 3 map to JSON and saves it in the specified folder.
  /// </summary>
  public void Convert(string baseMapPath, string outputFolderPath)
  {
    var map = Map.Open(baseMapPath);
    SerializeAndWriteMapData(map, outputFolderPath);

    CopyImportedFiles(baseMapPath, outputFolderPath);
    CopyUnserializableFiles(baseMapPath, outputFolderPath);
    CopyGameInterface(baseMapPath, outputFolderPath, map.TriggerStrings);
  }

  private void SerializeAndWriteMapData(Map map, string outputFolderPath)
  {
    if (Directory.Exists(outputFolderPath))
    {
      Directory.Delete(outputFolderPath, true);
    }

    if (map.Doodads != null)
    {
      SerializeAndWriteDoodads(map.Doodads, Path.Combine(outputFolderPath, DoodadsDirectoryPath));
    }

    if (map.Environment != null)
    {
      SerializeAndWrite<MapEnvironment, MapEnvironmentDto>(map.Environment, outputFolderPath, EnvironmentPath);
    }

    if (map.Info != null)
    {
      SerializeAndWriteMapInfo(map.Info, new MapInfoMapper(map.TriggerStrings), Path.Combine(outputFolderPath, InfoPath));
    }

    if (map.Regions != null)
    {
      SerializeAndWriteRegions(map.Regions, Path.Combine(outputFolderPath, RegionsDirectoryPath));
    }

    if (map.Units != null)
    {
      SerializeAndWriteUnits(map.Units, Path.Combine(outputFolderPath, UnitsDirectoryPath));
    }

    if (map.PathingMap != null)
    {
      SerializeAndWrite<MapPathingMap, MapPathingMapDto>(map.PathingMap, outputFolderPath, PathingMapPath);
    }

    if (map.PreviewIcons != null)
    {
      SerializeAndWritePreviewIcons(map.PreviewIcons, Path.Combine(outputFolderPath, PreviewIconsPath));
    }

    if (map.ShadowMap != null)
    {
      SerializeAndWrite<MapShadowMap, MapShadowMapDto>(map.ShadowMap, outputFolderPath, ShadowMapPath);
    }

    if (map.Sounds != null)
    {
      SerializeAndWriteSounds(map.Sounds, Path.Combine(outputFolderPath, SoundsDirectoryPath));
    }

    if (map.UnitObjectData is { } unitObjectData)
    {
      if (map.UnitSkinObjectData is { } skinData)
      {
        Merge(unitObjectData.BaseUnits, skinData.BaseUnits, map.TriggerStrings);
        Merge(unitObjectData.NewUnits, skinData.NewUnits, map.TriggerStrings);
      }

      SerializeAndWriteUnitData(Path.Combine(outputFolderPath, UnitDataDirectoryPath), unitObjectData);
    }

    if (map.AbilityObjectData is { } abilityObjectData)
    {
      if (map.AbilitySkinObjectData is { } skinData)
      {
        Merge(abilityObjectData.BaseAbilities, skinData.BaseAbilities, map.TriggerStrings);
        Merge(abilityObjectData.NewAbilities, skinData.NewAbilities, map.TriggerStrings);
      }

      SerializeAndWriteAbilityData(Path.Combine(outputFolderPath, AbilityDataDirectoryPath), abilityObjectData);
    }

    if (map.ItemObjectData is { } itemObjectData)
    {
      if (map.ItemSkinObjectData is { } skinData)
      {
        Merge(itemObjectData.BaseItems, skinData.BaseItems, map.TriggerStrings);
        Merge(itemObjectData.NewItems, skinData.NewItems, map.TriggerStrings);
      }

      SerializeAndWriteItemData(Path.Combine(outputFolderPath, ItemDataDirectoryPath), itemObjectData);
    }

    if (map.DestructableObjectData is { } destructableObjectData)
    {
      if (map.DestructableSkinObjectData is { } skinData)
      {
        Merge(destructableObjectData.BaseDestructables, skinData.BaseDestructables, map.TriggerStrings);
        Merge(destructableObjectData.NewDestructables, skinData.NewDestructables, map.TriggerStrings);
      }

      SerializeAndWriteDestructableData(Path.Combine(outputFolderPath, DestructableDataDirectoryPath), destructableObjectData);
    }

    if (map.DoodadObjectData is { } doodadObjectData)
    {
      if (map.DoodadSkinObjectData is { } skinData)
      {
        Merge(doodadObjectData.BaseDoodads, skinData.BaseDoodads, map.TriggerStrings);
        Merge(doodadObjectData.NewDoodads, skinData.NewDoodads, map.TriggerStrings);
      }

      SerializeAndWriteDoodadData(Path.Combine(outputFolderPath, DoodadDataDirectoryPath), doodadObjectData);
    }

    if (map.BuffObjectData is { } buffObjectData)
    {
      if (map.BuffSkinObjectData is { } skinData)
      {
        Merge(buffObjectData.BaseBuffs, skinData.BaseBuffs, map.TriggerStrings);
        Merge(buffObjectData.NewBuffs, skinData.NewBuffs, map.TriggerStrings);
      }

      SerializeAndWriteBuffData(Path.Combine(outputFolderPath, BuffDataDirectoryPath), buffObjectData);
    }

    if (map.UpgradeObjectData is { } upgradeObjectData)
    {
      if (map.UpgradeSkinObjectData is { } skinData)
      {
        Merge(upgradeObjectData.BaseUpgrades, skinData.BaseUpgrades, map.TriggerStrings);
        Merge(upgradeObjectData.NewUpgrades, skinData.NewUpgrades, map.TriggerStrings);
      }

      SerializeAndWriteUpgradeData(Path.Combine(outputFolderPath, UpgradeDataDirectoryPath), upgradeObjectData);
    }
  }

  private static void CopyImportedFiles(string baseMapPath, string outputFolderPath)
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

      var destinationFileName = Path.Combine(outputFolderPath, ImportsPath, relativePath);
      Directory.CreateDirectory(Path.GetDirectoryName(destinationFileName)!);
      File.Copy(file, destinationFileName, true);
    }
  }

  private static void CopyUnserializableFiles(string baseMapPath, string outputFolderPath)
  {
    foreach (var filePath in GetUnserializableFilePaths())
    {
      var fullSourceFilePath = Path.Combine(baseMapPath, filePath);
      if (!File.Exists(fullSourceFilePath))
      {
        continue;
      }

      var fullOutputFilePath = Path.Combine(outputFolderPath, filePath);
      File.Copy(fullSourceFilePath, fullOutputFilePath, true);
    }
  }

  private static void CopyGameInterface(string baseMapPath, string outputFolderPath, TriggerStrings? triggerStrings)
  {
    var gameInterfacePath = Path.Combine(baseMapPath, GameInterfacePath);
    if (!File.Exists(gameInterfacePath))
    {
      return;
    }

    var localizedContent = Regex.Replace(
      File.ReadAllText(gameInterfacePath),
      @"TRIGSTR_\d+",
      match => $"\"{match.Value.Localize(triggerStrings)}\"");

    File.WriteAllText(Path.Combine(outputFolderPath, GameInterfacePath), localizedContent);
  }

  /// <summary>
  /// Converts the provided input into a Data Transfer Object, then serializes it, then writes it.
  /// </summary>
  private void SerializeAndWrite<TInput, TDataTransferObject>(TInput inputValue, string outputDirectoryPath, string fileName)
  {
    if (!Directory.Exists(outputDirectoryPath))
    {
      Directory.CreateDirectory(outputDirectoryPath);
    }

    var dataTransferObject = mapper.Map<TInput, TDataTransferObject>(inputValue);
    var asJson = JsonSerializer.Serialize(dataTransferObject, _jsonSerializerOptions);
    var fullPath = Path.Combine(outputDirectoryPath, fileName);
    File.WriteAllText(fullPath, asJson);
  }

  private void SerializeAndWritePreviewIcons(MapPreviewIcons mapPreviewIcons, string path)
  {
    var dto = mapper.Map<MapPreviewIcons, MapPreviewIconsDto>(mapPreviewIcons);
    dto.Icons = dto.Icons
      .OrderByDescending(x => x.IconType)
      .ThenByDescending(x => x.X)
      .ThenByDescending(x => x.Y)
      .ToList();
    var asJson = JsonSerializer.Serialize(dto, _jsonSerializerOptions);
    File.WriteAllText(path, asJson);
  }

  private void SerializeAndWriteMapInfo(MapInfo mapInfo, MapInfoMapper mapInfoMapper, string path)
  {
    var dto = mapInfoMapper.MapToDto(mapInfo);
    var asJson = JsonSerializer.Serialize(dto, _jsonSerializerOptions);
    File.WriteAllText(path, asJson);
  }

  private void SerializeAndWriteUnits(MapUnits units, string path)
  {
    if (!Directory.Exists(path))
    {
      Directory.CreateDirectory(path);
    }

    SerializeAndWriteInChunks(units.Units, path, mapper.Map<UnitDataDto[]>);
  }

  private void SerializeAndWriteDoodads(MapDoodads doodads, string path)
  {
    if (!Directory.Exists(path))
    {
      Directory.CreateDirectory(path);
    }

    SerializeAndWriteInChunks(doodads.Doodads, path, mapper.Map<DoodadDataDto[]>);
  }

  private void SerializeAndWriteSounds(MapSounds sounds, string path)
  {
    foreach (var sound in sounds.Sounds)
    {
      SerializeAndWrite<Sound, SoundDto>(sound, path, $"{sound.Name.Remove(0, 7)}.json");
    }
  }

  private void SerializeAndWriteRegions(MapRegions regions, string path)
  {
    foreach (var region in regions.Regions)
    {
      SerializeAndWrite<Region, RegionDto>(region, path, $"{region.Name}.json");
    }
  }

  private void SerializeAndWriteUnitData(string path, UnitObjectData objectData)
  {
    SerializeAndWriteModifications(path, objectData.BaseUnits);
    SerializeAndWriteModifications(path, objectData.NewUnits);
  }

  private void SerializeAndWriteBuffData(string path, BuffObjectData objectData)
  {
    SerializeAndWriteModifications(path, objectData.BaseBuffs);
    SerializeAndWriteModifications(path, objectData.NewBuffs);
  }

  private void SerializeAndWriteDoodadData(string path, DoodadObjectData objectData)
  {
    SerializeAndWriteModifications(path, objectData.BaseDoodads);
    SerializeAndWriteModifications(path, objectData.NewDoodads);
  }

  private void SerializeAndWriteDestructableData(string path, DestructableObjectData objectData)
  {
    SerializeAndWriteModifications(path, objectData.BaseDestructables);
    SerializeAndWriteModifications(path, objectData.NewDestructables);
  }

  private void SerializeAndWriteItemData(string path, ItemObjectData objectData)
  {
    SerializeAndWriteModifications(path, objectData.BaseItems);
    SerializeAndWriteModifications(path, objectData.NewItems);
  }

  private void SerializeAndWriteAbilityData(string path, AbilityObjectData objectData)
  {
    SerializeAndWriteModifications(path, objectData.BaseAbilities);
    SerializeAndWriteModifications(path, objectData.NewAbilities);
  }

  private void SerializeAndWriteUpgradeData(string path, UpgradeObjectData objectData)
  {
    SerializeAndWriteModifications(path, objectData.BaseUpgrades);
    SerializeAndWriteModifications(path, objectData.NewUpgrades);
  }

  private void SerializeAndWriteModifications(string path, IEnumerable<VariationObjectModification> modifications)
  {
    foreach (var modification in modifications)
    {
      SerializeAndWriteModification(path, modification);
    }
  }

  private void SerializeAndWriteModifications(string path, IEnumerable<LevelObjectModification> modifications)
  {
    foreach (var modification in modifications)
    {
      SerializeAndWriteModification(path, modification);
    }
  }

  private void SerializeAndWriteModifications(string path, IEnumerable<SimpleObjectModification> modifications)
  {
    foreach (var modification in modifications)
    {
      SerializeAndWriteModification(path, modification);
    }
  }

  private void SerializeAndWriteModification(string path, SimpleObjectModification modification)
  {
    SerializeAndWriteModification(path, modification, m => m.GetId().ToRawcode());
  }

  private void SerializeAndWriteModification(string path, VariationObjectModification modification)
  {
    SerializeAndWriteModification(path, modification, m => m.GetId().ToRawcode());
  }

  private void SerializeAndWriteModification(string path, LevelObjectModification modification)
  {
    SerializeAndWriteModification(path, modification, m => m.GetId().ToRawcode());
  }

  private void SerializeAndWriteModification<T>(string path, T modification, Func<T, string> fileNameSelector)
    where T : notnull
  {
    if (!Directory.Exists(path))
    {
      Directory.CreateDirectory(path);
    }

    SerializeAndWrite(Path.Combine(path, $"{fileNameSelector(modification)}.json"), modification);
  }

  private void SerializeAndWriteInChunks<T>(IEnumerable<T> widgets, string path, Func<IEnumerable<T>, object>? mapper = null)
    where T : WidgetData
  {
    foreach (var (chunkCoords, widgetsInChunk) in new ChunkedWidgetSet<T>(widgets))
    {
      SerializeAndWrite(Path.Combine(path, $"{chunkCoords.X}_{chunkCoords.Y}.json"), mapper?.Invoke(widgetsInChunk) ?? widgetsInChunk);
    }
  }

  private void SerializeAndWrite(string path, object value)
  {
    File.WriteAllText(path, JsonSerializer.Serialize(value, _jsonSerializerOptions));
  }

  private static void Merge(
    List<LevelObjectModification> target,
    List<LevelObjectModification> source,
    TriggerStrings? triggerStrings)
  {
    Merge(
      target,
      source,
      modification => modification.ToString(),
      modification => modification.Modifications,
      triggerStrings);
  }

  private static void Merge(
    List<SimpleObjectModification> target,
    List<SimpleObjectModification> source,
    TriggerStrings? triggerStrings)
  {
    Merge(
      target,
      source,
      modification => modification.ToString(),
      modification => modification.Modifications,
      triggerStrings);
  }

  private static void Merge(
    List<VariationObjectModification> target,
    List<VariationObjectModification> source,
    TriggerStrings? triggerStrings)
  {
    Merge(
      target,
      source,
      modification => modification.ToString(),
      modification => modification.Modifications,
      triggerStrings);
  }

  private static void Merge<T, TT>(
    List<T> target,
    List<T> source,
    Func<T, string> keySelector,
    Func<T, List<TT>> modSelector,
    TriggerStrings? triggerStrings = null)
  where TT : ObjectDataModification
  {
    if (target.Count == 0 || source.Count == 0)
    {
      return;
    }

    var sourceObjects = new Dictionary<string, T>(source.Count, StringComparer.Ordinal);

    foreach (var sourceObject in source)
    {
      sourceObjects[keySelector(sourceObject)] = sourceObject;
    }

    foreach (var targetObject in target)
    {
      if (!sourceObjects.TryGetValue(keySelector(targetObject), out var sourceObject))
      {
        continue;
      }

      var targetMods = modSelector(targetObject);
      var sourceMods = modSelector(sourceObject);

      if (triggerStrings != null)
      {
        LocalizeModifications(targetMods, triggerStrings);
        LocalizeModifications(sourceMods, triggerStrings);
      }

      targetMods.AddRange(sourceMods);
    }
  }

  private static void LocalizeModifications<T>(IEnumerable<T> modifications, TriggerStrings triggerStrings)
    where T : ObjectDataModification
  {
    foreach (var modification in modifications)
    {
      if (modification.Type == ObjectDataType.String)
      {
        modification.Value = modification.ValueAsString.Localize(triggerStrings);
      }
    }
  }
}
