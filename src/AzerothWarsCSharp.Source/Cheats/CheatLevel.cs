//using AzerothWarsCSharp.Source.Libraries;
//using static War3Api.Common;
//using WCSharp.Shared.Extensions;

//namespace AzerothWarsCSharp.Source.Commands
//{
//  /// <summary>
//  /// A cheat to set a units level.
//  /// </summary>
//  public static class CheatLevel
//  {
//    public static void Initialize()
//    {
//      CheatCommand.Register("level", (player triggerPlayer, string[] arguments) =>
//      {
//        if (int.TryParse(arguments[0], out int level))
//        {
//          var tempGroup = CreateGroup();
//          GroupEnumUnitsSelected(tempGroup, triggerPlayer, null);
//          foreach (unit u in tempGroup.Enumerate())
//          {
//            SetHeroLevel(u, level, true);
//          }
//          DestroyGroup(tempGroup);
//          CheatCommand.Display(triggerPlayer, "Setting level of selected units to " + arguments[0] + ".");
//        }
//      }
//      );
//    }
//  }
//}