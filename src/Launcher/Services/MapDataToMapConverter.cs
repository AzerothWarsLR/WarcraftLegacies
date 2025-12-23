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
using Launcher.Paths;
using War3Net.Build;
using War3Net.Build.Audio;
using War3Net.Build.Environment;
using War3Net.Build.Info;
using War3Net.Build.Object;
using War3Net.Build.Script;
using War3Net.Build.Widget;
using static Launcher.Paths.PathConventions;

namespace Launcher.Services;

/// <summary>
///   Converts collections of loose files into a <see cref="Map" />.
/// </summary>
public sealed class MapDataToMapConverter(MapDataToMapConverterOptions options, IMapper mapper)
{
  private readonly JsonSerializerOptions _jsonSerializerOptions = new()
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

  /// <summary>
  ///   Converts the provided JSON data into a <see cref="Map" /> and a set of additional files that should be included
  ///   in the output, such as imported textures.
  /// </summary>
  public (Map Map, IEnumerable<PathData> AdditionalFiles) ConvertToMapAndAdditionalFiles()
  {
    var map = ConvertToMap();
    var additionalFiles = GetAdditionalFiles();
    return (map, additionalFiles);
  }

  /// <summary>
  ///   Converts the provided JSON data into a <see cref="Map" /> and a set of directories containing any additional
  ///   files that should be included in the output, such as imported textures.
  /// </summary>
  public (Map Map, IEnumerable<DirectoryEnumerationOptions> AdditionalFiles) ConvertToMapAndAdditionalFileDirectories()
  {
    var map = ConvertToMap();
    var additionalFiles = GetAdditionalFileDirectories();
    return (map, additionalFiles);
  }

  private Map ConvertToMap()
  {
    var map = new Map
    {
      Sounds = DeserializeSounds(),
      Environment = DeserializeFromFile<MapEnvironment, MapEnvironmentDto>(options.MapDataPaths.EnvironmentPath),
      PathingMap = DeserializeFromFile<MapPathingMap, MapPathingMapDto>(options.MapDataPaths.PathingMapPath),
      PreviewIcons = DeserializeFromFile<MapPreviewIcons, MapPreviewIconsDto>(options.MapDataPaths.PreviewIconsPath),
      Regions = DeserializeRegions(),
      ShadowMap = DeserializeFromFile<MapShadowMap, MapShadowMapDto>(options.MapDataPaths.ShadowMapPath),
      Info = DeserializeFromFile<MapInfo, MapInfoDto>(options.MapDataPaths.InfoPath),
      Doodads = DeserializeDoodads(),
      Units = DeserializeUnits(),
      Triggers = GenerateEmptyMapTriggers(),

      AbilityObjectData = DeserializeAbilityData(),
      BuffObjectData = DeserializeBuffData(),
      DestructableObjectData = DeserializeDestructableData(),
      DoodadObjectData = DeserializeDoodadData(),
      ItemObjectData = DeserializeItemData(),
      UnitObjectData = DeserializeUnitData(),
      UpgradeObjectData = DeserializeUpgradeData()
    };
    return map;
  }

