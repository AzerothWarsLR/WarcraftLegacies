using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Localization;
using WCSharp.Shared;

namespace WarcraftLegacies.Source.Commands;

/// <summary>
///   Joins the specified <see cref="Team" />. Only works if an invite has first been extended.
/// </summary>
public static class JoinCommand
{
  private const string Command = "-join ";

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

    if (FactionManager.TryGetTeamByName(content, out var targetTeam))
    {
      if (targetTeam.IsPlayerInvited(triggerPlayer))
      {
        var triggerPlayerData = triggerPlayer.GetPlayerData();
        triggerPlayerData.SetTeam(targetTeam);
        triggerPlayer.DisplayTextTo(Loc.Format("You have joined {team}.", ("{team}", targetTeam.Name)));
        targetTeam.DisplayText(Loc.Format(
          "{faction} has joined the {team}.",
          ("{faction}", triggerPlayerData.Faction?.ColoredName ?? ""),
          ("{team}", targetTeam.Name)));
      }
      else
      {
        triggerPlayer.DisplayTextTo(Loc.Format("You have not been invited to join {team}.", ("{team}", targetTeam.Name)));
      }
    }
    else
    {
      triggerPlayer.DisplayTextTo(Loc.Format("There is no Team with the name {name}.", ("{name}", content)));
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
