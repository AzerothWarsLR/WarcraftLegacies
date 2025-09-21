using System;
using MacroTools.Extensions;
using WCSharp.Shared;

namespace WarcraftLegacies.Source.GameLogic;

/// <summary>
/// Display intro text to all players after some period of time has elapsed.
/// </summary>
public static class DisplayIntroText
{
  /// <summary>
  /// Displays intro text to all players after some period of time has elapsed.
  /// </summary>
  /// <param name="displayTime">The time after which to display intro text, in seconds.</param>
  public static void Setup(float displayTime)
  {
    timer.Create().Start(displayTime, false, () =>
    {
      try
      {
        foreach (var player1 in Util.EnumeratePlayers())
        {
          player1.DisplayTextTo(player1.GetFaction()?.IntroText ?? "", 0, 0);
        }

        @event.ExpiredTimer.Dispose();
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Error displaying intro text {ex}");
      }
    });
    foreach (var player in Util.EnumeratePlayers())
    {
      player.DisplayTimedTextTo(displayTime - 1, @"|cffffcc00Warcraft Legacies|r
  |cffaaaaaaJoin our Discord:|r discord.gg/pnWZs69
  |cffff0000Support our Patreon:|r https://www.patreon.com/lordsebas

  If you are a new player, look at the Quest (F9) tab to see your objectives
  ", 0, 0);
    }
  }
}
