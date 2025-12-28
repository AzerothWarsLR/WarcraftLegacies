using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using War3Net.Build.Object;

namespace Warcraft.Cartographer.Json;

public sealed class JsonModifierProvider
{
  /// <summary>
  /// Data stored as <see cref="ObjectDataModification"/> or anything deriving from it has an object field which
  /// needs to be manually given a type by interpreting the object's Type field.
  /// </summary>
  public static void CastModificationSets(JsonTypeInfo typeInfo)
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
              modification.Value = GetCastedValue(modification);
            }
          }

          if (value is List<LevelObjectDataModification> levelObjectDataModificationSet)
          {
            foreach (var modification in levelObjectDataModificationSet)
            {
              modification.Value = GetCastedValue(modification);
            }
          }

          if (value is List<SimpleObjectDataModification> simpleObjectDataModificationSet)
          {
            foreach (var modification in simpleObjectDataModificationSet)
            {
              modification.Value = GetCastedValue(modification);
            }
          }

          if (value is List<VariationObjectDataModification> variationObjectDataModificationSet)
          {
            foreach (var modification in variationObjectDataModificationSet)
            {
              modification.Value = GetCastedValue(modification);
            }
          }

          setProperty(obj, value);
        };
      }
    }
  }

  private static object GetCastedValue(ObjectDataModification modification)
  {
    if (modification.Value is not JsonElement jsonElement)
    {
      throw new InvalidOperationException();
    }

    switch (modification.Type)
    {
      case ObjectDataType.Int:
        return jsonElement.GetInt32();
      case ObjectDataType.Real:
        return jsonElement.GetSingle();
      case ObjectDataType.Unreal:
        return jsonElement.GetSingle();
      case ObjectDataType.String:
        return jsonElement.GetString();
      default:
        throw new ArgumentOutOfRangeException(nameof(modification));
    }
  }
}
