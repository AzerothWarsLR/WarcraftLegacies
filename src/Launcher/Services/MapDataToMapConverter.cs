#nullable enable
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using AutoMapper;
using Launcher.DataTransferObjects;
using Launcher.JsonConverters;
using War3Net.Build;
using War3Net.Build.Audio;
using War3Net.Build.Environment;
using War3Net.Build.Info;
using War3Net.Build.Object;
using War3Net.Build.Script;
using War3Net.Build.Widget;
using static Launcher.MapDataPaths;

namespace Launcher.Services;

/// <summary>
///   Converts collections of loose files into a <see cref="Map" />.
/// </summary>
public sealed class MapDataToMapConverter
{
  private readonly IMapper _mapper;

  private readonly JsonSerializerOptions _jsonSerializerOptions;

  public MapDataToMapConverter(IMapper mapper)
  {
    _mapper = mapper;
    _jsonSerializerOptions = new JsonSerializerOptions
    {
      IgnoreReadOnlyProperties = true,
      DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
      WriteIndented = true,
      TypeInfoResolver = new DefaultJsonTypeInfoResolver
      {
        Modifiers = { JsonModifierProvider.CastModificationSets }
      },
      Converters = { new ColorJsonConverter() }
    };
  }

  /// <summary>
  ///   Converts the provided JSON data into a <see cref="Map" /> and a set of additional files that should be included
  ///   in the output, such as imported textures.
  /// </summary>
  public (Map Map, IEnumerable<PathData> AdditionalFiles) ConvertToMapAndAdditionalFiles(string mapDataRootDirectory)
  {
    var map = ConvertToMap(mapDataRootDirectory);
    var additionalFiles = GetAdditionalFiles(mapDataRootDirectory);
    return (map, additionalFiles);
  }

  /// <summary>
  ///   Converts the provided JSON data into a <see cref="Map" /> and a set of directories containing any additional
  ///   files that should be includedin the output, such as imported textures.
  /// </summary>
  public (Map Map, IEnumerable<DirectoryEnumerationOptions> AdditionalFiles) ConvertToMapAndAdditionalFileDirectories(
    string mapDataRootDirectory)
  {
    var map = ConvertToMap(mapDataRootDirectory);
    var additionalFiles = GetAdditionalFileDirectories(mapDataRootDirectory);
    return (map, additionalFiles);
  }

  private Map ConvertToMap(string mapDataRootDirectory)
  {
    var map = new Map
    {
      Sounds = DeserializeSoundsFromDirectory(Path.Combine(mapDataRootDirectory, SoundsDirectoryPath)),
      Environment = DeserializeFromFile<MapEnvironment, MapEnvironmentDto>(Path.Combine(mapDataRootDirectory, EnvironmentPath)),
      PathingMap = DeserializeFromFile<MapPathingMap, MapPathingMapDto>(Path.Combine(mapDataRootDirectory, PathingMapPath)),
      PreviewIcons = DeserializeFromFile<MapPreviewIcons, MapPreviewIconsDto>(Path.Combine(mapDataRootDirectory, PreviewIconsPath)),
      Regions = DeserializeRegionsFromDirectory(Path.Combine(mapDataRootDirectory, RegionsDirectoryPath)),
      ShadowMap = DeserializeFromFile<MapShadowMap, MapShadowMapDto>(Path.Combine(mapDataRootDirectory, ShadowMapPath)),
      Info = DeserializeFromFile<MapInfo, MapInfoDto>(Path.Combine(mapDataRootDirectory, InfoPath)),
      TriggerStrings = DeserializeTriggerStringsFromDirectory(Path.Combine(mapDataRootDirectory, TriggerStringsDirectoryPath)),
      Doodads = DeserializeDoodadsFromDirectory(Path.Combine(mapDataRootDirectory, DoodadsDirectoryPath)),
      Units = DeserializeUnitsFromDirectory(Path.Combine(mapDataRootDirectory, UnitsDirectoryPath)),
      Triggers = GenerateEmptyMapTriggers(),

      AbilityObjectData = DeserializeAbilityDataFromDirectory(Path.Combine(mapDataRootDirectory, AbilityDataDirectoryPath)),
      BuffObjectData = DeserializeBuffDataFromDirectory(Path.Combine(mapDataRootDirectory, BuffDataDirectoryPath)),
      DestructableObjectData = DeserializeDestructableDataFromDirectory(Path.Combine(mapDataRootDirectory, DestructableDataDirectoryPath)),
      DoodadObjectData = DeserializeDoodadDataFromDirectory(Path.Combine(mapDataRootDirectory, DoodadDataDirectoryPath)),
      ItemObjectData = DeserializeItemDataFromDirectory(Path.Combine(mapDataRootDirectory, ItemDataDirectoryPath)),
      UnitObjectData = DeserializeUnitDataFromDirectory(Path.Combine(mapDataRootDirectory, UnitDataDirectoryPath)),
      UpgradeObjectData = DeserializeUpgradeDataFromDirectory(Path.Combine(mapDataRootDirectory, UpgradeDataDirectoryPath))
    };
    return map;
  }

