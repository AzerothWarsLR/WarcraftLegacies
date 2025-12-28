using War3Net.Build;
using War3Net.Build.Extensions;
using War3Net.Build.Object;
using War3Net.Build.Script;

namespace Warcraft.Cartographer.Extensions;

public static class War3NetExtensions
{
  /// <summary>
  /// Merges skin modifications for each object type (units, abilities, items, etc.) into the corresponding object data.
  /// </summary>
  /// <remarks>
  /// <para>
  /// If the map has trigger strings, string-valued fields in the modifications are localized.
  /// </para>
  /// </remarks>
  public static void MergeObjectData(this Map map)
  {
    {
      if (map is { AbilityObjectData: { } objectData, AbilitySkinObjectData: { } skinData })
      {
        MergeObjectData(objectData.BaseAbilities, skinData.BaseAbilities, map.TriggerStrings);
        MergeObjectData(objectData.NewAbilities, skinData.NewAbilities, map.TriggerStrings);
        map.AbilitySkinObjectData = null;
      }
    }

    {
      if (map is { BuffObjectData: { } objectData, BuffSkinObjectData: { } skinData })
      {
        MergeObjectData(objectData.BaseBuffs, skinData.BaseBuffs, map.TriggerStrings);
        MergeObjectData(objectData.NewBuffs, skinData.NewBuffs, map.TriggerStrings);
        map.BuffSkinObjectData = null;
      }
    }

    {
      if (map is { DestructableObjectData: { } objectData, DestructableSkinObjectData: { } skinData })
      {
        MergeObjectData(objectData.BaseDestructables, skinData.BaseDestructables, map.TriggerStrings);
        MergeObjectData(objectData.NewDestructables, skinData.NewDestructables, map.TriggerStrings);
        map.DestructableSkinObjectData = null;
      }
    }

    {
      if (map is { DoodadObjectData: { } objectData, DoodadSkinObjectData: { } skinData })
      {
        MergeObjectData(objectData.BaseDoodads, skinData.BaseDoodads, map.TriggerStrings);
        MergeObjectData(objectData.NewDoodads, skinData.NewDoodads, map.TriggerStrings);
        map.DoodadSkinObjectData = null;
      }
    }

    {
      if (map is { ItemObjectData: { } objectData, ItemSkinObjectData: { } skinData })
      {
        MergeObjectData(objectData.BaseItems, skinData.BaseItems, map.TriggerStrings);
        MergeObjectData(objectData.NewItems, skinData.NewItems, map.TriggerStrings);
        map.ItemSkinObjectData = null;
      }
    }

    {
      if (map is { UnitObjectData: { } objectData, UnitSkinObjectData: { } skinData })
      {
        MergeObjectData(objectData.BaseUnits, skinData.BaseUnits, map.TriggerStrings);
        MergeObjectData(objectData.NewUnits, skinData.NewUnits, map.TriggerStrings);
        map.UnitSkinObjectData = null;
      }
    }

    {
      if (map is { UpgradeObjectData: { } objectData, UpgradeSkinObjectData: { } skinData })
      {
        MergeObjectData(objectData.BaseUpgrades, skinData.BaseUpgrades, map.TriggerStrings);
        MergeObjectData(objectData.NewUpgrades, skinData.NewUpgrades, map.TriggerStrings);
        map.UpgradeSkinObjectData = null;
      }
    }
  }

  /// <summary>
  /// Replaces string-valued fields in the object data modifications with their localized values
  /// from the provided <see cref="TriggerStrings"/> instance.
  /// </summary>
  /// <typeparam name="T">The type of object data modification.</typeparam>
  /// <param name="modifications">The modifications whose string fields should be localized.</param>
  /// <param name="triggerStrings">The trigger strings used to look up localized values.</param>
  /// <remarks>
  /// <para>
  /// Each string that starts with the prefix <c>TRIGSTR_</c> is interpreted as a trigger string key.
  /// If the key exists in <paramref name="triggerStrings"/>, the modification's value is replaced with the corresponding localized string.
  /// Strings that do not match this pattern remain unchanged.
  /// </para>
  /// </remarks>
  public static void LocalizeModifications<T>(this IEnumerable<T> modifications, TriggerStrings triggerStrings)
    where T : ObjectDataModification
  {
    foreach (var modification in modifications)
    {
      if (modification.Type == ObjectDataType.String)
      {
        modification.Value = modification.ValueAsString.Localize(triggerStrings);
      }
    }
  }

  private static void MergeObjectData(
    List<SimpleObjectModification> objectData,
    List<SimpleObjectModification> skinData,
    TriggerStrings? triggerStrings)
  {
    MergeObjectData(
      objectData,
      skinData,
      modification => modification.ToString(),
      modification => modification.Modifications,
      triggerStrings);
  }

  private static void MergeObjectData(
    List<LevelObjectModification> objectData,
    List<LevelObjectModification> skinData,
    TriggerStrings? triggerStrings)
  {
    MergeObjectData(
      objectData,
      skinData,
      modification => modification.ToString(),
      modification => modification.Modifications,
      triggerStrings);
  }

  private static void MergeObjectData(
    List<VariationObjectModification> objectData,
    List<VariationObjectModification> skinData,
    TriggerStrings? triggerStrings)
  {
    MergeObjectData(
      objectData,
      skinData,
      modification => modification.ToString(),
      modification => modification.Modifications,
      triggerStrings);
  }

  private static void MergeObjectData<T, TT>(
    List<T> objectData,
    List<T> skinData,
    Func<T, string> objectIdSelector,
    Func<T, List<TT>> modificationsSelector,
    TriggerStrings? triggerStrings = null)
    where T : class
    where TT : ObjectDataModification
  {
    if (objectData.Count == 0 || skinData.Count == 0)
    {
      return;
    }

    var skinDataObjects = new Dictionary<string, T>(skinData.Count, StringComparer.Ordinal);

    foreach (var skinDataObject in skinData)
    {
      skinDataObjects[objectIdSelector(skinDataObject)] = skinDataObject;
    }

    foreach (var dataObject in objectData)
    {
      if (!skinDataObjects.TryGetValue(objectIdSelector(dataObject), out var skinDataObject))
      {
        continue;
      }

      var objectDataModifications = modificationsSelector(dataObject);
      var skinDataModifications = modificationsSelector(skinDataObject);

      if (triggerStrings != null)
      {
        objectDataModifications.LocalizeModifications(triggerStrings);
        skinDataModifications.LocalizeModifications(triggerStrings);
      }

      objectDataModifications.AddRange(skinDataModifications);
    }
  }
}
