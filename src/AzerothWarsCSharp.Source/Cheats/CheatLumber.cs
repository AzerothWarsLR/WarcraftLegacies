//using AzerothWarsCSharp.Source.Libraries;
//using static War3Api.Common;
//using static War3Api.Blizzard;

//namespace AzerothWarsCSharp.Source.Commands
//{
//  /// <summary>
//  /// A cheat to increase or decrease the user's lumber.
//  /// </summary>
//  public static class CheatLumber
//  {
//    public static void Initialize()
//    {
//      CheatCommand.Register("lumber", (player triggerPlayer, string[] arguments) =>
//      {
//        if (int.TryParse(arguments[0], out int lumber))
//        {
//          AdjustPlayerStateBJ(lumber, triggerPlayer, PLAYER_STATE_RESOURCE_LUMBER);
//          CheatCommand.Display(triggerPlayer, "Granted " + arguments[0] + " lumber.");
//        }
//      }
//      );
//    }
//  }
//}