  private TriggerStrings? DeserializeTriggerStringsFromDirectory(string directory)
  {
    if (!Directory.Exists(directory))
    {
      return null;
    }

    var triggerStrings = new TriggerStrings();
    var files = Directory.EnumerateFiles(directory, "*", SearchOption.AllDirectories);
    foreach (var file in files)
    {
      var fileContents = File.ReadAllText(file);
      var triggerString = JsonSerializer.Deserialize<TriggerString>(fileContents, _jsonSerializerOptions);
      triggerStrings.Strings.Add(triggerString);
    }
    return triggerStrings;
  }

  private MapDoodads DeserializeDoodadsFromDirectory(string directory)
  {
    var mapDoodads = new MapDoodads(MapWidgetsFormatVersion.v8, MapWidgetsSubVersion.v11, true);
    var files = Directory.EnumerateFiles(directory, "*", SearchOption.AllDirectories);
    foreach (var file in files)
    {
      var fileContents = File.ReadAllText(file);
      var doodadDtoSet = JsonSerializer.Deserialize<HashSet<DoodadDataDto>>(fileContents, _jsonSerializerOptions);

      if (doodadDtoSet == null)
      {
        throw new JsonException($"File {file} could not be serialized to {nameof(HashSet<DoodadDataDto>)}.");
      }

      foreach (var doodadDto in doodadDtoSet)
      {
        var doodad = _mapper.Map<DoodadData>(doodadDto);
        mapDoodads.Doodads.Add(doodad);
      }
    }
    return mapDoodads;
  }

  private MapUnits DeserializeUnitsFromDirectory(string directory)
  {
    var mapUnits = new MapUnits(MapWidgetsFormatVersion.v8, MapWidgetsSubVersion.v11, true);
    var files = Directory.EnumerateFiles(directory, "*", SearchOption.AllDirectories);
    foreach (var file in files)
    {
      var fileContents = File.ReadAllText(file);
      var unitDtoSet = JsonSerializer.Deserialize<HashSet<UnitDataDto>>(fileContents, _jsonSerializerOptions);

      if (unitDtoSet == null)
      {
        throw new JsonException($"File {file} could not be serialized to {nameof(HashSet<UnitDataDto>)}.");
      }

      foreach (var unitDto in unitDtoSet)
      {
        var unit = _mapper.Map<UnitData>(unitDto);
        mapUnits.Units.Add(unit);
      }
    }
    return mapUnits;
  }

  private MapRegions? DeserializeRegionsFromDirectory(string directory)
  {
    if (!Directory.Exists(directory))
    {
      return null;
    }

    var regions = new MapRegions(MapRegionsFormatVersion.v5);
    var files = Directory.EnumerateFiles(directory, "*", SearchOption.AllDirectories);
    foreach (var file in files)
    {
      var fileContents = File.ReadAllText(file);
      var dataTransferObject = JsonSerializer.Deserialize<RegionDto>(fileContents, _jsonSerializerOptions);
      var region = _mapper.Map<Region>(dataTransferObject);
      regions.Regions.Add(region);
    }
    return regions;
  }

  private MapSounds? DeserializeSoundsFromDirectory(string directory)
  {
    if (!Directory.Exists(directory))
    {
      return null;
    }

    var sounds = new MapSounds(MapSoundsFormatVersion.v3);
    var files = Directory.EnumerateFiles(directory, "*", SearchOption.AllDirectories);
    foreach (var file in files)
    {
      var fileContents = File.ReadAllText(file);
      var dataTransferObject = JsonSerializer.Deserialize<SoundDto>(fileContents, _jsonSerializerOptions);
      var sound = _mapper.Map<Sound>(dataTransferObject);
      sounds.Sounds.Add(sound);
    }
    return sounds;
  }

