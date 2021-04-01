using AzerothWarsCSharp.Source.Libraries;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Commands
{
  /// <summary>
  /// A command to withdraw an invite for a faction to a team.
  /// </summary>
  public static class UninviteCommand
  {
    public static void Initialize()
    {
      Command.Register("uninvite", (player triggerPlayer, string[] arguments) =>
      {
        var factionToInvite = Faction.ByName(arguments[0]);
        var sendingTeam = Faction.ByPlayerHandle(triggerPlayer).Team;

        if (factionToInvite == null)
        {
          DisplayTextToPlayer(triggerPlayer, 0, 0, "There is no Faction with the name " + arguments[0] + ".");
          return;
        }

        if (!sendingTeam.IsFactionInvited(factionToInvite))
        {
          DisplayTextToPlayer(triggerPlayer, 0, 0, factionToInvite.ColoredName + " hasn't been invited to join the " + sendingTeam.Name + ".");
          return;
        }

        if (factionToInvite.Player == null)
        {
          DisplayTextToPlayer(triggerPlayer, 0, 0, "There is no player with the faction " + factionToInvite.ColoredName);
          return;
        }

        sendingTeam.UninviteFaction(factionToInvite);
        DisplayTextToPlayer(triggerPlayer, 0, 0, factionToInvite.ColoredName + " is no longer invited to join the " + sendingTeam.Name + ".");
      }
      );
    }
  }
}