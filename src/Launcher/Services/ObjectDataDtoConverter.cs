#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using Launcher.DataTransferObjects;
using War3Net.Build.Object;
using War3Net.Build.Script;

namespace Launcher.Services
{
  /// <summary>
  /// Responsible for converting ObjectData files to their Data Transfer Object equivalents.
  /// </summary>
  public sealed class ObjectDataToDtoConverter
  {
    /// <summary>
    /// Converts a <see cref="UnitObjectData"/> object to its <see cref="UnitObjectDataDto"/> equivalent.
    /// </summary>
    /// <param name="unitObjectData">The object to convert.</param>
    /// <param name="triggerStrings">If supplied, unit data values that point to trigger string keys will instead be
    /// replaced with the value of those keys.</param>
    public UnitObjectDataDto ConvertToDto(UnitObjectData unitObjectData, TriggerStrings? triggerStrings)
    {
      var triggerStringsDictionary = ConvertTriggerStringsToDictionary(triggerStrings);
      var dto = new UnitObjectDataDto
      {
        FormatVersion = 0,
        BaseUnits = unitObjectData.BaseUnits
          .Select(x => ConvertSimpleModificationToDto(x, triggerStringsDictionary))
          .ToArray(),
        NewUnits = unitObjectData.NewUnits
          .Select(x => ConvertSimpleModificationToDto(x, triggerStringsDictionary))
          .ToArray()
      };
      return dto;
    }
    
    private static SimpleObjectModification ConvertSimpleModificationToDto(
      SimpleObjectModification simpleObjectModification, IReadOnlyDictionary<uint, string>? triggerStringDictionary)
    {
      var dto = new SimpleObjectModification
      {
        OldId = simpleObjectModification.OldId,
        NewId = simpleObjectModification.NewId,
        Unk = new List<int>(),
        Modifications = simpleObjectModification.Modifications
          .Select(x => ConvertSimpleObjectDataModificationToDto(x, triggerStringDictionary))
          .ToList()
      };
      return dto;
    }

    private static SimpleObjectDataModification ConvertSimpleObjectDataModificationToDto(SimpleObjectDataModification simpleObjectDataModification, IReadOnlyDictionary<uint, string>? triggerStrings)
    {
      var value = triggerStrings != null && ValueIsTriggerString(simpleObjectDataModification)
        ? triggerStrings[ParseTriggerStringAsKey((simpleObjectDataModification.Value as string)!)]
        : simpleObjectDataModification.Value;

      return new SimpleObjectDataModification
      {
        Id = simpleObjectDataModification.Id,
        Type = simpleObjectDataModification.Type,
        Value = value
      };
    }

    private static bool ValueIsTriggerString(ObjectDataModification modification)
    {
      if (modification.Type == ObjectDataType.String)
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
    
    private static Dictionary<uint, string>? ConvertTriggerStringsToDictionary(TriggerStrings? triggerStrings)
    {
      if (triggerStrings == null)
        return null;
      
      var dictionary = new Dictionary<uint, string>();
      foreach (var triggerString in triggerStrings.Strings)
      {
        if (triggerString.Value == null)
          throw new InvalidOperationException($"Cannot parse a {nameof(TriggerString)} with a null value.");
        
        dictionary.Add(triggerString.Key, triggerString.Value);
      } 
      
      return dictionary;
    }
  }
}