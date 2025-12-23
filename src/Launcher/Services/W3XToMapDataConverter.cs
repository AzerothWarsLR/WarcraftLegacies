#nullable enable
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using AutoMapper;
using Launcher.DataTransferObjects;
using Launcher.DTOMappers;
using Launcher.Extensions;
using Launcher.JsonConverters;
using War3Net.Build;
using War3Net.Build.Audio;
using War3Net.Build.Environment;
using War3Net.Build.Info;
using War3Net.Build.Object;
using War3Net.Build.Widget;
using War3Net.Common.Extensions;
using static Launcher.MapDataPaths;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Launcher.Services;

/// <summary>
/// Converts a Warcraft 3 map into a collection of loose files so that they can be stored in version control.
/// </summary>
public sealed class W3XToMapDataConverter
{
  private readonly IMapper _mapper;
  private readonly W3XToMapDataConverterOptions _options;

  private readonly JsonSerializerOptions _jsonSerializerOptions = new()
  {
    IgnoreReadOnlyProperties = true,
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
    WriteIndented = true,
    Converters = { new ColorJsonConverter() }
  };

  public W3XToMapDataConverter(IMapper mapper, W3XToMapDataConverterOptions options)
  {
    _mapper = mapper;
    _options = options;
  }

  /// <summary>
  /// Converts the provided Warcraft 3 map to JSON and saves it in the specified folder.
  /// </summary>
  public void Convert(string baseMapPath)
  {
    var map = Map.Open(baseMapPath);
    var triggerStrings = map.TriggerStrings.ToDictionary();
    SerializeAndWriteMapData(map, triggerStrings);

    CopyImportedFiles(baseMapPath);
    CopyUnserializableFiles(baseMapPath);
  }

  private void SerializeAndWriteMapData(Map map, TriggerStringDictionary triggerStrings)
  {
    var objectDataMapper = new ObjectDataMapper(triggerStrings);

    if (map.Doodads != null)
    {
      SerializeAndWriteDoodads(map.Doodads, _options.MapDataPathOptions.DoodadsPath);
    }

    if (map.Environment != null)
    {
      SerializeAndWrite<MapEnvironment, MapEnvironmentDto>(map.Environment, _options.MapDataPathOptions.EnvironmentPath);
    }

    if (map.Info != null)
    {
      SerializeAndWriteMapInfo(map.Info, new MapInfoMapper(triggerStrings));
    }

    if (map.Regions != null)
    {
      SerializeAndWriteRegions(map.Regions);
    }

    if (map.Units != null)
    {
      SerializeAndWriteUnits(map.Units, _options.MapDataPathOptions.UnitsPath);
    }

    if (map.PathingMap != null)
    {
      SerializeAndWrite<MapPathingMap, MapPathingMapDto>(map.PathingMap, _options.MapDataPathOptions.PathingMapPath);
    }

    if (map.PreviewIcons != null)
    {
      SerializeAndWritePreviewIcons(map.PreviewIcons, _options.MapDataPathOptions.PreviewIconsPath);
    }

    if (map.ShadowMap != null)
    {
      SerializeAndWrite<MapShadowMap, MapShadowMapDto>(map.ShadowMap, _options.MapDataPathOptions.ShadowMapPath);
    }

    if (map.Sounds != null)
    {
      SerializeAndWriteSounds(map.Sounds);
    }

    if (map.UnitObjectData != null)
    {
      SerializeAndWriteUnitData(map.UnitObjectData, map.UnitSkinObjectData, objectDataMapper, _options.MapDataPathOptions.UnitDataPath);
    }

    if (map.AbilityObjectData != null)
    {
      SerializeAndWriteAbilityData(map.AbilityObjectData, map.AbilitySkinObjectData, objectDataMapper, _options.MapDataPathOptions.AbilityDataPath);
    }

    if (map.ItemObjectData != null)
    {
      SerializeAndWriteItemData(map.ItemObjectData, map.ItemSkinObjectData, objectDataMapper, _options.MapDataPathOptions.ItemDataPath);
    }

    if (map.DestructableObjectData != null)
    {
      SerializeAndWriteDestructableData(map.DestructableObjectData, map.DestructableSkinObjectData, objectDataMapper, _options.MapDataPathOptions.DestructableDataPath);
    }

    if (map.DoodadObjectData != null)
    {
      SerializeAndWriteDoodadData(map.DoodadObjectData, map.DoodadSkinObjectData, objectDataMapper, _options.MapDataPathOptions.DoodadDataPath);
    }

    if (map.BuffObjectData != null)
    {
      SerializeAndWriteBuffData(map.BuffObjectData, map.BuffSkinObjectData, objectDataMapper, _options.MapDataPathOptions.BuffDataPath);
    }

    if (map.UpgradeObjectData != null)
    {
      SerializeAndWriteUpgradeData(map.UpgradeObjectData, map.UpgradeSkinObjectData, objectDataMapper, _options.MapDataPathOptions.UpgradeDataPath);
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

      var destinationFileName = Path.Combine(_options.MapDataPathOptions.ImportsPath, relativePath);
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

      var fullOutputFilePath = Path.Combine(_options.MapDataPathOptions.RootPath, filePath);
      File.Copy(fullSourceFilePath, fullOutputFilePath, true);
    }
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

    var dataTransferObject = _mapper.Map<TInput, TDataTransferObject>(inputValue);
    var asJson = JsonSerializer.Serialize(dataTransferObject, _jsonSerializerOptions);
    File.WriteAllText(filePath, asJson);
  }