  private UpgradeObjectData DeserializeUpgradeDataFromDirectory(string directory)
  {
    var objectData = new UpgradeObjectData(ObjectDataFormatVersion.v3);
    var files = Directory.EnumerateFiles(directory, "*", SearchOption.AllDirectories);
    foreach (var file in files)
    {
      var fileContents = File.ReadAllText(file);
      var objectModification = JsonSerializer.Deserialize<LevelObjectModification>(fileContents, _jsonSerializerOptions);

      if (objectModification == null)
      {
        throw new JsonException($"File {file} could not be serialized to {nameof(SimpleObjectModification)}.");
      }

      if (objectModification.NewId == 0)
      {
        objectData.BaseUpgrades.Add(objectModification);
      }
      else
      {
        objectData.NewUpgrades.Add(objectModification);
      }
    }

    return objectData;
  }

  private ItemObjectData? DeserializeItemDataFromDirectory(string directory)
  {
    if (!Directory.Exists(directory))
    {
      return null;
    }

    var objectData = new ItemObjectData(ObjectDataFormatVersion.v3);
    var files = Directory.EnumerateFiles(directory, "*", SearchOption.AllDirectories);
    foreach (var file in files)
    {
      var fileContents = File.ReadAllText(file);
      var objectModification = JsonSerializer.Deserialize<SimpleObjectModification>(fileContents, _jsonSerializerOptions);

      if (objectModification == null)
      {
        throw new JsonException($"File {file} could not be serialized to {nameof(SimpleObjectModification)}.");
      }

      if (objectModification.NewId == 0)
      {
        objectData.BaseItems.Add(objectModification);
      }
      else
      {
        objectData.NewItems.Add(objectModification);
      }
    }

    return objectData;
  }

  private DoodadObjectData? DeserializeDoodadDataFromDirectory(string directory)
  {
    if (!Directory.Exists(directory))
    {
      return null;
    }

    var objectData = new DoodadObjectData(ObjectDataFormatVersion.v3);
    var files = Directory.EnumerateFiles(directory, "*", SearchOption.AllDirectories);
    foreach (var file in files)
    {
      var fileContents = File.ReadAllText(file);
      var objectModification = JsonSerializer.Deserialize<VariationObjectModification>(fileContents, _jsonSerializerOptions);

      if (objectModification == null)
      {
        throw new JsonException($"File {file} could not be serialized to {nameof(SimpleObjectModification)}.");
      }

      if (objectModification.NewId == 0)
      {
        objectData.BaseDoodads.Add(objectModification);
      }
      else
      {
        objectData.NewDoodads.Add(objectModification);
      }
    }

    return objectData;
  }

  private DestructableObjectData? DeserializeDestructableDataFromDirectory(string directory)
  {
    if (!Directory.Exists(directory))
    {
      return null;
    }

    var objectData = new DestructableObjectData(ObjectDataFormatVersion.v3);
    var files = Directory.EnumerateFiles(directory, "*", SearchOption.AllDirectories);
    foreach (var file in files)
    {
      var fileContents = File.ReadAllText(file);
      var objectModification = JsonSerializer.Deserialize<SimpleObjectModification>(fileContents, _jsonSerializerOptions);

      if (objectModification == null)
      {
        throw new JsonException($"File {file} could not be serialized to {nameof(SimpleObjectModification)}.");
      }

      if (objectModification.NewId == 0)
      {
        objectData.BaseDestructables.Add(objectModification);
      }
      else
      {
        objectData.NewDestructables.Add(objectModification);
      }
    }

    return objectData;
  }

  private BuffObjectData? DeserializeBuffDataFromDirectory(string directory)
  {
    if (!Directory.Exists(directory))
    {
      return null;
    }

    var objectData = new BuffObjectData(ObjectDataFormatVersion.v3);
    var files = Directory.EnumerateFiles(directory, "*", SearchOption.AllDirectories);
    foreach (var file in files)
    {
      var fileContents = File.ReadAllText(file);
      var objectModification = JsonSerializer.Deserialize<SimpleObjectModification>(fileContents, _jsonSerializerOptions);

      if (objectModification == null)
      {
        throw new JsonException($"File {file} could not be serialized to {nameof(SimpleObjectModification)}.");
      }

      if (objectModification.NewId == 0)
      {
        objectData.BaseBuffs.Add(objectModification);
      }
      else
      {
        objectData.NewBuffs.Add(objectModification);
      }
    }

    return objectData;
  }

