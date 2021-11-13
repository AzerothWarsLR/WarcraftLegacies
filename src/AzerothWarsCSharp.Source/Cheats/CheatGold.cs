//using AzerothWarsCSharp.Source.Libraries;
//using static War3Api.Common;
//using static War3Api.Blizzard;

//namespace AzerothWarsCSharp.Source.Commands
//{
//  /// <summary>
//  /// A cheat to increase or decrease the user's gold.
//  /// </summary>
//  public static class CheatGold
//  {
//    public static void Initialize()
//    {
//      CheatCommand.Register("gold", (player triggerPlayer, string[] arguments) =>
//      {
//        if (int.TryParse(arguments[0], out int gold))
//        {
//          AdjustPlayerStateBJ(gold, triggerPlayer, PLAYER_STATE_RESOURCE_GOLD);
//          CheatCommand.Display(triggerPlayer, "Granted " + arguments[0] + " gold.");
//        }
//      }
//      );
//    }
//  }
//}