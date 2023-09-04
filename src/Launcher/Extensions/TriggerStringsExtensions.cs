using System;
using System.Collections.Generic;
using War3Net.Build.Script;

namespace Launcher.Extensions;

public static class TriggerStringsExtensions
{
  public static Dictionary<uint, string> ToDictionary(this TriggerStrings triggerStrings)
  {
    if (triggerStrings == null)
      return null;
      
    var dictionary = new Dictionary<uint, string>();
    foreach (var triggerString in triggerStrings.Strings)
    {
      if (triggerString.Value == null)
        throw new InvalidOperationException($"Cannot parse a {nameof(TriggerString)} with a null value.");
        
      dictionary.Add(triggerString.Key, triggerString.Value);
    } 
      
    return dictionary;
  }
}