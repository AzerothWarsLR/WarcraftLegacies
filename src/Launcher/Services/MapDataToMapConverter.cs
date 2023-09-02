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
using War3Net.Build.Import;
using War3Net.Build.Info;
using War3Net.Build.Object;
using War3Net.Build.Script;
using War3Net.Build.Widget;
using static Launcher.MapDataPaths;

namespace Launcher.Services
{
  /// <summary>
  ///   Converts collections of loose files into a <see cref="Map" />.
  /// </summary>
  public sealed class MapDataToMapConverter
  {
    private readonly IMapper _mapper;

    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public MapDataToMapConverter(IMapper mapper, JsonModifierProvider jsonModifierProvider)
    {
      _mapper = mapper;
      _jsonSerializerOptions = new JsonSerializerOptions
      {
        IgnoreReadOnlyProperties = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
        WriteIndented = true,
        TypeInfoResolver = new DefaultJsonTypeInfoResolver
        {
          Modifiers = { jsonModifierProvider.CastModificationSets }
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
        Sounds = null,
        Environment = DeserializeFromFile<MapEnvironment, MapEnvironmentDto>(Path.Combine(mapDataRootDirectory, EnvironmentPath)),
        PathingMap = DeserializeFromFile<MapPathingMap, MapPathingMapDto>(Path.Combine(mapDataRootDirectory, PathingMapPath)),
        PreviewIcons = DeserializeFromFile<MapPreviewIcons, MapPreviewIconsDto>(Path.Combine(mapDataRootDirectory, PreviewIconsPath)),
        Regions = DeserializeFromFile<MapRegions, MapRegionsDto>(Path.Combine(mapDataRootDirectory, RegionsPath)),
        ShadowMap = DeserializeFromFile<MapShadowMap, MapShadowMapDto>(Path.Combine(mapDataRootDirectory, ShadowMapPath)),
        ImportedFiles = DeserializeFromFile<ImportedFiles, MapImportedFilesDto>(Path.Combine(mapDataRootDirectory, ImportedFilesPath)),
        Info = DeserializeFromFile<MapInfo, MapInfoDto>(Path.Combine(mapDataRootDirectory, InfoPath)),
        CustomTextTriggers = DeserializeFromFile<MapCustomTextTriggers, MapCustomTextTriggersDto>(Path.Combine(mapDataRootDirectory, CustomTextTriggersPath)),
        TriggerStrings = DeserializeFromFile<TriggerStrings, MapTriggerStringsDto>(Path.Combine(mapDataRootDirectory, TriggerStringsPath)),
        Doodads = DeserializeFromFile<MapDoodads, MapDoodadsDto>(Path.Combine(mapDataRootDirectory, DoodadsPath)),
        Units = DeserializeFromFile<MapUnits, MapUnitsDto>(Path.Combine(mapDataRootDirectory, UnitsPath)),
        Triggers = GenerateEmptyMapTriggers(),
        
        AbilityObjectData = DeserializeAbilityDataFromDirectory(Path.Combine(mapDataRootDirectory, AbilityDataDirectoryPath, CoreDataDirectorySubPath)),
        BuffObjectData = DeserializeBuffDataFromDirectory(Path.Combine(mapDataRootDirectory, BuffDataDirectoryPath, CoreDataDirectorySubPath)),
        DestructableObjectData = DeserializeDestructableDataFromDirectory(Path.Combine(mapDataRootDirectory, DestructableDataDirectoryPath, CoreDataDirectorySubPath)),
        DoodadObjectData = DeserializeDoodadDataFromDirectory(Path.Combine(mapDataRootDirectory, DoodadDataDirectoryPath, CoreDataDirectorySubPath)),
        ItemObjectData = DeserializeItemDataFromDirectory(Path.Combine(mapDataRootDirectory, ItemDataDirectoryPath, CoreDataDirectorySubPath)),
        UnitObjectData = DeserializeUnitDataFromDirectory(Path.Combine(mapDataRootDirectory, UnitDataDirectoryPath, CoreDataDirectorySubPath)),
        UpgradeObjectData = DeserializeUpgradeDataFromDirectory(Path.Combine(mapDataRootDirectory, UpgradeDataDirectoryPath, CoreDataDirectorySubPath)),
        
        AbilitySkinObjectData = DeserializeAbilityDataFromDirectory(Path.Combine(mapDataRootDirectory, AbilityDataDirectoryPath, SkinDataDirectorySubPath)),
        BuffSkinObjectData = DeserializeBuffDataFromDirectory(Path.Combine(mapDataRootDirectory, BuffDataDirectoryPath, SkinDataDirectorySubPath)),
        DestructableSkinObjectData = DeserializeDestructableDataFromDirectory(Path.Combine(mapDataRootDirectory, DestructableDataDirectoryPath, SkinDataDirectorySubPath)),
        DoodadSkinObjectData = DeserializeDoodadDataFromDirectory(Path.Combine(mapDataRootDirectory, DoodadDataDirectoryPath, SkinDataDirectorySubPath)),
        ItemSkinObjectData = DeserializeItemDataFromDirectory(Path.Combine(mapDataRootDirectory, ItemDataDirectoryPath, SkinDataDirectorySubPath)),
        UnitSkinObjectData = DeserializeUnitDataFromDirectory(Path.Combine(mapDataRootDirectory, UnitDataDirectoryPath, SkinDataDirectorySubPath)),
        UpgradeSkinObjectData = DeserializeUpgradeDataFromDirectory(Path.Combine(mapDataRootDirectory, UpgradeDataDirectoryPath, SkinDataDirectorySubPath)),
        Script = File.ReadAllText(Path.Combine(mapDataRootDirectory, ScriptPath))
      };
      return map;
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
          throw new JsonException($"File {file} could not be serialized to {nameof(SimpleObjectModification)}.");
        
        if (objectModification.NewId == 0)
          objectData.BaseUpgrades.Add(objectModification);
        else
          objectData.NewUpgrades.Add(objectModification);
      }

      return objectData;
    }

