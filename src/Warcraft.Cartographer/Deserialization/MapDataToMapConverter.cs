using War3Net.Build;
using War3Net.Build.Audio;
using War3Net.Build.Environment;
using War3Net.Build.Info;
using War3Net.Build.Object;
using War3Net.Build.Script;
using War3Net.Build.Widget;
using Warcraft.Cartographer.Json;
using Warcraft.Cartographer.Paths;
using static Warcraft.Cartographer.Paths.PathConventions;

namespace Warcraft.Cartographer.Deserialization;

/// <summary>
///   Converts collections of loose files into a <see cref="Map" />.
/// </summary>
public sealed class MapDataToMapConverter(MapDataToMapConverterOptions options)
{
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
      Environment = JsonHelper.DeserializeIfExist<MapEnvironment>(options.MapDataPaths.EnvironmentPath),
      PathingMap = JsonHelper.DeserializeIfExist<MapPathingMap>(options.MapDataPaths.PathingMapPath),
      PreviewIcons = JsonHelper.DeserializeIfExist<MapPreviewIcons>(options.MapDataPaths.PreviewIconsPath),
      Regions = DeserializeRegions(),
      ShadowMap = JsonHelper.DeserializeIfExist<MapShadowMap>(options.MapDataPaths.ShadowMapPath),
      Info = JsonHelper.DeserializeIfExist<MapInfo>(options.MapDataPaths.GetEffectiveRootFilePath(options.MapDataPaths.InfoPath)),
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

  private MapDoodads? DeserializeDoodads()
  {
    if (!options.IncludeFromMap.HasFlag(IncludeFromMap.Doodads))
    {
      return null;
    }

    var mapDoodads = new MapDoodads(MapWidgetsFormatVersion.v8, MapWidgetsSubVersion.v11, true);
    foreach (var file in options.MapDataPaths.EnumerateLocalizedFiles(options.MapDataPaths.DoodadsPath))
    {
      mapDoodads.Doodads.AddRange(JsonHelper.Deserialize<DoodadData[]>(file));
    }
    return mapDoodads;
  }

  private MapUnits? DeserializeUnits()
  {
    if (!options.IncludeFromMap.HasFlag(IncludeFromMap.Units))
    {
      return null;
    }

    var mapUnits = new MapUnits(MapWidgetsFormatVersion.v8, MapWidgetsSubVersion.v11, true);
    foreach (var file in options.MapDataPaths.EnumerateLocalizedFiles(options.MapDataPaths.UnitsPath))
    {
      mapUnits.Units.AddRange(JsonHelper.Deserialize<UnitData[]>(file));
    }
    return mapUnits;
  }

  private MapRegions? DeserializeRegions()
  {
    if (!options.IncludeFromMap.HasFlag(IncludeFromMap.Regions) || !Directory.Exists(options.MapDataPaths.RegionsPath))
    {
      return null;
    }

    var mapRegions = new MapRegions(MapRegionsFormatVersion.v5);
    foreach (var file in options.MapDataPaths.EnumerateLocalizedFiles(options.MapDataPaths.RegionsPath))
    {
      mapRegions.Regions.Add(JsonHelper.Deserialize<Region>(file));
    }
    return mapRegions;
  }

  private MapSounds? DeserializeSounds()
  {
    var directory = options.MapDataPaths.SoundsPath;
    if (!options.IncludeFromMap.HasFlag(IncludeFromMap.Sounds) || !Directory.Exists(directory))
    {
      return null;
    }

    var sounds = new MapSounds(MapSoundsFormatVersion.v3);
    foreach (var file in options.MapDataPaths.EnumerateLocalizedFiles(directory))
    {
      sounds.Sounds.AddRange(JsonHelper.Deserialize<Sound>(file));
    }
    return sounds;
  }

