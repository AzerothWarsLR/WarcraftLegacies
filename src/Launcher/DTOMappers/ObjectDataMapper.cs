#nullable enable
using System.Collections.Generic;
using System.Linq;
using Launcher.DataTransferObjects;
using War3Net.Build.Object;

namespace Launcher.DTOMappers
{
  /// <summary>
  /// Responsible for converting ObjectData files to their Data Transfer Object equivalents.
  /// </summary>
  public sealed class ObjectDataMapper
  {
    private readonly TriggerStringDictionary _triggerStrings;

    public ObjectDataMapper(TriggerStringDictionary triggerStrings) => _triggerStrings = triggerStrings;

    /// <summary>
    /// Converts a <see cref="UnitObjectData"/> object to its <see cref="UnitObjectDataDto"/> equivalent.
    /// </summary>
    /// <param name="objectData">The objects to convert.</param>
    /// <param name="substituteTriggerStrings">If supplied, unit data values that point to trigger string keys will instead be
    /// replaced with the value of those keys.</param>
    public UnitObjectDataDto MapToDto(UnitObjectData objectData, bool substituteTriggerStrings)
    {
      var dto = new UnitObjectDataDto
      {
        FormatVersion = 0,
        BaseUnits = objectData.BaseUnits
          .Select(x => MapSimpleModificationToDto(x, substituteTriggerStrings))
          .ToArray(),
        NewUnits = objectData.NewUnits
          .Select(x => MapSimpleModificationToDto(x, substituteTriggerStrings))
          .ToArray()
      };
      return dto;
    }

    public MapBuffObjectDataDto MapToDto(BuffObjectData objectData, bool substituteTriggerStrings)
    {
      var dto = new MapBuffObjectDataDto
      {
        FormatVersion = 0,
        BaseBuffs = objectData.BaseBuffs
          .Select(x => MapSimpleModificationToDto(x, substituteTriggerStrings))
          .ToArray(),
        NewBuffs = objectData.NewBuffs
          .Select(x => MapSimpleModificationToDto(x, substituteTriggerStrings))
          .ToArray()
      };
      return dto;
    }

    public MapDoodadObjectDataDto MapToDto(DoodadObjectData objectData, bool substituteTriggerStrings)
    {
      var dto = new MapDoodadObjectDataDto
      {
        FormatVersion = 0,
        BaseDoodads = objectData.BaseDoodads
          .Select(x => MapVariationModificationToDto(x, substituteTriggerStrings))
          .ToArray(),
        NewDoodads = objectData.NewDoodads
          .Select(x => MapVariationModificationToDto(x, substituteTriggerStrings))
          .ToArray()
      };
      return dto;
    }

    public MapDestructableObjectDataDto MapToDto(DestructableObjectData objectData, bool substituteTriggerStrings)
    {
      var dto = new MapDestructableObjectDataDto
      {
        FormatVersion = 0,
        BaseDestructables = objectData.BaseDestructables
          .Select(x => MapSimpleModificationToDto(x, substituteTriggerStrings))
          .ToArray(),
        NewDestructables = objectData.NewDestructables
          .Select(x => MapSimpleModificationToDto(x, substituteTriggerStrings))
          .ToArray()
      };
      return dto;
    }

    public MapItemObjectDataDto MapToDto(ItemObjectData objectData, bool substituteTriggerStrings)
    {
      var dto = new MapItemObjectDataDto
      {
        FormatVersion = 0,
        BaseItems = objectData.BaseItems
          .Select(x => MapSimpleModificationToDto(x, substituteTriggerStrings))
          .ToArray(),
        NewItems = objectData.NewItems
          .Select(x => MapSimpleModificationToDto(x, substituteTriggerStrings))
          .ToArray()
      };
      return dto;
    }

