using System;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using War3Net.Build.Audio;

namespace Launcher.JsonConverters;

public sealed class JsonSoundConverter : JsonConverter<Sound>
{
  private const MapSoundsFormatVersion FormatVersion = MapSoundsFormatVersion.v3;

  private delegate void ReadFrom(
    ref Utf8JsonReader reader,
    MapSoundsFormatVersion version);

  private delegate void WriteTo(
    Utf8JsonWriter writer,
    JsonSerializerOptions options,
    MapSoundsFormatVersion formatVersion);

  private static readonly MethodInfo _readFromMethod = GetMethodForDelegate<ReadFrom>();
  private static readonly MethodInfo _writeToMethod = GetMethodForDelegate<WriteTo>();

  public override Sound Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    var sound = new Sound();
    _readFromMethod.CreateDelegate<ReadFrom>(sound).Invoke(ref reader, FormatVersion);
    return sound;
  }

  public override void Write(Utf8JsonWriter writer, Sound value, JsonSerializerOptions options)
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

    return typeof(Sound).GetMethod(
      methodName,
      BindingFlags.Instance | BindingFlags.NonPublic,
      paramTypes
    ) ?? throw new InvalidOperationException($"Method '{methodName}' not found.");
  }
}
