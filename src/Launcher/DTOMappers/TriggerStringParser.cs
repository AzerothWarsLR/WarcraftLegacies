using System;

namespace Launcher.DTOMappers
{
  public static class TriggerStringParser
  {
    public static uint ParseTriggerStringAsKey(string triggerString)
    {
      var textAfterUnderscore = triggerString[(triggerString.LastIndexOf('_') + 1)..];
      if (uint.TryParse(textAfterUnderscore, out var parsedKey))
        return parsedKey;

      throw new InvalidOperationException($"{triggerString} does not contain a valid TriggerString key.");
    }
  }
}