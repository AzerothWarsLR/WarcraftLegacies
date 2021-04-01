using AzerothWarsCSharp.Source.Libraries;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Commands
{
  /// <summary>
  /// A command to join a team.
  /// </summary>
  public static class JoinCommand
  {
    public static void Initialize()
    {
      Command.Register("join", (player triggerPlayer, string[] arguments) =>
      {
        var teamToJoin = Team.ByName(arguments[1]);
        var joinerFaction = Faction.ByPlayerHandle(triggerPlayer);

        if (teamToJoin == null)
        {
          DisplayTextToPlayer(triggerPlayer, 0, 0, "There is no Team with the name " + teamToJoin.Name + ".");
          return;
        }

        if (!teamToJoin.IsFactionInvited(joinerFaction))
        {
          DisplayTextToPlayer(triggerPlayer, 0, 0, "You have not been invited to join " + teamToJoin.Name + ".");
          return;
        }

        if (!teamToJoin.CanFitFaction(joinerFaction))
        {
          DisplayTextToPlayer(triggerPlayer, 0, 0, "That team is already full.");
        }

        joinerFaction.Team = teamToJoin;
      }
      );
    }
  }
}