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
using static Launcher.MapDataPaths;

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
    
    /// <summary>
    /// Converts the provided Warcraft 3 map to JSON and saves it in the specified folder.
    /// </summary>
    public void Convert(string baseMapPath, string outputFolderPath)
    {
      var map = Map.Open(baseMapPath);
      SerializeAndWriteMapData(map, outputFolderPath);
      
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
    
    private void SerializeAndWriteMapData(Map map, string outputFolderPath)
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
      SerializeAndWrite<MapCustomTextTriggers, MapCustomTextTriggersDto>(map.CustomTextTriggers, outputFolderPath, CustomTextTriggersPath);
      
      SerializeAndWriteUnitData(map.UnitObjectData, outputFolderPath, UnitDataDirectoryPath, CoreDataDirectorySubPath);
      SerializeAndWriteUnitData(map.UnitSkinObjectData, outputFolderPath, UnitDataDirectoryPath, SkinDataDirectorySubPath);
      SerializeAndWriteAbilityData(map.AbilityObjectData, outputFolderPath, AbilityDataDirectoryPath, CoreDataDirectorySubPath);
      SerializeAndWriteAbilityData(map.AbilitySkinObjectData, outputFolderPath, AbilityDataDirectoryPath, SkinDataDirectorySubPath);
      SerializeAndWriteItemData(map.ItemObjectData, outputFolderPath, ItemDataDirectoryPath, CoreDataDirectorySubPath);
      SerializeAndWriteItemData(map.ItemSkinObjectData, outputFolderPath, ItemDataDirectoryPath, SkinDataDirectorySubPath);
      SerializeAndWriteDestructableData(map.DestructableObjectData, outputFolderPath, DestructableDataDirectoryPath, CoreDataDirectorySubPath);
      SerializeAndWriteDestructableData(map.DestructableSkinObjectData, outputFolderPath, DestructableDataDirectoryPath, SkinDataDirectorySubPath);
      SerializeAndWriteDoodadData(map.DoodadObjectData, outputFolderPath, DoodadDataDirectoryPath, CoreDataDirectorySubPath);
      SerializeAndWriteDoodadData(map.DoodadSkinObjectData, outputFolderPath, DoodadDataDirectoryPath, SkinDataDirectorySubPath);
      SerializeAndWriteBuffData(map.BuffObjectData, outputFolderPath, BuffDataDirectoryPath, CoreDataDirectorySubPath);
      SerializeAndWriteBuffData(map.BuffSkinObjectData, outputFolderPath, BuffDataDirectoryPath, SkinDataDirectorySubPath);
      SerializeAndWriteUpgradeData(map.UpgradeObjectData, outputFolderPath, UpgradeDataDirectoryPath, CoreDataDirectorySubPath);
      SerializeAndWriteUpgradeData(map.UpgradeSkinObjectData, outputFolderPath, UpgradeDataDirectoryPath, SkinDataDirectorySubPath);
      
      File.WriteAllText(Path.Combine(outputFolderPath, "Script.json"), map.Script);
    }

    /// <summary>
    /// Converts the provided input into a Data Transfer Object, then serializes it, then writes it.
    /// </summary>
    private void SerializeAndWrite<TInput, TDataTransferObject>(TInput inputValue, string outputDirectoryPath, string fileName)
    {
      if (!Directory.Exists(outputDirectoryPath))
        Directory.CreateDirectory(outputDirectoryPath!);
      
      var dataTransferObject = _mapper.Map<TInput, TDataTransferObject>(inputValue);
      var asJson = JsonSerializer.Serialize(dataTransferObject, _jsonSerializerOptions);
      var fullPath = Path.Combine(outputDirectoryPath, fileName);
      File.WriteAllText(fullPath, asJson);
    }
    
    private void SerializeAndWriteUnitData(UnitObjectData unitObjectData, params string[] paths)
    {
      foreach (var unit in unitObjectData.BaseUnits) 
        SerializeAndWriteSimpleObjectModification(unit, Path.Combine(paths));
      
      foreach (var unit in unitObjectData.NewUnits) 
        SerializeAndWriteSimpleObjectModification(unit, Path.Combine(paths));
    }
    
    private void SerializeAndWriteBuffData(BuffObjectData buffObjectData, params string[] paths)
    {
      foreach (var buff in buffObjectData.BaseBuffs) 
        SerializeAndWriteSimpleObjectModification(buff, Path.Combine(paths));
      
      foreach (var buff in buffObjectData.NewBuffs) 
        SerializeAndWriteSimpleObjectModification(buff, Path.Combine(paths));
    }

    private void SerializeAndWriteDoodadData(DoodadObjectData doodadObjectData, params string[] paths)
    {
      foreach (var doodad in doodadObjectData.BaseDoodads) 
        SerializeAndWriteVariationObjectModification(doodad, Path.Combine(paths));
      
      foreach (var doodad in doodadObjectData.NewDoodads) 
        SerializeAndWriteVariationObjectModification(doodad, Path.Combine(paths));
    }

    private void SerializeAndWriteDestructableData(DestructableObjectData destructableObjectData, params string[] paths)
    {
      foreach (var destructable in destructableObjectData.BaseDestructables) 
        SerializeAndWriteSimpleObjectModification(destructable, Path.Combine(paths));
      
      foreach (var destructable in destructableObjectData.NewDestructables) 
        SerializeAndWriteSimpleObjectModification(destructable, Path.Combine(paths));
    }

    private void SerializeAndWriteItemData(ItemObjectData itemObjectData, params string[] paths)
    {
      foreach (var item in itemObjectData.BaseItems) 
        SerializeAndWriteSimpleObjectModification(item, Path.Combine(paths));
      
      foreach (var item in itemObjectData.NewItems) 
        SerializeAndWriteSimpleObjectModification(item, Path.Combine(paths));
    }

    private void SerializeAndWriteAbilityData(AbilityObjectData abilityObjectData, params string[] paths)
    {
      foreach (var ability in abilityObjectData.BaseAbilities)
        SerializeAndWriteLevelObjectModification(ability, Path.Combine(paths));
      
      foreach (var ability in abilityObjectData.NewAbilities)
        SerializeAndWriteLevelObjectModification(ability, Path.Combine(paths));
    }
    
    private void SerializeAndWriteUpgradeData(UpgradeObjectData upgradeObjectData, params string[] paths)
    {
      foreach (var upgrade in upgradeObjectData.BaseUpgrades)
        SerializeAndWriteLevelObjectModification(upgrade, Path.Combine(paths));
      
      foreach (var upgrade in upgradeObjectData.NewUpgrades)
        SerializeAndWriteLevelObjectModification(upgrade, Path.Combine(paths));
    }
    
    private void SerializeAndWriteSimpleObjectModification(SimpleObjectModification simpleObject, string outputDirectoryPath)
    {
      if (!Directory.Exists(outputDirectoryPath))
        Directory.CreateDirectory(outputDirectoryPath!);
      
      var id = simpleObject.NewId > 0 ? simpleObject.NewId : simpleObject.OldId;
      var asJson = JsonSerializer.Serialize(simpleObject, _jsonSerializerOptions);
      var fullPath = Path.Combine(outputDirectoryPath, $"{id}.json");
      File.WriteAllText(fullPath, asJson);
    }
    
    private void SerializeAndWriteVariationObjectModification(VariationObjectModification variationObject, string outputDirectoryPath)
    {
      if (!Directory.Exists(outputDirectoryPath))
        Directory.CreateDirectory(outputDirectoryPath!);
      
      var id = variationObject.NewId > 0 ? variationObject.NewId : variationObject.OldId;
      var asJson = JsonSerializer.Serialize(variationObject, _jsonSerializerOptions);
      var fullPath = Path.Combine(outputDirectoryPath, $"{id}.json");
      File.WriteAllText(fullPath, asJson);
    }
    
    private void SerializeAndWriteLevelObjectModification(LevelObjectModification levelObjectModification, string outputDirectoryPath)
    {
      if (!Directory.Exists(outputDirectoryPath))
        Directory.CreateDirectory(outputDirectoryPath!);
      
      var id = levelObjectModification.NewId > 0 ? levelObjectModification.NewId : levelObjectModification.OldId;
      var asJson = JsonSerializer.Serialize(levelObjectModification, _jsonSerializerOptions);
      var fullPath = Path.Combine(outputDirectoryPath, $"{id}.json");
      File.WriteAllText(fullPath, asJson);
    }
  }
}