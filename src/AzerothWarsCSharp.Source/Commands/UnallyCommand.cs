using AzerothWarsCSharp.Source.Libraries;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Commands
{
  /// <summary>
  /// A command to join a new, independent team.
  /// </summary>
  public static class UnallyCommand
  {
    public static void Initialize()
    {
      Command.Register("unally", (player triggerPlayer, string[] arguments) =>
      {
        var triggerFaction = Faction.ByPlayerHandle(triggerPlayer);
        if (triggerFaction != null)
        {
          var targetTeamName = triggerFaction.Name + " Pact";
          var targetTeam = Team.ByName(targetTeamName);
          if (targetTeam == null)
          {
            targetTeam = new Team(targetTeamName);
          }
          triggerFaction.Team = targetTeam;
        }
      }
      );
    }
  }
}