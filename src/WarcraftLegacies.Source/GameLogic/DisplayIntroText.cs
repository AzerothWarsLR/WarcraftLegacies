using System;
using MacroTools.Extensions;
using MacroTools.Timer;
using static War3Api.Common;

namespace WarcraftLegacies.Source.GameLogic
{
  /// <summary>
  /// Display intro text to all players after some period of time has elapsed.
  /// </summary>
  public sealed class DisplayIntroText : ITimer
  {
    /// <inheritdoc/>
    public EventHandler? OnTimerEnds { get; set; }

    private float _timeout;


    /// <summary>
    /// Displays intro text to all players after some period of time has elapsed.
    /// </summary>
    /// <param name="timeout">The time after which to display intro text, in seconds.</param>
    public DisplayIntroText(float timeout)
    {
      _timeout = timeout;
    }

    /// <inheritdoc/>
    public void StartTimer()
    {
      CreateTimer().Start(_timeout, false, () =>
      {
        try
        {
          foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
            DisplayTextToPlayer(player, 0, 0, player.GetFaction()?.IntroText ?? "");
          TimerEnd();
        }
        catch (Exception ex)
        {
          Console.WriteLine($"Error displaying intro text {ex}");
        }
      });
      DisplayTimedTextToPlayer(GetLocalPlayer(), 0, 0, _timeout - 1, @"|cffffcc00Warcraft Legacies|r
|cffaaaaaaJoin our Discord:|r discord.gg/pnWZs69
|cffff0000Support our Patreon:|r https://www.patreon.com/lordsebas

If you are a new player, look at the Quest (F9) tab to see your objectives
");
    }

    private void TimerEnd()
    {
      DestroyTimer(GetExpiredTimer());
      OnTimerEnds?.Invoke(this, new EventArgs());
    }

  }
}