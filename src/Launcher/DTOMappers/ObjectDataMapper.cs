#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using Launcher.DataTransferObjects;
using War3Net.Build.Object;

namespace Launcher.DTOMappers
{
  /// <summary>
  /// Responsible for converting ObjectData files to their Data Transfer Object equivalents.
  /// </summary>
  public static class ObjectDataMapper
  {
    /// <summary>
    /// Converts a <see cref="UnitObjectData"/> object to its <see cref="UnitObjectDataDto"/> equivalent.
    /// </summary>
    /// <param name="objectData">The objects to convert.</param>
    /// <param name="triggerStrings">If supplied, unit data values that point to trigger string keys will instead be
    /// replaced with the value of those keys.</param>
    public static UnitObjectDataDto MapToDto(UnitObjectData objectData, Dictionary<uint, string>? triggerStrings)
    {
      var dto = new UnitObjectDataDto
      {
        FormatVersion = 0,
        BaseUnits = objectData.BaseUnits
          .Select(x => MapSimpleModificationToDto(x, triggerStrings))
          .ToArray(),
        NewUnits = objectData.NewUnits
          .Select(x => MapSimpleModificationToDto(x, triggerStrings))
          .ToArray()
      };
      return dto;
    }
    
    public static MapBuffObjectDataDto MapToDto(BuffObjectData objectData, Dictionary<uint, string>? triggerStrings)
    {
      var dto = new MapBuffObjectDataDto
      {
        FormatVersion = 0,
        BaseBuffs = objectData.BaseBuffs
          .Select(x => MapSimpleModificationToDto(x, triggerStrings))
          .ToArray(),
        NewBuffs = objectData.NewBuffs
          .Select(x => MapSimpleModificationToDto(x, triggerStrings))
          .ToArray()
      };
      return dto;
    }
    
    public static MapDoodadObjectDataDto MapToDto(DoodadObjectData objectData, Dictionary<uint, string>? triggerStrings)
    {
      var dto = new MapDoodadObjectDataDto
      {
        FormatVersion = 0,
        BaseDoodads = objectData.BaseDoodads
          .Select(x => MapVariationModificationToDto(x, triggerStrings))
          .ToArray(),
        NewDoodads = objectData.NewDoodads
          .Select(x => MapVariationModificationToDto(x, triggerStrings))
          .ToArray()
      };
      return dto;
    }
    
    public static MapDestructableObjectDataDto MapToDto(DestructableObjectData objectData, Dictionary<uint, string>? triggerStrings)
    {
      var dto = new MapDestructableObjectDataDto
      {
        FormatVersion = 0,
        BaseDestructables = objectData.BaseDestructables
          .Select(x => MapSimpleModificationToDto(x, triggerStrings))
          .ToArray(),
        NewDestructables = objectData.NewDestructables
          .Select(x => MapSimpleModificationToDto(x, triggerStrings))
          .ToArray()
      };
      return dto;
    }
    
    public static MapItemObjectDataDto MapToDto(ItemObjectData objectData, Dictionary<uint, string>? triggerStrings)
    {
      var dto = new MapItemObjectDataDto
      {
        FormatVersion = 0,
        BaseItems = objectData.BaseItems
          .Select(x => MapSimpleModificationToDto(x, triggerStrings))
          .ToArray(),
        NewItems = objectData.NewItems
          .Select(x => MapSimpleModificationToDto(x, triggerStrings))
          .ToArray()
      };
      return dto;
    }
    
    public static MapAbilityObjectDataDto MapToDto(AbilityObjectData objectData, Dictionary<uint, string>? triggerStrings)
    {
      var dto = new MapAbilityObjectDataDto
      {
        FormatVersion = 0,
        BaseAbilities = objectData.BaseAbilities
          .Select(x => MapLevelModificationToDto(x, triggerStrings))
          .ToArray(),
        NewAbilities = objectData.NewAbilities
          .Select(x => MapLevelModificationToDto(x, triggerStrings))
          .ToArray()
      };
      return dto;
    }
    
