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
using Launcher.Extensions;
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
using static Launcher.Paths.PathConventions;

namespace Launcher.Services;

/// <summary>
/// Converts a Warcraft 3 map into a collection of loose files so that they can be stored in version control.
/// </summary>
public sealed class W3XToMapDataConverter(IMapper mapper, W3XToMapDataConverterOptions options)
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
      SerializeAndWrite<MapEnvironment, MapEnvironmentDto>(map.Environment, options.MapDataPaths.EnvironmentPath);
    }

    if (map.Info != null)
    {
      SerializeAndWriteMapInfo(map.Info, new MapInfoMapper(map.TriggerStrings));
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
      SerializeAndWrite<MapPathingMap, MapPathingMapDto>(map.PathingMap, options.MapDataPaths.PathingMapPath);
    }

    if (map.PreviewIcons != null)
    {
      SerializeAndWritePreviewIcons(map.PreviewIcons, options.MapDataPaths.PreviewIconsPath);
    }

    if (map.ShadowMap != null)
    {
      SerializeAndWrite<MapShadowMap, MapShadowMapDto>(map.ShadowMap, options.MapDataPaths.ShadowMapPath);
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

  /// <summary>
  /// Converts the provided input into a Data Transfer Object, then serializes it, then writes it.
  /// </summary>
  private void SerializeAndWrite<TInput, TDataTransferObject>(TInput inputValue, string filePath)
  {
    var directory = Path.GetDirectoryName(filePath)!;
    if (!Directory.Exists(directory))
    {
      Directory.CreateDirectory(directory);
    }

    var dataTransferObject = mapper.Map<TInput, TDataTransferObject>(inputValue);
    var asJson = JsonSerializer.Serialize(dataTransferObject, _jsonSerializerOptions);
    File.WriteAllText(filePath, asJson);
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

  private void SerializeAndWriteMapInfo(MapInfo mapInfo, MapInfoMapper mapInfoMapper)
  {
    var dto = mapInfoMapper.MapToDto(mapInfo);
    var asJson = JsonSerializer.Serialize(dto, _jsonSerializerOptions);
    File.WriteAllText(options.MapDataPaths.InfoPath, asJson);
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

  private void SerializeAndWriteSounds(MapSounds sounds)
  {
    foreach (var sound in sounds.Sounds)
    {
      SerializeAndWrite<Sound, SoundDto>(sound, Path.Combine(options.MapDataPaths.SoundsPath, $"{sound.Name.Remove(0, 7)}.json"));
    }
  }

  private void SerializeAndWriteRegions(MapRegions regions)
  {
    foreach (var region in regions.Regions)
    {
      SerializeAndWrite<Region, RegionDto>(region, Path.Combine(options.MapDataPaths.RegionsPath, $"{region.Name}.json"));
    }
  }

  private void SerializeAndWriteUnitData(UnitObjectData objectData)
  {
    var path = options.MapDataPaths.UnitDataPath;
    SerializeAndWriteModifications(path, objectData.BaseUnits);
    SerializeAndWriteModifications(path, objectData.NewUnits);
  }

  private void SerializeAndWriteBuffData(BuffObjectData objectData)
  {
    var path = options.MapDataPaths.BuffDataPath;
    SerializeAndWriteModifications(path, objectData.BaseBuffs);
    SerializeAndWriteModifications(path, objectData.NewBuffs);
  }

  private void SerializeAndWriteDoodadData(DoodadObjectData objectData)
  {
    var path = options.MapDataPaths.DoodadDataPath;
    SerializeAndWriteModifications(path, objectData.BaseDoodads);
    SerializeAndWriteModifications(path, objectData.NewDoodads);
  }

  private void SerializeAndWriteDestructableData(DestructableObjectData objectData)
  {
    var path = options.MapDataPaths.DestructableDataPath;
    SerializeAndWriteModifications(path, objectData.BaseDestructables);
    SerializeAndWriteModifications(path, objectData.NewDestructables);
  }

  private void SerializeAndWriteItemData(ItemObjectData objectData)
  {
    var path = options.MapDataPaths.ItemDataPath;
    SerializeAndWriteModifications(path, objectData.BaseItems);
    SerializeAndWriteModifications(path, objectData.NewItems);
  }

  private void SerializeAndWriteAbilityData(AbilityObjectData objectData)
  {
    var path = options.MapDataPaths.AbilityDataPath;
    SerializeAndWriteModifications(path, objectData.BaseAbilities);
    SerializeAndWriteModifications(path, objectData.NewAbilities);
  }

  private void SerializeAndWriteUpgradeData(UpgradeObjectData objectData)
  {
    var path = options.MapDataPaths.UpgradeDataPath;
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
}
