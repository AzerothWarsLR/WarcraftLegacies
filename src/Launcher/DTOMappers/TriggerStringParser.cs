using System;
using System.Collections.Generic;

namespace Launcher.DTOMappers
{
  public static class TriggerStringParser
  {
    /// <summary>
    /// Gets a value from a <see cref="Dictionary{TKey,TValue}"/> of TriggerString values indexed by a key.
    /// <para>If the provided key turns out to be invalid, this method will return the key back.</para> 
    /// </summary>
    public static string GetTriggerStringValueFromKey(string key, Dictionary<uint, string> triggerStrings)
    {
      return !key.StartsWith("TRIGSTR_") ? key : triggerStrings[ParseTriggerStringAsKey(key)];
    }
    
    public static uint ParseTriggerStringAsKey(string triggerString)
    {
      var textAfterUnderscore = triggerString[(triggerString.LastIndexOf('_') + 1)..];
      if (uint.TryParse(textAfterUnderscore, out var parsedKey))
        return parsedKey;

      throw new InvalidOperationException($"{triggerString} does not contain a valid TriggerString key.");
    }
  }
}