  private void SerializeAndWritePreviewIcons(MapPreviewIcons mapPreviewIcons, string path)
  {
    var dto = _mapper.Map<MapPreviewIcons, MapPreviewIconsDto>(mapPreviewIcons);
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
    File.WriteAllText(_options.MapDataPathOptions.InfoPath, asJson);
  }

  private void SerializeAndWriteUnits(MapUnits units, string path)
  {
    if (!Directory.Exists(path))
    {
      Directory.CreateDirectory(path);
    }

    SerializeAndWriteInChunks(units.Units, path, widgets => _mapper.Map<UnitDataDto[]>(widgets));
  }

  private void SerializeAndWriteDoodads(MapDoodads doodads, string path)
  {
    if (!Directory.Exists(path))
    {
      Directory.CreateDirectory(path);
    }

    SerializeAndWriteInChunks(doodads.Doodads, path, widgets => _mapper.Map<DoodadDataDto[]>(widgets));
  }

  private void SerializeAndWriteSounds(MapSounds sounds)
  {
    foreach (var sound in sounds.Sounds)
    {
      SerializeAndWrite<Sound, SoundDto>(sound, Path.Combine(_options.MapDataPathOptions.SoundsPath, $"{sound.Name.Remove(0, 7)}.json"));
    }
  }

  private void SerializeAndWriteRegions(MapRegions regions)
  {
    foreach (var region in regions.Regions)
    {
      SerializeAndWrite<Region, RegionDto>(region, Path.Combine(_options.MapDataPathOptions.RegionsPath, $"{region.Name}.json"));
    }
  }

  private void SerializeAndWriteUnitData(UnitObjectData unitObjectData, UnitObjectData? unitSkinObjectData, ObjectDataMapper objectDataMapper,
    params string[] paths)
  {
    var dto = objectDataMapper.MapToDto(unitObjectData, unitSkinObjectData);

    foreach (var unit in dto.Units)
    {
      SerializeAndWriteSimpleObjectModification(unit, Path.Combine(paths));
    }
  }

  private void SerializeAndWriteBuffData(BuffObjectData buffObjectData, BuffObjectData? buffSkinObjectdata, ObjectDataMapper objectDataMapper,
    params string[] paths)
  {
    var dto = objectDataMapper.MapToDto(buffObjectData, buffSkinObjectdata);

    foreach (var buff in dto.Buffs)
    {
      SerializeAndWriteSimpleObjectModification(buff, Path.Combine(paths));
    }
  }

  private void SerializeAndWriteDoodadData(DoodadObjectData doodadObjectData, DoodadObjectData? doodadSkinObjectData, ObjectDataMapper objectDataMapper,
    params string[] paths)
  {
    var dto = objectDataMapper.MapToDto(doodadObjectData, doodadSkinObjectData);

    foreach (var doodad in dto.Doodads)
    {
      SerializeAndWriteVariationObjectModification(doodad, Path.Combine(paths));
    }
  }

