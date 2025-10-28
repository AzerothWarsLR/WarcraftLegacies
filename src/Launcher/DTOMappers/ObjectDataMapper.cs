#nullable enable
using System.Collections.Generic;
using System.Linq;
using Launcher.DataTransferObjects;
using War3Net.Build.Object;

namespace Launcher.DTOMappers;

/// <summary>
/// Responsible for converting ObjectData files to their Data Transfer Object equivalents.
/// </summary>
public sealed class ObjectDataMapper
{
  /// <summary>
  /// Converts a <see cref="UnitObjectData"/> object to its <see cref="UnitObjectDataDto"/> equivalent.
  /// </summary>
  /// <param name="objectData">The objects to convert.</param>
  public UnitObjectDataDto MapToDto(UnitObjectData objectData)
  {
    var dto = new UnitObjectDataDto
    {
      FormatVersion = 0,
      BaseUnits = objectData.BaseUnits
        .Select(MapSimpleModificationToDto)
        .ToArray(),
      NewUnits = objectData.NewUnits
        .Select(MapSimpleModificationToDto)
        .ToArray()
    };
    return dto;
  }

  public MapBuffObjectDataDto MapToDto(BuffObjectData objectData)
  {
    var dto = new MapBuffObjectDataDto
    {
      FormatVersion = 0,
      BaseBuffs = objectData.BaseBuffs
        .Select(MapSimpleModificationToDto)
        .ToArray(),
      NewBuffs = objectData.NewBuffs
        .Select(MapSimpleModificationToDto)
        .ToArray()
    };
    return dto;
  }

  public MapDoodadObjectDataDto MapToDto(DoodadObjectData objectData)
  {
    var dto = new MapDoodadObjectDataDto
    {
      FormatVersion = 0,
      BaseDoodads = objectData.BaseDoodads
        .Select(MapVariationModificationToDto)
        .ToArray(),
      NewDoodads = objectData.NewDoodads
        .Select(MapVariationModificationToDto)
        .ToArray()
    };
    return dto;
  }

  public MapDestructableObjectDataDto MapToDto(DestructableObjectData objectData)
  {
    var dto = new MapDestructableObjectDataDto
    {
      FormatVersion = 0,
      BaseDestructables = objectData.BaseDestructables
        .Select(MapSimpleModificationToDto)
        .ToArray(),
      NewDestructables = objectData.NewDestructables
        .Select(MapSimpleModificationToDto)
        .ToArray()
    };
    return dto;
  }

  public MapItemObjectDataDto MapToDto(ItemObjectData objectData)
  {
    var dto = new MapItemObjectDataDto
    {
      FormatVersion = 0,
      BaseItems = objectData.BaseItems
        .Select(MapSimpleModificationToDto)
        .ToArray(),
      NewItems = objectData.NewItems
        .Select(MapSimpleModificationToDto)
        .ToArray()
    };
    return dto;
  }

  public MapAbilityObjectDataDto MapToDto(AbilityObjectData objectData)
  {
    var dto = new MapAbilityObjectDataDto
    {
      FormatVersion = 0,
      BaseAbilities = objectData.BaseAbilities
        .Select(MapLevelModificationToDto)
        .ToArray(),
      NewAbilities = objectData.NewAbilities
        .Select(MapLevelModificationToDto)
        .ToArray()
    };
    return dto;
  }

  public MapUpgradeObjectDataDto MapToDto(UpgradeObjectData objectData)
  {
    var dto = new MapUpgradeObjectDataDto
    {
      FormatVersion = 0,
      BaseUpgrades = objectData.BaseUpgrades
        .Select(MapLevelModificationToDto)
        .ToArray(),
      NewUpgrades = objectData.NewUpgrades
        .Select(MapLevelModificationToDto)
        .ToArray()
    };
    return dto;
  }

  private SimpleObjectModification MapSimpleModificationToDto(SimpleObjectModification simpleObjectModification)
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
        .Select(MapObjectDataModificationToDto)
        .Where(x => !ignoredDataModifications.Contains(x.Id))
        .ToList()
    };
    return dto;
  }

  private LevelObjectModification MapLevelModificationToDto(LevelObjectModification objectModification)
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
        .Select(MapLevelObjectDataModificationToDto)
        .ToList()
    };
    return dto;
  }

  private VariationObjectModification MapVariationModificationToDto(VariationObjectModification objectModification)
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
        .Select(MapVariationObjectDataModificationToDto)
        .ToList()
    };
    return dto;
  }

  private SimpleObjectDataModification MapObjectDataModificationToDto(
    SimpleObjectDataModification objectDataModification)
  {
    return new SimpleObjectDataModification
    {
      Id = objectDataModification.Id,
      Type = objectDataModification.Type,
      Value = objectDataModification.Value
    };
  }

  private LevelObjectDataModification MapLevelObjectDataModificationToDto(
    LevelObjectDataModification objectDataModification)
  {
    return new LevelObjectDataModification
    {
      Id = objectDataModification.Id,
      Type = objectDataModification.Type,
      Value = objectDataModification.Value,
      Level = objectDataModification.Level,
      Pointer = objectDataModification.Pointer
    };
  }

  private VariationObjectDataModification MapVariationObjectDataModificationToDto(
    VariationObjectDataModification objectDataModification)
  {
    return new VariationObjectDataModification
    {
      Id = objectDataModification.Id,
      Type = objectDataModification.Type,
      Value = objectDataModification.Value,
      Variation = objectDataModification.Variation,
      Pointer = objectDataModification.Pointer
    };
  }
}
