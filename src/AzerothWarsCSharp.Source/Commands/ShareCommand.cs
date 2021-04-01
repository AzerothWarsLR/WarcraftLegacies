using AzerothWarsCSharp.Source.Libraries;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Commands
{
  /// <summary>
  /// A command to share control with another faction.
  /// </summary>
  public static class ShareCommand
  {
    public static void Initialize()
    {
      Command.Register("share", (player triggerPlayer, string[] arguments) =>
      {
        var targetPlayer = Faction.ByName(arguments[0]).Player;
        if (IsPlayerAlly(triggerPlayer, targetPlayer))
        {
          SetPlayerAlliance(triggerPlayer, targetPlayer, ALLIANCE_SHARED_CONTROL, true);
          SetPlayerAlliance(triggerPlayer, targetPlayer, ALLIANCE_SHARED_ADVANCED_CONTROL, true);
        }
      }
      );
    }
  }
}