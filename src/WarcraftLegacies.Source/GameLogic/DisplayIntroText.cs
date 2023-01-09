using System;
using MacroTools.Extensions;
using static War3Api.Common;

namespace WarcraftLegacies.Source.GameLogic
{
  /// <summary>
  /// Display intro text to all players after some period of time has elapsed.
  /// </summary>
  public static class DisplayIntroText
  {
    /// <summary>
    /// Displays intro text to all players after some period of time has elapsed.
    /// </summary>
    /// <param name="timeout">The time after which to display intro text, in seconds.</param>
    public static void Setup(float timeout)
    {
      CreateTimer().Start(timeout, false, () =>
      {
        try
        {
          foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
            DisplayTextToPlayer(player, 0, 0, player.GetFaction()?.IntroText ?? "");
          DestroyTimer(GetExpiredTimer());
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex);
        }
      });
      DisplayTimedTextToPlayer(GetLocalPlayer(), 0, 0, 51, @"|cffffcc00Warcraft Legacies|r
|cffaaaaaaJoin our Discord:|r discord.gg/pnWZs69
|cffff0000Support our Patreon:|r https://www.patreon.com/lordsebas
");
    }
  }
}