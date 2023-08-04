using System;
using System.Text.Json;
using System.Text.Json.Nodes;
using War3Net.Build.Object;

namespace Launcher
{
  public static class SimpleObjectDataModificationExtensions
  {
    public static object GetCastedValue(this SimpleObjectDataModification modification)
    {
      if (modification.Value is not JsonElement jsonElement) 
        throw new InvalidOperationException();
      
      switch (modification.Type)
      {
        case ObjectDataType.Int:
          return jsonElement.GetInt32();
        case ObjectDataType.Real:
          return jsonElement.GetDecimal();
        case ObjectDataType.Unreal:
          return jsonElement.GetDecimal();
        case ObjectDataType.String:
          return jsonElement.GetString();
        default:
          throw new ArgumentOutOfRangeException(nameof(modification));
      }
    }
  }
}