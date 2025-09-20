using System;
using System.Text.Json;
using War3Net.Build.Object;

namespace Launcher.Extensions;

public static class ObjectDataModificationExtensions
{
  public static object GetCastedValue(this ObjectDataModification modification)
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
