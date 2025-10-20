#nullable enable
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

  private readonly JsonSerializerOptions _jsonSerializerOptions = new()
  {
    IgnoreReadOnlyProperties = true,
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
    WriteIndented = true,
    Converters = { new ColorJsonConverter() }
  };

  public W3XToMapDataConverter(IMapper mapper)
  {
    _mapper = mapper;
  }

  /// <summary>
  /// Converts the provided Warcraft 3 map to JSON and saves it in the specified folder.
  /// </summary>
  public void Convert(string baseMapPath, string outputFolderPath)
  {
    var map = Map.Open(baseMapPath);
    var triggerStrings = map.TriggerStrings.ToDictionary();
    SerializeAndWriteMapData(map, triggerStrings, outputFolderPath);

    CopyImportedFiles(baseMapPath, outputFolderPath);
    CopyUnserializableFiles(baseMapPath, outputFolderPath);
    CopyGameInterface(baseMapPath, triggerStrings, outputFolderPath);
  }

  private void SerializeAndWriteMapData(Map map, TriggerStringDictionary triggerStrings, string outputFolderPath)
  {
    if (Directory.Exists(outputFolderPath))
    {
      Directory.Delete(outputFolderPath, true);
    }

    var objectDataMapper = new ObjectDataMapper(triggerStrings);

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
      SerializeAndWriteMapInfo(map.Info, new MapInfoMapper(triggerStrings), Path.Combine(outputFolderPath, InfoPath));
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

    if (map.UnitObjectData != null)
    {
      SerializeAndWriteUnitData(map.UnitObjectData, map.UnitSkinObjectData, objectDataMapper,
        outputFolderPath, UnitDataDirectoryPath);
    }

    if (map.AbilityObjectData != null)
    {
      SerializeAndWriteAbilityData(map.AbilityObjectData, map.AbilitySkinObjectData, objectDataMapper,
        outputFolderPath, AbilityDataDirectoryPath);
    }

    if (map.ItemObjectData != null)
    {
      SerializeAndWriteItemData(map.ItemObjectData, map.ItemSkinObjectData, objectDataMapper,
        outputFolderPath, ItemDataDirectoryPath);
    }

    if (map.DestructableObjectData != null)
    {
      SerializeAndWriteDestructableData(map.DestructableObjectData, map.DestructableSkinObjectData, objectDataMapper,
        outputFolderPath, DestructableDataDirectoryPath);
    }

    if (map.DoodadObjectData != null)
    {
      SerializeAndWriteDoodadData(map.DoodadObjectData, map.DoodadSkinObjectData, objectDataMapper,
        outputFolderPath, DoodadDataDirectoryPath);
    }

    if (map.BuffObjectData != null)
    {
      SerializeAndWriteBuffData(map.BuffObjectData, map.BuffSkinObjectData, objectDataMapper,
        outputFolderPath, BuffDataDirectoryPath);
    }

    if (map.UpgradeObjectData != null)
    {
      SerializeAndWriteUpgradeData(map.UpgradeObjectData, map.UpgradeSkinObjectData, objectDataMapper,
        outputFolderPath, UpgradeDataDirectoryPath);
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

  private static void CopyGameInterface(string baseMapPath, TriggerStringDictionary triggerStringDictionary, string outputFolderPath)
  {
    var gameInterfacePath = Path.Combine(baseMapPath, GameInterfacePath);
    if (!File.Exists(gameInterfacePath))
    {
      return;
    }

    var subtitutedText = triggerStringDictionary.SubstituteTriggerStringsInText(File.ReadAllText(gameInterfacePath));
    File.WriteAllText(Path.Combine(outputFolderPath, GameInterfacePath), subtitutedText);
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

    var dataTransferObject = _mapper.Map<TInput, TDataTransferObject>(inputValue);
    var asJson = JsonSerializer.Serialize(dataTransferObject, _jsonSerializerOptions);
    var fullPath = Path.Combine(outputDirectoryPath, fileName);
    File.WriteAllText(fullPath, asJson);
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

    var positionallyChunkedUnitCollection = new PositionallyChunkedUnitSet(ChunkSize);

    foreach (var unit in units.Units)
    {
      var asDto = _mapper.Map<UnitDataDto>(unit);
      positionallyChunkedUnitCollection.Add(asDto);
    }

    foreach (var (chunk, unitSet) in positionallyChunkedUnitCollection.GetAll())
    {
      var fullPath = Path.Combine(path, $"{chunk.Item1}_{chunk.Item2}.json");
      var asJson = JsonSerializer.Serialize(unitSet, _jsonSerializerOptions);
      File.WriteAllText(fullPath, asJson);
    }
  }

  private void SerializeAndWriteDoodads(MapDoodads doodads, string path)
  {
    if (!Directory.Exists(path))
    {
      Directory.CreateDirectory(path);
    }

    var positionallyChunkedUnitCollection = new PositionallyChunkedDoodadSet(ChunkSize);

    foreach (var doodad in doodads.Doodads)
    {
      var asDto = _mapper.Map<DoodadDataDto>(doodad);
      positionallyChunkedUnitCollection.Add(asDto);
    }

    foreach (var (chunk, doodadSet) in positionallyChunkedUnitCollection.GetAll())
    {
      var fullPath = Path.Combine(path, $"{chunk.Item1}_{chunk.Item2}.json");
      var asJson = JsonSerializer.Serialize(doodadSet, _jsonSerializerOptions);
      File.WriteAllText(fullPath, asJson);
    }
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
}
