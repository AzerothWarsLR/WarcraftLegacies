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
      
      SerializeAndWriteUnitData(map.UnitObjectData, outputFolderPath);
      SerializeAndWriteUnitData(map.UnitSkinObjectData, outputFolderPath);
      SerializeAndWriteAbilityData(map.AbilityObjectData, outputFolderPath);
      SerializeAndWriteAbilityData(map.AbilitySkinObjectData, outputFolderPath);
      SerializeAndWriteItemData(map.ItemObjectData, outputFolderPath);
      SerializeAndWriteItemData(map.ItemSkinObjectData, outputFolderPath);
      SerializeAndWriteDestructableData(map.DestructableObjectData, outputFolderPath);
      SerializeAndWriteDestructableData(map.DestructableSkinObjectData, outputFolderPath);
      SerializeAndWriteDoodadData(map.DoodadObjectData, outputFolderPath);
      SerializeAndWriteDoodadData(map.DoodadSkinObjectData, outputFolderPath);
      SerializeAndWriteBuffData(map.BuffObjectData, outputFolderPath);
      SerializeAndWriteBuffData(map.BuffSkinObjectData, outputFolderPath);
      SerializeAndWriteUpgradeData(map.UpgradeObjectData, outputFolderPath);
      SerializeAndWriteUpgradeData(map.UpgradeSkinObjectData, outputFolderPath);
      
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
    
    private void SerializeAndWriteUnitData(UnitObjectData unitObjectData, string outputFolderPath)
    {
      foreach (var unit in unitObjectData.BaseUnits) 
        SerializeAndWriteSimpleObjectModification(unit, Path.Combine(outputFolderPath, BaseUnitsDataDirectoryPath));
      
      foreach (var unit in unitObjectData.NewUnits) 
        SerializeAndWriteSimpleObjectModification(unit, Path.Combine(outputFolderPath, NewUnitsDataDirectoryPath));
    }
    
    private void SerializeAndWriteBuffData(BuffObjectData buffObjectData, string outputFolderPath)
    {
      foreach (var buff in buffObjectData.BaseBuffs) 
        SerializeAndWriteSimpleObjectModification(buff, Path.Combine(outputFolderPath, BaseBuffsDataDirectoryPath));
      
      foreach (var buff in buffObjectData.NewBuffs) 
        SerializeAndWriteSimpleObjectModification(buff, Path.Combine(outputFolderPath, BaseBuffsDataDirectoryPath));
    }

    private void SerializeAndWriteDoodadData(DoodadObjectData doodadObjectData, string outputFolderPath)
    {
      foreach (var doodad in doodadObjectData.BaseDoodads) 
        SerializeAndWriteVariationObjectModification(doodad, Path.Combine(outputFolderPath, BaseDoodadsDataDirectoryPath));
      
      foreach (var doodad in doodadObjectData.NewDoodads) 
        SerializeAndWriteVariationObjectModification(doodad, Path.Combine(outputFolderPath, NewDoodadsDataDirectoryPath));
    }

    private void SerializeAndWriteDestructableData(DestructableObjectData destructableObjectData, string outputFolderPath)
    {
      foreach (var destructable in destructableObjectData.BaseDestructables) 
        SerializeAndWriteSimpleObjectModification(destructable, Path.Combine(outputFolderPath, BaseDestructablesDataDirectoryPath));
      
      foreach (var destructable in destructableObjectData.NewDestructables) 
        SerializeAndWriteSimpleObjectModification(destructable, Path.Combine(outputFolderPath, NewDestructablesDataDirectoryPath));
    }

    private void SerializeAndWriteItemData(ItemObjectData itemObjectData, string outputFolderPath)
    {
      foreach (var item in itemObjectData.BaseItems) 
        SerializeAndWriteSimpleObjectModification(item, Path.Combine(outputFolderPath, BaseItemsDataDirectoryPath));
      
      foreach (var item in itemObjectData.NewItems) 
        SerializeAndWriteSimpleObjectModification(item, Path.Combine(outputFolderPath, NewItemsDataDirectoryPath));
    }

    private void SerializeAndWriteAbilityData(AbilityObjectData abilityObjectData, string outputFolderPath)
    {
      foreach (var ability in abilityObjectData.BaseAbilities)
        SerializeAndWriteLevelObjectModification(ability, Path.Combine(outputFolderPath, BaseAbilitiesDataDirectoryPath));
      
      foreach (var ability in abilityObjectData.NewAbilities)
        SerializeAndWriteLevelObjectModification(ability, Path.Combine(outputFolderPath, NewAbilitiesDataDirectoryPath));
    }
    
    private void SerializeAndWriteUpgradeData(UpgradeObjectData upgradeObjectData, string outputFolderPath)
    {
      foreach (var upgrade in upgradeObjectData.BaseUpgrades)
        SerializeAndWriteLevelObjectModification(upgrade, Path.Combine(outputFolderPath, BaseUpgradesDataDirectoryPath));
      
      foreach (var upgrade in upgradeObjectData.NewUpgrades)
        SerializeAndWriteLevelObjectModification(upgrade, Path.Combine(outputFolderPath, NewUpgradesDataDirectoryPath));
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