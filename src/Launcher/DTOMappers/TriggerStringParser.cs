using System;
using War3Net.Build.Object;

namespace Launcher.DTOMappers
{
  public static class TriggerStringParser
  {
    public static bool ValueIsTriggerString(ObjectDataModification modification)
    {
      if (modification.Type != ObjectDataType.String)
        return false;

      return modification.Value is string asString && asString.StartsWith("TRIGSTR_");
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