using MacroTools.Extensions;
using MacroTools.FactionSystem;
using WCSharp.Shared;

namespace WarcraftLegacies.Source.Commands;

/// <summary>
///   Invites the specified <see cref="Faction" />'s <see cref="player" /> to the sender's <see cref="Team" />.
/// </summary>
public static class InviteCommand
{
  private const string Command = "-invite ";

  private static void Actions()
  {
    var enteredString = @event.PlayerChatString;
    var triggerPlayer = @event.Player;

    if (SubString(enteredString, 0, StringLength(Command)) != Command)
    {
      return;
    }

    var content = SubString(enteredString, StringLength(Command), StringLength(enteredString));
    content = StringCase(content, false);

    if (!FactionManager.TryGetFactionByName(content, out var targetFaction))
    {
      triggerPlayer.DisplayTextTo($"There is no Faction with the name {content}.");
      return;
    }

    if (triggerPlayer.GetFaction() == targetFaction)
    {
      triggerPlayer.DisplayTextTo("You can'invite yourself to your own team.");
      return;
    }

    if (targetFaction.Player == null)
    {
      triggerPlayer.DisplayTextTo($"There is no player with the Faction {targetFaction.PrefixCol} {targetFaction.Name}|r.");
      return;
    }

    if (targetFaction.Player != null)
    {
      triggerPlayer.GetTeam()?.Invite(targetFaction.Player);
    }
  }

  public static void Setup()
  {
    var trig = trigger.Create();
    foreach (var player in Util.EnumeratePlayers())
    {
      trig.RegisterPlayerChatEvent(player, Command, false);
    }

    trig.AddAction(Actions);
  }
}
