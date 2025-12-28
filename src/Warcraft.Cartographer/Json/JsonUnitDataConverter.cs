using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using War3Net.Build.Widget;

namespace Warcraft.Cartographer.Json;

public sealed class JsonUnitDataConverter : JsonConverter<UnitData>
{
  private const MapWidgetsFormatVersion FormatVersion = MapWidgetsFormatVersion.v8;
  private const MapWidgetsSubVersion SubVersion = MapWidgetsSubVersion.v11;
  private const bool UseNewFormat = true;

  private delegate void ReadFrom(
    ref Utf8JsonReader reader,
    MapWidgetsFormatVersion formatVersion,
    MapWidgetsSubVersion subVersion,
    bool useNewFormat);

  private delegate void WriteTo(
    Utf8JsonWriter writer,
    JsonSerializerOptions options,
    MapWidgetsFormatVersion formatVersion,
    MapWidgetsSubVersion subVersion,
    bool useNewFormat);

  private static readonly MethodInfo _readFromMethod = GetMethodForDelegate<ReadFrom>();
  private static readonly MethodInfo _writeToMethod = GetMethodForDelegate<WriteTo>();

  public override UnitData Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    var unitData = new UnitData();
    _readFromMethod.CreateDelegate<ReadFrom>(unitData).Invoke(ref reader, FormatVersion, SubVersion, UseNewFormat);
    return unitData;
  }

  public override void Write(Utf8JsonWriter writer, UnitData value, JsonSerializerOptions options)
  {
    _writeToMethod.CreateDelegate<WriteTo>(value).Invoke(writer, options, FormatVersion, SubVersion, UseNewFormat);
  }

  private static MethodInfo GetMethodForDelegate<TDelegate>() where TDelegate : Delegate
  {
    var invoke = typeof(TDelegate).GetMethod("Invoke")!;

    var paramTypes = invoke.GetParameters()
      .Select(p => p.ParameterType)
      .ToArray();

    var methodName = typeof(TDelegate).Name;

    return typeof(UnitData).GetMethod(
      methodName,
      BindingFlags.Instance | BindingFlags.NonPublic,
      paramTypes
    ) ?? throw new InvalidOperationException($"Method '{methodName}' not found.");
  }
}
