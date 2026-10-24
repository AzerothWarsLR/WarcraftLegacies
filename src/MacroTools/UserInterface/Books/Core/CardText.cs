using System;
using System.Collections.Generic;
using System.Text;
using MacroTools.Quests;

namespace MacroTools.UserInterface.Books.Core;

/// <summary>
/// Text formatting shared by cards that show requirements and countdowns.
/// </summary>
public static class CardText
{
  /// <summary>Formats a number of seconds as minutes and seconds, like 1:05.</summary>
  public static string FormatTime(float seconds)
  {
    var wholeSeconds = (int)Math.Ceiling(seconds);
    var remainder = wholeSeconds % 60;
    return $"{wholeSeconds / 60}:{(remainder < 10 ? "0" : "")}{remainder}";
  }

  /// <summary>Lists requirements one per line: green when complete, red when failed, grey otherwise.</summary>
  public static string FormatRequirements(IEnumerable<Objective> requirements)
  {
    var text = new StringBuilder();
    foreach (var requirement in requirements)
    {
      var color = requirement.Progress switch
      {
        QuestProgress.Complete => "|cff00ff00",
        QuestProgress.Failed => "|cffff0000",
        _ => "|cffaaaaaa"
      };
      text.Append($"\n{color}- {requirement.Description}|r");
    }

    return text.ToString();
  }
}