    public static MapUpgradeObjectDataDto MapToDto(UpgradeObjectData objectData, Dictionary<uint, string>? triggerStrings)
    {
      var dto = new MapUpgradeObjectDataDto
      {
        FormatVersion = 0,
        BaseUpgrades = objectData.BaseUpgrades
          .Select(x => MapLevelModificationToDto(x, triggerStrings))
          .ToArray(),
        NewUpgrades = objectData.NewUpgrades
          .Select(x => MapLevelModificationToDto(x, triggerStrings))
          .ToArray()
      };
      return dto;
    }
    
    private static SimpleObjectModification MapSimpleModificationToDto(
      SimpleObjectModification simpleObjectModification, IReadOnlyDictionary<uint, string>? triggerStringDictionary)
    {
      var dto = new SimpleObjectModification
      {
        OldId = simpleObjectModification.OldId,
        NewId = simpleObjectModification.NewId,
        Unk = new List<int>
        {
          0
        },
        Modifications = simpleObjectModification.Modifications
          .Select(x => MapObjectDataModificationToDto(x, triggerStringDictionary))
          .ToList()
      };
      return dto;
    }
    
    private static LevelObjectModification MapLevelModificationToDto(LevelObjectModification objectModification,
      IReadOnlyDictionary<uint, string>? triggerStringDictionary)
    {
      var dto = new LevelObjectModification
      {
        OldId = objectModification.OldId,
        NewId = objectModification.NewId,
        Unk = new List<int>
        {
          0
        },
        Modifications = objectModification.Modifications
          .Select(x => MapLevelObjectDataModificationToDto(x, triggerStringDictionary))
          .ToList()
      };
      return dto;
    }
    
    private static VariationObjectModification MapVariationModificationToDto(VariationObjectModification objectModification,
      IReadOnlyDictionary<uint, string>? triggerStringDictionary)
    {
      var dto = new VariationObjectModification
      {
        OldId = objectModification.OldId,
        NewId = objectModification.NewId,
        Unk = new List<int>
        {
          0
        },
        Modifications = objectModification.Modifications
          .Select(x => MapVariationObjectDataModificationToDto(x, triggerStringDictionary))
          .ToList()
      };
      return dto;
    }

    private static SimpleObjectDataModification MapObjectDataModificationToDto(SimpleObjectDataModification objectDataModification,
      IReadOnlyDictionary<uint, string>? triggerStrings)
    {
      var value = triggerStrings != null && ValueIsTriggerString(objectDataModification)
        ? triggerStrings[TriggerStringParser.ParseTriggerStringAsKey((objectDataModification.Value as string)!)]
        : objectDataModification.Value;
      
      return new SimpleObjectDataModification
      {
        Id = objectDataModification.Id,
        Type = objectDataModification.Type,
        Value = value
      };
    }
    
    private static LevelObjectDataModification MapLevelObjectDataModificationToDto(LevelObjectDataModification objectDataModification,
      IReadOnlyDictionary<uint, string>? triggerStrings)
    {
      var value = triggerStrings != null && ValueIsTriggerString(objectDataModification)
        ? triggerStrings[TriggerStringParser.ParseTriggerStringAsKey((objectDataModification.Value as string)!)]
        : objectDataModification.Value;
      
      return new LevelObjectDataModification
      {
        Id = objectDataModification.Id,
        Type = objectDataModification.Type,
        Value = value,
        Level = objectDataModification.Level,
        Pointer = objectDataModification.Level
      };
    }
    
    private static VariationObjectDataModification MapVariationObjectDataModificationToDto(VariationObjectDataModification objectDataModification,
      IReadOnlyDictionary<uint, string>? triggerStrings)
    {
      var value = triggerStrings != null && ValueIsTriggerString(objectDataModification)
        ? triggerStrings[TriggerStringParser.ParseTriggerStringAsKey((objectDataModification.Value as string)!)]
        : objectDataModification.Value;
      
      return new VariationObjectDataModification
      {
        Id = objectDataModification.Id,
        Type = objectDataModification.Type,
        Value = value,
        Variation = objectDataModification.Variation,
        Pointer = objectDataModification.Pointer
      };
    }

    private static bool ValueIsTriggerString(ObjectDataModification modification)
    {
      if (modification.Type != ObjectDataType.String)
        return false;

      return modification.Value is string asString && asString.StartsWith("TRIGSTR_");
    }
  }
}