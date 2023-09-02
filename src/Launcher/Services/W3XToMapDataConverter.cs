#nullable enable
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
      
      CopyUnserializableFiles(baseMapPath, outputFolderPath);
    }

    private void SerializeAndWriteMapData(Map map, string outputFolderPath)
    {
      if (Directory.Exists(outputFolderPath))
        Directory.Delete(outputFolderPath, true);
      
      if (map.Doodads != null) 
        SerializeAndWriteDoodads(map.Doodads, Path.Combine(outputFolderPath, DoodadsDirectoryPath));
      if (map.Environment != null) 
        SerializeAndWrite<MapEnvironment, MapEnvironmentDto>(map.Environment, outputFolderPath, EnvironmentPath);
      if (map.Info != null) 
        SerializeAndWrite<MapInfo, MapInfoDto>(map.Info, outputFolderPath, InfoPath);
      if (map.Regions != null)
        SerializeAndWriteRegions(map.Regions, Path.Combine(outputFolderPath, RegionsDirectoryPath));
      if (map.Units != null)
        SerializeAndWriteUnits(map.Units, Path.Combine(outputFolderPath, UnitsDirectoryPath));
      if (map.PathingMap != null)
        SerializeAndWrite<MapPathingMap, MapPathingMapDto>(map.PathingMap, outputFolderPath, PathingMapPath);
      if (map.PreviewIcons != null)
        SerializeAndWrite<MapPreviewIcons, MapPreviewIconsDto>(map.PreviewIcons, outputFolderPath, PreviewIconsPath);
      if (map.ShadowMap != null)
        SerializeAndWrite<MapShadowMap, MapShadowMapDto>(map.ShadowMap, outputFolderPath, ShadowMapPath);
      if (map.TriggerStrings != null)
        SerializeAndWriteTriggerStrings(map.TriggerStrings, Path.Combine(outputFolderPath, TriggerStringsDirectoryPath));
      if (map.Sounds != null)
        SerializeAndWriteSounds(map.Sounds, Path.Combine(outputFolderPath, SoundsDirectoryPath));

      if (map.UnitObjectData != null)
        SerializeAndWriteUnitData(map.UnitObjectData, outputFolderPath, UnitDataDirectoryPath, CoreDataDirectorySubPath);
      if (map.UnitSkinObjectData != null)
        SerializeAndWriteUnitData(map.UnitSkinObjectData, outputFolderPath, UnitDataDirectoryPath, SkinDataDirectorySubPath);
      if (map.AbilityObjectData != null)
        SerializeAndWriteAbilityData(map.AbilityObjectData, outputFolderPath, AbilityDataDirectoryPath, CoreDataDirectorySubPath);
      if (map.AbilitySkinObjectData != null)
        SerializeAndWriteAbilityData(map.AbilitySkinObjectData, outputFolderPath, AbilityDataDirectoryPath, SkinDataDirectorySubPath);
      if (map.ItemObjectData != null)
        SerializeAndWriteItemData(map.ItemObjectData, outputFolderPath, ItemDataDirectoryPath, CoreDataDirectorySubPath);
      if (map.ItemSkinObjectData != null)
        SerializeAndWriteItemData(map.ItemSkinObjectData, outputFolderPath, ItemDataDirectoryPath, SkinDataDirectorySubPath);
      if (map.DestructableObjectData != null)
        SerializeAndWriteDestructableData(map.DestructableObjectData, outputFolderPath, DestructableDataDirectoryPath, CoreDataDirectorySubPath);
      if (map.DestructableSkinObjectData != null)
        SerializeAndWriteDestructableData(map.DestructableSkinObjectData, outputFolderPath, DestructableDataDirectoryPath, SkinDataDirectorySubPath);
      if (map.DoodadObjectData != null)
        SerializeAndWriteDoodadData(map.DoodadObjectData, outputFolderPath, DoodadDataDirectoryPath, CoreDataDirectorySubPath);
      if (map.DoodadSkinObjectData != null)
        SerializeAndWriteDoodadData(map.DoodadSkinObjectData, outputFolderPath, DoodadDataDirectoryPath, SkinDataDirectorySubPath);
      if (map.BuffObjectData != null)
        SerializeAndWriteBuffData(map.BuffObjectData, outputFolderPath, BuffDataDirectoryPath, CoreDataDirectorySubPath);
      if (map.BuffSkinObjectData != null)
        SerializeAndWriteBuffData(map.BuffSkinObjectData, outputFolderPath, BuffDataDirectoryPath, SkinDataDirectorySubPath);
      if (map.UpgradeObjectData != null)
        SerializeAndWriteUpgradeData(map.UpgradeObjectData, outputFolderPath, UpgradeDataDirectoryPath, CoreDataDirectorySubPath);
      if (map.UpgradeSkinObjectData != null) 
        SerializeAndWriteUpgradeData(map.UpgradeSkinObjectData, outputFolderPath, UpgradeDataDirectoryPath, SkinDataDirectorySubPath);

      File.WriteAllText(Path.Combine(outputFolderPath, ScriptPath), map.Script);
    }

    private static void CopyImportedFiles(string baseMapPath, List<ImportedFile> files, string outputFolderPath)
    {
      foreach (var file in files)
      {
        var sourceFileName = $@"{baseMapPath}\{file.FullPath}";
        var destinationFileName = $@"{outputFolderPath}\{ImportsPath}\{file.FullPath}";
        Directory.CreateDirectory(Path.GetDirectoryName(destinationFileName)!);
        File.Copy(sourceFileName, destinationFileName, true);
      }
    }
    
    private static void CopyUnserializableFiles(string baseMapPath, string outputFolderPath)
    {
      foreach (var filePath in GetUnserializableFilePaths())
        File.Copy($"{baseMapPath}/{filePath}", $@"{outputFolderPath}\{filePath}", true);
    }
    
    /// <summary>
    /// Converts the provided input into a Data Transfer Object, then serializes it, then writes it.
    /// </summary>
    private void SerializeAndWrite<TInput, TDataTransferObject>(TInput inputValue, string outputDirectoryPath, string fileName)
    {
      if (!Directory.Exists(outputDirectoryPath))
        Directory.CreateDirectory(outputDirectoryPath);
      
      var dataTransferObject = _mapper.Map<TInput, TDataTransferObject>(inputValue);
      var asJson = JsonSerializer.Serialize(dataTransferObject, _jsonSerializerOptions);
      var fullPath = Path.Combine(outputDirectoryPath, fileName);
      File.WriteAllText(fullPath, asJson);
    }

    private void SerializeAndWriteUnits(MapUnits units, string path)
    {
      if (!Directory.Exists(path))
        Directory.CreateDirectory(path);
      
      var positionallyChunkedUnitCollection = new PositionallyChunkedUnitSet(ChunkSize);

      foreach (var unit in units.Units)
      {
        var asDto = _mapper.Map<UnitDataDto>(unit);
        positionallyChunkedUnitCollection.Add(asDto);
      }

      foreach (var (chunk, unitSet) in positionallyChunkedUnitCollection.GetAll())
      {
        var fullPath = Path.Combine(path, $"{chunk.Item1}_{chunk.Item2}.json");
        var asJson = JsonSerializer.Serialize(unitSet, _jsonSerializerOptions);
        File.WriteAllText(fullPath, asJson);
      }
    }
    
    private void SerializeAndWriteDoodads(MapDoodads doodads, string path)
    {
      if (!Directory.Exists(path))
        Directory.CreateDirectory(path);
      
      var positionallyChunkedUnitCollection = new PositionallyChunkedDoodadSet(ChunkSize);

      foreach (var doodad in doodads.Doodads)
      {
        var asDto = _mapper.Map<DoodadDataDto>(doodad);
        positionallyChunkedUnitCollection.Add(asDto);
      }

      foreach (var (chunk, doodadSet) in positionallyChunkedUnitCollection.GetAll())
      {
        var fullPath = Path.Combine(path, $"{chunk.Item1}_{chunk.Item2}.json");
        var asJson = JsonSerializer.Serialize(doodadSet, _jsonSerializerOptions);
        File.WriteAllText(fullPath, asJson);
      }
    }
    
    private void SerializeAndWriteSounds(MapSounds sounds, string path)
    {
      foreach (var sound in sounds.Sounds)
        SerializeAndWrite<Sound, SoundDto>(sound, path, $"{sound.Name.Remove(0, 7)}.json");
    }
    
    private void SerializeAndWriteTriggerStrings(TriggerStrings triggerStrings, string path)
    {
      if (!Directory.Exists(path))
        Directory.CreateDirectory(path);
      
      foreach (var triggerString in triggerStrings.Strings)
      {
        var asJson = JsonSerializer.Serialize(triggerString, _jsonSerializerOptions);
        var fileName = Path.Combine(path, $"{triggerString.Key}.json");
        File.WriteAllText(fileName, asJson);
      }
    }
    
    private void SerializeAndWriteRegions(MapRegions regions, string path)
    {
      foreach (var region in regions.Regions)
        SerializeAndWrite<Region, RegionDto>(region, path, $"{region.Name}.json");
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
        Directory.CreateDirectory(outputDirectoryPath);
      
      var id = simpleObject.NewId > 0 ? simpleObject.NewId : simpleObject.OldId;
      var asJson = JsonSerializer.Serialize(simpleObject, _jsonSerializerOptions);
      var fullPath = Path.Combine(outputDirectoryPath, $"{id}.json");
      File.WriteAllText(fullPath, asJson);
    }
    
    private void SerializeAndWriteVariationObjectModification(VariationObjectModification variationObject, string outputDirectoryPath)
    {
      if (!Directory.Exists(outputDirectoryPath))
        Directory.CreateDirectory(outputDirectoryPath);
      
      var id = variationObject.NewId > 0 ? variationObject.NewId : variationObject.OldId;
      var asJson = JsonSerializer.Serialize(variationObject, _jsonSerializerOptions);
      var fullPath = Path.Combine(outputDirectoryPath, $"{id}.json");
      File.WriteAllText(fullPath, asJson);
    }
    
    private void SerializeAndWriteLevelObjectModification(LevelObjectModification levelObjectModification, string outputDirectoryPath)
    {
      if (!Directory.Exists(outputDirectoryPath))
        Directory.CreateDirectory(outputDirectoryPath);
      
      var id = levelObjectModification.NewId > 0 ? levelObjectModification.NewId : levelObjectModification.OldId;
      var asJson = JsonSerializer.Serialize(levelObjectModification, _jsonSerializerOptions);
      var fullPath = Path.Combine(outputDirectoryPath, $"{id}.json");
      File.WriteAllText(fullPath, asJson);
    }
  }
}