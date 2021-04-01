using AzerothWarsCSharp.Source.Libraries;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Commands
{
  /// <summary>
  /// A cheat to change the user's team.
  /// </summary>
  public static class CheatTeam
  {
    public static void Initialize()
    {
      CheatCommand.Register("faction", (player triggerPlayer, string[] arguments) =>
      {
        var newTeam = arguments[0];
        Person.ByPlayerHandle(triggerPlayer).Faction.Team = Team.ByName(newTeam);
        CheatCommand.Display(triggerPlayer, "Changed faction to " + newTeam + ".");
      }
      );
    }
  }
}