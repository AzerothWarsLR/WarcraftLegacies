using System;
using System.Drawing;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Launcher.JsonConverters;

public sealed class ColorJsonConverter : JsonConverter<Color>
{
  public override Color Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
    ColorTranslator.FromHtml(reader.GetString()!);

  public override void Write(Utf8JsonWriter writer, Color value, JsonSerializerOptions options) =>
    writer.WriteStringValue($"#{value.R:X2}{value.G:X2}{value.B.ToString("X2").ToLower()}");
}
