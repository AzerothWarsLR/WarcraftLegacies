//using AzerothWarsCSharp.Source.Libraries;
//using static War3Api.Common;
//using static War3Api.Blizzard;

//namespace AzerothWarsCSharp.Source.Commands
//{
//  /// <summary>
//  /// A cheat to give the user control of other players.
//  /// </summary>
//  public static class CheatHasResearch
//  {
//    public static void Initialize()
//    {
//      CheatCommand.Register("hasresearch", (player triggerPlayer, string[] arguments) =>
//      {
//        if (int.TryParse(arguments[0], out int researchId))
//        {
//          var faction = Faction.ByPlayerHandle(triggerPlayer);
//          CheatCommand.Display(triggerPlayer, GetObjectName(researchId)  + "Level: " + faction.GetObjectLevel(researchId).ToString());
//        }
//      }
//      );
//    }
//  }
//}