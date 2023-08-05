#nullable enable
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using AutoMapper;
using Launcher.DataTransferObjects;
using Launcher.Extensions;
using Launcher.JsonConverters;
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
    /// <summary>
    /// Data stored as <see cref="ObjectDataModification"/> or anything deriving from it has an object field which
    /// needs to be manually given a type by interpreting the object's Type field.
    /// </summary>
    private static void CastModificationSets(JsonTypeInfo typeInfo)
    {
      foreach (var propertyInfo in typeInfo.Properties)
      {
        if (propertyInfo.Name != "Modifications")
          continue;
        
        var setProperty = propertyInfo.Set;
        if (setProperty is not null)
        {
          propertyInfo.Set = (obj, value) =>
          {
            if (value is List<ObjectDataModification> modificationSet)
              foreach (var modification in modificationSet)
                modification.Value = modification.GetCastedValue();
            
            if (value is List<LevelObjectDataModification> levelObjectDataModificationSet)
              foreach (var modification in levelObjectDataModificationSet)
                modification.Value = modification.GetCastedValue();
            
            if (value is List<SimpleObjectDataModification> simpleObjectDataModificationSet)
              foreach (var modification in simpleObjectDataModificationSet)
                modification.Value = modification.GetCastedValue();
            
            if (value is List<VariationObjectDataModification> variationObjectDataModificationSet)
              foreach (var modification in variationObjectDataModificationSet)
                modification.Value = modification.GetCastedValue();

            setProperty(obj, value);
          };
        }
      }
    }
    
    private readonly IMapper _mapper;

    private readonly JsonSerializerOptions _jsonSerializerOptions = new()
    {
      IgnoreReadOnlyProperties = true,
      DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
      WriteIndented = true,
      TypeInfoResolver = new DefaultJsonTypeInfoResolver
      {
        Modifiers = { CastModificationSets }
      },
      Converters = { new ColorJsonConverter() }
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
    private const string ScriptPath = "Script.json";
    private const string RegionsPath = "Regions.json";
    private const string InfoPath = "Info.json";
    private const string EnvironmentPath = "Environment.json";
    private const string DoodadsPath = "Doodads.json";
    private const string TriggersPath = "Triggers.json";

    /// <summary>
    /// Converts the provided JSON data into a Warcraft 3 map and saves it in the specified folder.
    /// </summary>
    public void Convert(string mapDataRootFolder, string outputFilePath)
    {
      var map = new Map
      {
        Sounds = DeserializeFromFile<MapSounds, MapSoundsDto>(Path.Combine(mapDataRootFolder, SoundsPath)),
        Environment = DeserializeFromFile<MapEnvironment, MapEnvironmentDto>(Path.Combine(mapDataRootFolder, EnvironmentPath)),
        PathingMap = DeserializeFromFile<MapPathingMap, MapPathingMapDto>(Path.Combine(mapDataRootFolder, PathingMapPath)),
        PreviewIcons = DeserializeFromFile<MapPreviewIcons, MapPreviewIconsDto>(Path.Combine(mapDataRootFolder, PreviewIconsPath)),
        Regions = DeserializeFromFile<MapRegions, MapRegionsDto>(Path.Combine(mapDataRootFolder, RegionsPath)),
        ShadowMap = DeserializeFromFile<MapShadowMap, MapShadowMapDto>(Path.Combine(mapDataRootFolder, ShadowMapPath)),
        ImportedFiles = DeserializeFromFile<ImportedFiles, MapImportedFilesDto>(Path.Combine(mapDataRootFolder, ImportedFilesPath)),
        Info = DeserializeFromFile<MapInfo, MapInfoDto>(Path.Combine(mapDataRootFolder, InfoPath)),
        AbilityObjectData = DeserializeFromFile<AbilityObjectData, MapAbilityObjectDataDto>(Path.Combine(mapDataRootFolder, AbilityObjectDataPath)),
        BuffObjectData = DeserializeFromFile<BuffObjectData, MapBuffObjectDataDto>(Path.Combine(mapDataRootFolder, BuffObjectDataPath)),
        DestructableObjectData = DeserializeFromFile<DestructableObjectData, MapDestructableObjectDataDto>(Path.Combine(mapDataRootFolder, DestructableObjectDataPath)),
        DoodadObjectData = DeserializeFromFile<DoodadObjectData, MapDoodadObjectDataDto>(Path.Combine(mapDataRootFolder, DoodadObjectDataPath)),
        ItemObjectData = DeserializeFromFile<ItemObjectData, MapItemObjectDataDto>(Path.Combine(mapDataRootFolder, ItemObjectDataPath)),
        UnitObjectData = DeserializeFromFile<UnitObjectData, MapUnitObjectDataDto>(Path.Combine(mapDataRootFolder, UnitObjectDataPath)),
        UpgradeObjectData = DeserializeFromFile<UpgradeObjectData, MapUpgradeObjectDataDto>(Path.Combine(mapDataRootFolder, UpgradeObjectDataPath)),
        CustomTextTriggers = DeserializeFromFile<MapCustomTextTriggers, MapCustomTextTriggersDto>(Path.Combine(mapDataRootFolder, CustomTextTriggersPath)),
        TriggerStrings = DeserializeFromFile<TriggerStrings, MapTriggerStringsDto>(Path.Combine(mapDataRootFolder, TriggerStringsPath)),
        Doodads = DeserializeFromFile<MapDoodads, MapDoodadsDto>(Path.Combine(mapDataRootFolder, DoodadsPath)),
        Units = DeserializeFromFile<MapUnits, MapUnitsDto>(Path.Combine(mapDataRootFolder, UnitsPath)),
        Triggers = DeserializeFromFile<MapTriggers, MapTriggersDto>(Path.Combine(mapDataRootFolder, TriggersPath)),
        Script = File.ReadAllText(Path.Combine(mapDataRootFolder, ScriptPath))
      };

      var builder = new MapBuilder(map);
      builder.Build(outputFilePath, _archiveCreateOptions);
    }

    private TReturn DeserializeFromFile<TReturn, TDataTransferObject>(string filePath)
    {
      var dto = JsonSerializer.Deserialize<TDataTransferObject>(File.ReadAllText(filePath), _jsonSerializerOptions);
      return _mapper.Map<TReturn>(dto);
    }
  }
}