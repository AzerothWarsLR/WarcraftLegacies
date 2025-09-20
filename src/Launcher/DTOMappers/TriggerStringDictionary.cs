using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Launcher.DTOMappers;

public sealed class TriggerStringDictionary
{
  private readonly Dictionary<uint, string> _triggerStrings = new();

  public void Add(uint key, string value) => _triggerStrings.Add(key, value);

  public string this[uint key] => _triggerStrings[key];

  public string this[string key] => GetTriggerStringValueFromKey(key);

  public static bool IsTriggerStringKey(string text) => text.StartsWith("TRIGSTR_");

  public static bool IsTriggerStringKey(object obj) => obj is string asString && asString.StartsWith("TRIGSTR_");

  /// <summary>
  /// Finds all trigger string keys in the provided text and replaces them with their corresponding values.
  /// </summary>
  public string SubstituteTriggerStringsInText(string text)
  {
    using var stringReader = new StringReader(text);
    var stringBuilder = new StringBuilder();
    while (stringReader.ReadLine() is { } line)
    {
      var match = Regex.Match(line, "TRIGSTR_(.*)");
      if (match.Success)
      {
        var substitutionValue = this[match.Value];
        var substitutedFullLine = Regex.Replace(line, "(.*)=TRIGSTR_(.*)", $"$1=\"{substitutionValue}\"");
        stringBuilder.AppendLine(substitutedFullLine);
      }
      else
      {
        stringBuilder.AppendLine(match.Success ? $"{this[match.Value]}" : line);
      }
    }
    return stringBuilder.ToString();
  }

  /// <summary>
  /// Gets a value from a <see cref="Dictionary{TKey,TValue}"/> of TriggerString values indexed by a key.
  /// <para>If the provided key turns out to be invalid, this method will return the key back.</para> 
  /// </summary>
  private string GetTriggerStringValueFromKey(string key) =>
    !IsTriggerStringKey((object)key) ? key : _triggerStrings[ParseTriggerStringAsKey(key)];

  private static uint ParseTriggerStringAsKey(string triggerString)
  {
    var textAfterUnderscore = triggerString[(triggerString.LastIndexOf('_') + 1)..];
    if (uint.TryParse(textAfterUnderscore, out var parsedKey))
    {
      return parsedKey;
    }

    throw new InvalidOperationException($"{triggerString} is not a valid TriggerString key.");
  }
}
