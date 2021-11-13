//using AzerothWarsCSharp.Source.Libraries;
//using static War3Api.Common;

//namespace AzerothWarsCSharp.Source.GameLogic
//{
//  /// <summary>
//  /// Cheats are enabled for everyone when there are fewer than 2 human players in the game.
//  /// </summary>
//  public static class TryEnableCheats
//  {
//    public static void Initialize()
//    {
//      var humanPlayerCount = 0;
//      for (var i = 0; i < Common.Constants.PlayerConstants.PlayerSlotCount; i++)
//      {
//        if (GetPlayerSlotState(Player(i)) == PLAYER_SLOT_STATE_PLAYING)
//        {
//          humanPlayerCount++;
//        }
//      }
//      if (humanPlayerCount < 2)
//      {
//        CheatCommand.Active = true;
//      }
//    }
//  }
//}