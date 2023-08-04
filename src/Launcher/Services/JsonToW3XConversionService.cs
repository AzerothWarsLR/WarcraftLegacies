using System.IO;
using System.Text.Json;
using Launcher.DataTransferObjects;
using War3Net.Build;
using War3Net.Build.Audio;
using War3Net.Build.Common;
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
      var mapInfoDto = DeserializeFromFile<MapInfoDto>(Path.Combine(mapDataRootFolder, InfoPath));
      var mapInfo = new MapInfo(mapInfoDto.FormatVersion)
      {
        MapVersion = mapInfoDto.MapVersion,
        EditorVersion = mapInfoDto.EditorVersion,
        GameVersion = mapInfoDto.GameVersion,
        MapName = mapInfoDto.MapName,
        MapAuthor = mapInfoDto.MapAuthor,
        MapDescription = mapInfoDto.MapDescription,
        RecommendedPlayers = mapInfoDto.RecommendedPlayers,
        Unk1 = mapInfoDto.Unk1,
        Unk2 = mapInfoDto.Unk2,
        Unk3 = mapInfoDto.Unk3,
        Unk4 = mapInfoDto.Unk4,
        Unk5 = mapInfoDto.Unk5,
        Unk6 = mapInfoDto.Unk6,
        CameraBounds = new Quadrilateral(mapInfoDto.CameraBounds.BottomLeft, mapInfoDto.CameraBounds.TopRight,
          mapInfoDto.CameraBounds.TopLeft, mapInfoDto.CameraBounds.BottomRight),
        CameraBoundsComplements = mapInfoDto.CameraBoundsComplements,
        PlayableMapAreaWidth = mapInfoDto.PlayableMapAreaWidth,
        PlayableMapAreaHeight = mapInfoDto.PlayableMapAreaHeight,
        Unk7 = mapInfoDto.Unk7,
        MapFlags = mapInfoDto.MapFlags,
        Tileset = mapInfoDto.Tileset,
        CampaignBackgroundNumber = mapInfoDto.CampaignBackgroundNumber,
        LoadingScreenBackgroundNumber = mapInfoDto.LoadingScreenBackgroundNumber,
        LoadingScreenPath = mapInfoDto.LoadingScreenPath,
        LoadingScreenText = mapInfoDto.LoadingScreenText,
        LoadingScreenTitle = mapInfoDto.LoadingScreenTitle,
        LoadingScreenSubtitle = mapInfoDto.LoadingScreenSubtitle,
        LoadingScreenNumber = mapInfoDto.LoadingScreenNumber,
        GameDataSet = mapInfoDto.GameDataSet,
        PrologueScreenPath = mapInfoDto.PrologueScreenPath,
        PrologueScreenText = mapInfoDto.PrologueScreenText,
        PrologueScreenTitle = mapInfoDto.PrologueScreenTitle,
        PrologueScreenSubtitle = mapInfoDto.PrologueScreenSubtitle,
        FogStyle = mapInfoDto.FogStyle,
        FogStartZ = mapInfoDto.FogStartZ,
        FogEndZ = mapInfoDto.FogEndZ,
        FogDensity = mapInfoDto.FogDensity,
        FogColor = mapInfoDto.FogColor,
        GlobalWeather = mapInfoDto.GlobalWeather,
        SoundEnvironment = mapInfoDto.SoundEnvironment,
        LightEnvironment = mapInfoDto.LightEnvironment,
        WaterTintingColor = mapInfoDto.WaterTintingColor,
        ScriptLanguage = mapInfoDto.ScriptLanguage,
        SupportedModes = mapInfoDto.SupportedModes,
        GameDataVersion = mapInfoDto.GameDataVersion,
        Players = mapInfoDto.Players,
        Forces = mapInfoDto.Forces,
        UpgradeData = mapInfoDto.UpgradeData,
        TechData = mapInfoDto.TechData,
        RandomUnitTables = mapInfoDto.RandomUnitTables,
        RandomItemTables = null
      };
      
      var map = new Map
      {
        Sounds = DeserializeFromFile<MapSounds>(Path.Combine(mapDataRootFolder, SoundsPath)),
        Environment = DeserializeFromFile<MapEnvironment>(Path.Combine(mapDataRootFolder, EnvironmentPath)),
        PathingMap = DeserializeFromFile<MapPathingMap>(Path.Combine(mapDataRootFolder, PathingMapPath)),
        PreviewIcons = DeserializeFromFile<MapPreviewIcons>(Path.Combine(mapDataRootFolder, PreviewIconsPath)),
        Regions = DeserializeFromFile<MapRegions>(Path.Combine(mapDataRootFolder, RegionsPath)),
        ShadowMap = DeserializeFromFile<MapShadowMap>(Path.Combine(mapDataRootFolder, ShadowMapPath)),
        ImportedFiles = DeserializeFromFile<MapImportedFiles>(Path.Combine(mapDataRootFolder, ImportedFilesPath)),
        Info = mapInfo,
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