#nullable enable
using Launcher.DTOMappers;
using War3Net.Build.Script;

namespace Launcher.Extensions;

public static class TriggerStringsExtensions
{
  public static TriggerStringDictionary ToDictionary(this TriggerStrings? triggerStrings)
  {
    var dictionary = new TriggerStringDictionary();

    if (triggerStrings == null)
    {
      return dictionary;
    }

    foreach (var triggerString in triggerStrings.Strings)
    {
      if (triggerString.Value != null)
      {
        dictionary.Add(triggerString.Key, triggerString.Value);
      }
    }

    return dictionary;
  }
}
