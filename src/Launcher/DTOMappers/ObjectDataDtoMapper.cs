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
  public sealed class ObjectDataToDtoMapper
  {
    /// <summary>
    /// Converts a <see cref="UnitObjectData"/> object to its <see cref="UnitObjectDataDto"/> equivalent.
    /// </summary>
    /// <param name="unitObjectData">The object to convert.</param>
    /// <param name="triggerStrings">If supplied, unit data values that point to trigger string keys will instead be
    /// replaced with the value of those keys.</param>
    public UnitObjectDataDto MapToDto(UnitObjectData unitObjectData, Dictionary<uint, string> triggerStrings)
    {
      var dto = new UnitObjectDataDto
      {
        FormatVersion = 0,
        BaseUnits = unitObjectData.BaseUnits
          .Select(x => MapSimpleModificationToDto(x, triggerStrings))
          .ToArray(),
        NewUnits = unitObjectData.NewUnits
          .Select(x => MapSimpleModificationToDto(x, triggerStrings))
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

    private static T MapObjectDataModificationToDto<T>(T simpleObjectDataModification,
      IReadOnlyDictionary<uint, string>? triggerStrings) where T : ObjectDataModification, new()
    {
      var value = triggerStrings != null && ValueIsTriggerString(simpleObjectDataModification)
        ? triggerStrings[ParseTriggerStringAsKey((simpleObjectDataModification.Value as string)!)]
        : simpleObjectDataModification.Value;

      return new T
      {
        Id = simpleObjectDataModification.Id,
        Type = simpleObjectDataModification.Type,
        Value = value
      };
    }

    private static bool ValueIsTriggerString(ObjectDataModification modification)
    {
      if (modification.Type != ObjectDataType.String)
        return false;

      return modification.Value is string asString && asString.StartsWith("TRIGSTR_");
    }
    
    private static uint ParseTriggerStringAsKey(string triggerString)
    {
      var textAfterUnderscore = triggerString[(triggerString.LastIndexOf('_') + 1)..];
      if (uint.TryParse(textAfterUnderscore, out var parsedKey))
        return parsedKey;

      throw new InvalidOperationException($"{triggerString} does not contain a valid TriggerString key.");
    }
  }
}