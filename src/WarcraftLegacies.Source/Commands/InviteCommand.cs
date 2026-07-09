using MacroTools.Extensions;
using MacroTools.Factions;
using WCSharp.Shared;
using MacroTools.Localization;

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
    var triggerPlayerData = triggerPlayer.GetPlayerData();

    if (SubString(enteredString, 0, StringLength(Command)) != Command)
    {
      return;
    }

    var content = SubString(enteredString, StringLength(Command), StringLength(enteredString));
    content = StringCase(content, false);

    if (!FactionManager.TryGetFactionByName(content, out var targetFaction))
    {
      triggerPlayer.DisplayTextTo(Loc.Format("There is no Faction with the name {name}.", ("{name}", content)));
      return;
    }

    if (triggerPlayerData.Faction == targetFaction)
    {
      triggerPlayer.DisplayTextTo(Loc.Get("You can't invite yourself to your own team."));
      return;
    }

    if (targetFaction.Player == null)
    {
      var coloredFactionName = $"{targetFaction.PrefixCol} {targetFaction.Name}|r";
      triggerPlayer.DisplayTextTo(Loc.Format("There is no player with the Faction {faction}.", ("{faction}", coloredFactionName)));
      return;
    }

    if (targetFaction.Player != null)
    {
      triggerPlayerData.Team?.Invite(targetFaction.Player);
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
