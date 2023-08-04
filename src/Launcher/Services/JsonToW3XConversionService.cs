using System.IO;
using System.Text.Json;
using AutoMapper;
using War3Net.Build;
using War3Net.Build.Audio;
using War3Net.Build.Environment;
using War3Net.Build.Import;
using War3Net.Build.Info;
using War3Net.Build.Object;
using War3Net.Build.Script;
using War3Net.Build.Widget;
using War3Net.IO.Mpq;

namespace Launcher.Services
{
  /// <summary>
  /// Converts .json files into a playable Warcraft 3 map.
  /// </summary>
  public sealed class JsonToW3XConversionService
  {
    private readonly IMapper _mapper;

    private readonly JsonSerializerOptions _jsonSerializerOptions = new()
    {
      IgnoreReadOnlyProperties = true,
      WriteIndented = true
    };
    
    private readonly MpqArchiveCreateOptions _archiveCreateOptions = new()
    {
      BlockSize = 3,
      AttributesCreateMode = MpqFileCreateMode.Overwrite,
      ListFileCreateMode = MpqFileCreateMode.Overwrite
    };

    public JsonToW3XConversionService(IMapper mapper)
    {
      _mapper = mapper;
    }

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

    /// <summary>
    /// Converts the provided JSON data into a Warcraft 3 map and saves it in the specified folder.
    /// </summary>
    public void Convert(string mapDataRootFolder, string outputFilePath)
    {
      var map = new Map
      {
        Sounds = DeserializeFromFile<MapSounds>(Path.Combine(mapDataRootFolder, SoundsPath)),
        Environment = DeserializeFromFile<MapEnvironment>(Path.Combine(mapDataRootFolder, EnvironmentPath)),
        PathingMap = DeserializeFromFile<MapPathingMap>(Path.Combine(mapDataRootFolder, PathingMapPath)),
        PreviewIcons = DeserializeFromFile<MapPreviewIcons>(Path.Combine(mapDataRootFolder, PreviewIconsPath)),
        Regions = DeserializeFromFile<MapRegions>(Path.Combine(mapDataRootFolder, RegionsPath)),
        ShadowMap = DeserializeFromFile<MapShadowMap>(Path.Combine(mapDataRootFolder, ShadowMapPath)),
        ImportedFiles = DeserializeFromFile<MapImportedFiles>(Path.Combine(mapDataRootFolder, ImportedFilesPath)),
        Info = _mapper.Map<MapInfo>(DeserializeFromFile<MapImportedFiles>(Path.Combine(mapDataRootFolder, InfoPath))),
        AbilityObjectData = DeserializeFromFile<AbilityObjectData>(Path.Combine(mapDataRootFolder, AbilityObjectDataPath)),
        BuffObjectData = DeserializeFromFile<BuffObjectData>(Path.Combine(mapDataRootFolder, BuffObjectDataPath)),
        DestructableObjectData = DeserializeFromFile<DestructableObjectData>(Path.Combine(mapDataRootFolder, DestructableObjectDataPath)),
        DoodadObjectData = DeserializeFromFile<DoodadObjectData>(Path.Combine(mapDataRootFolder, DoodadObjectDataPath)),
        ItemObjectData = DeserializeFromFile<ItemObjectData>(Path.Combine(mapDataRootFolder, ItemObjectDataPath)),
        UnitObjectData = DeserializeFromFile<UnitObjectData>(Path.Combine(mapDataRootFolder, UnitObjectDataPath)),
        UpgradeObjectData = DeserializeFromFile<UpgradeObjectData>(Path.Combine(mapDataRootFolder, UpgradeObjectDataPath)),
        CustomTextTriggers = DeserializeFromFile<MapCustomTextTriggers>(Path.Combine(mapDataRootFolder, CustomTextTriggersPath)),
        TriggerStrings = DeserializeFromFile<TriggerStrings>(Path.Combine(mapDataRootFolder, TriggerStringsPath)),
        Doodads = DeserializeFromFile<MapDoodads>(Path.Combine(mapDataRootFolder, DoodadsPath)),
        Units = DeserializeFromFile<MapUnits>(Path.Combine(mapDataRootFolder, UnitsPath))
      };

      var builder = new MapBuilder(map);
      builder.Build(outputFilePath, _archiveCreateOptions);
    }

    private T DeserializeFromFile<T>(string filePath) => JsonSerializer.Deserialize<T>(File.ReadAllText(filePath), _jsonSerializerOptions);
  }
}