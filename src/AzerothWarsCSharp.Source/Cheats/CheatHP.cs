//using AzerothWarsCSharp.Source.Libraries;
//using static War3Api.Common;
//using WCSharp.Shared.Extensions;

//namespace AzerothWarsCSharp.Source.Commands
//{
//  /// <summary>
//  /// A cheat to increase or decrease the user's gold.
//  /// </summary>
//  public static class CheatHP
//  {
//    public static void Initialize()
//    {
//      CheatCommand.Register("hp", (player triggerPlayer, string[] arguments) =>
//      {
//        if (int.TryParse(arguments[0], out int hp))
//        {
//          var tempGroup = CreateGroup();
//          GroupEnumUnitsSelected(tempGroup, triggerPlayer, null);
//          foreach (unit u in tempGroup.Enumerate())
//          {
//            SetUnitState(u, UNIT_STATE_LIFE, hp);
//          }
//          DestroyGroup(tempGroup);
//          CheatCommand.Display(triggerPlayer, "Setting health of selected units to " + arguments[0] + ".");
//        }
//      }
//      );
//    }
//  }
//}