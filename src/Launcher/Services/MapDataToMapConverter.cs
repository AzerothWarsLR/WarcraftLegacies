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
using static System.IO.SearchOption;

namespace Launcher.Services
{
  /// <summary>
  ///   Converts collections of loose files into a <see cref="Map" />.
  /// </summary>
  public sealed class MapDataToMapConverter
  {
    private const string UpgradeObjectDataPath = "UpgradeObjectData.json";
    private const string UnitObjectDataPath = "UnitObjectData.json";
    private const string ItemObjectDataPath = "ItemObjectData.json";
    private const string DoodadObjectDataPath = "DoodadObjectData.json";
    private const string DestructableObjectDataPath = "DestructableObjectData.json";
    private const string CustomTextTriggersPath = "CustomTextTriggers.json";
    private const string BuffObjectDataPath = "BuffObjectData.json";
    private const string AbilityObjectDataPath = "AbilityObjectData.json";
    private const string TriggerStringsPath = "TriggerStrings.json";
    private const string ShadowMapPath = "ShadowMap.json";
    private const string PreviewIconsPath = "PreviewIcons.json";
    private const string PathingMapPath = "PathingMap.json";
    private const string ImportedFilesPath = "ImportedFiles.json";
    private const string UnitsPath = "Units.json";
    private const string SoundsPath = "Sounds.json";
    private const string RegionsPath = "Regions.json";
    private const string InfoPath = "Info.json";
    private const string EnvironmentPath = "Environment.json";
    private const string DoodadsPath = "Doodads.json";
    private const string TriggersPath = "Triggers.json";
    private const string UpgradeSkinObjectDataPath = "UpgradeSkinObjectData.json";
    private const string UnitSkinObjectDataPath = "UnitSkinObjectData.json";
    private const string ItemSkinObjectDataPath = "ItemSkinObjectData.json";
    private const string DoodadSkinObjectDataPath = "DoodadSkinObjectData.json";
    private const string DestructableSkinObjectDataPath = "DestructableSkinObjectData.json";
    private const string BuffSkinObjectDataPath = "BuffSkinObjectData.json";
    private const string AbilitySkinObjectDataPath = "AbilitySkinObjectData.json";

