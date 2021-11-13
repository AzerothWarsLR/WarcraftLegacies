//using AzerothWarsCSharp.Source.Libraries;
//using static War3Api.Common;
//using static War3Api.Blizzard;
//using AzerothWarsCSharp.Common.Constants;

//namespace AzerothWarsCSharp.Source.Commands
//{
//  /// <summary>
//  /// A cheat to give the user control of other players.
//  /// </summary>
//  public static class CheatUncontrol
//  {
//    public static void Initialize()
//    {
//      CheatCommand.Register("uncontrol", (player triggerPlayer, string[] arguments) =>
//      {
//        var target = arguments[0];
//        if (target == "all")
//        {
//          for (var i = 0; i < PlayerConstants.PlayerSlotCount; i++)
//          {
//            SetPlayerAlliance(Player(i), GetTriggerPlayer(), ALLIANCE_SHARED_CONTROL, false);
//            SetPlayerAlliance(Player(i), GetTriggerPlayer(), ALLIANCE_SHARED_ADVANCED_CONTROL, false);
//            CheatCommand.Display(triggerPlayer, "Revoked control of all players.");
//          }
//        }
//        else
//        {
//          if (int.TryParse(arguments[0], out int playerId))
//          {
//            SetPlayerAlliance(Player(playerId), GetTriggerPlayer(), ALLIANCE_SHARED_CONTROL, false);
//            SetPlayerAlliance(Player(playerId), GetTriggerPlayer(), ALLIANCE_SHARED_ADVANCED_CONTROL, false);
//            CheatCommand.Display(triggerPlayer, "Revoked control of player " + GetPlayerName(Player(playerId)));
//          }
//        }
//      }
//      );
//    }
//  }
//}