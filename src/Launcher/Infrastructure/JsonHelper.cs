#nullable enable

using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using AutoMapper;
using Launcher.JsonConverters;
using Launcher.Services;

namespace Launcher.Infrastructure;

/// <summary>
/// Provides methods for JSON serialization and deserialization with optional type mapping support.
/// </summary>
internal static class JsonHelper
{
  private static readonly JsonSerializerOptions _options = new()
  {
    IgnoreReadOnlyProperties = true,
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
    WriteIndented = true,
    TypeInfoResolver = new DefaultJsonTypeInfoResolver
    {
      Modifiers = { JsonModifierProvider.CastModificationSets }
    },
    Converters = { new ColorJsonConverter() }
  };

  private static readonly Mapper _mapper = new(AutoMapperConfigurationProvider.GetConfiguration());

  /// <summary>
  /// Serializes the specified value to a JSON string.
  /// </summary>
  /// <param name="value">The value to serialize.</param>
  public static string Serialize<T>(T value)
  {
    return JsonSerializer.Serialize(value, _options);
  }


  /// <summary>
  /// Maps the specified value to a target type and serializes it to a JSON string.
  /// </summary>
  /// <typeparam name="T">The source type.</typeparam>
  /// <typeparam name="TT">The target type.</typeparam>
  /// <param name="value">The value to map and serialize.</param>
  public static string Serialize<T, TT>(T value)
  {
    return JsonSerializer.Serialize(_mapper.Map<T, TT>(value), _options);
  }

  /// <summary>
  /// Deserializes the JSON file at the specified path into the specified type.
  /// </summary>
  /// <typeparam name="T">The target type.</typeparam>
  /// <param name="path">The path to the JSON file.</param>
  /// <exception cref="JsonException">Thrown when the JSON is invalid or deserialization fails.</exception>
  public static T Deserialize<T>(string path)
  {
    return JsonSerializer.Deserialize<T>(File.ReadAllText(path), _options)
      ?? throw new JsonException($"Failed to deserialize '{path}' into {typeof(T).Name} (result was null).");
  }

  /// <summary>
  /// Deserializes the JSON file at the specified path into a source type and maps it to the target type.
  /// </summary>
  /// <typeparam name="T">The target type.</typeparam>
  /// <typeparam name="TT">The source type.</typeparam>
  /// <param name="path">The path to the JSON file.</param>
  /// <exception cref="JsonException">Thrown when the JSON is invalid or deserialization fails.</exception>
  public static T Deserialize<T, TT>(string path)
  {
    return _mapper.Map<TT, T>(Deserialize<TT>(path));
  }

  /// <summary>
  /// Deserializes the JSON file at the specified path into a target type, if the file exists.
  /// </summary>
  /// <remarks>Returns the <see langword="default"/> value of <typeparamref name="T"/> if the file does not exist.</remarks>
  /// <typeparam name="T">The target type.</typeparam>
  /// <param name="path">The path to the JSON file.</param>
  /// <exception cref="JsonException">Thrown when the JSON is invalid or deserialization fails.</exception>
  public static T? DeserializeIfExist<T>(string path)
  {
    return File.Exists(path) ? Deserialize<T>(path) : default;
  }

  /// <summary>
  /// Deserializes the JSON file at the specified path into a source type and maps it to the target type,
  /// if the file exists.
  /// </summary>
  /// <remarks>Returns the <see langword="default"/> value of <typeparamref name="T"/> if the file does not exist.</remarks>
  /// <typeparam name="T">The target type.</typeparam>
  /// <typeparam name="TT">The source type.</typeparam>
  /// <param name="path">The path to the JSON file.</param>
  /// <exception cref="JsonException">Thrown when the JSON is invalid or deserialization fails.</exception>
  public static T? DeserializeIfExist<T, TT>(string path)
  {
    return File.Exists(path) ? Deserialize<T, TT>(path) : default;
  }
}
