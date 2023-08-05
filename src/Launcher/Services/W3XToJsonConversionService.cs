using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using AutoMapper;
using Launcher.DataTransferObjects;
using Launcher.JsonConverters;
using War3Api.Object;
using War3Net.Build;
using War3Net.Build.Audio;
using War3Net.Build.Environment;
using War3Net.Build.Import;
using War3Net.Build.Info;
using War3Net.Build.Object;
using War3Net.Build.Script;
using War3Net.Build.Widget;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Launcher.Services
{
  /// <summary>
  /// Converts a Warcraft 3 map into .json files so that they can be stored in version control.
  /// </summary>
  public sealed class W3XToJsonConversionService
  {
    private readonly IMapper _mapper;

    private readonly JsonSerializerOptions _jsonSerializerOptions = new()
    {
      IgnoreReadOnlyProperties = true,
      DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
      WriteIndented = true,
      Converters = { new ColorJsonConverter() }
    };

    public W3XToJsonConversionService(IMapper mapper)
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
    private const string TriggersPath = "Triggers.json";

    /// <summary>
    /// Converts the provided Warcraft 3 map to JSON and saves it in the specified folder.
    /// </summary>
    public void Convert(string baseMapPath, string outputFolderPath)
    {
      var map = Map.Open(baseMapPath);

      SerializeAndWrite<MapDoodads, MapDoodadsDto>(map.Doodads, outputFolderPath, DoodadsPath);
      SerializeAndWrite<MapEnvironment, MapEnvironmentDto>(map.Environment, outputFolderPath, EnvironmentPath);
      SerializeAndWrite<MapInfo, MapInfoDto>(map.Info, outputFolderPath, InfoPath);
      SerializeAndWrite<MapRegions, MapRegionsDto>(map.Regions, outputFolderPath, RegionsPath);
      SerializeAndWrite<MapSounds, MapSoundsDto>(map.Sounds, outputFolderPath, SoundsPath);
      SerializeAndWrite<MapUnits, MapUnitsDto>(map.Units, outputFolderPath, UnitsPath);
      SerializeAndWrite<ImportedFiles, MapImportedFilesDto>(map.ImportedFiles, outputFolderPath, ImportedFilesPath);
      SerializeAndWrite<MapPathingMap, MapPathingMapDto>(map.PathingMap, outputFolderPath, PathingMapPath);
      SerializeAndWrite<MapPreviewIcons, MapPreviewIconsDto>(map.PreviewIcons, outputFolderPath, PreviewIconsPath);
      SerializeAndWrite<MapShadowMap, MapShadowMapDto>(map.ShadowMap, outputFolderPath, ShadowMapPath);
      SerializeAndWrite<TriggerStrings, MapTriggerStringsDto>(map.TriggerStrings, outputFolderPath, TriggerStringsPath);
      SerializeAndWrite<AbilityObjectData, MapAbilityObjectDataDto>(map.AbilityObjectData, outputFolderPath, AbilityObjectDataPath);
      SerializeAndWrite<BuffObjectData, MapBuffObjectDataDto>(map.BuffObjectData, outputFolderPath, BuffObjectDataPath);
      SerializeAndWrite<MapCustomTextTriggers, MapCustomTextTriggersDto>(map.CustomTextTriggers, outputFolderPath, CustomTextTriggersPath);
      SerializeAndWrite<DestructableObjectData, MapDestructableObjectDataDto>(map.DestructableObjectData, outputFolderPath, DestructableObjectDataPath);
      SerializeAndWrite<DoodadObjectData, MapDoodadObjectDataDto>(map.DoodadObjectData, outputFolderPath, DoodadObjectDataPath);
      SerializeAndWrite<ItemObjectData, MapItemObjectDataDto>(map.ItemObjectData, outputFolderPath, ItemObjectDataPath);
      SerializeAndWrite<UnitObjectData, MapUnitObjectDataDto>(map.UnitObjectData, outputFolderPath, UnitObjectDataPath);
      SerializeAndWrite<UpgradeObjectData, MapUpgradeObjectDataDto>(map.UpgradeObjectData, outputFolderPath, UpgradeObjectDataPath);
      SerializeAndWrite<MapTriggers, MapTriggersDto>(map.Triggers, outputFolderPath, TriggersPath);
    }
    
    /// <summary>
    /// Converts the provided input into a Data Transfer Object, then serializes it, then writes it.
    /// </summary>
    private void SerializeAndWrite<TInput, TDataTransferObject>(TInput inputValue, string outputFolderPath, string subPath)
    {
      var dataTransferObject = _mapper.Map<TInput, TDataTransferObject>(inputValue);
      SerializeAndWrite(dataTransferObject, outputFolderPath, subPath);
    }
    
    /// <summary>
    /// Serializes then writes the provided input to the file system.
    /// </summary>
    private void SerializeAndWrite<T>(T value, string outputFolderPath, string subPath)
    {
      if (!Directory.Exists(outputFolderPath))
        Directory.CreateDirectory(outputFolderPath!);
      
      var asJson = JsonSerializer.Serialize(value, _jsonSerializerOptions);
      var fullPath = Path.Combine(outputFolderPath, subPath);
      
      File.WriteAllText(fullPath, asJson);
    }
  }
}