  private MapDoodads DeserializeDoodads()
  {
    var mapDoodads = new MapDoodads(MapWidgetsFormatVersion.v8, MapWidgetsSubVersion.v11, true);
    var files = Directory.EnumerateFiles(options.MapDataPaths.DoodadsPath, "*", SearchOption.AllDirectories);
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
        var doodad = mapper.Map<DoodadData>(doodadDto);
        mapDoodads.Doodads.Add(doodad);
      }
    }
    return mapDoodads;
  }

  private MapUnits DeserializeUnits()
  {
    var mapUnits = new MapUnits(MapWidgetsFormatVersion.v8, MapWidgetsSubVersion.v11, true);
    var files = Directory.EnumerateFiles(options.MapDataPaths.UnitsPath, "*", SearchOption.AllDirectories);
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
        var unit = mapper.Map<UnitData>(unitDto);
        mapUnits.Units.Add(unit);
      }
    }
    return mapUnits;
  }

  private MapRegions? DeserializeRegions()
  {
    var directory = options.MapDataPaths.RegionsPath;
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
      var region = mapper.Map<Region>(dataTransferObject);
      regions.Regions.Add(region);
    }
    return regions;
  }

  private MapSounds? DeserializeSounds()
  {
    var directory = options.MapDataPaths.SoundsPath;
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
      var sound = mapper.Map<Sound>(dataTransferObject);
      sounds.Sounds.Add(sound);
    }
    return sounds;
  }

  private UpgradeObjectData DeserializeUpgradeData()
  {
    var objectData = new UpgradeObjectData(ObjectDataFormatVersion.v3);
    var files = Directory.EnumerateFiles(options.MapDataPaths.UpgradeDataPath, "*", SearchOption.AllDirectories);
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

  private ItemObjectData? DeserializeItemData()
  {
    var directory = options.MapDataPaths.ItemDataPath;
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

  private DoodadObjectData? DeserializeDoodadData()
  {
    var directory = options.MapDataPaths.DoodadDataPath;
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
        throw new JsonException($"File {file} could not be serialized to {nameof(VariationObjectModification)}.");
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

  private DestructableObjectData? DeserializeDestructableData()
  {
    var directory = options.MapDataPaths.DestructableDataPath;
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

  private BuffObjectData? DeserializeBuffData()
  {
    var directory = options.MapDataPaths.BuffDataPath;
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

  private AbilityObjectData DeserializeAbilityData()
  {
    var objectData = new AbilityObjectData(ObjectDataFormatVersion.v3);
    var files = Directory.EnumerateFiles(options.MapDataPaths.AbilityDataPath, "*", SearchOption.AllDirectories);
    foreach (var file in files)
    {
      var fileContents = File.ReadAllText(file);
      var objectModification = JsonSerializer.Deserialize<LevelObjectModification>(fileContents, _jsonSerializerOptions);

      if (objectModification == null)
      {
        throw new JsonException($"File {file} could not be serialized to {nameof(LevelObjectModification)}.");
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

  private UnitObjectData DeserializeUnitData()
  {
    var objectData = new UnitObjectData(ObjectDataFormatVersion.v3);
    var files = Directory.EnumerateFiles(options.MapDataPaths.UnitDataPath, "*", SearchOption.AllDirectories);
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

  private List<PathData> GetAdditionalFiles()
  {
    var importsDirectory = options.MapDataPaths.ImportsPath;

    var additionalFiles = Directory.Exists(importsDirectory)
      ? Directory.EnumerateFiles(importsDirectory, "*", SearchOption.AllDirectories).Select(x => new PathData
      {
        AbsolutePath = x,
        RelativePath = Path.GetRelativePath(importsDirectory, x)
      }).ToList()
      : [];

    foreach (var filePath in GetUnserializableFilePaths())
    {
      additionalFiles.Add(new PathData
      {
        AbsolutePath = Path.Combine(options.MapDataPaths.RootPath, filePath),
        RelativePath = filePath
      });
    }

    return additionalFiles;
  }

  private List<DirectoryEnumerationOptions> GetAdditionalFileDirectories()
  {
    var importsDirectory = options.MapDataPaths.ImportsPath;

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
        Path = options.MapDataPaths.RootPath,
        SearchPattern = filePath
      });
    }

    fileDirectories.Add(new DirectoryEnumerationOptions
    {
      Path = options.MapDataPaths.RootPath,
      SearchPattern = MapData.GameInterface
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
    return mapper.Map<TReturn>(dto);
  }

  private static MapTriggers GenerateEmptyMapTriggers()
  {
    return new MapTriggers(MapTriggersFormatVersion.v7, MapTriggersSubVersion.v4)
    {
      GameVersion = 2,
      Variables = [],
      TriggerItems = [],
      TriggerItemCounts = new Dictionary<TriggerItemType, int>()
    };
  }
}