  private AbilityObjectData DeserializeAbilityDataFromDirectory(string directory)
  {
    var objectData = new AbilityObjectData(ObjectDataFormatVersion.v3);
    var files = Directory.EnumerateFiles(directory, "*", SearchOption.AllDirectories);
    foreach (var file in files)
    {
      var fileContents = File.ReadAllText(file);
      var objectModification = JsonSerializer.Deserialize<LevelObjectModification>(fileContents, _jsonSerializerOptions);

      if (objectModification == null)
      {
        throw new JsonException($"File {file} could not be serialized to {nameof(SimpleObjectModification)}.");
      }

      if (objectModification.NewId == 0)
      {
        objectData.BaseAbilities.Add(objectModification);
      }
      else
      {
        objectData.NewAbilities.Add(objectModification);
      }
    }

    return objectData;
  }

  private UnitObjectData DeserializeUnitDataFromDirectory(string directory)
  {
    var objectData = new UnitObjectData(ObjectDataFormatVersion.v3);
    var files = Directory.EnumerateFiles(directory, "*", SearchOption.AllDirectories);
    foreach (var file in files)
    {
      var fileContents = File.ReadAllText(file);
      var objectModification = JsonSerializer.Deserialize<SimpleObjectModification>(fileContents, _jsonSerializerOptions);

      if (objectModification == null)
      {
        throw new JsonException($"File {file} could not be serialized to {nameof(SimpleObjectModification)}.");
      }

      if (objectModification.NewId == 0)
      {
        objectData.BaseUnits.Add(objectModification);
      }
      else
      {
        objectData.NewUnits.Add(objectModification);
      }
    }

    return objectData;
  }

  private static IEnumerable<PathData> GetAdditionalFiles(string mapDataRootDirectory)
  {
    var importsDirectory = Path.Combine(mapDataRootDirectory, ImportsPath);

    var additionalFiles = Directory.Exists(importsDirectory)
      ? Directory.EnumerateFiles(importsDirectory, "*", SearchOption.AllDirectories).Select(x => new PathData
      {
        AbsolutePath = x,
        RelativePath = Path.GetRelativePath(importsDirectory, x)
      }).ToList()
      : new List<PathData>();

    foreach (var filePath in GetUnserializableFilePaths())
    {
      additionalFiles.Add(new PathData
      {
        AbsolutePath = Path.Combine(mapDataRootDirectory, filePath),
        RelativePath = filePath
      });
    }

    additionalFiles.Add(new PathData()
    {
      AbsolutePath = Path.Combine(mapDataRootDirectory, GameInterfacePath),
      RelativePath = GameInterfacePath
    });

    return additionalFiles;
  }

  private static IEnumerable<DirectoryEnumerationOptions> GetAdditionalFileDirectories(string mapDataRootDirectory)
  {
    var importsDirectory = Path.Combine(mapDataRootDirectory, ImportsPath);

    var fileDirectories = Directory.Exists(importsDirectory)
      ? new List<DirectoryEnumerationOptions>
      {
        new()
        {
          Path = importsDirectory,
          SearchPattern = "*"
        }
      }
      : new List<DirectoryEnumerationOptions>();

    foreach (var filePath in GetUnserializableFilePaths())
    {
      fileDirectories.Add(new DirectoryEnumerationOptions
      {
        Path = mapDataRootDirectory,
        SearchPattern = filePath
      });
    }

    fileDirectories.Add(new DirectoryEnumerationOptions
    {
      Path = mapDataRootDirectory,
      SearchPattern = GameInterfacePath
    });

    return fileDirectories;
  }

  private TReturn? DeserializeFromFile<TReturn, TDataTransferObject>(string filePath)
  {
    if (!File.Exists(filePath))
    {
      return default;
    }

    var dto = JsonSerializer.Deserialize<TDataTransferObject>(File.ReadAllText(filePath), _jsonSerializerOptions);
    return _mapper.Map<TReturn>(dto);
  }

  private static MapTriggers GenerateEmptyMapTriggers()
  {
    return new MapTriggers(MapTriggersFormatVersion.v7, MapTriggersSubVersion.v4)
    {
      GameVersion = 2,
      Variables = new List<VariableDefinition>(),
      TriggerItems = new List<TriggerItem>(),
      TriggerItemCounts = new Dictionary<TriggerItemType, int>()
    };
  }
}
