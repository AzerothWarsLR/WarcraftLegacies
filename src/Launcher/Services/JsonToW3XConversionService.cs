using System.IO;
using System.Text.Json;
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
    private readonly JsonSerializerOptions _jsonSerializerOptions;
    private readonly MpqArchiveCreateOptions _archiveCreateOptions;
    
    private const string CamerasPath = "Cameras.json";
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
    private const string ScriptPath = "Script.json";
    private const string RegionsPath = "Regions.json";
    private const string InfoPath = "Info.json";
    private const string EnvironmentPath = "Environment.json";
    private const string DoodadsPath = "Doodads.json";
    
    public JsonToW3XConversionService()
    {
      _jsonSerializerOptions = new JsonSerializerOptions
      {
        IgnoreReadOnlyProperties = true,
        WriteIndented = true
      };
      
      _archiveCreateOptions = new MpqArchiveCreateOptions
      {
        BlockSize = 3,
        AttributesCreateMode = MpqFileCreateMode.Overwrite,
        ListFileCreateMode = MpqFileCreateMode.Overwrite
      };
    }
    
    /// <summary>
    /// Converts the provided JSON data into a Warcraft 3 map and saves it in the specified folder.
    /// </summary>
    public void Convert(string mapDataRootFolder, string outputFilePath)
    {
      var map = new Map
      {
        Sounds = JsonSerializer.Deserialize<MapSounds>(Path.Combine(mapDataRootFolder, SoundsPath), _jsonSerializerOptions),
        Cameras = JsonSerializer.Deserialize<MapCameras>(Path.Combine(mapDataRootFolder, CamerasPath), _jsonSerializerOptions),
        Environment = JsonSerializer.Deserialize<MapEnvironment>(Path.Combine(mapDataRootFolder, EnvironmentPath), _jsonSerializerOptions),
        PathingMap = JsonSerializer.Deserialize<MapPathingMap>(Path.Combine(mapDataRootFolder, PathingMapPath), _jsonSerializerOptions),
        PreviewIcons = JsonSerializer.Deserialize<MapPreviewIcons>(Path.Combine(mapDataRootFolder, PreviewIconsPath), _jsonSerializerOptions),
        Regions = JsonSerializer.Deserialize<MapRegions>(Path.Combine(mapDataRootFolder, RegionsPath), _jsonSerializerOptions),
        ShadowMap = JsonSerializer.Deserialize<MapShadowMap>(Path.Combine(mapDataRootFolder, ShadowMapPath), _jsonSerializerOptions),
        ImportedFiles = JsonSerializer.Deserialize<MapImportedFiles>(Path.Combine(mapDataRootFolder, ImportedFilesPath), _jsonSerializerOptions),
        Info = JsonSerializer.Deserialize<MapInfo>(Path.Combine(mapDataRootFolder, InfoPath), _jsonSerializerOptions),
        AbilityObjectData = JsonSerializer.Deserialize<AbilityObjectData>(Path.Combine(mapDataRootFolder, AbilityObjectDataPath), _jsonSerializerOptions),
        BuffObjectData = JsonSerializer.Deserialize<BuffObjectData>(Path.Combine(mapDataRootFolder, BuffObjectDataPath), _jsonSerializerOptions),
        DestructableObjectData = JsonSerializer.Deserialize<DestructableObjectData>(Path.Combine(mapDataRootFolder, DestructableObjectDataPath), _jsonSerializerOptions),
        DoodadObjectData = JsonSerializer.Deserialize<DoodadObjectData>(Path.Combine(mapDataRootFolder, DoodadObjectDataPath), _jsonSerializerOptions),
        ItemObjectData = JsonSerializer.Deserialize<ItemObjectData>(Path.Combine(mapDataRootFolder, ItemObjectDataPath), _jsonSerializerOptions),
        UnitObjectData = JsonSerializer.Deserialize<UnitObjectData>(Path.Combine(mapDataRootFolder, UnitObjectDataPath), _jsonSerializerOptions),
        UpgradeObjectData = JsonSerializer.Deserialize<UpgradeObjectData>(Path.Combine(mapDataRootFolder, UpgradeObjectDataPath), _jsonSerializerOptions),
        CustomTextTriggers = JsonSerializer.Deserialize<MapCustomTextTriggers>(Path.Combine(mapDataRootFolder, CustomTextTriggersPath), _jsonSerializerOptions),
        TriggerStrings = JsonSerializer.Deserialize<TriggerStrings>(Path.Combine(mapDataRootFolder, TriggerStringsPath), _jsonSerializerOptions),
        Doodads = JsonSerializer.Deserialize<MapDoodads>(Path.Combine(mapDataRootFolder, DoodadsPath), _jsonSerializerOptions),
        Units = JsonSerializer.Deserialize<MapUnits>(Path.Combine(mapDataRootFolder, UnitsPath), _jsonSerializerOptions)
      };

      var builder = new MapBuilder(map);
      builder.Build(outputFilePath, _archiveCreateOptions);
    }
  }
}