  private void SerializeAndWriteDestructableData(DestructableObjectData destructableObjectData, DestructableObjectData? destructableSkinObjectData,
    ObjectDataMapper objectDataMapper, params string[] paths)
  {
    var dto = objectDataMapper.MapToDto(destructableObjectData, destructableSkinObjectData);

    foreach (var destructable in dto.Destructables)
    {
      SerializeAndWriteSimpleObjectModification(destructable, Path.Combine(paths));
    }
  }

  private void SerializeAndWriteItemData(ItemObjectData itemObjectData, ItemObjectData? itemSkinObjectData, ObjectDataMapper objectDataMapper,
    params string[] paths)
  {
    var dto = objectDataMapper.MapToDto(itemObjectData, itemSkinObjectData);

    foreach (var item in dto.Items)
    {
      SerializeAndWriteSimpleObjectModification(item, Path.Combine(paths));
    }
  }

  private void SerializeAndWriteAbilityData(AbilityObjectData abilityObjectData, AbilityObjectData? abilitySkinObjectData, ObjectDataMapper objectDataMapper,
    params string[] paths)
  {
    var dto = objectDataMapper.MapToDto(abilityObjectData, abilitySkinObjectData);

    foreach (var ability in dto.Abilities)
    {
      SerializeAndWriteLevelObjectModification(ability, Path.Combine(paths));
    }
  }

  private void SerializeAndWriteUpgradeData(UpgradeObjectData upgradeObjectData, UpgradeObjectData? upgradeSkinObjectData, ObjectDataMapper objectDataMapper,
    params string[] paths)
  {
    var dto = objectDataMapper.MapToDto(upgradeObjectData, upgradeSkinObjectData);

    foreach (var upgrade in dto.Upgrades)
    {
      SerializeAndWriteLevelObjectModification(upgrade, Path.Combine(paths));
    }
  }

  private void SerializeAndWriteSimpleObjectModification(SimpleObjectModification simpleObject, string outputDirectoryPath)
  {
    if (!Directory.Exists(outputDirectoryPath))
    {
      Directory.CreateDirectory(outputDirectoryPath);
    }

    var id = simpleObject.NewId > 0 ? simpleObject.NewId : simpleObject.OldId;
    var asJson = JsonSerializer.Serialize(simpleObject, _jsonSerializerOptions);
    var fullPath = Path.Combine(outputDirectoryPath, $"{id.ToRawcode()}.json");
    File.WriteAllText(fullPath, asJson);
  }

  private void SerializeAndWriteVariationObjectModification(VariationObjectModification variationObject, string outputDirectoryPath)
  {
    if (!Directory.Exists(outputDirectoryPath))
    {
      Directory.CreateDirectory(outputDirectoryPath);
    }

    var id = variationObject.NewId > 0 ? variationObject.NewId : variationObject.OldId;
    var asJson = JsonSerializer.Serialize(variationObject, _jsonSerializerOptions);
    var fullPath = Path.Combine(outputDirectoryPath, $"{id.ToRawcode()}.json");
    File.WriteAllText(fullPath, asJson);
  }

  private void SerializeAndWriteLevelObjectModification(LevelObjectModification levelObjectModification, string outputDirectoryPath)
  {
    if (!Directory.Exists(outputDirectoryPath))
    {
      Directory.CreateDirectory(outputDirectoryPath);
    }

    var id = levelObjectModification.NewId > 0 ? levelObjectModification.NewId : levelObjectModification.OldId;
    var asJson = JsonSerializer.Serialize(levelObjectModification, _jsonSerializerOptions);
    var fullPath = Path.Combine(outputDirectoryPath, $"{id.ToRawcode()}.json");
    File.WriteAllText(fullPath, asJson);
  }

  private void SerializeAndWriteInChunks<T>(IEnumerable<T> widgets, string path, Func<IEnumerable<T>, object>? mapper = null)
    where T : WidgetData
  {
    var chunkedWidgets = new ChunkedWidgetSet<T>(widgets);

    foreach (var (chunkCoords, widgetsInChunk) in chunkedWidgets)
    {
      var serializedChunk = JsonSerializer.Serialize(mapper?.Invoke(widgetsInChunk) ?? widgetsInChunk, _jsonSerializerOptions);
      File.WriteAllText(Path.Combine(path, $"{chunkCoords.X}_{chunkCoords.Y}.json"), serializedChunk);
    }
  }
}
