using MacroTools.Extensions;
using MacroTools.FactionSystem;
using WCSharp.Shared;

namespace WarcraftLegacies.Source.Commands;

/// <summary>
///   A command that causes a player to leave their <see cref="Team" /> and be given a solo Team with their
///   <see cref="Faction" /> as the name.
/// </summary>
public static class UnallyCommand
{
  private const string Command = "-unally";

  private static void Actions()
  {
    var triggerPlayer = @event.Player;
    triggerPlayer.GetPlayerData().Faction?.Unally();
  }

  public static void Setup()
  {
    var trig = trigger.Create();
    foreach (var player in Util.EnumeratePlayers())
    {
      trig.RegisterPlayerChatEvent(player, Command, true);
    }

    trig.AddAction(Actions);
  }
}
