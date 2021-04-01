using AzerothWarsCSharp.Source.Libraries;
using WCSharp.Utils.Extensions;
using static War3Api.Common;
using static War3Api.Blizzard;

namespace AzerothWarsCSharp.Source.Commands
{
  /// <summary>
  /// A command makes the user into an observer.
  /// </summary>
  public static class ObserverCommand
  {
    public static void Initialize()
    {
      Command.Register("obs", (player triggerPlayer, string[] arguments) =>
      {
        var triggerFaction = Faction.ByPlayerHandle(triggerPlayer);
        if (triggerFaction != null)
        {
          triggerFaction.Leave();
          triggerFaction.Team = null;
          triggerFaction.Player = null;
          DisplayTextToForce(bj_FORCE_ALL_PLAYERS, triggerFaction.ColoredName + " has become an observer.");
        }
        DisplayTextToForce(bj_FORCE_ALL_PLAYERS, GetPlayerName(triggerPlayer) + " has become an observer.");
        SetPlayerState(triggerPlayer, PLAYER_STATE_OBSERVER, 1);
        CreateFogModifierRectBJ(true, triggerPlayer, FOG_OF_WAR_VISIBLE, GetPlayableMapRect());
      }
      );
    }
  }
}