  private UpgradeObjectData? DeserializeUpgradeData()
  {
    if (!options.IncludeFromMap.HasFlag(IncludeFromMap.UpgradeData))
    {
      return null;
    }

    var objectData = new UpgradeObjectData(ObjectDataFormatVersion.v3);
    foreach (var file in options.MapDataPaths.EnumerateLocalizedObjectFiles(options.MapDataPaths.UpgradeDataPath))
    {
      var objectModification = ReadLevelObjectRecord(file);
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
    if (!options.IncludeFromMap.HasFlag(IncludeFromMap.ItemData) || !Directory.Exists(directory))
    {
      return null;
    }

    var objectData = new ItemObjectData(ObjectDataFormatVersion.v3);
    foreach (var file in options.MapDataPaths.EnumerateLocalizedObjectFiles(directory))
    {
      var objectModification = ReadObjectRecord(file);
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
    if (!options.IncludeFromMap.HasFlag(IncludeFromMap.DoodadData) || !Directory.Exists(directory))
    {
      return null;
    }

    var objectData = new DoodadObjectData(ObjectDataFormatVersion.v3);
    var files = options.MapDataPaths.EnumerateLocalizedFiles(directory, "*", SearchOption.AllDirectories);
    foreach (var file in files)
    {
      var objectModification = JsonHelper.Deserialize<VariationObjectModification>(file);
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
    if (!options.IncludeFromMap.HasFlag(IncludeFromMap.DestructableData) || !Directory.Exists(directory))
    {
      return null;
    }

    var objectData = new DestructableObjectData(ObjectDataFormatVersion.v3);
    foreach (var file in options.MapDataPaths.EnumerateLocalizedObjectFiles(directory))
    {
      var objectModification = ReadObjectRecord(file);
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
    if (!options.IncludeFromMap.HasFlag(IncludeFromMap.BuffData) || !Directory.Exists(directory))
    {
      return null;
    }

    var objectData = new BuffObjectData(ObjectDataFormatVersion.v3);
    foreach (var file in options.MapDataPaths.EnumerateLocalizedObjectFiles(directory))
    {
      var objectModification = ReadObjectRecord(file);
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

  private AbilityObjectData? DeserializeAbilityData()
  {
    if (!options.IncludeFromMap.HasFlag(IncludeFromMap.AbilityData))
    {
      return null;
    }

    var objectData = new AbilityObjectData(ObjectDataFormatVersion.v3);
    foreach (var file in options.MapDataPaths.EnumerateLocalizedObjectFiles(options.MapDataPaths.AbilityDataPath))
    {
      var objectModification = ReadLevelObjectRecord(file);
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

  /// <summary>
  /// Reads one object record, letting the locale overlay replace individual fields rather than the whole record.
  /// <para>
  /// A translation only has to list the fields it changes, so the overlay stays a sparse diff and every field it
  /// leaves out keeps its base value. A field the overlay adds is kept even when the base record has none, which
  /// is what allows a translation to supply text the base map data inherits from the game.
  /// </para>
  /// </summary>
  private static SimpleObjectModification ReadObjectRecord(LocalizedObjectFile file)
  {
    if (file.OverlayPath is null)
    {
      return JsonHelper.Deserialize<SimpleObjectModification>(file.EffectivePath);
    }

    if (file.BasePath is null)
    {
      return JsonHelper.Deserialize<SimpleObjectModification>(file.OverlayPath);
    }

    var baseRecord = JsonHelper.Deserialize<SimpleObjectModification>(file.BasePath);
    var overlayRecord = JsonHelper.Deserialize<SimpleObjectModification>(file.OverlayPath);

    var merged = new Dictionary<(int Id, int Level, ObjectDataType Type), SimpleObjectDataModification>();
    var order = new List<(int Id, int Level, ObjectDataType Type)>();

    foreach (var modification in baseRecord.Modifications)
    {
      var key = (modification.Id, 0, modification.Type);
      merged[key] = modification;
      order.Add(key);
    }

    foreach (var modification in overlayRecord.Modifications)
    {
      var key = (modification.Id, 0, modification.Type);
      if (!merged.ContainsKey(key))
      {
        order.Add(key);
      }

      merged[key] = modification;
    }

    return new SimpleObjectModification
    {
      OldId = baseRecord.OldId,
      NewId = baseRecord.NewId,
      Unk = baseRecord.Unk,
      Modifications = order.Select(key => merged[key]).ToList()
    };
  }

  /// <summary>
  /// Reads one level-based object record, letting the locale overlay replace individual fields per level.
  /// </summary>
  private static LevelObjectModification ReadLevelObjectRecord(LocalizedObjectFile file)
  {
    if (file.OverlayPath is null)
    {
      return JsonHelper.Deserialize<LevelObjectModification>(file.EffectivePath);
    }

    if (file.BasePath is null)
    {
      return JsonHelper.Deserialize<LevelObjectModification>(file.OverlayPath);
    }

    var baseRecord = JsonHelper.Deserialize<LevelObjectModification>(file.BasePath);
    LevelObjectModification overlayRecord;
    try
    {
      overlayRecord = JsonHelper.Deserialize<LevelObjectModification>(file.OverlayPath);
    }
    catch (System.Text.Json.JsonException exception)
    {
      throw new System.InvalidOperationException($"Failed to read overlay '{file.OverlayPath}'.", exception);
    }

    var merged = new Dictionary<(int Id, int Level, ObjectDataType Type), LevelObjectDataModification>();
    var order = new List<(int Id, int Level, ObjectDataType Type)>();

    foreach (var modification in baseRecord.Modifications)
    {
      var key = (modification.Id, modification.Level, modification.Type);
      merged[key] = modification;
      order.Add(key);
    }

    foreach (var modification in overlayRecord.Modifications)
    {
      var key = (modification.Id, modification.Level, modification.Type);
      if (!merged.ContainsKey(key))
      {
        order.Add(key);
      }

      merged[key] = modification;
    }

    return new LevelObjectModification
    {
      OldId = baseRecord.OldId,
      NewId = baseRecord.NewId,
      Unk = baseRecord.Unk,
      Modifications = order.Select(key => merged[key]).ToList()
    };
  }

  private UnitObjectData? DeserializeUnitData()
  {
    if (!options.IncludeFromMap.HasFlag(IncludeFromMap.UnitData))
    {
      return null;
    }

    var objectData = new UnitObjectData(ObjectDataFormatVersion.v3);
    foreach (var file in options.MapDataPaths.EnumerateLocalizedObjectFiles(options.MapDataPaths.UnitDataPath))
    {
      var objectModification = ReadObjectRecord(file);
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

  /// <summary>
  /// Adds a file that lives directly in the map data root, honouring the locale overlay.
  /// </summary>
  private void AddRootFile(List<PathData> additionalFiles, string relativePath)
  {
    var basePath = Path.Combine(options.MapDataPaths.RootPath, relativePath);

    additionalFiles.Add(new PathData
    {
      AbsolutePath = options.MapDataPaths.GetEffectiveRootFilePath(basePath),
      RelativePath = relativePath
    });
  }

  private List<PathData> GetAdditionalFiles()
  {
    var additionalFiles = new List<PathData>();

    if (options.IncludeFromMap.HasFlag(IncludeFromMap.Imports))
    {
      var importsDirectory = options.MapDataPaths.ImportsPath;

      additionalFiles.AddRange(Directory.EnumerateFiles(importsDirectory, "*", SearchOption.AllDirectories).Select(x => new PathData
      {
        AbsolutePath = x,
        RelativePath = Path.GetRelativePath(importsDirectory, x)
      }).ToList());
    }

    if (options.IncludeFromMap.HasFlag(IncludeFromMap.Minimap))
    {
      AddRootFile(additionalFiles, MapData.Minimap);
    }

    if (options.IncludeFromMap.HasFlag(IncludeFromMap.GameplayConstants))
    {
      AddRootFile(additionalFiles, MapData.GameplayConstants);
    }

    if (options.IncludeFromMap.HasFlag(IncludeFromMap.GameInterface))
    {
      AddRootFile(additionalFiles, MapData.GameInterface);
    }

    return additionalFiles;
  }

  private List<DirectoryEnumerationOptions> GetAdditionalFileDirectories()
  {
    List<DirectoryEnumerationOptions> fileDirectories = [];

    if (options.IncludeFromMap.HasFlag(IncludeFromMap.Imports))
    {
      var importsDirectory = options.MapDataPaths.ImportsPath;
      fileDirectories.AddRange(new List<DirectoryEnumerationOptions>
      {
        new()
        {
          Path = importsDirectory,
          SearchPattern = "*"
        }
      });
    }

    if (options.IncludeFromMap.HasFlag(IncludeFromMap.Minimap))
    {
      AddRootFileDirectory(fileDirectories, MapData.Minimap);
    }

    if (options.IncludeFromMap.HasFlag(IncludeFromMap.GameplayConstants))
    {
      AddRootFileDirectory(fileDirectories, MapData.GameplayConstants);
    }

    if (options.IncludeFromMap.HasFlag(IncludeFromMap.GameInterface))
    {
      AddRootFileDirectory(fileDirectories, MapData.GameInterface);
    }

    return fileDirectories;
  }

  /// <summary>
  /// Adds a root-level file to the output, honouring the locale overlay.
  /// </summary>
  private void AddRootFileDirectory(List<DirectoryEnumerationOptions> fileDirectories, string relativePath)
  {
    var basePath = Path.Combine(options.MapDataPaths.RootPath, relativePath);
    var localizedPath = options.MapDataPaths.GetLocalizedRootFilePath(basePath);

    if (File.Exists(localizedPath))
    {
      fileDirectories.Add(new DirectoryEnumerationOptions
      {
        Path = Path.GetDirectoryName(localizedPath)!,
        SearchPattern = Path.GetFileName(localizedPath)
      });
      return;
    }

    fileDirectories.Add(new DirectoryEnumerationOptions
    {
      Path = options.MapDataPaths.RootPath,
      SearchPattern = relativePath
    });
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
