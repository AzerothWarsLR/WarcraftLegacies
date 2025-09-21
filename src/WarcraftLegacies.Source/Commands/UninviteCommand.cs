using MacroTools.Extensions;
using MacroTools.FactionSystem;
using WCSharp.Shared;

namespace WarcraftLegacies.Source.Commands;

/// <summary>
///   Revokes an invitation sent to a player from the sending player's <see cref="Team" />.
/// </summary>
public static class UninviteCommand
{
  private const string Command = "-uninvite ";

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

    if (FactionManager.TryGetFactionByName(content, out var targetFaction))
    {
      if (targetFaction.Player != null)
      {
        triggerPlayer.GetTeam()?.Uninvite(targetFaction.Player);
      }
      else
      {
        triggerPlayer.DisplayTextTo($"There is no player with the Faction {targetFaction.ColoredName}.", 0, 0);
      }
    }
    else
    {
      triggerPlayer.DisplayTextTo($"There is no Faction with the name {content}.", 0, 0);
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
