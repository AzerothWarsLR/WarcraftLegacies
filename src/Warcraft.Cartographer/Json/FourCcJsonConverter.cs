using System.Text.Json;
using System.Text.Json.Serialization;
using War3Net.Common.Extensions;

namespace Warcraft.Cartographer.Json;

internal sealed class FourCcJsonConverter : JsonConverter<int>
{
  public static readonly FourCcJsonConverter Instance = new();

  public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    var rawcode = reader.GetString();
    if (rawcode == null)
    {
      throw new JsonException("Expected a FourCC string but got null.");
    }

    if (rawcode.Length != 4)
    {
      throw new JsonException($"Expected a 4-character FourCC string but got '{rawcode}'.");
    }

    return rawcode.FromRawcode();
  }

  public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
  {
    writer.WriteStringValue(value.ToRawcode());
  }
}
