using System.Collections.Generic;
using System.Text.Json.Serialization.Metadata;
using Launcher.Extensions;
using War3Net.Build.Object;

namespace Launcher.Services;

public sealed class JsonModifierProvider
{
  /// <summary>
  /// Data stored as <see cref="ObjectDataModification"/> or anything deriving from it has an object field which
  /// needs to be manually given a type by interpreting the object's Type field.
  /// </summary>
  public void CastModificationSets(JsonTypeInfo typeInfo)
  {
    foreach (var propertyInfo in typeInfo.Properties)
    {
      if (propertyInfo.Name != "Modifications")
      {
        continue;
      }

      var setProperty = propertyInfo.Set;
      if (setProperty is not null)
      {
        propertyInfo.Set = (obj, value) =>
        {
          if (value is List<ObjectDataModification> modificationSet)
          {
            foreach (var modification in modificationSet)
            {
              modification.Value = modification.GetCastedValue();
            }
          }

          if (value is List<LevelObjectDataModification> levelObjectDataModificationSet)
          {
            foreach (var modification in levelObjectDataModificationSet)
            {
              modification.Value = modification.GetCastedValue();
            }
          }

          if (value is List<SimpleObjectDataModification> simpleObjectDataModificationSet)
          {
            foreach (var modification in simpleObjectDataModificationSet)
            {
              modification.Value = modification.GetCastedValue();
            }
          }

          if (value is List<VariationObjectDataModification> variationObjectDataModificationSet)
          {
            foreach (var modification in variationObjectDataModificationSet)
            {
              modification.Value = modification.GetCastedValue();
            }
          }

          setProperty(obj, value);
        };
      }
    }
  }
}
