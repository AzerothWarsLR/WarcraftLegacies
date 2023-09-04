using System.Collections.Generic;
using Launcher.DTOMappers;
using War3Net.Build.Script;

namespace Launcher.Extensions;

public static class TriggerStringsExtensions
{
  public static TriggerStringDictionary ToDictionary(this TriggerStrings triggerStrings)
  {
    if (triggerStrings == null)
      return null;
      
    var dictionary = new TriggerStringDictionary();
    foreach (var triggerString in triggerStrings.Strings)
    {
      if (triggerString.Value != null)
        dictionary.Add(triggerString.Key, triggerString.Value);
    } 
      
    return dictionary;
  }
}