    private const string ImportsPath = "Imports";

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
        Sounds = DeserializeFromFile<MapSounds, MapSoundsDto>(Path.Combine(mapDataRootDirectory, SoundsPath)),
        Environment =
          DeserializeFromFile<MapEnvironment, MapEnvironmentDto>(Path.Combine(mapDataRootDirectory, EnvironmentPath)),
        PathingMap =
          DeserializeFromFile<MapPathingMap, MapPathingMapDto>(Path.Combine(mapDataRootDirectory, PathingMapPath)),
        PreviewIcons =
          DeserializeFromFile<MapPreviewIcons, MapPreviewIconsDto>(Path.Combine(mapDataRootDirectory,
            PreviewIconsPath)),
        Regions = DeserializeFromFile<MapRegions, MapRegionsDto>(Path.Combine(mapDataRootDirectory, RegionsPath)),
        ShadowMap =
          DeserializeFromFile<MapShadowMap, MapShadowMapDto>(Path.Combine(mapDataRootDirectory, ShadowMapPath)),
        ImportedFiles =
          DeserializeFromFile<ImportedFiles, MapImportedFilesDto>(Path.Combine(mapDataRootDirectory,
            ImportedFilesPath)),
        Info = DeserializeFromFile<MapInfo, MapInfoDto>(Path.Combine(mapDataRootDirectory, InfoPath)),
        AbilityObjectData =
          DeserializeFromFile<AbilityObjectData, MapAbilityObjectDataDto>(Path.Combine(mapDataRootDirectory,
            AbilityObjectDataPath)),
        BuffObjectData =
          DeserializeFromFile<BuffObjectData, MapBuffObjectDataDto>(Path.Combine(mapDataRootDirectory,
            BuffObjectDataPath)),
        DestructableObjectData =
          DeserializeFromFile<DestructableObjectData, MapDestructableObjectDataDto>(Path.Combine(mapDataRootDirectory,
            DestructableObjectDataPath)),
        DoodadObjectData =
          DeserializeFromFile<DoodadObjectData, MapDoodadObjectDataDto>(Path.Combine(mapDataRootDirectory,
            DoodadObjectDataPath)),
        ItemObjectData =
          DeserializeFromFile<ItemObjectData, MapItemObjectDataDto>(Path.Combine(mapDataRootDirectory,
            ItemObjectDataPath)),
        UnitObjectData =
          DeserializeFromFile<UnitObjectData, MapUnitObjectDataDto>(Path.Combine(mapDataRootDirectory,
            UnitObjectDataPath)),
        UpgradeObjectData =
          DeserializeFromFile<UpgradeObjectData, MapUpgradeObjectDataDto>(Path.Combine(mapDataRootDirectory,
            UpgradeObjectDataPath)),
        CustomTextTriggers =
          DeserializeFromFile<MapCustomTextTriggers, MapCustomTextTriggersDto>(Path.Combine(mapDataRootDirectory,
            CustomTextTriggersPath)),
        TriggerStrings =
          DeserializeFromFile<TriggerStrings, MapTriggerStringsDto>(Path.Combine(mapDataRootDirectory,
            TriggerStringsPath)),
        Doodads = DeserializeFromFile<MapDoodads, MapDoodadsDto>(Path.Combine(mapDataRootDirectory, DoodadsPath)),
        Units = DeserializeFromFile<MapUnits, MapUnitsDto>(Path.Combine(mapDataRootDirectory, UnitsPath)),
        Triggers = DeserializeFromFile<MapTriggers, MapTriggersDto>(Path.Combine(mapDataRootDirectory, TriggersPath)),
        AbilitySkinObjectData =
          DeserializeFromFile<AbilityObjectData, MapAbilityObjectDataDto>(Path.Combine(mapDataRootDirectory,
            AbilitySkinObjectDataPath)),
        BuffSkinObjectData =
          DeserializeFromFile<BuffObjectData, MapBuffObjectDataDto>(Path.Combine(mapDataRootDirectory,
            BuffSkinObjectDataPath)),
        DestructableSkinObjectData =
          DeserializeFromFile<DestructableObjectData, MapDestructableObjectDataDto>(Path.Combine(mapDataRootDirectory,
            DestructableSkinObjectDataPath)),
        DoodadSkinObjectData =
          DeserializeFromFile<DoodadObjectData, MapDoodadObjectDataDto>(Path.Combine(mapDataRootDirectory,
            DoodadSkinObjectDataPath)),
        ItemSkinObjectData =
          DeserializeFromFile<ItemObjectData, MapItemObjectDataDto>(Path.Combine(mapDataRootDirectory,
            ItemSkinObjectDataPath)),
        UnitSkinObjectData =
          DeserializeFromFile<UnitObjectData, MapUnitObjectDataDto>(Path.Combine(mapDataRootDirectory,
            UnitSkinObjectDataPath)),
        UpgradeSkinObjectData =
          DeserializeFromFile<UpgradeObjectData, MapUpgradeObjectDataDto>(Path.Combine(mapDataRootDirectory,
            UpgradeSkinObjectDataPath)),
        Script = File.ReadAllText(Path.Combine(mapDataRootDirectory, "Script.json"))
      };
      return map;
    }

    private static IEnumerable<PathData> GetAdditionalFiles(string mapDataRootDirectory)
    {
      var importsDirectory = $@"{mapDataRootDirectory}\{ImportsPath}";

      var additionalFiles = Directory.Exists(importsDirectory)
        ? Directory.EnumerateFiles(importsDirectory, "*", AllDirectories).Select(x => new PathData
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
  }
}