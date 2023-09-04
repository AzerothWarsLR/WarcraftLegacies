using System;
using System.Collections.Generic;

namespace Launcher.DTOMappers
{
  public sealed class TriggerStringDictionary
  {
    private readonly Dictionary<uint, string> _triggerStrings = new();

    public void Add(uint key, string value) => _triggerStrings.Add(key, value);

    public string this[uint key] => _triggerStrings[key];

    public string this[string key] => GetTriggerStringValueFromKey(key);

    public bool ObjectIsTriggerStringKey(object obj) => obj is string asString && asString.StartsWith("TRIGSTR_");

    /// <summary>
    /// Gets a value from a <see cref="Dictionary{TKey,TValue}"/> of TriggerString values indexed by a key.
    /// <para>If the provided key turns out to be invalid, this method will return the key back.</para> 
    /// </summary>
    private string GetTriggerStringValueFromKey(string key) =>
      !ObjectIsTriggerStringKey(key) ? key : _triggerStrings[ParseTriggerStringAsKey(key)];

    private static uint ParseTriggerStringAsKey(string triggerString)
    {
      var textAfterUnderscore = triggerString[(triggerString.LastIndexOf('_') + 1)..];
      if (uint.TryParse(textAfterUnderscore, out var parsedKey))
        return parsedKey;

      throw new InvalidOperationException($"{triggerString} is not a valid TriggerString key.");
    }
  }
}