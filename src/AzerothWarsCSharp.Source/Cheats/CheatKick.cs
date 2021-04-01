using AzerothWarsCSharp.Source.Libraries;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Commands
{
  /// <summary>
  /// A cheat to give force other players to leave.
  /// </summary>
  public static class CheatKick
  {
    public static void Initialize()
    {
      CheatCommand.Register("kick", (player triggerPlayer, string[] arguments) =>
      {
        var target = arguments[0];
        if (int.TryParse(arguments[0], out int playerId))
        {
          var faction = Faction.ByPlayerHandle(Player(playerId));
          if (faction != null)
          {
            CheatCommand.Display(triggerPlayer, "Kicking player " + GetPlayerName(Player(playerId)));
            faction.Leave();
          }
        }
      }
      );
    }
  }
}