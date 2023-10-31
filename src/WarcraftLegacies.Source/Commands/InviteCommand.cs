using MacroTools.Extensions;
using MacroTools.FactionSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Commands
{
  /// <summary>
  ///   Invites the specified <see cref="Faction" />'s <see cref="player" /> to the sender's <see cref="Team" />.
  /// </summary>
  public static class InviteCommand
  {
    private const string Command = "-invite ";

    private static void Actions()
    {
      var enteredString = GetEventPlayerChatString();
      var triggerPlayer = GetTriggerPlayer();
      
      if (SubString(enteredString, 0, StringLength(Command)) != Command) return;
      var content = SubString(enteredString, StringLength(Command), StringLength(enteredString));
      content = StringCase(content, false);

      if (!FactionManager.FactionWithNameExists(content))
      {
        DisplayTextToPlayer(triggerPlayer, 0, 0, $"There is no Faction with the name {content}.");
        return;
      }

      var targetFaction = FactionManager.GetFromName(content);

      if (triggerPlayer.GetFaction() == targetFaction)
      {
        DisplayTextToPlayer(triggerPlayer, 0, 0, "You can'invite yourself to your own team.");
        return;
      }

      if (targetFaction.Player == null)
      {
        DisplayTextToPlayer(triggerPlayer, 0, 0,
          $"There is no player with the Faction {targetFaction.PrefixCol} {targetFaction.Name}|r.");
        return;
      }

      if (targetFaction.Player != null) triggerPlayer.GetTeam()?.Invite(targetFaction.Player);
    }

    public static void Setup()
    {
      var trig = CreateTrigger();
      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
        TriggerRegisterPlayerChatEvent(trig, player, Command, false);
      TriggerAddAction(trig, Actions);
    }
  }
}