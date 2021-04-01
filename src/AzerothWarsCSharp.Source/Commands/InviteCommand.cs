using AzerothWarsCSharp.Source.Libraries;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Commands
{
  /// <summary>
  /// A command to invite a faction to a team.
  /// </summary>
  public static class InviteCommand
  {
    public static void Initialize()
    {
      Command.Register("invite", (player triggerPlayer, string[] arguments) =>
      {
        var factionToInvite = Faction.ByName(arguments[0]);
        var sendingTeam = Faction.ByPlayerHandle(triggerPlayer).Team;

        if (factionToInvite == null)
        {
          DisplayTextToPlayer(triggerPlayer, 0, 0, "There is no Faction with the name " + arguments[0] + ".");
          return;
        }

        if (!factionToInvite.CanVoluntarilyChangeTeams)
        {
          DisplayTextToPlayer(triggerPlayer, 0, 0, factionToInvite.ColoredName + " cannot voluntarily change teams.");
          return;
        }

        if (factionToInvite.Team == sendingTeam)
        {
          DisplayTextToPlayer(triggerPlayer, 0, 0, factionToInvite.ColoredName + " is already on your team.");
          return;
        }

        if (factionToInvite.Player == null)
        {
          DisplayTextToPlayer(triggerPlayer, 0, 0, "There is no player with the faction " + factionToInvite.ColoredName);
          return;
        }

        sendingTeam.InviteFaction(factionToInvite);
        DisplayTextToPlayer(triggerPlayer, 0, 0, factionToInvite.ColoredName + " has been invited to join the " + sendingTeam.Name);
      }
      );
    }
  }
}