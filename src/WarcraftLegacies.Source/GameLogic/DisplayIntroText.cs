using System;
using MacroTools.Extensions;
using MacroTools.Factions;
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
  /// Shows the generic welcome/Discord message to all players.
  /// </summary>
  public static void SetupWelcomeMessage(float displayDuration)
  {
    SaveManager.RunWhenLocalPlayerSettingsReady(() =>
    {
      foreach (var player in Util.EnumeratePlayers())
      {
        player.DisplayTimedTextTo(displayDuration, $@"|cffffcc00{Loc.Get("Warcraft Legacies")}|r
  |cffaaaaaa{Loc.Get("Join our Discord:")}|r discord.gg/ubQM7PgaG

  {Loc.Get("If you are a new player, look at the Quest (F9) tab to see your objectives.")}
  ");
      }
    });
  }

  /// <summary>
  /// Displays each player's faction's intro text after <paramref name="displayTime"/> seconds have elapsed.
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
            player.DisplayTextTo(GetIntroText(player.GetPlayerData().Faction));
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

  private static string GetIntroText(Faction? faction)
  {
    if (faction == null)
    {
      return "";
    }

    if (RoleplaySetting.IsActive && faction is IHasRoleplayIntro roleplayIntro)
    {
      return roleplayIntro.RoleplayIntroText;
    }

    return faction.IntroText?.Invoke() ?? "";
  }
}