    private ItemObjectData DeserializeItemDataFromDirectory(string directory)
    {
      var objectData = new ItemObjectData(ObjectDataFormatVersion.v3);
      var files = Directory.EnumerateFiles(directory, "*", SearchOption.AllDirectories);
      foreach (var file in files)
      {
        var fileContents = File.ReadAllText(file);
        var objectModification = JsonSerializer.Deserialize<SimpleObjectModification>(fileContents, _jsonSerializerOptions);

        if (objectModification == null)
          throw new JsonException($"File {file} could not be serialized to {nameof(SimpleObjectModification)}.");
        
        if (objectModification.NewId == 0)
          objectData.BaseItems.Add(objectModification);
        else
          objectData.NewItems.Add(objectModification);
      }

      return objectData;
    }

    private DoodadObjectData DeserializeDoodadDataFromDirectory(string directory)
    {
      var objectData = new DoodadObjectData(ObjectDataFormatVersion.v3);
      var files = Directory.EnumerateFiles(directory, "*", SearchOption.AllDirectories);
      foreach (var file in files)
      {
        var fileContents = File.ReadAllText(file);
        var objectModification = JsonSerializer.Deserialize<VariationObjectModification>(fileContents, _jsonSerializerOptions);

        if (objectModification == null)
          throw new JsonException($"File {file} could not be serialized to {nameof(SimpleObjectModification)}.");
        
        if (objectModification.NewId == 0)
          objectData.BaseDoodads.Add(objectModification);
        else
          objectData.NewDoodads.Add(objectModification);
      }

      return objectData;
    }

    private DestructableObjectData DeserializeDestructableDataFromDirectory(string directory)
    {
      var objectData = new DestructableObjectData(ObjectDataFormatVersion.v3);
      var files = Directory.EnumerateFiles(directory, "*", SearchOption.AllDirectories);
      foreach (var file in files)
      {
        var fileContents = File.ReadAllText(file);
        var objectModification = JsonSerializer.Deserialize<SimpleObjectModification>(fileContents, _jsonSerializerOptions);

        if (objectModification == null)
          throw new JsonException($"File {file} could not be serialized to {nameof(SimpleObjectModification)}.");
        
        if (objectModification.NewId == 0)
          objectData.BaseDestructables.Add(objectModification);
        else
          objectData.NewDestructables.Add(objectModification);
      }

      return objectData;
    }

    private BuffObjectData DeserializeBuffDataFromDirectory(string directory)
    {
      var objectData = new BuffObjectData(ObjectDataFormatVersion.v3);
      var files = Directory.EnumerateFiles(directory, "*", SearchOption.AllDirectories);
      foreach (var file in files)
      {
        var fileContents = File.ReadAllText(file);
        var objectModification = JsonSerializer.Deserialize<SimpleObjectModification>(fileContents, _jsonSerializerOptions);

        if (objectModification == null)
          throw new JsonException($"File {file} could not be serialized to {nameof(SimpleObjectModification)}.");
        
        if (objectModification.NewId == 0)
          objectData.BaseBuffs.Add(objectModification);
        else
          objectData.NewBuffs.Add(objectModification);
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
          throw new JsonException($"File {file} could not be serialized to {nameof(SimpleObjectModification)}.");
        
        if (objectModification.NewId == 0)
          objectData.BaseAbilities.Add(objectModification);
        else
          objectData.NewAbilities.Add(objectModification);
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
          throw new JsonException($"File {file} could not be serialized to {nameof(SimpleObjectModification)}.");
        
        if (objectModification.NewId == 0)
          objectData.BaseUnits.Add(objectModification);
        else
          objectData.NewUnits.Add(objectModification);
      }

      return objectData;
    }
    
    private static IEnumerable<PathData> GetAdditionalFiles(string mapDataRootDirectory)
    {
      var importsDirectory = $@"{mapDataRootDirectory}\{ImportsPath}";

      var additionalFiles = Directory.Exists(importsDirectory)
        ? Directory.EnumerateFiles(importsDirectory, "*", SearchOption.AllDirectories).Select(x => new PathData
        {
          AbsolutePath = x,
          RelativePath = Path.GetRelativePath(importsDirectory, x)
        }).ToList()
        : new List<PathData>();

      additionalFiles.Add(new PathData
      {
        AbsolutePath = Path.Combine(mapDataRootDirectory, "war3mapMap.blp"),
        RelativePath = "war3mapMap.blp"
      });
      return additionalFiles;
    }
    
    private static IEnumerable<DirectoryEnumerationOptions> GetAdditionalFileDirectories(string mapDataRootDirectory)
    {
      var importsDirectory = $@"{mapDataRootDirectory}\{ImportsPath}";

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
      
      fileDirectories.Add(new DirectoryEnumerationOptions
      {
        Path = mapDataRootDirectory,
        SearchPattern = "war3mapMap.blp"
      });
      return fileDirectories;
    }

    private TReturn DeserializeFromFile<TReturn, TDataTransferObject>(string filePath)
    {
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
}