    public MapAbilityObjectDataDto MapToDto(AbilityObjectData objectData, bool substituteTriggerStrings)
    {
      var dto = new MapAbilityObjectDataDto
      {
        FormatVersion = 0,
        BaseAbilities = objectData.BaseAbilities
          .Select(x => MapLevelModificationToDto(x, substituteTriggerStrings))
          .ToArray(),
        NewAbilities = objectData.NewAbilities
          .Select(x => MapLevelModificationToDto(x, substituteTriggerStrings))
          .ToArray()
      };
      return dto;
    }

    public MapUpgradeObjectDataDto MapToDto(UpgradeObjectData objectData, bool substituteTriggerStrings)
    {
      var dto = new MapUpgradeObjectDataDto
      {
        FormatVersion = 0,
        BaseUpgrades = objectData.BaseUpgrades
          .Select(x => MapLevelModificationToDto(x, substituteTriggerStrings))
          .ToArray(),
        NewUpgrades = objectData.NewUpgrades
          .Select(x => MapLevelModificationToDto(x, substituteTriggerStrings))
          .ToArray()
      };
      return dto;
    }

    private SimpleObjectModification MapSimpleModificationToDto(SimpleObjectModification simpleObjectModification, bool substituteTriggerStrings)
    {
      var ignoredDataModifications = new List<int>
      {
        //These object data fields are not converted to MapData, usually because they are already comprehensively handled
        //by a migration script.
        1986358389, //StatsLevel
        1633837685, //StatsGoldBountyAwardedBase
        1768186485, //StatsGoldBountyAwardedNumberOfDice
        1769169525  //StatsGoldBountyAwardedSidesPerDie
      };
      
      var dto = new SimpleObjectModification
      {
        OldId = simpleObjectModification.OldId,
        NewId = simpleObjectModification.NewId,
        Unk = new List<int>
        {
          0
        },
        Modifications = simpleObjectModification.Modifications
          .Select(x => MapObjectDataModificationToDto(x, substituteTriggerStrings))
          .Where(x => !ignoredDataModifications.Contains(x.Id))
          .ToList()
      };
      return dto;
    }

    private LevelObjectModification MapLevelModificationToDto(LevelObjectModification objectModification, bool substituteTriggerStrings)
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
          .Select(x => MapLevelObjectDataModificationToDto(x, substituteTriggerStrings))
          .ToList()
      };
      return dto;
    }

    private VariationObjectModification MapVariationModificationToDto(VariationObjectModification objectModification, bool substituteTriggerStrings)
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
          .Select(x => MapVariationObjectDataModificationToDto(x, substituteTriggerStrings))
          .ToList()
      };
      return dto;
    }

    private SimpleObjectDataModification MapObjectDataModificationToDto(
      SimpleObjectDataModification objectDataModification, bool substituteTriggerStrings)
    {
      var value = substituteTriggerStrings && TriggerStringDictionary.IsTriggerStringKey(objectDataModification.Value)
        ? _triggerStrings[objectDataModification.Value as string]
        : objectDataModification.Value;

      return new SimpleObjectDataModification
      {
        Id = objectDataModification.Id,
        Type = objectDataModification.Type,
        Value = value
      };
    }

    private LevelObjectDataModification MapLevelObjectDataModificationToDto(
      LevelObjectDataModification objectDataModification, bool substituteTriggerStrings)
    {
      var value = substituteTriggerStrings && TriggerStringDictionary.IsTriggerStringKey(objectDataModification.Value)
        ? _triggerStrings[objectDataModification.Value as string]
        : objectDataModification.Value;

      return new LevelObjectDataModification
      {
        Id = objectDataModification.Id,
        Type = objectDataModification.Type,
        Value = value,
        Level = objectDataModification.Level,
        Pointer = objectDataModification.Pointer
      };
    }

    private VariationObjectDataModification MapVariationObjectDataModificationToDto(
      VariationObjectDataModification objectDataModification, bool substituteTriggerStrings)
    {
      var value = substituteTriggerStrings && TriggerStringDictionary.IsTriggerStringKey(objectDataModification.Value)
        ? _triggerStrings[objectDataModification.Value as string]
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
  }
}