using System;
using MacroTools.Extensions;
using MacroTools.Localization;
using MacroTools.Save;
using WCSharp.Shared;

namespace WarcraftLegacies.Source.GameLogic;

/// <summary>
/// Display intro text to all players after some period of time has elapsed.
/// </summary>
public static class DisplayIntroText
{
  /// <summary>
  /// Shows the generic welcome/Discord message to all players, staying up for <paramref name="displayDuration"/>
  /// seconds. Independent of <see cref="SetupFactionIntroText"/> - this one isn't faction-specific, so there's
  /// no reason to wait on the game-start vote sequence for it.
  /// </summary>
  public static void SetupWelcomeMessage(float displayDuration)
  {
    SaveManager.RunWhenLocalPlayerSettingsReady(() =>
    {
      foreach (var player in Util.EnumeratePlayers())
      {
        player.DisplayTimedTextTo(displayDuration, $@"|cffffcc00Warcraft Legacies|r
  |cffaaaaaa{Loc.Get("Join our Discord:")}|r discord.gg/pnWZs69

  {Loc.Get("If you are a new player, look at the Quest (F9) tab to see your objectives.")}
  ");
      }
    });
  }

  /// <summary>
  /// Displays each player's faction's intro text after <paramref name="displayTime"/> seconds have elapsed.
  /// Meant to be called a few seconds after the game-start vote sequence concludes, not on a fixed timer from
  /// map init - a fixed timer risks firing while the vote UI is still up, since voting can now take a variable
  /// amount of time (see <see cref="MacroTools.UserInterface.Voting.VotePageTimer"/>-driven early conclusion).
  /// </summary>
  public static void SetupFactionIntroText(float displayTime)
  {
    timer.Create().Start(displayTime, false, () =>
    {
      try
      {
        SaveManager.RunWhenLocalPlayerSettingsReady(() =>
        {
          foreach (var player in Util.EnumeratePlayers(playerslotstate.Playing, mapcontrol.User))
          {
            player.DisplayTextTo(player.GetPlayerData().Faction?.IntroText?.Invoke() ?? "");
          }
        });

        @event.ExpiredTimer.Dispose();
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Error displaying intro text {ex}");
      }
    });
  }
}
