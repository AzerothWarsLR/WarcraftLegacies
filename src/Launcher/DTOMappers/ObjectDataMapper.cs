#nullable enable
using System.Collections.Generic;
using System.Linq;
using Launcher.DataTransferObjects;
using War3Net.Build.Object;

namespace Launcher.DTOMappers;

/// <summary>
/// Responsible for converting ObjectData files to their Data Transfer Object equivalents.
/// </summary>
public sealed class ObjectDataMapper(TriggerStringDictionary triggerStrings)
{
  /// <summary>
  /// Converts a <see cref="UnitObjectData"/> object to its <see cref="UnitObjectDataDto"/> equivalent.
  /// </summary>
  /// <remarks>Unit data values that point to trigger string keys will instead be
  /// replaced with the value of those keys.</remarks>
  /// <param name="objectData">Core data to include.</param>
  /// <param name="skinData">Skin data to include.</param>
  public UnitObjectDataDto MapToDto(UnitObjectData objectData, UnitObjectData? skinData)
  {
    var coreUnits = objectData.BaseUnits.Concat(objectData.NewUnits).ToArray();
    if (skinData != null)
    {
      var skinUnits = skinData.BaseUnits.Concat(skinData.NewUnits).ToDictionary(x => x.GetId());
      foreach (var coreUnit in coreUnits)
      {
        if (skinUnits.TryGetValue(coreUnit.GetId(), out var skinUnit))
        {
          coreUnit.Modifications.AddRange(skinUnit.Modifications);
        }
      }
    }

    var dto = new UnitObjectDataDto
    {
      FormatVersion = 0,
      Units = coreUnits.Select(MapSimpleModificationToDto).ToArray()
    };
    return dto;
  }

  public MapBuffObjectDataDto MapToDto(BuffObjectData objectData, BuffObjectData? skinData)
  {
    var coreBuffs = objectData.BaseBuffs.Concat(objectData.NewBuffs).ToArray();
    if (skinData != null)
    {
      var skinBuffs = skinData.BaseBuffs.Concat(skinData.NewBuffs).ToDictionary(x => x.GetId());

      foreach (var coreBuff in coreBuffs)
      {
        if (skinBuffs.TryGetValue(coreBuff.GetId(), out var skinBuff))
        {
          coreBuff.Modifications.AddRange(skinBuff.Modifications);
        }
      }
    }

    var dto = new MapBuffObjectDataDto
    {
      FormatVersion = 0,
      Buffs = coreBuffs.Select(MapSimpleModificationToDto).ToArray()
    };
    return dto;
  }


  public MapDoodadObjectDataDto MapToDto(DoodadObjectData objectData, DoodadObjectData? skinData)
  {
    var coreDoodads = objectData.BaseDoodads.Concat(objectData.NewDoodads).ToArray();
    if (skinData != null)
    {
      var skinDoodads = skinData.BaseDoodads.Concat(skinData.NewDoodads).ToDictionary(x => x.GetId());

      foreach (var coreDoodad in coreDoodads)
      {
        if (skinDoodads.TryGetValue(coreDoodad.GetId(), out var skinDoodad))
        {
          coreDoodad.Modifications.AddRange(skinDoodad.Modifications);
        }
      }
    }

    var dto = new MapDoodadObjectDataDto
    {
      FormatVersion = 0,
      Doodads = coreDoodads.Select(MapVariationModificationToDto).ToArray()
    };
    return dto;
  }

  public MapDestructableObjectDataDto MapToDto(DestructableObjectData objectData, DestructableObjectData? skinData)
  {
    var coreDestructables = objectData.BaseDestructables.Concat(objectData.NewDestructables).ToArray();
    if (skinData != null)
    {
      var skinDestructables = skinData.BaseDestructables.Concat(skinData.NewDestructables).ToDictionary(x => x.GetId());

      foreach (var coreDestructable in coreDestructables)
      {
        if (skinDestructables.TryGetValue(coreDestructable.GetId(), out var skinDestructable))
        {
          coreDestructable.Modifications.AddRange(skinDestructable.Modifications);
        }
      }
    }

    var dto = new MapDestructableObjectDataDto
    {
      FormatVersion = 0,
      Destructables = coreDestructables.Select(MapSimpleModificationToDto).ToArray()
    };
    return dto;
  }

  public MapItemObjectDataDto MapToDto(ItemObjectData objectData, ItemObjectData? skinData)
  {
    var coreItems = objectData.BaseItems.Concat(objectData.NewItems).ToArray();
    if (skinData != null)
    {
      var skinItems = skinData.BaseItems.Concat(skinData.NewItems).ToDictionary(x => x.GetId());

      foreach (var coreItem in coreItems)
      {
        if (skinItems.TryGetValue(coreItem.GetId(), out var skinItem))
        {
          coreItem.Modifications.AddRange(skinItem.Modifications);
        }
      }
    }

    var dto = new MapItemObjectDataDto
    {
      FormatVersion = 0,
      Items = coreItems.Select(MapSimpleModificationToDto).ToArray()
    };
    return dto;
  }

  public MapAbilityObjectDataDto MapToDto(AbilityObjectData objectData, AbilityObjectData? skinData)
  {
    var coreAbilities = objectData.BaseAbilities.Concat(objectData.NewAbilities).ToArray();
    if (skinData != null)
    {
      var skinAbilities = skinData.BaseAbilities.Concat(skinData.NewAbilities).ToDictionary(x => x.GetId());

      foreach (var coreAbility in coreAbilities)
      {
        if (skinAbilities.TryGetValue(coreAbility.GetId(), out var skinAbility))
        {
          coreAbility.Modifications.AddRange(skinAbility.Modifications);
        }
      }
    }

    var dto = new MapAbilityObjectDataDto
    {
      FormatVersion = 0,
      Abilities = coreAbilities.Select(MapLevelModificationToDto).ToArray()
    };
    return dto;
  }

  public MapUpgradeObjectDataDto MapToDto(UpgradeObjectData objectData, UpgradeObjectData? skinData)
  {
    var coreUpgrades = objectData.BaseUpgrades.Concat(objectData.NewUpgrades).ToArray();
    if (skinData != null)
    {
      var skinUpgrades = skinData.BaseUpgrades.Concat(skinData.NewUpgrades).ToDictionary(x => x.GetId());

      foreach (var coreUpgrade in coreUpgrades)
      {
        if (skinUpgrades.TryGetValue(coreUpgrade.GetId(), out var skinUpgrade))
        {
          coreUpgrade.Modifications.AddRange(skinUpgrade.Modifications);
        }
      }
    }

    var dto = new MapUpgradeObjectDataDto
    {
      FormatVersion = 0,
      Upgrades = coreUpgrades.Select(MapLevelModificationToDto).ToArray()
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
    var value = TriggerStringDictionary.IsTriggerStringKey(objectDataModification.Value)
      ? triggerStrings[objectDataModification.Value as string]
      : objectDataModification.Value;

    return new SimpleObjectDataModification
    {
      Id = objectDataModification.Id,
      Type = objectDataModification.Type,
      Value = value
    };
  }

  private LevelObjectDataModification MapLevelObjectDataModificationToDto(
    LevelObjectDataModification objectDataModification)
  {
    var value = TriggerStringDictionary.IsTriggerStringKey(objectDataModification.Value)
      ? triggerStrings[objectDataModification.Value as string]
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
    VariationObjectDataModification objectDataModification)
  {
    var value = TriggerStringDictionary.IsTriggerStringKey(objectDataModification.Value)
      ? triggerStrings[objectDataModification.Value as string]
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
