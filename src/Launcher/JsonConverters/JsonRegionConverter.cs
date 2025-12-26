using System;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using War3Net.Build.Environment;

namespace Launcher.JsonConverters;

public sealed class JsonRegionConverter : JsonConverter<Region>
{
  private const MapRegionsFormatVersion FormatVersion = MapRegionsFormatVersion.v5;

  private delegate void ReadFrom(
    ref Utf8JsonReader reader,
    MapRegionsFormatVersion version);

  private delegate void WriteTo(
    Utf8JsonWriter writer,
    JsonSerializerOptions options,
    MapRegionsFormatVersion formatVersion);

  private static readonly MethodInfo _readFromMethod = GetMethodForDelegate<ReadFrom>();
  private static readonly MethodInfo _writeToMethod = GetMethodForDelegate<WriteTo>();

  public override Region Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    var region = new Region();
    _readFromMethod.CreateDelegate<ReadFrom>(region).Invoke(ref reader, FormatVersion);
    return region;
  }

  public override void Write(Utf8JsonWriter writer, Region value, JsonSerializerOptions options)
  {
    _writeToMethod.CreateDelegate<WriteTo>(value).Invoke(writer, options, FormatVersion);
  }

  private static MethodInfo GetMethodForDelegate<TDelegate>() where TDelegate : Delegate
  {
    var invoke = typeof(TDelegate).GetMethod("Invoke")!;

    var paramTypes = invoke.GetParameters()
      .Select(p => p.ParameterType)
      .ToArray();

    var methodName = typeof(TDelegate).Name;

    return typeof(Region).GetMethod(
      methodName,
      BindingFlags.Instance | BindingFlags.NonPublic,
      paramTypes
    ) ?? throw new InvalidOperationException($"Method '{methodName}' not found.");
  }
}
