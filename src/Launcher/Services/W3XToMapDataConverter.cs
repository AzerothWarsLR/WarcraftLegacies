using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
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
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Launcher.Services
{
  /// <summary>
  /// Converts a Warcraft 3 map into a collection of loose files so that they can be stored in version control.
  /// </summary>
  public sealed class W3XToMapDataConverter
  {
    private readonly IMapper _mapper;

    private readonly JsonSerializerOptions _jsonSerializerOptions = new()
    {
      IgnoreReadOnlyProperties = true,
      DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
      WriteIndented = true,
      Converters = { new ColorJsonConverter() }
    };

    public W3XToMapDataConverter(IMapper mapper)
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
    private const string UpgradeSkinObjectDataPath = "UpgradeSkinObjectData.json";
    private const string UnitSkinObjectDataPath = "UnitSkinObjectData.json";
    private const string ItemSkinObjectDataPath = "ItemSkinObjectData.json";
    private const string DoodadSkinObjectDataPath = "DoodadSkinObjectData.json";
    private const string DestructableSkinObjectDataPath = "DestructableSkinObjectData.json";
    private const string BuffSkinObjectDataPath = "BuffSkinObjectData.json";
    private const string AbilitySkinObjectDataPath = "AbilitySkinObjectData.json";

    private const string UnitDataDirectoryPath = "UnitData/";
    
    private const string ImportsPath = "Imports";
    
    /// <summary>
    /// Converts the provided Warcraft 3 map to JSON and saves it in the specified folder.
    /// </summary>
    public void Convert(string baseMapPath, string outputFolderPath)
    {
      var map = Map.Open(baseMapPath);
      SerializeAndWriteJson(map, outputFolderPath);
      
      var importedFiles = map.ImportedFiles?.Files;
      if (importedFiles != null) 
        CopyImportedFiles(baseMapPath, importedFiles, outputFolderPath);
      
      File.Copy($"{baseMapPath}/war3mapMap.blp", $@"{outputFolderPath}\war3mapMap.blp", true);
    }

    private void CopyImportedFiles(string baseMapPath, List<ImportedFile> files, string outputFolderPath)
    {
      foreach (var file in files)
      {
        var sourceFileName = $@"{baseMapPath}\{file.FullPath}";
        var destinationFileName = $@"{outputFolderPath}\{ImportsPath}\{file.FullPath}";
        Directory.CreateDirectory(Path.GetDirectoryName(destinationFileName)!);
        File.Copy(sourceFileName, destinationFileName, true);
      }
    }
    
    private void SerializeAndWriteJson(Map map, string outputFolderPath)
    {
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
      SerializeAndWrite<AbilityObjectData, MapAbilityObjectDataDto>(map.AbilitySkinObjectData, outputFolderPath, AbilitySkinObjectDataPath);
      SerializeAndWrite<BuffObjectData, MapBuffObjectDataDto>(map.BuffSkinObjectData, outputFolderPath, BuffSkinObjectDataPath);
      SerializeAndWrite<DestructableObjectData, MapDestructableObjectDataDto>(map.DestructableSkinObjectData, outputFolderPath, DestructableSkinObjectDataPath);
      SerializeAndWrite<DoodadObjectData, MapDoodadObjectDataDto>(map.DoodadSkinObjectData, outputFolderPath, DoodadSkinObjectDataPath);
      SerializeAndWrite<ItemObjectData, MapItemObjectDataDto>(map.ItemSkinObjectData, outputFolderPath, ItemSkinObjectDataPath);
      SerializeAndWrite<UnitObjectData, MapUnitObjectDataDto>(map.UnitSkinObjectData, outputFolderPath, UnitSkinObjectDataPath);
      SerializeAndWrite<UpgradeObjectData, MapUpgradeObjectDataDto>(map.UpgradeSkinObjectData, outputFolderPath, UpgradeSkinObjectDataPath);
      File.WriteAllText(Path.Combine(outputFolderPath, "Script.json"), map.Script);
    }
    
    /// <summary>
    /// Converts the provided input into a Data Transfer Object, then serializes it, then writes it.
    /// </summary>
    private void SerializeAndWrite<TInput, TDataTransferObject>(TInput inputValue, string outputFolderPath, string subPath)
    {
      if (!Directory.Exists(outputFolderPath))
        Directory.CreateDirectory(outputFolderPath!);
      
      var dataTransferObject = _mapper.Map<TInput, TDataTransferObject>(inputValue);
      var asJson = JsonSerializer.Serialize(dataTransferObject, _jsonSerializerOptions);
      var fullPath = Path.Combine(outputFolderPath, subPath);
      File.WriteAllText(fullPath, asJson);
    }
  }
}